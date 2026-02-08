using System.IO.Compression;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json;

namespace Indy3DModInstaller;

public class OpenJonesVersion(int major, int minor, int patch, string? build, string? downloadUrl)
{
    public int Major { get; } = major;
    public int Minor { get; } = minor;
    public int Patch { get; } = patch;
    public string? Build { get; } = build;
    public string? DownloadUrl { get; } = downloadUrl;

    public override string ToString()
    {
        string buildString = $"{Major}.{Minor}.{Patch}";
        if (Build is not null)
        {
            buildString += $"-{Build}";
        }

        return buildString;
    }

    public static OpenJonesVersion FromString(string versionString)
    {
        // Example version strings: "1.2.3", "1.2.3-beta"
        var versionParts = versionString.Split('-', 2);
        var numberParts = versionParts[0].Split('.');
        int major = int.Parse(numberParts[0]);
        int minor = int.Parse(numberParts[1]);
        int patch = int.Parse(numberParts[2]);
        string? build = (versionParts.Length > 1) ? versionParts[1] : null;
        return new OpenJonesVersion(major, minor, patch, build, null);
    }
}

public class IndyPatch
{
    private const string EXPECTED_MAGIC = "INDYPTCH";
    private const int HASH_SIZE = 32;
    public const int SPAN_SIZE = 4;
    public string Magic { get; }
    public long OriginalFileSize { get; }
    public long PatchedFileSize { get; }
    public byte[] OriginalFileHash { get; }
    public bool IsCompressed { get; }
    public byte[] PatchData { get; }

    public IndyPatch(byte[] patchBytes)
    {
        using var reader = new BinaryReader(new MemoryStream(patchBytes));

        Magic = new string(reader.ReadChars(EXPECTED_MAGIC.Length));
        if (Magic != EXPECTED_MAGIC)
        {
            throw new InvalidDataException("ERROR: Invalid patch file - incorrect magic number.");
        }

        OriginalFileSize = reader.ReadInt64();
        PatchedFileSize = reader.ReadInt64();
        OriginalFileHash = reader.ReadBytes(HASH_SIZE);
        IsCompressed = Convert.ToBoolean(reader.ReadInt32());
        PatchData = reader.ReadBytes((int) (reader.BaseStream.Length - reader.BaseStream.Position));
    }
}

public class OpenJonesInstaller
{
    private const string OPENJONES_VERSION_DB_URL = "https://raw.githubusercontent.com/thekovic/Indy3DModInstaller/refs/heads/main/Data/OpenJonesVersionDatabase.json";
    private const string OPENJONES_STEAM_PATCH_URL = "https://github.com/thekovic/Indy3DModInstaller/raw/refs/heads/main/Data/SteamTo10.patch";
    private const string OPENJONES_GOG_PATCH_URL = "https://github.com/thekovic/Indy3DModInstaller/raw/refs/heads/main/Data/GogTo10.patch";

