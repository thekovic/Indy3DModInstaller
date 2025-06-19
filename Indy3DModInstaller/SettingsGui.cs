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

    private readonly Config _originalConfig;
    private readonly Config _modifiedConfig;

    public SettingsGui(Config config)
    {
        this.InitializeComponent();
        this.ResizeGui();

        _originalConfig = config;
        _modifiedConfig = new Config(config);

        richTextBoxGamePath.Text = _modifiedConfig.InstallPath;
        richTextBoxExecutablePath.Text = _modifiedConfig.ExecutablePath;
        checkBoxConvertCndToNdy.Checked = _modifiedConfig.ConvertCndToNdy;

        if (_modifiedConfig.InstallPath != null)
        {
            folderBrowserDialogGamePath.InitialDirectory = _modifiedConfig.InstallPath;
            openFileDialogExecutablePath.InitialDirectory = _modifiedConfig.InstallPath;
        }
    }

    private void ResizeGui()
    {
        // Resize game path panel.
        panelGamePath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        richTextBoxGamePath.Width = panelGamePath.Width - buttonBrowseGamePath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseGamePath.Location = new Point(panelGamePath.Width - buttonBrowseGamePath.Width - MARGIN_COMMON, richTextBoxGamePath.Location.Y);
        // Resize executable path panel.
        panelExecutablePath.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        richTextBoxExecutablePath.Width = panelExecutablePath.Width - buttonBrowseExecutablePath.Width - (2 * MARGIN_DOUBLE);
        buttonBrowseExecutablePath.Location = new Point(panelExecutablePath.Width - buttonBrowseExecutablePath.Width - MARGIN_COMMON, richTextBoxExecutablePath.Location.Y);
        // Resize checkbox panel.

        // Resize and move button panel.
        flowLayoutPanelButtonPane.Width = panelContentWrapper.Width - MARGIN_DOUBLE;
        flowLayoutPanelButtonPane.Location = new Point(flowLayoutPanelButtonPane.Location.X, panelContentWrapper.Height - flowLayoutPanelButtonPane.Height - MARGIN_DOUBLE);
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
        }
    }

    private void Gui_richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        _modifiedConfig.InstallPath = richTextBoxGamePath.Text;
    }

    private void Gui_buttonBrowseExecutablePath_Click(object sender, EventArgs e)
    {
        if (openFileDialogExecutablePath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxExecutablePath.Text = openFileDialogExecutablePath.FileName;
            _modifiedConfig.ExecutablePath = openFileDialogExecutablePath.FileName;
        }
    }

    private void Gui_richTextBoxExecutablePath_TextChanged(object sender, EventArgs e)
    {
        _modifiedConfig.ExecutablePath = richTextBoxExecutablePath.Text;
    }

    private void Gui_buttonApply_Click(object sender, EventArgs e)
    {
        _originalConfig.UpdateWithValues(_modifiedConfig);
        Config.SaveConfig(_originalConfig);
        this.Close();
    }

    private void Gui_buttonCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void Gui_checkBoxConvertCndToNdy_CheckedChanged(object sender, EventArgs e)
    {
        _modifiedConfig.ConvertCndToNdy = checkBoxConvertCndToNdy.Checked;
    }
}
