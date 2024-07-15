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
    private static readonly Indy3DRegistryEntry[] registryEntries = [
        new Indy3DRegistryEntry("Steam", "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new Indy3DRegistryEntry("GOG", "HKEY_CURRENT_USER\\SOFTWARE\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new Indy3DRegistryEntry("CD", "HKEY_LOCAL_MACHINE\\Software\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0")
    ];

    public static void Unpack(string installPath)
    {
        string cogPath = Path.Combine(installPath, "cog");
        string cogBackupPath = Path.Combine(installPath, "cog_backup");

        // Backup existing cog override (important for Steam version)
        if (Directory.Exists(cogPath))
        {
            Directory.Move(cogPath, cogBackupPath);
        }

        try
        {
            Program.WriteLine("Extracting archive CD1.GOB...");
            OsUtils.LaunchProcess("gobext.exe", ["CD1.GOB", "-o=."], installPath);
            Program.WriteLine("Extracting archive CD2.GOB...");
            OsUtils.LaunchProcess("gobext.exe", ["CD2.GOB", "-o=."], installPath);
        }
        catch (Exception)
        {
            throw;
        }

        string cd1Path = Path.Combine(installPath, "CD1.GOB");
        string cd2Path = Path.Combine(installPath, "CD2.GOB");
        string cd1BackupPath = Path.Combine(installPath, "CD1_backup.GOB");
        string cd2BackupPath = Path.Combine(installPath, "CD2_backup.GOB");

        // rename/backup GOB files so that the game is running solely from extracted files
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
        foreach (Indy3DRegistryEntry registryEntry in registryEntries)
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
        foreach (Indy3DRegistryEntry registryEntry in registryEntries)
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

    public static void Uninstall()
    {
        Program.WriteLine("Uninstalling mods, reverting to vanilla state from backups...");
        string[] folderNames = ["3do", "cog", "hi3do", "mat", "misc", "ndy", "sound"];

        foreach (string folderName in folderNames)
        {
            if (Directory.Exists(folderName))
            {
                Directory.Delete(folderName, true);
            }
        }

        if (File.Exists("CD1_backup.GOB"))
        {
            File.Move("CD1_backup.GOB", "CD1.GOB");
        }

        if (File.Exists("CD2_backup.GOB"))
        {
            File.Move("CD2_backup.GOB", "CD2.GOB");
        }

        if (Directory.Exists("cog_backup"))
        {
            Directory.Move("cog_backup", "cog");
        }
    }
}
