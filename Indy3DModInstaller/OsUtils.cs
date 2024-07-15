using System.Diagnostics;
using System.Text;

namespace Indy3DModInstaller;

internal class OsUtils
{
    public static void LaunchProcess(string processName, string[] args, string workingDirectory)
    {
        StringBuilder sbArgs = new StringBuilder();
        StringBuilder sbStderr = new StringBuilder();

        try
        {
            using (var process = new Process())
            {
                // Set process name from the config
                process.StartInfo.FileName = processName;
                // Pass arguments to the process
                foreach (string arg in args)
                {
                    sbArgs.Append($"{arg} ");
                    process.StartInfo.ArgumentList.Add(arg);
                }

                process.StartInfo.UseShellExecute = false;
                // Despite its name, the following setting also prevents
                // stdout of the launched process from showing up in our
                // terminal.
                process.StartInfo.CreateNoWindow = true;
                // Set process working directory to the Resource folder
                process.StartInfo.WorkingDirectory = workingDirectory;

                // Enable capture of stderr of the process
                process.StartInfo.RedirectStandardError = true;
                process.ErrorDataReceived += new DataReceivedEventHandler((sender, output) =>
                {
                    if (!string.IsNullOrEmpty(output.Data))
                    {
                        sbStderr.AppendLine(output.Data);
                    }
                });

                // PER MICROSOFT:
                // This code assumes the process you are starting will terminate itself.
                // Given that it is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
                process.Start();
                // Start capturing stderr
                process.BeginErrorReadLine();

                // Blocking wait for the process to finish
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    Program.WriteLine("ERROR:");
                    Program.WriteLine(sbStderr.ToString());
                    throw new Exception($"Subprocess {process.StartInfo.FileName} failed during execution.{Environment.NewLine}");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static void CopyDirectoryContent(string sourceDir, string destDir, bool verbose = false)
    {
        if (verbose)
        {
            Program.WriteLine($"Moving \"{sourceDir}\" to \"{destDir}\"...");
        }

        // Check if the source directory exists
        if (!Directory.Exists(sourceDir))
        {
            throw new DirectoryNotFoundException($"Source directory not found: {sourceDir}");
        }

        // If the destination directory doesn't exist, create it
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }

        // Copy all files from source to destination, overwriting if necessary
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFileName = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFileName, true);
        }

        // Recursively merge all subdirectories
        foreach (string dir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(dir));
            CopyDirectoryContent(dir, destSubDir);
        }
    }
}
