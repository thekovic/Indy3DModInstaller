using Microsoft.Win32;
using System.Diagnostics;

namespace Indy3DModInstaller;

internal class Indy3DRegistryEntry(string gameVersionId, string registryKey)
{
    public string GameVersionId { get; set; } = gameVersionId;

    public string RegistryKey { get; set; } = registryKey;
}

internal class Indy3DModInstaller
{
    private static readonly Indy3DRegistryEntry[] _registryEntries = [
        new Indy3DRegistryEntry("Steam", "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new Indy3DRegistryEntry("GOG", "HKEY_CURRENT_USER\\SOFTWARE\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new Indy3DRegistryEntry("CD", "HKEY_LOCAL_MACHINE\\Software\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0")
    ];

    private static readonly string[] _gameAssetFolderNames = ["3do", "cog", "hi3do", "mat", "misc", "ndy", "sound"];

    private const string _cogBackupFolder = "cog_backup";

    private const string _jones3dGobFile = "Jones3D.GOB";
    private const string _jones3dGobBackupFile = "Jones3D.GOB.BAK";
    private const string _cd1GobFile = "CD1.GOB";
    private const string _cd1GobBackupFile = "CD1.GOB.BAK";
    private const string _cd2GobFile = "CD2.GOB";
    private const string _cd2GobBackupFile = "CD2.GOB.BAK";

    public static void Unpack(string installPath)
    {
        string cogPath = Path.Combine(installPath, "cog");
        string cogBackupPath = Path.Combine(installPath, _cogBackupFolder);

        // Backup existing cog override (important for Steam version)
        if (Directory.Exists(cogPath))
        {
            Directory.Move(cogPath, cogBackupPath);
        }

        try
        {
            Program.WriteLine($"Extracting archive {_jones3dGobFile}...");
            OsUtils.LaunchProcess("gobext.exe", [_jones3dGobFile, "-o=."], installPath);
            Program.WriteLine($"Extracting archive {_cd1GobFile}...");
            OsUtils.LaunchProcess("gobext.exe", [_cd1GobFile, "-o=."], installPath);
            Program.WriteLine($"Extracting archive {_cd2GobFile}...");
            OsUtils.LaunchProcess("gobext.exe", [_cd2GobFile, "-o=."], installPath);
        }
        catch (Exception)
        {
            throw;
        }

        string jones3dPath = Path.Combine(installPath, _jones3dGobFile);
        string cd1Path = Path.Combine(installPath, _cd1GobFile);
        string cd2Path = Path.Combine(installPath, _cd2GobFile);

        string jones3dBackupPath = Path.Combine(installPath, _jones3dGobBackupFile);
        string cd1BackupPath = Path.Combine(installPath, _cd1GobBackupFile);
        string cd2BackupPath = Path.Combine(installPath, _cd2GobBackupFile);

        // rename/backup GOB files so that the game is running solely from extracted files
        File.Move(jones3dPath, jones3dBackupPath);
        File.Move(cd1Path, cd1BackupPath);
        File.Move(cd2Path, cd2BackupPath);

        string[] cnd_files = Directory.GetFiles(Path.Combine(installPath, "ndy"), "*.cnd");
        try
        {
            foreach (string file in cnd_files)
            {
                Program.WriteLine($"Extracting level {Path.GetFileName(file)}...");
                OsUtils.LaunchProcess("cndtool.exe", ["extract", "--no-template", $"-o=.", $"{Path.Combine("ndy", Path.GetFileName(file))}"], installPath);
            }
        }
        catch (Exception)
        {
            throw;
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
    }

    public static string? GetInstallPathFromRegistry()
    {
        foreach (Indy3DRegistryEntry registryEntry in _registryEntries)
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

    public static void SetDevMode()
    {
        foreach (Indy3DRegistryEntry registryEntry in _registryEntries)
        {
            object? registryKey = Registry.GetValue(registryEntry.RegistryKey, "Start Mode", 42);
            if (registryKey == null)
            {
                continue;
            }

            Program.WriteLine($"Dev Mode: Found entry for {registryEntry.GameVersionId} version.");
            int startMode = (int) registryKey;
            if (startMode != 2)
            {
                Registry.SetValue(registryEntry.RegistryKey, "Start Mode", 2, RegistryValueKind.DWord);
                Program.WriteLine("Dev Mode for Indy3D.exe enabled.");
            }
            else
            {
                Registry.SetValue(registryEntry.RegistryKey, "Start Mode", 1, RegistryValueKind.DWord);
                Program.WriteLine("Dev Mode was already enabled.");
                Program.WriteLine("Dev Mode for Indy3D.exe disabled.");
            }
        }
    }

    public static void Install(string installPath, string modPath)
    {
        Program.WriteLine($"Installing mod from {modPath}...");

        foreach (string folderName in _gameAssetFolderNames)
        {
            string folderInInstallPath = Path.Combine(installPath, folderName);
            string folderInModPath = Path.Combine(modPath, folderName);

            if (Directory.Exists(folderInModPath))
            {
                string folderinModPathWithModPrefix = Path.Combine(Path.GetFileName(modPath), Path.GetFileName(folderInModPath));
                Program.WriteLine($"Installing {folderinModPathWithModPrefix}...");
                OsUtils.CopyDirectoryContent(folderInModPath, folderInInstallPath);
            }
        }
    }

    public static void Uninstall(string installPath)
    {
        Program.WriteLine("Uninstalling mods, reverting to vanilla state from backups...");

        foreach (string folderName in _gameAssetFolderNames)
        {
            string folderInInstallPath = Path.Combine(installPath, folderName);

            if (Directory.Exists(folderInInstallPath))
            {
                Program.WriteLine($"Uninstalling modded {Path.GetFileName(folderInInstallPath)}...");
                Directory.Delete(folderInInstallPath, true);
            }
        }

        string jones3dPath = Path.Combine(installPath, _jones3dGobFile);
        string cd1Path = Path.Combine(installPath, _cd1GobFile);
        string cd2Path = Path.Combine(installPath, _cd2GobFile);

        string jones3dBackupPath = Path.Combine(installPath, _jones3dGobBackupFile);
        string cd1BackupPath = Path.Combine(installPath, _cd1GobBackupFile);
        string cd2BackupPath = Path.Combine(installPath, _cd2GobBackupFile);

        // Restore backups
        if (File.Exists(jones3dPath))
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
        string cogBackupPath = Path.Combine(installPath, _cogBackupFolder);

        if (Directory.Exists(cogBackupPath))
        {
            Directory.Move(cogBackupPath, cogPath);
        }
    }
}
