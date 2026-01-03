namespace Indy3DModInstaller;

public partial class SettingsGui : Form
{
    /// <summary>
    /// Default margin value used for all the controls in the GUI. Used when calculating window size during resizing.
    /// </summary>
    private const int MARGIN_COMMON = 3;
    /// <summary>
    /// Double the margin value to account for two sides (left and right or up and down) of the control.
    /// </summary>
    private const int MARGIN_DOUBLE = 2 * MARGIN_COMMON;

    private readonly AppConfig _originalConfig;
    private readonly AppConfig _modifiedConfig;

    private readonly OpenJonesInstaller _openJonesInstaller;

    public SettingsGui()
    {
        this.InitializeComponent();
        this.ResizeGui();

        _originalConfig = AppState.Instance.CurrentConfig;
        _modifiedConfig = new AppConfig(_originalConfig);
        _openJonesInstaller = AppState.Instance.OpenJonesInstaller;

        richTextBoxGamePath.Text = _modifiedConfig.InstallPath;
        richTextBoxOpenJonesDirPath.Text = _modifiedConfig.OpenJonesDirPath;
        UpdateOpenJonesVersionComboBox();
        UpdateOpenJonesInstallUninstallButtonState();
        progressBarOpenJonesInstallation.Visible = false;
        checkBoxLaunchOpenJones.Checked = _modifiedConfig.LaunchOpenJones;
        checkBoxConvertCndToNdy.Checked = _modifiedConfig.ConvertCndToNdy;

        if (_modifiedConfig.InstallPath != null)
        {
            folderBrowserDialogGamePath.InitialDirectory = _modifiedConfig.InstallPath;
        }

        if (_modifiedConfig.OpenJonesDirPath != null)
        {
            folderBrowserDialogOpenJonesDirPath.InitialDirectory = _modifiedConfig.OpenJonesDirPath;
        }
    }

    private void ResizeGui()
    {
        // Resize game path panel.
        panelGamePath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        richTextBoxGamePath.Width = panelGamePath.Width - buttonBrowseGamePath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseGamePath.Location = new Point(panelGamePath.Width - buttonBrowseGamePath.Width - MARGIN_COMMON, richTextBoxGamePath.Location.Y);
        // Resize OpenJones directory path panel.
        panelOpenJonesDirPath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        richTextBoxOpenJonesDirPath.Width = panelOpenJonesDirPath.Width - buttonBrowseOpenJonesDirPath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseOpenJonesDirPath.Location = new Point(panelOpenJonesDirPath.Width - buttonBrowseOpenJonesDirPath.Width - MARGIN_COMMON, richTextBoxOpenJonesDirPath.Location.Y);
        // Resize OpenJones controls panel.
        panelOpenJonesControls.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        buttonUninstallOpenJones.Location = new Point(panelOpenJonesControls.Width - buttonUninstallOpenJones.Width - MARGIN_COMMON, buttonUninstallOpenJones.Location.Y);
        buttonInstallOpenJones.Location = new Point(buttonUninstallOpenJones.Location.X - buttonInstallOpenJones.Width - MARGIN_DOUBLE, buttonInstallOpenJones.Location.Y);
        // Resize OpenJones installation progress bar.
        progressBarOpenJonesInstallation.Width = panelOpenJonesControls.Width - MARGIN_DOUBLE;
        // Resize checkbox panel.

        // Resize and move button panel.
        flowLayoutPanelButtonPane.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        flowLayoutPanelButtonPane.Location = new Point(flowLayoutPanelButtonPane.Location.X, panelContentWrapper.Height - flowLayoutPanelButtonPane.Height - MARGIN_DOUBLE);
    }

    private void DisableAllControls()
    {
        panelGamePath.Enabled = false;
        panelOpenJonesDirPath.Enabled = false;
        panelOpenJonesControls.Enabled = false;
        flowLayoutPanelCheckBoxes.Enabled = false;
        flowLayoutPanelButtonPane.Enabled = false;
    }

    private void EnableAllControls()
    {
        panelGamePath.Enabled = true;
        panelOpenJonesDirPath.Enabled = true;
        panelOpenJonesControls.Enabled = true;
        flowLayoutPanelCheckBoxes.Enabled = true;
        flowLayoutPanelButtonPane.Enabled = true;
    }

