using Microsoft.Win32;
using System.Diagnostics;

internal class Program
{
    static void LaunchProcess(string processName, string[] args, bool verbose = false)
    {
        try
        {
            using (var process = new Process())
            {
                // Set process name from the config
                process.StartInfo.FileName = processName;
                // Pass arguments to the process
                foreach (string arg in args)
                {
                    process.StartInfo.ArgumentList.Add(arg);
                }
                // This doesn't really matter since we're using absolute path
                // to the executable but it should be set to false so that
                // CreateProcess is used from Win32 API.
                process.StartInfo.UseShellExecute = false;
                // Despite its name, the following setting also prevents
                // stdout of the launched process from showing up in our
                // terminal.
                process.StartInfo.CreateNoWindow = true;
                // Enable capture of stdout of the process
                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += new DataReceivedEventHandler((sender, output) =>
                {
                    if (!string.IsNullOrEmpty(output.Data) && verbose)
                    {
                        Console.WriteLine(output.Data);
                    }
                });
                // Enable capture of stderr of the process
                process.StartInfo.RedirectStandardError = true;
                process.ErrorDataReceived += new DataReceivedEventHandler((sender, output) =>
                {
                    if (!string.IsNullOrEmpty(output.Data) && verbose)
                    {
                        Console.WriteLine(output.Data);
                    }
                });

                // PER MICROSOFT:
                // This code assumes the process you are starting will terminate itself.
                // Given that it is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
                process.Start();
                // Start capturing stdout
                process.BeginOutputReadLine();
                // Start capturing stderr
                process.BeginErrorReadLine();
                // Blocking wait for the process to finish
                process.WaitForExit();

                Console.WriteLine($"Process {process.StartInfo.FileName} ({process.Id}) exited with {process.ExitCode}.");

                if (process.ExitCode != 0)
                {
                    throw new Exception(
                        $"Subprocess {process.StartInfo.FileName} ({process.Id}) failed during execution.{Environment.NewLine}" +
                        $"Execution: {processName} {args}{Environment.NewLine}");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    static void MoveDirectory(string sourceDir, string destDir)
    {
        Console.WriteLine($"Moving \"{sourceDir}\" to \"{destDir}\"...");

        // Check if the source directory exists
        if (!Directory.Exists(sourceDir))
        {
            throw new DirectoryNotFoundException($"Source directory not found: {sourceDir}");
        }

        // If the destination directory doesn't exist, create it
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }

        // Copy all files from source to destination, overwriting if necessary
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFileName = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFileName, true);
        }

        // Recursively merge all subdirectories
        foreach (string dir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
            MoveDirectory(dir, destSubDir);
        }
    }

    public static void Indy3D_Unpack()
    {
        // Backup existing cog override (important for Steam version)
        if (Directory.Exists("cog"))
        {
            Directory.Move("cog", "cog_backup");
        }

        Console.WriteLine("Extracting archive CD1.GOB...");
        LaunchProcess("gobext.exe", ["CD1.GOB", "-o=."]);
        Console.WriteLine("Extracting archive CD2.GOB...");
        LaunchProcess("gobext.exe", ["CD2.GOB", "-o=."]);

        File.Move("CD1.GOB", "CD1_backup.GOB");
        File.Move("CD2.GOB", "CD2_backup.GOB");

        string[] cnd_files = Directory.GetFiles("ndy", "*.cnd");
        foreach (string file in cnd_files)
        {
            Console.WriteLine($"Extracting level {Path.GetFileName(file)}...");
            LaunchProcess("cndtool.exe", ["extract", "--no-template", "-o=.", $"{file}"]);
        }

        MoveDirectory("key", Path.Combine("3do", "key"));
        Directory.Delete("key", true);

        MoveDirectory("cog_backup", "cog");
    }

    public static void Indy3D_SetDevMode()
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
        }
    }

    public static void Indy3D_Uninstall()
    {
        Console.WriteLine("Uninstalling mods, reverting to vanilla state from backups...");
        string[] folderNames = ["3do", "cog", "hi3do", "mat", "misc", "ndy", "sound"];

        foreach (string folderName in folderNames)
        {
            Directory.Delete(folderName, true);
        }

        File.Move("CD1_backup.GOB", "CD1.GOB");
        File.Move("CD2_backup.GOB", "CD2.GOB");

        Directory.Move("cog_backup", "cog");
    }

    public static void Main(string[] args)
    {
        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("ERROR: This app requires access to Windows Registry.");
            return;
        }

        bool unpack = false;
        string? mod = null;
        bool devMode = false;
        bool uninstall = false;

        if (args.Length == 0)
        {
            unpack = true;
            devMode = true;
            mod = "sed";
        }
        else
        {
            foreach (string par in args)
            {
                string[] arg = par.Split('=');
                string option = arg[0];
                string? value = (arg.Length > 1) ? arg[1] : null;

                switch (option)
                {
                    case "help":
                        Console.WriteLine("Options:");
                        Console.WriteLine("    unpack: Unpack assets from game files using gobext.exe and cndtool.exe. Creates backups of original files.");
                        Console.WriteLine("    devmode: Activate devmode");
                        Console.WriteLine("    mod=name: Install mod from folder of <name>");
                        Console.WriteLine("    devmode: Uninstall all mods and restore original files from backups.");
                        break;
                    case "unpack":
                        unpack = true;
                        break;
                    case "devmode":
                        devMode = true;
                        break;
                    case "uninstall":
                        uninstall = true;
                        break;
                    case "mod":
                        mod = value;
                        break;
                }
            }
        }

        if (unpack)
        {
            Indy3D_Unpack();
        }

        if (devMode)
        {
            Indy3D_SetDevMode();
        }

        if (mod != null)
        {
            Console.WriteLine($"Installing {mod}...");
            MoveDirectory(mod, ".");
        }

        if (uninstall)
        {
            Indy3D_Uninstall();
        }

        Console.WriteLine("Installer finished successfully. Press any key to exit.");
        Console.ReadKey();
    }
}