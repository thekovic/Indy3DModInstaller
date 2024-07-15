using Microsoft.Win32;

namespace Indy3DModInstaller;

internal class Indy3DModInstaller
{
    public static void Unpack()
    {
        // Backup existing cog override (important for Steam version)
        if (Directory.Exists("cog"))
        {
            Directory.Move("cog", "cog_backup");
        }

        try
        {
            Console.WriteLine("Extracting archive CD1.GOB...");
            OsUtils.LaunchProcess("gobext.exe", ["CD1.GOB", "-o=."]);
            Console.WriteLine("Extracting archive CD2.GOB...");
            OsUtils.LaunchProcess("gobext.exe", ["CD2.GOB", "-o=."]);
        }
        catch (Exception)
        {
            throw;
        }

        // rename/backup GOB files so that the game is running solely from extracted files
        File.Move("CD1.GOB", "CD1_backup.GOB");
        File.Move("CD2.GOB", "CD2_backup.GOB");

        string[] cnd_files = Directory.GetFiles("ndy", "*.cnd");
        try
        {
            foreach (string file in cnd_files)
            {
                Console.WriteLine($"Extracting level {Path.GetFileName(file)}...");
                OsUtils.LaunchProcess("cndtool.exe", ["extract", "--no-template", "-o=.", $"{file}"]);
            }
        }
        catch (Exception)
        {
            throw;
        }

        // move extracted "key" folder to "3do" folder
        if (Directory.Exists("key"))
        {
            OsUtils.CopyDirectoryContent("key", Path.Combine("3do", "key"));
            Directory.Delete("key", true);
        }

        // copy cog_backup content into cog
        if (Directory.Exists("cog_backup"))
        {
            OsUtils.CopyDirectoryContent("cog_backup", "cog");
        }
    }

    public static void SetDevMode()
    {
        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("ERROR: This app requires access to Windows Registry.");
            return;
        }

        string[] registryKeys = [
            // Steam
            "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0",
            // GOG
            "HKEY_CURRENT_USER\\SOFTWARE\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0",
            // CD
            "HKEY_LOCAL_MACHINE\\Software\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"
        ];

        foreach (string gameVersionKey in registryKeys)
        {
            object? registryKey = Registry.GetValue(gameVersionKey, "Start Mode", 42);
            if (registryKey == null)
            {
                continue;
            }

            Console.WriteLine($"Found {gameVersionKey}");
            int startMode = (int) registryKey;
            if (startMode != 2)
            {
                Console.WriteLine("Enabling Dev Mode for Indy3D.exe...");
                Registry.SetValue(gameVersionKey, "Start Mode", 2, RegistryValueKind.DWord);
            }
            else
            {
                Console.WriteLine("Dev Mode was already enabled!");
            }
        }
    }

    public static void Uninstall()
    {
        Console.WriteLine("Uninstalling mods, reverting to vanilla state from backups...");
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
