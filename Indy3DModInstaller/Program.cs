namespace Indy3DModInstaller;

internal class Program
{
    public static bool _unpack = false;
    public static string? _installPath = null;
    public static string? _modPath = null;
    public static bool _devMode = false;
    public static bool _uninstall = false;

    public static RichTextBox? messageBox = null;

    public static void WriteLine(string message)
    {
        messageBox!.AppendText($"{message}{Environment.NewLine}");
    }

    [STAThread]
    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        var gui = new ModInstallerGui();
        messageBox = gui.GetMessageBox();
        Application.Run(gui);

        return;

        if (args.Length == 0)
        {
            _unpack = true;
            _devMode = true;
            _modPath = "sed";
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
                        _modPath = value;
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

        if (_modPath != null)
        {
            Console.WriteLine($"Installing {_modPath}...");
            OsUtils.CopyDirectoryContent(_modPath, ".");
        }

        if (_uninstall)
        {
            Indy3DModInstaller.Uninstall();
        }

        Console.WriteLine("Installer finished successfully. Press any key to exit.");
        Console.ReadKey();
    }
}