using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indy3DModInstaller;

public partial class ModInstallerGui : Form
{
    public ModInstallerGui()
    {
        this.InitializeComponent();

        string? installPath = Indy3DModInstaller.GetInstallPathFromRegistry();
        if (installPath != null)
        {
            string resourcePath = Path.Combine(installPath, "Resource");
            richTextBoxGamePath.Text = resourcePath;
            Program._installPath = resourcePath;
        }

        StopProgressBar(progressBar1);
    }

    public RichTextBox GetMessageBox()
    {
        return richTextFeedback;
    }

    private static void StartProgressBar(ProgressBar progressBar)
    {
        progressBar.Style = ProgressBarStyle.Marquee;
        progressBar.MarqueeAnimationSpeed = 30;
    }

    private static void StopProgressBar(ProgressBar progressBar)
    {
        progressBar.Style = ProgressBarStyle.Continuous;
        progressBar.MarqueeAnimationSpeed = 0;
        progressBar.Value = 0;
    }

    private void EnableButtons()
    {
        buttonUnpack.Enabled = true;
        buttonSetDevMode.Enabled = true;
        buttonInstall.Enabled = true;
        buttonUninstall.Enabled = true;
    }

    private void DisableButtons()
    {
        buttonUnpack.Enabled = false;
        buttonSetDevMode.Enabled = false;
        buttonInstall.Enabled = false;
        buttonUninstall.Enabled = false;
    }

    private void buttonBrowseGamePath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogGamePath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxGamePath.Text = folderBrowserDialogGamePath.SelectedPath;
        }
    }

    private void richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        Program._installPath = richTextBoxGamePath.Text;
    }

    private void buttonBrowseModPath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogModPath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxModPath.Text = folderBrowserDialogModPath.SelectedPath;
        }
    }

    private void richTextBoxModPath_TextChanged(object sender, EventArgs e)
    {
        Program._modPath = richTextBoxModPath.Text;
    }

    private async void buttonUnpack_Click(object sender, EventArgs e)
    {
        if (Program._installPath == null)
        {
            Program.WriteLine("ERROR: Path empty. Cannot unpack game files.");
            Program.WriteLine("Please select path to Resource folder.");
        }
        else if (Path.GetFileName(Program._installPath) != "Resource")
        {
            Program.WriteLine("ERROR: Path doesn't lead to Resource folder. Cannot unpack game files.");
            Program.WriteLine("Please select path to Resource folder.");
        }
        else
        {
            StartProgressBar(progressBar1);
            this.DisableButtons();

            try
            {
                await Task.Run(() =>
                    {
                        try
                        {
                            Indy3DModInstaller.Unpack(Program._installPath);
                        }
                        catch (Exception ex)
                        {
                            Program.WriteLine(ex.Message);
                        }
                    });
            }
            finally
            {
                StopProgressBar(progressBar1);
                this.EnableButtons();
                Program.WriteLine("Unpacking successfully finished.");
            }
        }
    }

    private void buttonSetDevMode_Click(object sender, EventArgs e)
    {
        Indy3DModInstaller.SetDevMode();
    }
}
