using System.IO.Compression;

namespace Indy3DModInstaller;

public class DgVoodooInstaller
{
    private const string DGVOODOO2_PACKAGE_URL = "https://github.com/thekovic/dgVoodoo2-redistributable/releases/download/2.82.5/dgVoodoo2-2.82.5-redistributable.zip";

    private static IMessageWriter MessageWriter { get => AppState.Instance.MessageWriter; }

    public static async Task InstallDgVoodoo(string installPath)
    {
        MessageWriter.WriteLine($"Installing dgVoodoo2 for improved compatibility with DirectX 6 rendering...");
        using var httpClient = new HttpClient();

        MessageWriter.WriteLine($"Downloading dgVoodoo2 from '{DGVOODOO2_PACKAGE_URL}'...");
        var archiveData = await httpClient.GetByteArrayAsync(DGVOODOO2_PACKAGE_URL);

        using var archiveStream = new MemoryStream(archiveData);
        using var archive = new ZipArchive(archiveStream);
        MessageWriter.WriteLine($"Installing dgVoodoo2 to '{installPath}'...");
        archive.ExtractToDirectory(installPath);

        MessageWriter.WriteLine($"dgVoodoo2 successfully installed.");
    }
}