    private static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };

    private List<OpenJonesVersion>? OpenJonesVersions { get; set; }
    private IndyPatch? SteamPatch { get; set; }
    private IndyPatch? GogPatch { get; set; }

    public bool IsInitialized => OpenJonesVersions is not null && SteamPatch is not null && GogPatch is not null;

    private static IMessageWriter MessageWriter { get => AppState.Instance.MessageWriter; }

    public async Task InitializeOnlineResources()
    {
        using var httpClient = new HttpClient();

        var openJonesVersions = await httpClient.GetFromJsonAsync<List<OpenJonesVersion>>(OPENJONES_VERSION_DB_URL, JsonOptions);
        if (openJonesVersions is null)
        {
            throw new InvalidOperationException("ERROR: Could not get information about OpenJones3D versions. OpenJones3D installation feature will not be available.");
        }

        byte[] steamPatch = await httpClient.GetByteArrayAsync(OPENJONES_STEAM_PATCH_URL);
        byte[] gogPatch = await httpClient.GetByteArrayAsync(OPENJONES_GOG_PATCH_URL);

        OpenJonesVersions = openJonesVersions;
        SteamPatch = new IndyPatch(steamPatch);
        GogPatch = new IndyPatch(gogPatch);
    }

    public List<string> GetBuildStrings(string? openJonesDir)
    {
        var dbVersionStrings = (IsInitialized)
            ? OpenJonesVersions!.ConvertAll(version => version.ToString())
            : [];
        var installedVersionStrings = (Directory.Exists(openJonesDir))
            ? Directory.GetDirectories(openJonesDir).Select(dir => Path.GetFileName(dir)!).ToList()
            : [];
        var combinedVersionStrings = dbVersionStrings.Union(installedVersionStrings).OrderBy(s => s).Reverse().ToList();
        return combinedVersionStrings;
    }

    /// <summary>
    /// Determines whether the specified version can be installed in the given OpenJones directory.
    /// </summary>
    /// <param name="openJonesDir">The path to the OpenJones directory where the version would be installed.</param>
    /// <param name="versionString">The version identifier to check.</param>
    /// <returns>true if the specified version is available for installation and does not already exist in the target directory; otherwise, false.</returns>
    public bool CanVersionBeInstalled(string? openJonesDir, string? versionString)
    {
        if (openJonesDir is null || versionString is null)
        {
            return false;
        }

        string versionPath = Path.Combine(openJonesDir, versionString);
        var dbBuildStrings = (IsInitialized)
            ? OpenJonesVersions!.ConvertAll(version => version.ToString())
            : [];
        return !Directory.Exists(versionPath) && dbBuildStrings.Contains(versionString);
    }

    public static bool IsVersionInstalled(string? openJonesDir, string? versionString)
    {
        if (openJonesDir is null || versionString is null)
        {
            return false;
        }

        string versionPath = Path.Combine(openJonesDir, versionString);
        return Directory.Exists(versionPath);
    }

    /// <summary>
    /// Determines whether the selected OpenJones version should be treated like the original engine.
    /// </summary>
    /// <remarks>This method can be used to enable legacy behavior for OpenJones when a version is not
    /// specified or when compatibility with earlier minor versions is required.</remarks>
    /// <returns>true if no OpenJones version is selected or if the selected version is older than 0.4.0;
    /// otherwise, false.</returns>
    public static bool IsVersionLegacy(string? versionString)
    {
        // Use legacy behavior if OpenJones version is not selected or failed to parse.
        if (versionString == null)
        {
            return true;
        }

        var openJonesVersion = OpenJonesVersion.FromString(versionString);
        if (openJonesVersion == null || openJonesVersion.Minor < 4)
        {
            return true;
        }

        return false;
    }

    public async Task InstallVersion(string? executablePath, string? openJonesDir, string? versionString)
    {
        if (!IsInitialized)
        {
            throw new InvalidOperationException("ERROR: OpenJones3D installer is not initialized. OpenJones3D installation cannot proceed.");
        }

        if (executablePath is null)
        {
            throw new ArgumentNullException(nameof(executablePath), $"ERROR: Path empty. OpenJones3D installation cannot proceed.{Environment.NewLine}Please select path to Resource folder in the Settings window.");
        }

        if (!File.Exists(executablePath))
        {
            throw new FileNotFoundException($"ERROR: Original game executable not found. OpenJones3D installation cannot proceed.{Environment.NewLine}Please select path to Resource folder in the Settings window.");
        }

        if (openJonesDir is null)
        {
            throw new ArgumentNullException(nameof(openJonesDir), $"ERROR: OpenJones3D directory path is not set. OpenJones3D installation cannot proceed.{Environment.NewLine}Please select a directory in the Settings window.");
        }

        if (versionString is null)
        {
            throw new ArgumentNullException(nameof(versionString), "ERROR: OpenJones3D version is not selected. OpenJones3D installation cannot proceed.");
        }

        var versionInfo = OpenJonesVersions!.FirstOrDefault(v => v.ToString() == versionString);
        if (versionInfo is null)
        {
            throw new ArgumentException($"Version '{versionString}' not found in the OpenJones3D version database. OpenJones3D installation cannot proceed.");
        }

        if (versionInfo.DownloadUrl is null)
        {
            throw new InvalidOperationException($"ERROR: Download URL for OpenJones3D version '{versionString}' not found. OpenJones3D installation cannot proceed.");
        }

        // Figure out if executablePath corresponds to Steam or GOG version so that we can patch it.
        bool isSteamVersion = IsHashMatchingPatch(executablePath, SteamPatch!);
        bool isGogVersion = IsHashMatchingPatch(executablePath, GogPatch!);
        if (!isSteamVersion && !isGogVersion)
        {
            throw new InvalidOperationException("ERROR: The original game executable does not match known Steam or GOG versions. OpenJones3D installation cannot proceed.");
        }

        var usedPatch = isSteamVersion ? SteamPatch! : GogPatch!;

        // Create root OpenJones directory and the directory for the specific OpenJones version.
        string versionPath = Path.Combine(openJonesDir, versionString);
        Directory.CreateDirectory(versionPath);

        // Copy the original executable to the OpenJones version directory and patch it.
        string destExecutablePath = Path.Combine(versionPath, Path.GetFileName(executablePath));
        string tmpDestExecutablePath = destExecutablePath + ".tmp";
        File.Copy(executablePath, tmpDestExecutablePath, overwrite: true);
        ApplyPatch(tmpDestExecutablePath, usedPatch, destExecutablePath);
        File.Delete(tmpDestExecutablePath);

        using var httpClient = new HttpClient();

        // Download and extract the OpenJones3D build
        MessageWriter.WriteLine($"Downloading OpenJones3D version '{versionString}' from '{versionInfo.DownloadUrl}'...");
        var archiveData = await httpClient.GetByteArrayAsync(versionInfo.DownloadUrl);

        using var archiveStream = new MemoryStream(archiveData);
        using var archive = new ZipArchive(archiveStream);
        MessageWriter.WriteLine($"Installing OpenJones3D version '{versionString}' to '{versionPath}'...");
        archive.ExtractToDirectory(versionPath);

        MessageWriter.WriteLine($"OpenJones3D version '{versionString}' successfully installed.");

        // Download and install dgVoodoo2 to the OpenJones version directory if version is legacy (meaning it only has DirectX 6 renderer).
        if (IsVersionLegacy(versionString))
        {
            await DgVoodooInstaller.InstallDgVoodoo(versionPath);
        }
    }

    private static bool IsHashMatchingPatch(string executablePath, IndyPatch patch)
    {
        // Open file at executablePath, compute its hash and compare to patch.OriginalFileHash.
        using var fileStream = File.OpenRead(executablePath);

        var fileHash = SHA256.HashData(fileStream);

        return fileHash.SequenceEqual(patch.OriginalFileHash);
    }

    private void ApplyPatch(string basePath, IndyPatch patch, string outPath)
    {
        byte[] baseBytes = File.ReadAllBytes(basePath);
        byte[] baseHash = SHA256.HashData(baseBytes);

        if (baseBytes.Length != patch.OriginalFileSize)
        {
            throw new InvalidDataException("ERROR: Base file size mismatch. Expected size: {patch.OriginalFileSize}");
        }

        if (!baseHash.SequenceEqual(patch.OriginalFileHash))
        {
            throw new InvalidDataException($"ERROR: Base file hash mismatch.{Environment.NewLine}Received hash: {Convert.ToHexString(baseHash)}{Environment.NewLine}Expected hash: {Convert.ToHexString(patch.OriginalFileHash)}");
        }

        byte[] modifiedBytes = baseBytes;
        Array.Resize(ref modifiedBytes, (int) patch.PatchedFileSize);

        using var patchReader = (patch.IsCompressed)
            ? new BinaryReader(new DeflateStream(new MemoryStream(patch.PatchData), CompressionMode.Decompress))
            : new BinaryReader(new MemoryStream(patch.PatchData));

        int diffCount = patchReader.ReadInt32();
        int offset = 0;

        for (int i = 0; i < diffCount; i++)
        {
            offset += patchReader.ReadUInt16();
            ushort len = patchReader.ReadUInt16();
            byte[] diffData = patchReader.ReadBytes(len);
            diffData.CopyTo(modifiedBytes, offset * IndyPatch.SPAN_SIZE);
        }

        File.WriteAllBytes(outPath, modifiedBytes);
        MessageWriter.WriteLine($"Patched game executable written to: {outPath}");
    }

    public void UninstallVersion(string? openJonesDir, string? versionString)
    {
        if (openJonesDir is null)
        {
            throw new ArgumentNullException(nameof(openJonesDir), $"ERROR: OpenJones3D directory path is not set. OpenJones3D uninstallation cannot proceed.");
        }

        if (versionString is null)
        {
            throw new ArgumentNullException(nameof(versionString), "ERROR: OpenJones3D version is not selected. OpenJones3D uninstallation cannot proceed.");
        }

        string versionPath = Path.Combine(openJonesDir, versionString);
        if (!Directory.Exists(versionPath))
        {
            throw new DirectoryNotFoundException($"ERROR: OpenJones3D version directory '{versionPath}' not found. Uninstallation cannot proceed.");
        }

        Directory.Delete(versionPath, recursive: true);
        MessageWriter.WriteLine($"OpenJones3D version '{versionString}' uninstalled successfully from '{versionPath}'.");
    }
}
