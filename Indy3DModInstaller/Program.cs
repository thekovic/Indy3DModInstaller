namespace Indy3DModInstaller;

internal class Program
{
    public static bool _unpack = false;
    public static string? _installPath = null;
    public static string? _modPath = null;
    public static bool _devMode = false;
    public static bool _uninstall = false;

    public static RichTextBox? messageBox = null;

    /// <summary>
    /// Print a message to the message box in the GUI. Used as main user-facing feedback mechanism.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    public static void WriteLine(string message)
    {
        // Dispatch action based on what the GUI needs
        if (messageBox!.InvokeRequired)
        {
            messageBox.Invoke(new Action(() => messageBox.AppendText($"{message}{Environment.NewLine}")));
        }
        else
        {
            messageBox.AppendText($"{message}{Environment.NewLine}");
        }
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
    }
}