    /// <summary>
    /// Updates the items and selected value of the OpenJones3D version ComboBox to reflect the available builds and
    /// current selection. Tries to select the version stored in the config if it is available.
    /// </summary>
    /// <remarks>This method refreshes the ComboBox's data source based on the current OpenJones3D directory and
    /// selection. It temporarily detaches the SelectedIndexChanged event handler to prevent unintended event firing
    /// during the update, then reattaches it after the operation completes. Call this method when the available
    /// OpenJones3D builds may have changed.</remarks>
    private void UpdateOpenJonesVersionComboBox()
    {
        // Bug fix: Changing DataSource triggers SelectedIndexChanged event, which was intended to only be triggered by user interacting with the ComboBox, so temporarily remove event handler.
        comboBoxOpenJonesVersion.SelectedIndexChanged -= Gui_comboBoxOpenJonesVersion_SelectedIndexChanged!;
        comboBoxOpenJonesVersion.DataSource = _openJonesInstaller.GetBuildStrings(_modifiedConfig.OpenJonesDirPath);
        if (comboBoxOpenJonesVersion.Items.Contains(_modifiedConfig.OpenJonesSelectedVersion))
        {
            comboBoxOpenJonesVersion.SelectedItem = _modifiedConfig.OpenJonesSelectedVersion;
        }
        // Re-add event handler.
        comboBoxOpenJonesVersion.SelectedIndexChanged += Gui_comboBoxOpenJonesVersion_SelectedIndexChanged!;
    }

    private void UpdateOpenJonesInstallUninstallButtonState()
    {
        bool canBeInstalled = _openJonesInstaller.CanVersionBeInstalled(_modifiedConfig.OpenJonesDirPath, _modifiedConfig.OpenJonesSelectedVersion);
        buttonInstallOpenJones.Enabled = canBeInstalled;
        buttonUninstallOpenJones.Enabled = !canBeInstalled;
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
            _modifiedConfig.InstallPath = folderBrowserDialogGamePath.SelectedPath;
            _modifiedConfig.ExecutablePath = Path.Combine(folderBrowserDialogGamePath.SelectedPath, AppConfig.ORIGINAL_EXECUTABLE);
        }
    }

    private void Gui_richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        _modifiedConfig.InstallPath = richTextBoxGamePath.Text;
    }

    private void Gui_buttonBrowseOpenJonesDirPath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogOpenJonesDirPath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxOpenJonesDirPath.Text = folderBrowserDialogOpenJonesDirPath.SelectedPath;
            _modifiedConfig.OpenJonesDirPath = folderBrowserDialogOpenJonesDirPath.SelectedPath;
            UpdateOpenJonesVersionComboBox();
            UpdateOpenJonesInstallUninstallButtonState();
        }
    }

    private void Gui_richTextBoxOpenJonesDirPath_TextChanged(object sender, EventArgs e)
    {
        _modifiedConfig.OpenJonesDirPath = richTextBoxOpenJonesDirPath.Text;
        UpdateOpenJonesVersionComboBox();
        UpdateOpenJonesInstallUninstallButtonState();
    }

    private void Gui_comboBoxOpenJonesVersion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string? selectedVersion = comboBoxOpenJonesVersion.SelectedItem as string;
        if (selectedVersion is null)
        {
            return;
        }

        _modifiedConfig.OpenJonesSelectedVersion = selectedVersion;
        UpdateOpenJonesInstallUninstallButtonState();
    }

    private void Gui_buttonApply_Click(object sender, EventArgs e)
    {
        _originalConfig.UpdateWithValues(_modifiedConfig);
        AppConfig.SaveConfig(_originalConfig);
        this.Close();
    }

    private void Gui_buttonCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void Gui_checkBoxLaunchOpenJones_CheckedChanged(object sender, EventArgs e)
    {
        _modifiedConfig.LaunchOpenJones = checkBoxLaunchOpenJones.Checked;
    }

    private void Gui_checkBoxConvertCndToNdy_CheckedChanged(object sender, EventArgs e)
    {
        _modifiedConfig.ConvertCndToNdy = checkBoxConvertCndToNdy.Checked;
    }

    private async void Gui_buttonInstallOpenJones_Click(object sender, EventArgs e)
    {
        DisableAllControls();
        progressBarOpenJonesInstallation.Visible = true;

        try
        {
            await _openJonesInstaller.InstallVersion(_modifiedConfig.ExecutablePath, _modifiedConfig.OpenJonesDirPath, _modifiedConfig.OpenJonesSelectedVersion);
        }
        catch (Exception ex)
        {
            AppState.Instance.MessageWriter.WriteLine(ex.Message);
        }
        finally
        {
            progressBarOpenJonesInstallation.Visible = false;
            UpdateOpenJonesInstallUninstallButtonState();
            UpdateOpenJonesVersionComboBox();
            EnableAllControls();
        }
    }

    private void Gui_buttonUninstallOpenJones_Click(object sender, EventArgs e)
    {
        try
        {
            _openJonesInstaller.UninstallVersion(_modifiedConfig.OpenJonesDirPath, _modifiedConfig.OpenJonesSelectedVersion);
        }
        catch (Exception ex)
        {
            AppState.Instance.MessageWriter.WriteLine(ex.Message);
        }
        finally
        {
            UpdateOpenJonesInstallUninstallButtonState();
            UpdateOpenJonesVersionComboBox();
        }
    }
}
