using System.Text.Json;

namespace Indy3DModInstaller;

public class AppConfig
{
    private const string CONFIG_FILE = "Indy3DModInstallerConfig.json";
    public const string ORIGINAL_EXECUTABLE = "Indy3D.exe";
    private const int CONFIG_SERIALIZATION_VERSION = 3;

    private static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };

    public int Version { get; set; }
    public string? InstallPath { get; set; }
    public string? ExecutablePath { get; set; }
    public string? OpenJonesDirPath { get; set; }
    public string? OpenJonesSelectedVersion { get; set; }
    public bool LaunchOpenJones { get; set; }
    public bool ConvertCndToNdy {  get; set; }

    /// <summary>
    /// Constructor for serialization. Do not *actually* use.
    /// </summary>
    public AppConfig()
    {
        Version = CONFIG_SERIALIZATION_VERSION;
    }

    /// <summary>
    /// Initializes a new instance of the AppConfig class with default values for configuration settings.
    /// </summary>
    /// <remarks>The default configuration sets the installation path based on the registry and appends the
    /// "Resource" subdirectory. The executable path is set to the original executable within this resource directory.
    /// The OpenJonesDirPath is initialized to a subdirectory named "OpenJones3D" in the current working directory. The
    /// ConvertCndToNdy property is set to false by default.</remarks>
    public AppConfig(RegistryGameSettings registry)
    {
        this.Version = CONFIG_SERIALIZATION_VERSION;
        this.OpenJonesDirPath = Path.Combine(Directory.GetCurrentDirectory(), "OpenJones3D");
        this.LaunchOpenJones = false;
        this.ConvertCndToNdy = false;
        this.InstallPath = registry.InstallPath;
        // Append "Resource" to the install path from registry.
        if (this.InstallPath != null)
        {
            string resourcePath = Path.Combine(this.InstallPath, "Resource");
            this.InstallPath = resourcePath;
            // Set executable path to the original executable by default.
            this.ExecutablePath = Path.Combine(this.InstallPath, ORIGINAL_EXECUTABLE);
        }
    }

    /// <summary>
    /// Copy constructor.
    /// </summary>
    /// <param name="config"></param>
    public AppConfig(AppConfig config)
    {
        this.UpdateWithValues(config);
    }

    public void UpdateWithValues(AppConfig config)
    {
        this.Version = config.Version;
        this.InstallPath = config.InstallPath;
        this.ExecutablePath = config.ExecutablePath;
        this.OpenJonesDirPath = config.OpenJonesDirPath;
        this.OpenJonesSelectedVersion = config.OpenJonesSelectedVersion;
        this.LaunchOpenJones = config.LaunchOpenJones;
        this.ConvertCndToNdy = config.ConvertCndToNdy;
    }

    public static AppConfig ReadConfig()
    {
        if (!File.Exists(CONFIG_FILE))
        {
            throw new FileNotFoundException("WARNING: Config file not found. Using default instead.");
        }

        string json = File.ReadAllText(CONFIG_FILE);
        var config = JsonSerializer.Deserialize<AppConfig>(json, JsonOptions);
        if (config == null)
        {
            throw new IOException("WARNING: Failed to read config file. Using default instead.");
        }

        // Upgrade to version 3.
        if (config.Version == 2)
        {
            config.OpenJonesDirPath = Path.Combine(Directory.GetCurrentDirectory(), "OpenJones3D");
            config.Version = 3;
        }

        if (config.Version != CONFIG_SERIALIZATION_VERSION)
        {
            throw new InvalidDataException("WARNING: Config file version is incompatible. Using default instead.");
        }

        return config;
    }

    public static void SaveConfig(AppConfig config)
    {
        string json = JsonSerializer.Serialize(config, JsonOptions);
        File.WriteAllText(CONFIG_FILE, json);
    }
}
