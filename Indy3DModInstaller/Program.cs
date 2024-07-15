namespace Indy3DModInstaller;

internal class Program
{
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
            try
            {
                Indy3DModInstaller.Unpack();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Game file unpacking failed.");
                Console.WriteLine($"Reason: {ex.Message}");
                Console.WriteLine("Reverting changes...");
                Indy3DModInstaller.Uninstall();
            }
        }

        if (devMode)
        {
            Indy3DModInstaller.SetDevMode();
        }

        if (mod != null)
        {
            Console.WriteLine($"Installing {mod}...");
            OsUtils.CopyDirectoryContent(mod, ".");
        }

        if (uninstall)
        {
            Indy3DModInstaller.Uninstall();
        }

        Console.WriteLine("Installer finished successfully. Press any key to exit.");
        Console.ReadKey();
    }
}