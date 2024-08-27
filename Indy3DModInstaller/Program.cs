namespace Indy3DModInstaller;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        var gui = new ModInstallerGui();
        Application.Run(gui);
    }
}