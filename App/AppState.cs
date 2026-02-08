namespace Indy3DModInstaller;

/// <summary>
/// Provides centralized access to application-wide services, configuration, and global state.
/// </summary>
/// <remarks>AppState acts as a singleton, exposing key services such as configuration management, message
/// writing, mod installation, and game launching. Use the static Instance property to access the current application
/// state after initialization. This class is intended to be used as the main entry point for accessing shared
/// resources and services throughout the application's lifecycle.</remarks>
public class AppState
{
    public IMessageWriter MessageWriter { get; }
    public AppConfig CurrentConfig { get; }
    public Indy3DModInstaller ModInstaller { get; }
    public OpenJonesInstaller OpenJonesInstaller { get; }
    public GameLauncher GameLauncher { get; }
    private readonly RegistryGameSettings _registryGameSettings;
    private readonly OpenJonesGameSettings _openJonesGameSettings;
    public IGameSettings GameSettings
    {
        get
        {
            // For OpenJones3D versions 0.4 and above, use OpenJonesGameSettings if configured to launch OpenJones and version is installed.
            bool isInstalled = OpenJonesInstaller.IsVersionInstalled(CurrentConfig.OpenJonesDirPath, CurrentConfig.OpenJonesSelectedVersion);
            bool isLegacy = OpenJonesInstaller.IsVersionLegacy(CurrentConfig.OpenJonesSelectedVersion);
            if (CurrentConfig.LaunchOpenJones && isInstalled && !isLegacy)
            {
                return _openJonesGameSettings;
            }

            return _registryGameSettings;
        }
    }

    private static AppState? _instance;

    public static AppState Instance
    {
        get
        {
            // This should never happen.
            if (_instance == null)
            {
                throw new InvalidOperationException("ERROR: Application services not initialized.");
            }

            return _instance;
        }
    }

    public AppState(IMessageWriter messageWriter)
    {
        _instance = this;
        MessageWriter = messageWriter;
        ModInstaller = new Indy3DModInstaller();
        OpenJonesInstaller = new OpenJonesInstaller();
        GameLauncher = new GameLauncher();
        _registryGameSettings = new RegistryGameSettings();
        CurrentConfig = InitConfig();
        _openJonesGameSettings = new OpenJonesGameSettings();
    }

    private AppConfig InitConfig()
    {
        AppConfig config;
        try
        {
            config = AppConfig.ReadConfig();
            MessageWriter.WriteLine($"Config file loaded successfully.");
        }
        catch (Exception e)
        {
            MessageWriter.WriteLine(e.Message);
            config = new AppConfig(_registryGameSettings);
            AppConfig.SaveConfig(config);
        }

        // Emit warning if config failed to find game's install path.
        if (config.InstallPath == null)
        {
            MessageWriter.WriteLine("WARNING: Infernal Machine install path not found. Please, configure it in the Settings window.");
        }

        return config;
    }
}
