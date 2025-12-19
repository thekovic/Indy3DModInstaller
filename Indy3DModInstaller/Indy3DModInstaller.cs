using Microsoft.Win32;
using System.Diagnostics;

namespace Indy3DModInstaller;

public class Indy3DRegistryEntry(string gameVersionId, string registryKey)
{
    public string GameVersionId { get; set; } = gameVersionId;

    public string RegistryKey { get; set; } = registryKey;
}

public class Indy3DModInstaller(IMessageWriter messageWriter) : IHasMessageWriter
{
    private static readonly Indy3DRegistryEntry[] REGISTRY_ENTRIES = [
        new("Steam", "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new("GOG", "HKEY_CURRENT_USER\\SOFTWARE\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new("CD", "HKEY_LOCAL_MACHINE\\Software\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new("CD (Unofficial Installer)", "HKEY_CURRENT_USER\\SOFTWARE\\Classes\\VirtualStore\\MACHINE\\SOFTWARE\\WOW6432Node\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0")
    ];

    private static readonly string[] GAME_ASSET_FOLDER_NAMES = ["3do", "cog", "hi3do", "mat", "misc", "ndy", "sound"];

    private const string RESOURCE_FOLDER = "Resource";
    private const string COG_BACKUP_FOLDER = "cog_backup";

    private const string JONES3D_GOB_FILE = "Jones3D.GOB";
    private const string JONES3D_GOB_BACKUP_FILE = $"{JONES3D_GOB_FILE}.BAK";
    private const string CD1_GOB_FILE = "CD1.GOB";
    private const string CD1_GOB_BACKUP_FILE = $"{CD1_GOB_FILE}.BAK";
    private const string CD2_GOB_FILE = "CD2.GOB";
    private const string CD2_GOB_BACKUP_FILE = $"{CD2_GOB_FILE}.BAK";

    public IMessageWriter MessageWriter { get; } = messageWriter;

    public void Unpack(string? installPath, bool convertCndToNdy)
    {
        if (installPath == null)
        {
            throw new ArgumentNullException(nameof(installPath), $"ERROR: Path empty. Cannot unpack game files.{Environment.NewLine}Please select path to Resource folder.");
        }

        if (Path.GetFileName(installPath) != RESOURCE_FOLDER)
        {
            throw new ArgumentException($"ERROR: Path doesn't lead to Resource folder. Cannot unpack game files.{Environment.NewLine}Please select path to Resource folder.");
        }

        string jones3dPath = Path.Combine(installPath, JONES3D_GOB_FILE);
        string cd1Path = Path.Combine(installPath, CD1_GOB_FILE);
        string cd2Path = Path.Combine(installPath, CD2_GOB_FILE);

        string jones3dBackupPath = Path.Combine(installPath, JONES3D_GOB_BACKUP_FILE);
        string cd1BackupPath = Path.Combine(installPath, CD1_GOB_BACKUP_FILE);
        string cd2BackupPath = Path.Combine(installPath, CD2_GOB_BACKUP_FILE);

        if (!File.Exists(jones3dPath))
        {
            throw new FileNotFoundException($"ERROR: Resource folder doesn't contain .GOB files.{Environment.NewLine}If you have previously tried to Unpack Game Files, click Uninstall All Mods. Otherwise, verify that your game installation is complete and valid.");
        }

        string cogPath = Path.Combine(installPath, "cog");
        string cogBackupPath = Path.Combine(installPath, COG_BACKUP_FOLDER);

        // Backup existing cog override (important for Steam version)
        if (Directory.Exists(cogPath))
        {
            Directory.Move(cogPath, cogBackupPath);
        }

        MessageWriter.WriteLine($"Extracting archive {JONES3D_GOB_FILE}...");
        OsUtils.LaunchProcess("gobext.exe", [JONES3D_GOB_FILE, "-o=."], installPath);
        MessageWriter.WriteLine($"Extracting archive {CD1_GOB_FILE}...");
        OsUtils.LaunchProcess("gobext.exe", [CD1_GOB_FILE, "-o=."], installPath);
        MessageWriter.WriteLine($"Extracting archive {CD2_GOB_FILE}...");
        OsUtils.LaunchProcess("gobext.exe", [CD2_GOB_FILE, "-o=."], installPath);

        // rename/backup GOB files so that the game is running solely from extracted files
        File.Move(jones3dPath, jones3dBackupPath);
        File.Move(cd1Path, cd1BackupPath);
        File.Move(cd2Path, cd2BackupPath);

        string[] cndFiles = Directory.GetFiles(Path.Combine(installPath, "ndy"), "*.cnd");
        
        foreach (string cndFile in cndFiles)
        {
            if (convertCndToNdy)
            {
                MessageWriter.WriteLine($"Extracting level {Path.GetFileName(cndFile)} and converting to .ndy...");
                OsUtils.LaunchProcess("cndtool.exe", ["convert", "ndy", $"-o=.", $"{Path.Combine("ndy", Path.GetFileName(cndFile))}", cogPath], installPath);
                // Backup the original .CND after we finish converting.
                File.Move(cndFile, $"{cndFile}.bak");
            }
            else
            {
                MessageWriter.WriteLine($"Extracting level {Path.GetFileName(cndFile)}...");
                OsUtils.LaunchProcess("cndtool.exe", ["extract", "--no-template", $"-o=.", $"{Path.Combine("ndy", Path.GetFileName(cndFile))}"], installPath);
            }
        }

        string keyPath = Path.Combine(installPath, "key");

        // move extracted "key" folder to "3do" folder
        if (Directory.Exists(keyPath))
        {
            OsUtils.CopyDirectoryContent(keyPath, Path.Combine(installPath, "3do", "key"));
            Directory.Delete(keyPath, true);
        }

        // copy cog_backup content into cog
        if (Directory.Exists(cogBackupPath))
        {
            OsUtils.CopyDirectoryContent(cogBackupPath, cogPath);
        }

        MessageWriter.WriteLine("Unpacking successfully finished.");
    }

    public static string? GetInstallPathFromRegistry()
    {
        foreach (var registryEntry in REGISTRY_ENTRIES)
        {
            object? registryKey = Registry.GetValue(registryEntry.RegistryKey, "Install Path", null);
            if (registryKey == null)
            {
                continue;
            }

            Debug.WriteLine($"Install Path: Found entry for {registryEntry.GameVersionId} version.");
            return (string) registryKey;
        }

        return null;
    }

    public void SetDevMode()
    {
        foreach (var registryEntry in REGISTRY_ENTRIES)
        {
            object? registryKey = Registry.GetValue(registryEntry.RegistryKey, "Start Mode", 42);
            if (registryKey == null)
            {
                continue;
            }

            MessageWriter.WriteLine($"Dev Mode: Found entry for {registryEntry.GameVersionId} version.");
            int startMode = (int) registryKey;
            if (startMode != 2)
            {
                Registry.SetValue(registryEntry.RegistryKey, "Start Mode", 2, RegistryValueKind.DWord);
                MessageWriter.WriteLine("Dev Mode for Indy3D.exe enabled.");
            }
            else
            {
                Registry.SetValue(registryEntry.RegistryKey, "Start Mode", 1, RegistryValueKind.DWord);
                MessageWriter.WriteLine("Dev Mode was already enabled.");
                MessageWriter.WriteLine("Dev Mode for Indy3D.exe disabled.");
            }

            return;
        }
    }

    public void Install(string? installPath, string? modPath)
    {
        if (installPath == null)
        {
            throw new ArgumentNullException(nameof(installPath), $"ERROR: Path empty. Cannot install mod.{Environment.NewLine}Please select path to Resource folder.");
        }

        if (Path.GetFileName(installPath) != RESOURCE_FOLDER)
        {
            throw new ArgumentException($"ERROR: Path doesn't lead to Resource folder. Cannot install mod.{Environment.NewLine}Please select path to Resource folder.");
        }

        if (modPath == null)
        {
            throw new ArgumentNullException(nameof(modPath), $"ERROR: Path empty. Cannot install mod.{Environment.NewLine}Please select path to mod folder.");
        }

        MessageWriter.WriteLine($"Installing mod from {modPath}...");

        foreach (string folderName in GAME_ASSET_FOLDER_NAMES)
        {
            string folderInInstallPath = Path.Combine(installPath, folderName);
            string folderInModPath = Path.Combine(modPath, folderName);

            if (Directory.Exists(folderInModPath))
            {
                string folderInModPathWithModPrefix = Path.Combine(Path.GetFileName(modPath), Path.GetFileName(folderInModPath));
                MessageWriter.WriteLine($"Installing {folderInModPathWithModPrefix}...");
                OsUtils.CopyDirectoryContent(folderInModPath, folderInInstallPath);
            }
        }

        MessageWriter.WriteLine("Mod installation successfully finished.");
    }

    public void Uninstall(string? installPath)
    {
        if (installPath == null)
        {
            throw new ArgumentNullException(nameof(installPath), $"ERROR: Path empty. Cannot uninstall mods.{Environment.NewLine}Please select path to Resource folder.");
        }

        if (Path.GetFileName(installPath) != RESOURCE_FOLDER)
        {
            throw new ArgumentException($"ERROR: Path doesn't lead to Resource folder. Cannot uninstall mods.{Environment.NewLine}Please select path to Resource folder.");
        }

        MessageWriter.WriteLine("Uninstalling mods, reverting to vanilla state from backups...");

        foreach (string folderName in GAME_ASSET_FOLDER_NAMES)
        {
            string folderInInstallPath = Path.Combine(installPath, folderName);

            if (Directory.Exists(folderInInstallPath))
            {
                MessageWriter.WriteLine($"Uninstalling modded {Path.GetFileName(folderInInstallPath)}...");
                Directory.Delete(folderInInstallPath, true);
            }
        }

        string jones3dPath = Path.Combine(installPath, JONES3D_GOB_FILE);
        string cd1Path = Path.Combine(installPath, CD1_GOB_FILE);
        string cd2Path = Path.Combine(installPath, CD2_GOB_FILE);

        string jones3dBackupPath = Path.Combine(installPath, JONES3D_GOB_BACKUP_FILE);
        string cd1BackupPath = Path.Combine(installPath, CD1_GOB_BACKUP_FILE);
        string cd2BackupPath = Path.Combine(installPath, CD2_GOB_BACKUP_FILE);

        // Restore backups
        if (File.Exists(jones3dBackupPath))
        {
            File.Move(jones3dBackupPath, jones3dPath);
        }

        if (File.Exists(cd1BackupPath))
        {
            File.Move(cd1BackupPath, cd1Path);
        }

        if (File.Exists(cd2BackupPath))
        {
            File.Move(cd2BackupPath, cd2Path);
        }

        string cogPath = Path.Combine(installPath, "cog");
        string cogBackupPath = Path.Combine(installPath, COG_BACKUP_FOLDER);

        if (Directory.Exists(cogBackupPath))
        {
            Directory.Move(cogBackupPath, cogPath);
        }

        MessageWriter.WriteLine("Mod uninstallation successfully finished.");
    }
}
