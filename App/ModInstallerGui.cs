using System.Diagnostics;

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

    private AppState App { get; }

    private bool _configChanged = false;

    private IMessageWriter MessageWriter { get; }

    public ModInstallerGui()
    {
        this.InitializeComponent();

        var applicationVersion = FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
        Text += $" v{applicationVersion}";

        MessageWriter = new GuiMessageWriter(richTextFeedback);
        App = new AppState(MessageWriter);

        _buttonWidth = buttonUnpack.Width;
        _buttonHeight = buttonUnpack.Height;

        this.ResizeGui();
        // Progress bar is moving by default so stop it.
        this.StopProgressBar();
        UpdateDevModeButtonText();
    }

    private void ResizeGui()
    {
        // Resize mod path panel.
        panelModPath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        panelModPath.Height = labelModPath.Height + richTextBoxModPath.Height + (4 * MARGIN_COMMON);
        richTextBoxModPath.Width = panelModPath.Width - buttonBrowseModPath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseModPath.Location = new Point(panelModPath.Width - buttonBrowseModPath.Width - MARGIN_DOUBLE, richTextBoxModPath.Location.Y);

        // Resize and move button panel.
        int buttonOffsetY = _buttonHeight + MARGIN_DOUBLE;
        splitPanelButtonPane.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        int buttonOffsetX = (splitPanelButtonPane.Panel1.Width - _buttonWidth) / 2;
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
        panelFeedback.Height = panelContentWrapper.Height - (panelModPath.Height + splitPanelButtonPane.Height + (3 * MARGIN_DOUBLE));
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
        buttonSettings.Enabled = true;
    }

    private void DisableButtons()
    {
        buttonUnpack.Enabled = false;
        buttonSetDevMode.Enabled = false;
        buttonInstall.Enabled = false;
        buttonUninstall.Enabled = false;
        buttonPlay.Enabled = false;
        buttonSettings.Enabled = false;
    }

    private void UpdateDevModeButtonText()
    {
        try
        {
            var currentStartMode = App.GameSettings.StartMode;
            buttonSetDevMode.Text = currentStartMode == IGameSettings.START_MODE_DEV_DIALOG
                ? "Disable Dev Mode"
                : "Enable Dev Mode";
        }
        catch (Exception ex)
        {
            MessageWriter.WriteLine(ex.Message);
        }
    }

    private void Gui_window_Resize(object sender, EventArgs e)
    {
        this.ResizeGui();
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
            await App.ModInstaller.Unpack(App.CurrentConfig.InstallPath, App.CurrentConfig.ConvertCndToNdy);
        }
        catch (Exception ex)
        {
            MessageWriter.WriteLine(ex.Message);
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
            var currentStartMode = App.GameSettings.StartMode;
            App.GameSettings.StartMode = currentStartMode == IGameSettings.START_MODE_DEV_DIALOG
                ? IGameSettings.START_MODE_LOAD_DIALOG
                : IGameSettings.START_MODE_DEV_DIALOG;
            UpdateDevModeButtonText();
        }
        catch (Exception ex)
        {
            MessageWriter.WriteLine(ex.Message);
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
                    App.ModInstaller.Install(App.CurrentConfig.InstallPath, _modPath);
                }
                catch (Exception ex)
                {
                    MessageWriter.WriteLine(ex.Message);
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
                    App.ModInstaller.Uninstall(App.CurrentConfig.InstallPath);
                }
                catch (Exception ex)
                {
                    MessageWriter.WriteLine(ex.Message);
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
                    App.GameLauncher.LaunchGame(App.CurrentConfig);
                }
                catch (Exception ex)
                {
                    MessageWriter.WriteLine(ex.Message);
                }
            });
        }
        finally
        {
            this.EnableButtons();
        }
    }

    private void Gui_buttonSettings_Click(object sender, EventArgs e)
    {
        var settingsGui = new SettingsGui();
        _configChanged = true;
        // This is a blocking call until the Settings window is closed.
        settingsGui.ShowDialog();
        // Update Dev Mode button text in case user selected different game version in the Settings.
        UpdateDevModeButtonText();
    }

    private void Gui_window_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_configChanged)
        {
            AppConfig.SaveConfig(App.CurrentConfig);
        }
    }

    private async void Gui_window_Shown(object sender, EventArgs e)
    {
        try
        {
            await App.OpenJonesInstaller.InitializeOnlineResources();
            MessageWriter.WriteLine("OpenJones3D installer initialized successfully.");
        }
        catch (HttpRequestException httpEx)
        {
            MessageWriter.WriteLine($"WARNING: Failed to initialize OpenJones3D installer because remote resources could not be reached. {httpEx.Message} Try updating Indy3D Mod Installer.");
        }
        catch (Exception ex)
        {
            MessageWriter.WriteLine(ex.Message);
        }
        finally
        {
            MessageWriter.WriteLine("");
        }
    }
}
