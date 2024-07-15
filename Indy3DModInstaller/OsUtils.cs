using System.Diagnostics;

namespace Indy3DModInstaller;

internal class OsUtils
{
    public static void LaunchProcess(string processName, string[] args, bool verbose = false)
    {
        try
        {
            using (var process = new Process())
            {
                // Set process name from the config
                process.StartInfo.FileName = processName;
                // Pass arguments to the process
                foreach (string arg in args)
                {
                    process.StartInfo.ArgumentList.Add(arg);
                }

                process.StartInfo.UseShellExecute = false;
                // Despite its name, the following setting also prevents
                // stdout of the launched process from showing up in our
                // terminal.
                process.StartInfo.CreateNoWindow = true;
                // Enable capture of stdout of the process
                process.StartInfo.RedirectStandardOutput = true;
                process.OutputDataReceived += new DataReceivedEventHandler((sender, output) =>
                {
                    if (!string.IsNullOrEmpty(output.Data) && verbose)
                    {
                        Debug.WriteLine(output.Data);
                    }
                });
                // Enable capture of stderr of the process
                process.StartInfo.RedirectStandardError = true;
                process.ErrorDataReceived += new DataReceivedEventHandler((sender, output) =>
                {
                    if (!string.IsNullOrEmpty(output.Data) && verbose)
                    {
                        Debug.WriteLine(output.Data);
                    }
                });

                // PER MICROSOFT:
                // This code assumes the process you are starting will terminate itself.
                // Given that it is started without a window so you cannot terminate it
                // on the desktop, it must terminate itself or you can do it programmatically
                // from this application using the Kill method.
                process.Start();
                // Start capturing stdout
                process.BeginOutputReadLine();
                // Start capturing stderr
                process.BeginErrorReadLine();
                // Blocking wait for the process to finish
                process.WaitForExit();

                Program.WriteLine($"Process {process.StartInfo.FileName} exited with {process.ExitCode}.");

                if (process.ExitCode != 0)
                {
                    throw new Exception(
                        $"Subprocess {process.StartInfo.FileName} failed during execution.{Environment.NewLine}" +
                        $"Execution: {processName} {args}{Environment.NewLine}");
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static void CopyDirectoryContent(string sourceDir, string destDir)
    {
        Program.WriteLine($"Moving \"{sourceDir}\" to \"{destDir}\"...");

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
