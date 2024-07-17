using System.Diagnostics;

namespace Indy3DModInstaller;

public partial class ModInstallerGui : Form
{
    private readonly int _buttonsWidth = 0;

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

        this.StopProgressBar();

        _buttonsWidth = buttonUnpack.Width + buttonInstall.Width + buttonSetDevMode.Width + buttonUninstall.Width + buttonPlay.Width + (5 * 6);

        this.ResizeGui();
    }

    public RichTextBox GetMessageBox()
    {
        return richTextFeedback;
    }

    private void ResizeGui()
    {
        richTextBoxGamePath.Width = flowLayoutGamePath.Width - buttonBrowseGamePath.Width - 18;

        richTextBoxModPath.Width = flowLayoutModPath.Width - buttonBrowseModPath.Width - 18;

        richTextFeedback.Height = flowLayoutFeedbackArea.Height - progressBarFeedback.Height - 14;
        richTextFeedback.Width = flowLayoutFeedbackArea.Width - 12;
        progressBarFeedback.Width = flowLayoutFeedbackArea.Width - 16;

        int paddingLeft = (flowLayoutButtonPane.Width - _buttonsWidth) / 2;
        flowLayoutButtonPane.Padding = new Padding(paddingLeft, 0, 0, 0);
    }

    private void StartProgressBar()
    {
        progressBarFeedback.Style = ProgressBarStyle.Marquee;
        progressBarFeedback.MarqueeAnimationSpeed = 30;
    }

    private void StopProgressBar()
    {
        progressBarFeedback.Style = ProgressBarStyle.Continuous;
        progressBarFeedback.MarqueeAnimationSpeed = 0;
        progressBarFeedback.Value = 0;
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

    private void Gui_window_Resize(object sender, EventArgs e)
    {
        this.ResizeGui();
    }

    private void Gui_buttonBrowseGamePath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogGamePath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxGamePath.Text = folderBrowserDialogGamePath.SelectedPath;
            Program._installPath = folderBrowserDialogGamePath.SelectedPath;
        }
    }

    private void Gui_richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        Program._installPath = richTextBoxGamePath.Text;
    }

    private void Gui_buttonBrowseModPath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogModPath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxModPath.Text = folderBrowserDialogModPath.SelectedPath;
            Program._modPath = folderBrowserDialogModPath.SelectedPath;
        }
    }

    private void Gui_richTextBoxModPath_TextChanged(object sender, EventArgs e)
    {
        Program._modPath = richTextBoxModPath.Text;
    }

    private async void Gui_buttonUnpack_Click(object sender, EventArgs e)
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
            this.StartProgressBar();
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
                this.StopProgressBar();
                this.EnableButtons();
                Program.WriteLine("Unpacking successfully finished.");
            }
        }
    }

    private void Gui_buttonSetDevMode_Click(object sender, EventArgs e)
    {
        try
        {
            Indy3DModInstaller.SetDevMode();
        }
        catch (Exception ex)
        {
            Program.WriteLine(ex.Message);
        }
    }

    private async void Gui_buttonInstall_Click(object sender, EventArgs e)
    {
        if (Program._installPath == null)
        {
            Program.WriteLine("ERROR: Path empty. Cannot unpack game files.");
            Program.WriteLine("Please select path to Resource folder.");
            return;
        }
        else if (Path.GetFileName(Program._installPath) != "Resource")
        {
            Program.WriteLine("ERROR: Path doesn't lead to Resource folder. Cannot unpack game files.");
            Program.WriteLine("Please select path to Resource folder.");
            return;
        }

        if (Program._modPath == null)
        {
            Program.WriteLine("ERROR: Path empty. Cannot install mod.");
            Program.WriteLine("Please select path to mod folder.");
            return;
        }

        this.StartProgressBar();
        this.DisableButtons();

        try
        {
            await Task.Run(() =>
            {
                try
                {
                    Indy3DModInstaller.Install(Program._installPath, Program._modPath);
                }
                catch (Exception ex)
                {
                    Program.WriteLine(ex.Message);
                }
            });
        }
        finally
        {
            this.StopProgressBar();
            this.EnableButtons();
            Program.WriteLine("Mod installation successfully finished.");
        }
    }

    private async void Gui_buttonUninstall_Click(object sender, EventArgs e)
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
            this.StartProgressBar();
            this.DisableButtons();

            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        Indy3DModInstaller.Uninstall(Program._installPath);
                    }
                    catch (Exception ex)
                    {
                        Program.WriteLine(ex.Message);
                    }
                });
            }
            finally
            {
                this.StopProgressBar();
                this.EnableButtons();
                Program.WriteLine("Mod uninstallation successfully finished.");
            }
        }
    }

    private async void Gui_buttonPlay_Click(object sender, EventArgs e)
    {
        if (Program._installPath == null)
        {
            Program.WriteLine("ERROR: Path empty. Cannot launch game.");
            Program.WriteLine("Please select path to Resource folder.");
        }
        else if (Path.GetFileName(Program._installPath) != "Resource")
        {
            Program.WriteLine("ERROR: Path doesn't lead to Resource folder. Cannot launch game.");
            Program.WriteLine("Please select path to Resource folder.");
        }
        else
        {
            this.DisableButtons();

            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        Indy3DModInstaller.LaunchGame(Program._installPath);
                        Program.WriteLine("Game exited successfully.");
                    }
                    catch (Exception ex)
                    {
                        Program.WriteLine(ex.Message);
                    }
                });
            }
            finally
            {
                this.EnableButtons();
            }
        }
    }
}
