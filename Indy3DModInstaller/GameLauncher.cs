namespace Indy3DModInstaller;

internal class GameLauncher(IMessageWriter messageWriter) : IHasMessageWriter
{
    private const string OPENJONES_EXECUTABLE = "Jones3D.exe";

    public IMessageWriter MessageWriter { get; } = messageWriter;

    public void LaunchGame(Config config)
    {
        if (config.LaunchOpenJones)
        {
            if (config.OpenJonesDirPath is null)
            {
                throw new InvalidDataException($"ERROR: OpenJones3D directory path empty. Cannot launch OpenJones3D.{Environment.NewLine}Please select path to OpenJones3D directory in the Settings window.");
            }

            if (!Directory.Exists(config.OpenJonesDirPath))
            {
                throw new DirectoryNotFoundException($"ERROR: OpenJones3D directory {config.OpenJonesDirPath} not found. Cannot launch OpenJones3D.{Environment.NewLine}Please select valid path to OpenJones3D directory in the Settings window.");
            }

            if (config.OpenJonesSelectedVersion is null)
            {
                throw new InvalidDataException($"ERROR: OpenJones3D version not selected. Cannot launch OpenJones.{Environment.NewLine}Please select OpenJones3D version in the Settings window.");
            }

            string openJonesExecutablePath = Path.Combine(
                config.OpenJonesDirPath,
                config.OpenJonesSelectedVersion,
                OPENJONES_EXECUTABLE
            );

            MessageWriter.WriteLine("Launching OpenJones3D...");
            LaunchGame(openJonesExecutablePath);
        }
        else
        {
            MessageWriter.WriteLine("Launching game...");
            LaunchGame(config.ExecutablePath);
        }
    }

    private void LaunchGame(string? executablePath)
    {
        if (executablePath == null)
        {
            throw new ArgumentNullException(nameof(executablePath), $"ERROR: Executable path empty. Cannot launch game.");
        }

        if (!File.Exists(executablePath))
        {
            throw new FileNotFoundException($"ERROR: Executable {executablePath} not found. Cannot launch game.");
        }

        if (File.GetAttributes(executablePath).HasFlag(FileAttributes.Directory))
        {
            throw new ArgumentException($"ERROR: Executable path {executablePath} set to a directory. Cannot launch game.");
        }

        string executableDir = Path.GetDirectoryName(executablePath)!;
        OsUtils.LaunchProcess(executablePath, [], executableDir);

        MessageWriter.WriteLine("Game exited successfully.");
    }
}
