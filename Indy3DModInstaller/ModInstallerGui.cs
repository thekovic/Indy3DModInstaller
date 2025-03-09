namespace Indy3DModInstaller;

public partial class ModInstallerGui : Form
{
    /// <summary>
    /// Default margin value used for all the controls in the GUI. Used when calculating window size during resizing.
    /// </summary>
    private const int MARGIN_COMMON = 3;
    /// <summary>
    /// Double the margin value to account for two sides (left and right or up and down) of the control.
    /// </summary>
    private const int MARGIN_DOUBLE = 2 * MARGIN_COMMON;
    /// <summary>
    /// Width of every button at the bottom of the window. Matches the autosize of the widest button.
    /// </summary>
    private readonly int _buttonWidth = 0;
    /// <summary>
    /// Height of every button at the bottom of the window. Matches the autosize of the tallest button.
    /// </summary>
    private readonly int _buttonHeight = 0;

    private string? _modPath = null;

    private readonly GuiMessageWriter _messageWriter;

    private readonly Indy3DModInstaller _modInstaller;

    private Config _config;

    public ModInstallerGui()
    {
        this.InitializeComponent();

        _messageWriter = new GuiMessageWriter(richTextFeedback);
        _modInstaller = new Indy3DModInstaller(_messageWriter);

        _buttonWidth = buttonUnpack.Width;
        _buttonHeight = buttonUnpack.Height;
        this.ResizeGui();
        // Progress bar is moving by default so stop it.
        this.StopProgressBar();

        try
        {
            _config = Config.ReadConfig();
            _messageWriter.WriteLine("Config file loaded successfully.");
        }
        catch (Exception e)
        {
            _messageWriter.WriteLine(e.Message);
            _config = new Config();
        }

        richTextBoxGamePath.Text = _config.InstallPath;
    }

    private void ResizeGui()
    {
        // Resize game path panel.
        panelGamePath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        panelGamePath.Height = labelGamePath.Height + richTextBoxGamePath.Height + (4 * MARGIN_COMMON);
        richTextBoxGamePath.Width = panelGamePath.Width - buttonBrowseGamePath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseGamePath.Location = new Point(panelGamePath.Width - buttonBrowseGamePath.Width - MARGIN_DOUBLE, richTextBoxGamePath.Location.Y);

        // Resize mod path panel.
        panelModPath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        panelModPath.Height = labelModPath.Height + richTextBoxModPath.Height + (4 * MARGIN_COMMON);
        richTextBoxModPath.Width = panelModPath.Width - buttonBrowseModPath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseModPath.Location = new Point(panelModPath.Width - buttonBrowseModPath.Width - MARGIN_DOUBLE, richTextBoxModPath.Location.Y);

        // Resize and move button panel.
        int buttonOffsetX = (splitPanelButtonPane.Panel1.Width - _buttonWidth) / 2;
        int buttonOffsetY = _buttonHeight + MARGIN_DOUBLE;
        splitPanelButtonPane.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        splitPanelButtonPane.Height = (3 * buttonOffsetY) + MARGIN_DOUBLE;
        splitPanelButtonPane.Location = new Point(MARGIN_COMMON, panelContentWrapper.Height - splitPanelButtonPane.Height - MARGIN_DOUBLE);
        // Buttons in first half of the split panel.
        buttonUnpack.Location = new Point(buttonOffsetX, MARGIN_COMMON);
        buttonInstall.Location = new Point(buttonOffsetX, buttonOffsetY + MARGIN_COMMON);
        buttonUninstall.Location = new Point(buttonOffsetX, (2 * buttonOffsetY) + MARGIN_COMMON);
        // Buttons in second half of the split panel.
        buttonSettings.Location = new Point(buttonOffsetX, MARGIN_COMMON);
        buttonSetDevMode.Location = new Point(buttonOffsetX, buttonOffsetY + MARGIN_COMMON);
        buttonPlay.Location = new Point(buttonOffsetX, (2 * buttonOffsetY) + MARGIN_COMMON);

        // Resize and move feedback panel.
        panelFeedback.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        panelFeedback.Height = panelContentWrapper.Height - (panelGamePath.Height + panelModPath.Height + splitPanelButtonPane.Height + (4 * MARGIN_DOUBLE));
        richTextFeedback.Width = panelFeedback.Width - MARGIN_DOUBLE;
        richTextFeedback.Height = panelFeedback.Height - labelFeedback.Height - progressBarFeedback.Height - (3 * MARGIN_DOUBLE);
        progressBarFeedback.Width = panelFeedback.Width - MARGIN_DOUBLE;
        progressBarFeedback.Location = new Point(MARGIN_COMMON, richTextFeedback.Location.Y + richTextFeedback.Height + MARGIN_DOUBLE);
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
            _config.InstallPath = folderBrowserDialogGamePath.SelectedPath;
        }
    }

    private void Gui_richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        _config.InstallPath = richTextBoxGamePath.Text;
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
                    _modInstaller.Unpack(_config.InstallPath);
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
                    _modInstaller.Install(_config.InstallPath, _modPath);
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
                    _modInstaller.Uninstall(_config.InstallPath);
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
                    _modInstaller.LaunchGame(_config.ExecutablePath);
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
