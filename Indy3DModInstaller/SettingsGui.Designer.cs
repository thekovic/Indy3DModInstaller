namespace Indy3DModInstaller;

partial class SettingsGui
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.panelContentWrapper = new Panel();
        this.panelOpenJonesControls = new Panel();
        this.buttonUninstallOpenJones = new Button();
        this.buttonInstallOpenJones = new Button();
        this.comboBoxOpenJonesVersion = new ComboBox();
        this.labelOpenJonesControls = new Label();
        this.flowLayoutPanelCheckBoxes = new FlowLayoutPanel();
        this.checkBoxLaunchOpenJones = new CheckBox();
        this.checkBoxConvertCndToNdy = new CheckBox();
        this.flowLayoutPanelButtonPane = new FlowLayoutPanel();
        this.buttonCancel = new Button();
        this.buttonApply = new Button();
        this.panelOpenJonesDirPath = new Panel();
        this.buttonBrowseOpenJonesDirPath = new Button();
        this.richTextBoxOpenJonesDirPath = new RichTextBox();
        this.labelOpenJonesDirPath = new Label();
        this.panelGamePath = new Panel();
        this.buttonBrowseGamePath = new Button();
        this.richTextBoxGamePath = new RichTextBox();
        this.labelGamePath = new Label();
        this.folderBrowserDialogGamePath = new FolderBrowserDialog();
        this.folderBrowserDialogOpenJonesDirPath = new FolderBrowserDialog();
        this.panelContentWrapper.SuspendLayout();
        this.panelOpenJonesControls.SuspendLayout();
        this.flowLayoutPanelCheckBoxes.SuspendLayout();
        this.flowLayoutPanelButtonPane.SuspendLayout();
        this.panelOpenJonesDirPath.SuspendLayout();
        this.panelGamePath.SuspendLayout();
        this.SuspendLayout();
        // 
        // panelContentWrapper
        // 
        this.panelContentWrapper.Controls.Add(this.panelOpenJonesControls);
        this.panelContentWrapper.Controls.Add(this.flowLayoutPanelCheckBoxes);
        this.panelContentWrapper.Controls.Add(this.flowLayoutPanelButtonPane);
        this.panelContentWrapper.Controls.Add(this.panelOpenJonesDirPath);
        this.panelContentWrapper.Controls.Add(this.panelGamePath);
        this.panelContentWrapper.Dock = DockStyle.Fill;
        this.panelContentWrapper.Location = new Point(0, 0);
        this.panelContentWrapper.Name = "panelContentWrapper";
        this.panelContentWrapper.Size = new Size(682, 313);
        this.panelContentWrapper.TabIndex = 0;
        // 
        // panelOpenJonesControls
        // 
        this.panelOpenJonesControls.Controls.Add(this.buttonUninstallOpenJones);
        this.panelOpenJonesControls.Controls.Add(this.buttonInstallOpenJones);
        this.panelOpenJonesControls.Controls.Add(this.comboBoxOpenJonesVersion);
        this.panelOpenJonesControls.Controls.Add(this.labelOpenJonesControls);
        this.panelOpenJonesControls.Location = new Point(3, 145);
        this.panelOpenJonesControls.Name = "panelOpenJonesControls";
        this.panelOpenJonesControls.Size = new Size(676, 41);
        this.panelOpenJonesControls.TabIndex = 6;
        // 
        // buttonUninstallOpenJones
        // 
        this.buttonUninstallOpenJones.Location = new Point(579, 3);
        this.buttonUninstallOpenJones.Name = "buttonUninstallOpenJones";
        this.buttonUninstallOpenJones.Size = new Size(94, 35);
        this.buttonUninstallOpenJones.TabIndex = 3;
        this.buttonUninstallOpenJones.Text = "Uninstall";
        this.buttonUninstallOpenJones.UseVisualStyleBackColor = true;
        // 
        // buttonInstallOpenJones
        // 
        this.buttonInstallOpenJones.Location = new Point(479, 3);
        this.buttonInstallOpenJones.Name = "buttonInstallOpenJones";
        this.buttonInstallOpenJones.Size = new Size(94, 35);
        this.buttonInstallOpenJones.TabIndex = 2;
        this.buttonInstallOpenJones.Text = "Install";
        this.buttonInstallOpenJones.UseVisualStyleBackColor = true;
        // 
        // comboBoxOpenJonesVersion
        // 
        this.comboBoxOpenJonesVersion.FormattingEnabled = true;
        this.comboBoxOpenJonesVersion.Location = new Point(207, 7);
        this.comboBoxOpenJonesVersion.Name = "comboBoxOpenJonesVersion";
        this.comboBoxOpenJonesVersion.Size = new Size(151, 28);
        this.comboBoxOpenJonesVersion.TabIndex = 1;
        // 
        // labelOpenJonesControls
        // 
        this.labelOpenJonesControls.AutoSize = true;
        this.labelOpenJonesControls.Location = new Point(3, 10);
        this.labelOpenJonesControls.Name = "labelOpenJonesControls";
        this.labelOpenJonesControls.Size = new Size(198, 20);
        this.labelOpenJonesControls.TabIndex = 0;
        this.labelOpenJonesControls.Text = "Select OpenJones3D version:";
        // 
        // flowLayoutPanelCheckBoxes
        // 
        this.flowLayoutPanelCheckBoxes.Controls.Add(this.checkBoxLaunchOpenJones);
        this.flowLayoutPanelCheckBoxes.Controls.Add(this.checkBoxConvertCndToNdy);
        this.flowLayoutPanelCheckBoxes.Location = new Point(3, 192);
        this.flowLayoutPanelCheckBoxes.Name = "flowLayoutPanelCheckBoxes";
        this.flowLayoutPanelCheckBoxes.Size = new Size(676, 60);
        this.flowLayoutPanelCheckBoxes.TabIndex = 5;
        // 
        // checkBoxLaunchOpenJones
        // 
        this.checkBoxLaunchOpenJones.AutoSize = true;
        this.checkBoxLaunchOpenJones.Location = new Point(6, 3);
        this.checkBoxLaunchOpenJones.Margin = new Padding(6, 3, 3, 3);
        this.checkBoxLaunchOpenJones.Name = "checkBoxLaunchOpenJones";
        this.checkBoxLaunchOpenJones.Size = new Size(371, 24);
        this.checkBoxLaunchOpenJones.TabIndex = 0;
        this.checkBoxLaunchOpenJones.Text = "Launch OpenJones3D instead of the original engine";
        this.checkBoxLaunchOpenJones.UseVisualStyleBackColor = true;
        // 
        // checkBoxConvertCndToNdy
        // 
        this.checkBoxConvertCndToNdy.AutoSize = true;
        this.checkBoxConvertCndToNdy.Location = new Point(6, 33);
        this.checkBoxConvertCndToNdy.Margin = new Padding(6, 3, 3, 3);
        this.checkBoxConvertCndToNdy.Name = "checkBoxConvertCndToNdy";
        this.checkBoxConvertCndToNdy.Size = new Size(400, 24);
        this.checkBoxConvertCndToNdy.TabIndex = 0;
        this.checkBoxConvertCndToNdy.Text = "Convert .CND level files to .NDY format upon unpacking";
        this.checkBoxConvertCndToNdy.UseVisualStyleBackColor = true;
        this.checkBoxConvertCndToNdy.CheckedChanged += this.Gui_checkBoxConvertCndToNdy_CheckedChanged;
        // 
        // flowLayoutPanelButtonPane
        // 
        this.flowLayoutPanelButtonPane.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left;
        this.flowLayoutPanelButtonPane.Controls.Add(this.buttonCancel);
        this.flowLayoutPanelButtonPane.Controls.Add(this.buttonApply);
        this.flowLayoutPanelButtonPane.FlowDirection = FlowDirection.RightToLeft;
        this.flowLayoutPanelButtonPane.Location = new Point(3, 260);
        this.flowLayoutPanelButtonPane.Name = "flowLayoutPanelButtonPane";
        this.flowLayoutPanelButtonPane.Size = new Size(676, 41);
        this.flowLayoutPanelButtonPane.TabIndex = 4;
        // 
        // buttonCancel
        // 
        this.buttonCancel.Location = new Point(579, 3);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new Size(94, 35);
        this.buttonCancel.TabIndex = 1;
        this.buttonCancel.Text = "Cancel";
        this.buttonCancel.UseVisualStyleBackColor = true;
        this.buttonCancel.Click += this.Gui_buttonCancel_Click;
        // 
        // buttonApply
        // 
        this.buttonApply.Location = new Point(479, 3);
        this.buttonApply.Name = "buttonApply";
        this.buttonApply.Size = new Size(94, 35);
        this.buttonApply.TabIndex = 0;
        this.buttonApply.Text = "Apply";
        this.buttonApply.UseVisualStyleBackColor = true;
        this.buttonApply.Click += this.Gui_buttonApply_Click;
        // 
        // panelOpenJonesDirPath
        // 
        this.panelOpenJonesDirPath.Controls.Add(this.buttonBrowseOpenJonesDirPath);
        this.panelOpenJonesDirPath.Controls.Add(this.richTextBoxOpenJonesDirPath);
        this.panelOpenJonesDirPath.Controls.Add(this.labelOpenJonesDirPath);
        this.panelOpenJonesDirPath.Location = new Point(3, 74);
        this.panelOpenJonesDirPath.Name = "panelOpenJonesDirPath";
        this.panelOpenJonesDirPath.Size = new Size(676, 65);
        this.panelOpenJonesDirPath.TabIndex = 3;
        // 
        // buttonBrowseOpenJonesDirPath
        // 
        this.buttonBrowseOpenJonesDirPath.AutoSize = true;
        this.buttonBrowseOpenJonesDirPath.Location = new Point(589, 23);
        this.buttonBrowseOpenJonesDirPath.Name = "buttonBrowseOpenJonesDirPath";
        this.buttonBrowseOpenJonesDirPath.Size = new Size(84, 35);
        this.buttonBrowseOpenJonesDirPath.TabIndex = 0;
        this.buttonBrowseOpenJonesDirPath.Text = "Browse...";
        this.buttonBrowseOpenJonesDirPath.UseVisualStyleBackColor = true;
        this.buttonBrowseOpenJonesDirPath.Click += this.Gui_buttonBrowseOpenJonesDirPath_Click;
        // 
        // richTextBoxOpenJonesDirPath
        // 
        this.richTextBoxOpenJonesDirPath.Location = new Point(3, 23);
        this.richTextBoxOpenJonesDirPath.Name = "richTextBoxOpenJonesDirPath";
        this.richTextBoxOpenJonesDirPath.ScrollBars = RichTextBoxScrollBars.None;
        this.richTextBoxOpenJonesDirPath.Size = new Size(580, 35);
        this.richTextBoxOpenJonesDirPath.TabIndex = 1;
        this.richTextBoxOpenJonesDirPath.Text = "";
        this.richTextBoxOpenJonesDirPath.WordWrap = false;
        this.richTextBoxOpenJonesDirPath.TextChanged += this.Gui_richTextBoxOpenJonesDirPath_TextChanged;
        // 
        // labelOpenJonesDirPath
        // 
        this.labelOpenJonesDirPath.AutoSize = true;
        this.labelOpenJonesDirPath.Location = new Point(0, 0);
        this.labelOpenJonesDirPath.Name = "labelOpenJonesDirPath";
        this.labelOpenJonesDirPath.Size = new Size(320, 20);
        this.labelOpenJonesDirPath.TabIndex = 3;
        this.labelOpenJonesDirPath.Text = "Select path to OpenJones3D installation folder:";
        // 
        // panelGamePath
        // 
        this.panelGamePath.Controls.Add(this.buttonBrowseGamePath);
        this.panelGamePath.Controls.Add(this.richTextBoxGamePath);
        this.panelGamePath.Controls.Add(this.labelGamePath);
        this.panelGamePath.Location = new Point(3, 3);
        this.panelGamePath.Name = "panelGamePath";
        this.panelGamePath.Size = new Size(676, 65);
        this.panelGamePath.TabIndex = 2;
        // 
        // buttonBrowseGamePath
        // 
        this.buttonBrowseGamePath.AutoSize = true;
        this.buttonBrowseGamePath.Location = new Point(589, 23);
        this.buttonBrowseGamePath.Name = "buttonBrowseGamePath";
        this.buttonBrowseGamePath.Size = new Size(84, 35);
        this.buttonBrowseGamePath.TabIndex = 0;
        this.buttonBrowseGamePath.Text = "Browse...";
        this.buttonBrowseGamePath.UseVisualStyleBackColor = true;
        this.buttonBrowseGamePath.Click += this.Gui_buttonBrowseGamePath_Click;
        // 
        // richTextBoxGamePath
        // 
        this.richTextBoxGamePath.Location = new Point(3, 23);
        this.richTextBoxGamePath.Name = "richTextBoxGamePath";
        this.richTextBoxGamePath.ScrollBars = RichTextBoxScrollBars.None;
        this.richTextBoxGamePath.Size = new Size(580, 35);
        this.richTextBoxGamePath.TabIndex = 1;
        this.richTextBoxGamePath.Text = "";
        this.richTextBoxGamePath.WordWrap = false;
        this.richTextBoxGamePath.TextChanged += this.Gui_richTextBoxGamePath_TextChanged;
        // 
        // labelGamePath
        // 
        this.labelGamePath.AutoSize = true;
        this.labelGamePath.Location = new Point(0, 0);
        this.labelGamePath.Name = "labelGamePath";
        this.labelGamePath.Size = new Size(452, 20);
        this.labelGamePath.TabIndex = 3;
        this.labelGamePath.Text = "Select path to Resource folder in your Infernal Machine installation:";
        // 
        // folderBrowserDialogGamePath
        // 
        this.folderBrowserDialogGamePath.ShowNewFolderButton = false;
        // 
        // SettingsGui
        // 
        this.AcceptButton = this.buttonApply;
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new Size(682, 313);
        this.Controls.Add(this.panelContentWrapper);
        this.MaximizeBox = false;
        this.MaximumSize = new Size(9999, 960);
        this.MinimumSize = new Size(700, 350);
        this.Name = "SettingsGui";
        this.Text = "SettingsGui";
        this.Resize += this.Gui_window_Resize;
        this.panelContentWrapper.ResumeLayout(false);
        this.panelOpenJonesControls.ResumeLayout(false);
        this.panelOpenJonesControls.PerformLayout();
        this.flowLayoutPanelCheckBoxes.ResumeLayout(false);
        this.flowLayoutPanelCheckBoxes.PerformLayout();
        this.flowLayoutPanelButtonPane.ResumeLayout(false);
        this.panelOpenJonesDirPath.ResumeLayout(false);
        this.panelOpenJonesDirPath.PerformLayout();
        this.panelGamePath.ResumeLayout(false);
        this.panelGamePath.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private Panel panelContentWrapper;
    private Panel panelGamePath;
    private Button buttonBrowseGamePath;
    private RichTextBox richTextBoxGamePath;
    private Label labelGamePath;
    private Panel panelOpenJonesDirPath;
    private Button buttonBrowseOpenJonesDirPath;
    private RichTextBox richTextBoxOpenJonesDirPath;
    private Label labelOpenJonesDirPath;
    private FlowLayoutPanel flowLayoutPanelButtonPane;
    private Button buttonApply;
    private Button buttonCancel;
    private FolderBrowserDialog folderBrowserDialogGamePath;
    private FlowLayoutPanel flowLayoutPanelCheckBoxes;
    private CheckBox checkBoxConvertCndToNdy;
    private Panel panelOpenJonesControls;
    private Label labelOpenJonesControls;
    private ComboBox comboBoxOpenJonesVersion;
    private FolderBrowserDialog folderBrowserDialogOpenJonesDirPath;
    private Button buttonUninstallOpenJones;
    private Button buttonInstallOpenJones;
    private CheckBox checkBoxLaunchOpenJones;
}