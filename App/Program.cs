namespace Indy3DModInstaller;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();

        var gui = new ModInstallerGui();
        Application.Run(gui);
    }
}