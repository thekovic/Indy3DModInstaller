namespace Indy3DModInstaller;

public partial class ModInstallerGui : Form
{
    /// <summary>
    /// Width of the buttons at the bottom of the window. Precalculated manually once and stored here for later use.
    /// </summary>
    private readonly int _buttonsWidth = 0;

    private string? _installPath = null;
    private string? _modPath = null;

    private readonly GuiMessageWriter _messageWriter;

    private readonly Indy3DModInstaller _modInstaller;

    public ModInstallerGui()
    {
        this.InitializeComponent();

        string? installPath = Indy3DModInstaller.GetInstallPathFromRegistry();
        if (installPath != null)
        {
            string resourcePath = Path.Combine(installPath, "Resource");
            richTextBoxGamePath.Text = resourcePath;
            _installPath = resourcePath;
        }

        // Progress bar is moving by default so stop it.
        this.StopProgressBar();

        // Magic value. Total left/right margin values of all the buttons.
        const int buttonMargins = 5 * 6;
        _buttonsWidth = buttonUnpack.Width + buttonInstall.Width + buttonSetDevMode.Width + buttonUninstall.Width + buttonPlay.Width + buttonMargins;

        this.ResizeGui();

        _messageWriter = new GuiMessageWriter(richTextFeedback);
        _modInstaller = new Indy3DModInstaller(_messageWriter);
    }

    private void ResizeGui()
    {
        richTextBoxGamePath.Width = flowLayoutGamePath.Width - buttonBrowseGamePath.Width - 18;

        richTextBoxModPath.Width = flowLayoutModPath.Width - buttonBrowseModPath.Width - 18;

        richTextFeedback.Height = flowLayoutFeedbackArea.Height - labelFeedback.Height - progressBarFeedback.Height - 14;
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
        buttonPlay.Enabled = true;
    }

    private void DisableButtons()
    {
        buttonUnpack.Enabled = false;
        buttonSetDevMode.Enabled = false;
        buttonInstall.Enabled = false;
        buttonUninstall.Enabled = false;
        buttonPlay.Enabled = false;
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
            _installPath = folderBrowserDialogGamePath.SelectedPath;
        }
    }

    private void Gui_richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        _installPath = richTextBoxGamePath.Text;
    }

    private void Gui_buttonBrowseModPath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogModPath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxModPath.Text = folderBrowserDialogModPath.SelectedPath;
            _modPath = folderBrowserDialogModPath.SelectedPath;
        }
    }

    private void Gui_richTextBoxModPath_TextChanged(object sender, EventArgs e)
    {
        _modPath = richTextBoxModPath.Text;
    }

    private async void Gui_buttonUnpack_Click(object sender, EventArgs e)
    {
        this.StartProgressBar();
        this.DisableButtons();

        try
        {
            await Task.Run(() =>
            {
                try
                {
                    _modInstaller.Unpack(_installPath);
                }
                catch (Exception ex)
                {
                    _messageWriter.WriteLine(ex.Message);
                }
            });
        }
        finally
        {
            this.StopProgressBar();
            this.EnableButtons();
        }
    }

    private void Gui_buttonSetDevMode_Click(object sender, EventArgs e)
    {
        try
        {
            _modInstaller.SetDevMode();
        }
        catch (Exception ex)
        {
            _messageWriter.WriteLine(ex.Message);
        }
    }

    private async void Gui_buttonInstall_Click(object sender, EventArgs e)
    {
        this.StartProgressBar();
        this.DisableButtons();

        try
        {
            await Task.Run(() =>
            {
                try
                {
                    _modInstaller.Install(_installPath, _modPath);
                }
                catch (Exception ex)
                {
                    _messageWriter.WriteLine(ex.Message);
                }
            });
        }
        finally
        {
            this.StopProgressBar();
            this.EnableButtons();
        }
    }

    private async void Gui_buttonUninstall_Click(object sender, EventArgs e)
    {
        this.StartProgressBar();
        this.DisableButtons();

        try
        {
            await Task.Run(() =>
            {
                try
                {
                    _modInstaller.Uninstall(_installPath);
                }
                catch (Exception ex)
                {
                    _messageWriter.WriteLine(ex.Message);
                }
            });
        }
        finally
        {
            this.StopProgressBar();
            this.EnableButtons();
        }
    }

    private async void Gui_buttonPlay_Click(object sender, EventArgs e)
    {
        this.DisableButtons();

        try
        {
            await Task.Run(() =>
            {
                try
                {
                    _modInstaller.LaunchGame(_installPath);
                }
                catch (Exception ex)
                {
                    _messageWriter.WriteLine(ex.Message);
                }
            });
        }
        finally
        {
            this.EnableButtons();
        }
    }
}
