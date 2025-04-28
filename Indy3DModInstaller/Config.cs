using System.Text.Json;

namespace Indy3DModInstaller;

public class Config
{
    private const string CONFIG_FILE = "Indy3DModInstallerConfig.json";
    private const string ORIGINAL_EXECUTABLE = "Indy3D.exe";
    private const int CONFIG_SERIALIZATION_VERSION = 2;

    private static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };

    public int Version { get; set; }
    public string? InstallPath { get; set; }
    public string? ExecutablePath { get; set; }
    public bool ConvertCndToNdy {  get; set; }

    public Config()
    {
        this.Version = CONFIG_SERIALIZATION_VERSION;
        this.InstallPath = Indy3DModInstaller.GetInstallPathFromRegistry();
        // Append "Resource" to the install path from registry.
        if (this.InstallPath != null)
        {
            string resourcePath = Path.Combine(this.InstallPath, "Resource");
            this.InstallPath = resourcePath;
            // Set executable path to the original executable by default.
            this.ExecutablePath = Path.Combine(this.InstallPath, ORIGINAL_EXECUTABLE);
        }
        this.ConvertCndToNdy = false;
    }

    public Config(Config config)
    {
        this.UpdateWithValues(config);
    }

    public void UpdateWithValues(Config config)
    {
        this.Version = config.Version;
        this.InstallPath = config.InstallPath;
        this.ExecutablePath = config.ExecutablePath;
        this.ConvertCndToNdy = config.ConvertCndToNdy;
    }

    public static Config ReadConfig()
    {
        if (!File.Exists(CONFIG_FILE))
        {
            throw new Exception("WARNING: Config file not found. Using default instead.");
        }

        string json = File.ReadAllText(CONFIG_FILE);
        var config = JsonSerializer.Deserialize<Config>(json, JsonOptions);
        if (config == null)
        {
            throw new Exception("WARNING: Failed to read config file. Using default instead.");
        }

        config.Version = CONFIG_SERIALIZATION_VERSION;

        return config;
    }

    public static void SaveConfig(Config config)
    {
        string json = JsonSerializer.Serialize(config, JsonOptions);
        File.WriteAllText(CONFIG_FILE, json);
    }
}
