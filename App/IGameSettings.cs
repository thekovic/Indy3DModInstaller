using Microsoft.Win32;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Indy3DModInstaller;

public interface IGameSettings
{
    public const int START_MODE_INTRO_FMV = 0;
    public const int START_MODE_LOAD_DIALOG = 1;
    public const int START_MODE_DEV_DIALOG = 2;

    public string? InstallPath { get; }
    public int? StartMode { get; set; }
}

public class Indy3DRegistryEntry(string gameVersionId, string registryKey)
{
    public string GameVersionId { get; set; } = gameVersionId;
    public string RegistryKey { get; set; } = registryKey;
}

public class RegistryGameSettings : IGameSettings
{
    private static IMessageWriter MessageWriter { get => AppState.Instance.MessageWriter; }

    private static readonly Indy3DRegistryEntry[] REGISTRY_ENTRIES = [
        // Entry for Steam version set during installation. Requires admin mode to access which means changes will affect the game only if the game is launched via our launcher.
        new("Steam", "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0"),
        new("GOG", "HKEY_CURRENT_USER\\SOFTWARE\\LucasArts Entertainment Company LLC\\Indiana Jones and the Infernal Machine\\v1.0")
    ];

    public string? InstallPath
    { 
        get
        {
            foreach (var registryEntry in REGISTRY_ENTRIES)
            {
                object? registryKey = Registry.GetValue(registryEntry.RegistryKey, "Install Path", null);
                if (registryKey == null)
                {
                    continue;
                }

                MessageWriter.WriteLine($"Install Path: Found entry for {registryEntry.GameVersionId} version.");
                return (string) registryKey;
            }

            return null;
        }
    }

    public int? StartMode
    {
        get
        {
            foreach (var registryEntry in REGISTRY_ENTRIES)
            {
                object? registryKey = Registry.GetValue(registryEntry.RegistryKey, "Start Mode", null);
                if (registryKey == null)
                {
                    continue;
                }

                return (int) registryKey;
            }

            return null;
        }
        set
        {
            if (value == null)
            {
                return;
            }

            foreach (var registryEntry in REGISTRY_ENTRIES)
            {
                object? registryKey = Registry.GetValue(registryEntry.RegistryKey, "Start Mode", 42);
                if (registryKey == null)
                {
                    continue;
                }

                MessageWriter.WriteLine($"Dev Mode: Found entry for {registryEntry.GameVersionId} version.");

                bool isDevMode = value == IGameSettings.START_MODE_DEV_DIALOG;
                Registry.SetValue(registryEntry.RegistryKey, "Start Mode", value, RegistryValueKind.DWord);
                // Force disable "Dev Mode" (the checkbox in the dev dialog launcher) which tends to be on by default for some reason and breaks levels in .NDY format, confusing users who don't know about it. Power users who need it for the level editor can just check the box manually.
                Registry.SetValue(registryEntry.RegistryKey, "DevMode", 0, RegistryValueKind.DWord);
                if (isDevMode)
                {
                    MessageWriter.WriteLine("Dev Mode for Indy3D.exe enabled.");
                }
                else
                {
                    MessageWriter.WriteLine("Dev Mode for Indy3D.exe disabled.");
                }
            }
        }
    }
}

public class OpenJonesGameSettings : IGameSettings
{
    private static IMessageWriter MessageWriter { get => AppState.Instance.MessageWriter; }

    private const string OPENJONES_SETTINGS_FILE = "Jones.cfg";
    private static AppConfig Config { get => AppState.Instance.CurrentConfig; }

    private static JsonSerializerOptions JsonOptions { get; } = new JsonSerializerOptions
    {
        WriteIndented = true,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true
    };

    private string? _cachedSettingsPath;

    private JsonNode? _cachedJsonRoot;

    private JsonNode JsonRoot
    {
        get
        {
            string currentSettingsPath = Path.Combine(
                Config.OpenJonesDirPath!,
                Config.OpenJonesSelectedVersion!,
                OPENJONES_SETTINGS_FILE
            );

            if (_cachedJsonRoot is null || _cachedSettingsPath is null || _cachedSettingsPath != currentSettingsPath)
            {
                _cachedSettingsPath = currentSettingsPath;
                if (!File.Exists(_cachedSettingsPath))
                {
                    throw new FileNotFoundException($"ERROR: OpenJones3D settings file {_cachedSettingsPath} not found. Cannot read game settings.");
                }

                var jsonText = File.ReadAllText(_cachedSettingsPath);
                _cachedJsonRoot = JsonNode.Parse(jsonText);
            }

            if (_cachedJsonRoot is null)
            {
                throw new InvalidDataException($"ERROR: Invalid data. Could not read OpenJones3D settings from file {_cachedSettingsPath}.");
            }

            return _cachedJsonRoot;
        }
    }

    public string? InstallPath
    { 
        get
        {
            JsonNode root = JsonRoot;
            return root["installPath"]?.GetValue<string>();
        }
    }

    public int? StartMode
    {
        get
        {
            JsonNode root = JsonRoot;
            return root["startMode"]?.GetValue<int>();
        }
        set
        {
            JsonNode root = JsonRoot;
            if (value == null)
            {
                return;
            }

            switch (value)
            {
                case IGameSettings.START_MODE_INTRO_FMV:
                case IGameSettings.START_MODE_LOAD_DIALOG:
                    root["startMode"] = value;
                    MessageWriter.WriteLine("Dev Mode for OpenJones3D disabled.");
                    break;
                case IGameSettings.START_MODE_DEV_DIALOG:
                    root["startMode"] = value;
                    MessageWriter.WriteLine("Dev Mode for OpenJones3D enabled.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), $"ERROR: Invalid StartMode value {value} for OpenJones3D settings.");
            }

            // Force disable "Dev Mode" (the checkbox in the dev dialog launcher) which tends to be on by default for some reason and breaks levels in .NDY format, confusing users who don't know about it. Power users who need it for the level editor can just check the box manually.
            root["devMode"] = "false";

            File.WriteAllText(_cachedSettingsPath!, root.ToJsonString(JsonOptions));
        }
    }
}
