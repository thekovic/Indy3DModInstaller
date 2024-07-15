namespace Indy3DModInstaller;

internal class Program
{
    public static bool _unpack = false;
    public static string? _mod = null;
    public static bool _devMode = false;
    public static bool _uninstall = false;

    public static void Main(string[] args)
    {
        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("ERROR: This app requires access to Windows Registry.");
            return;
        }

        if (args.Length == 0)
        {
            _unpack = true;
            _devMode = true;
            _mod = "sed";
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
                        _unpack = true;
                        break;
                    case "devmode":
                        _devMode = true;
                        break;
                    case "uninstall":
                        _uninstall = true;
                        break;
                    case "mod":
                        _mod = value;
                        break;
                }
            }
        }

        if (_unpack)
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

        if (_devMode)
        {
            Indy3DModInstaller.SetDevMode();
        }

        if (_mod != null)
        {
            Console.WriteLine($"Installing {_mod}...");
            OsUtils.CopyDirectoryContent(_mod, ".");
        }

        if (_uninstall)
        {
            Indy3DModInstaller.Uninstall();
        }

        Console.WriteLine("Installer finished successfully. Press any key to exit.");
        Console.ReadKey();
    }
}