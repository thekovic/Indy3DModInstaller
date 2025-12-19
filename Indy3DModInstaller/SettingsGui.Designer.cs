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
        panelContentWrapper = new Panel();
        progressBarOpenJonesInstallation = new ProgressBar();
        panelOpenJonesControls = new Panel();
        buttonUninstallOpenJones = new Button();
        buttonInstallOpenJones = new Button();
        comboBoxOpenJonesVersion = new ComboBox();
        labelOpenJonesControls = new Label();
        flowLayoutPanelCheckBoxes = new FlowLayoutPanel();
        checkBoxLaunchOpenJones = new CheckBox();
        checkBoxConvertCndToNdy = new CheckBox();
        flowLayoutPanelButtonPane = new FlowLayoutPanel();
        buttonCancel = new Button();
        buttonApply = new Button();
        panelOpenJonesDirPath = new Panel();
        buttonBrowseOpenJonesDirPath = new Button();
        richTextBoxOpenJonesDirPath = new RichTextBox();
        labelOpenJonesDirPath = new Label();
        panelGamePath = new Panel();
        buttonBrowseGamePath = new Button();
        richTextBoxGamePath = new RichTextBox();
        labelGamePath = new Label();
        folderBrowserDialogGamePath = new FolderBrowserDialog();
        folderBrowserDialogOpenJonesDirPath = new FolderBrowserDialog();
        panelContentWrapper.SuspendLayout();
        panelOpenJonesControls.SuspendLayout();
        flowLayoutPanelCheckBoxes.SuspendLayout();
        flowLayoutPanelButtonPane.SuspendLayout();
        panelOpenJonesDirPath.SuspendLayout();
        panelGamePath.SuspendLayout();
        SuspendLayout();
        // 
        // panelContentWrapper
        // 
        panelContentWrapper.Controls.Add(progressBarOpenJonesInstallation);
        panelContentWrapper.Controls.Add(panelOpenJonesControls);
        panelContentWrapper.Controls.Add(flowLayoutPanelCheckBoxes);
        panelContentWrapper.Controls.Add(flowLayoutPanelButtonPane);
        panelContentWrapper.Controls.Add(panelOpenJonesDirPath);
        panelContentWrapper.Controls.Add(panelGamePath);
        panelContentWrapper.Dock = DockStyle.Fill;
        panelContentWrapper.Location = new Point(0, 0);
        panelContentWrapper.Name = "panelContentWrapper";
        panelContentWrapper.Size = new Size(682, 353);
        panelContentWrapper.TabIndex = 0;
        // 
        // progressBarOpenJonesInstallation
        // 
        progressBarOpenJonesInstallation.Location = new Point(3, 192);
        progressBarOpenJonesInstallation.MarqueeAnimationSpeed = 30;
        progressBarOpenJonesInstallation.Name = "progressBarOpenJonesInstallation";
        progressBarOpenJonesInstallation.Size = new Size(676, 29);
        progressBarOpenJonesInstallation.Style = ProgressBarStyle.Marquee;
        progressBarOpenJonesInstallation.TabIndex = 0;
        // 
        // panelOpenJonesControls
        // 
        panelOpenJonesControls.Controls.Add(buttonUninstallOpenJones);
        panelOpenJonesControls.Controls.Add(buttonInstallOpenJones);
        panelOpenJonesControls.Controls.Add(comboBoxOpenJonesVersion);
        panelOpenJonesControls.Controls.Add(labelOpenJonesControls);
        panelOpenJonesControls.Location = new Point(3, 145);
        panelOpenJonesControls.Name = "panelOpenJonesControls";
        panelOpenJonesControls.Size = new Size(676, 41);
        panelOpenJonesControls.TabIndex = 6;
        // 
        // buttonUninstallOpenJones
        // 
        buttonUninstallOpenJones.Location = new Point(579, 3);
        buttonUninstallOpenJones.Name = "buttonUninstallOpenJones";
        buttonUninstallOpenJones.Size = new Size(94, 35);
        buttonUninstallOpenJones.TabIndex = 3;
        buttonUninstallOpenJones.Text = "Uninstall";
        buttonUninstallOpenJones.UseVisualStyleBackColor = true;
        buttonUninstallOpenJones.Click += Gui_buttonUninstallOpenJones_Click;
        // 
        // buttonInstallOpenJones
        // 
        buttonInstallOpenJones.Location = new Point(479, 3);
        buttonInstallOpenJones.Name = "buttonInstallOpenJones";
        buttonInstallOpenJones.Size = new Size(94, 35);
        buttonInstallOpenJones.TabIndex = 2;
        buttonInstallOpenJones.Text = "Install";
        buttonInstallOpenJones.UseVisualStyleBackColor = true;
        buttonInstallOpenJones.Click += Gui_buttonInstallOpenJones_Click;
        // 
        // comboBoxOpenJonesVersion
        // 
        comboBoxOpenJonesVersion.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxOpenJonesVersion.FormattingEnabled = true;
        comboBoxOpenJonesVersion.Location = new Point(207, 7);
        comboBoxOpenJonesVersion.Name = "comboBoxOpenJonesVersion";
        comboBoxOpenJonesVersion.Size = new Size(151, 28);
        comboBoxOpenJonesVersion.TabIndex = 1;
        comboBoxOpenJonesVersion.SelectedIndexChanged += Gui_comboBoxOpenJonesVersion_SelectedIndexChanged;
        // 
        // labelOpenJonesControls
        // 
        labelOpenJonesControls.AutoSize = true;
        labelOpenJonesControls.Location = new Point(3, 10);
        labelOpenJonesControls.Name = "labelOpenJonesControls";
        labelOpenJonesControls.Size = new Size(198, 20);
        labelOpenJonesControls.TabIndex = 0;
        labelOpenJonesControls.Text = "Select OpenJones3D version:";
        // 
        // flowLayoutPanelCheckBoxes
        // 
        flowLayoutPanelCheckBoxes.Controls.Add(checkBoxLaunchOpenJones);
        flowLayoutPanelCheckBoxes.Controls.Add(checkBoxConvertCndToNdy);
        flowLayoutPanelCheckBoxes.Location = new Point(3, 227);
        flowLayoutPanelCheckBoxes.Name = "flowLayoutPanelCheckBoxes";
        flowLayoutPanelCheckBoxes.Size = new Size(676, 60);
        flowLayoutPanelCheckBoxes.TabIndex = 5;
        // 
        // checkBoxLaunchOpenJones
        // 
        checkBoxLaunchOpenJones.AutoSize = true;
        checkBoxLaunchOpenJones.Location = new Point(6, 3);
        checkBoxLaunchOpenJones.Margin = new Padding(6, 3, 3, 3);
        checkBoxLaunchOpenJones.Name = "checkBoxLaunchOpenJones";
        checkBoxLaunchOpenJones.Size = new Size(371, 24);
        checkBoxLaunchOpenJones.TabIndex = 0;
        checkBoxLaunchOpenJones.Text = "Launch OpenJones3D instead of the original engine";
        checkBoxLaunchOpenJones.UseVisualStyleBackColor = true;
        // 
        // checkBoxConvertCndToNdy
        // 
        checkBoxConvertCndToNdy.AutoSize = true;
        checkBoxConvertCndToNdy.Location = new Point(6, 33);
        checkBoxConvertCndToNdy.Margin = new Padding(6, 3, 3, 3);
        checkBoxConvertCndToNdy.Name = "checkBoxConvertCndToNdy";
        checkBoxConvertCndToNdy.Size = new Size(400, 24);
        checkBoxConvertCndToNdy.TabIndex = 0;
        checkBoxConvertCndToNdy.Text = "Convert .CND level files to .NDY format upon unpacking";
        checkBoxConvertCndToNdy.UseVisualStyleBackColor = true;
        checkBoxConvertCndToNdy.CheckedChanged += Gui_checkBoxConvertCndToNdy_CheckedChanged;
        // 
        // flowLayoutPanelButtonPane
        // 
        flowLayoutPanelButtonPane.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left;
        flowLayoutPanelButtonPane.Controls.Add(buttonCancel);
        flowLayoutPanelButtonPane.Controls.Add(buttonApply);
        flowLayoutPanelButtonPane.FlowDirection = FlowDirection.RightToLeft;
        flowLayoutPanelButtonPane.Location = new Point(3, 300);
        flowLayoutPanelButtonPane.Name = "flowLayoutPanelButtonPane";
        flowLayoutPanelButtonPane.Size = new Size(676, 41);
        flowLayoutPanelButtonPane.TabIndex = 4;
        // 
        // buttonCancel
        // 
        buttonCancel.Location = new Point(579, 3);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new Size(94, 35);
        buttonCancel.TabIndex = 1;
        buttonCancel.Text = "Cancel";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += Gui_buttonCancel_Click;
        // 
        // buttonApply
        // 
        buttonApply.Location = new Point(479, 3);
        buttonApply.Name = "buttonApply";
        buttonApply.Size = new Size(94, 35);
        buttonApply.TabIndex = 0;
        buttonApply.Text = "Apply";
        buttonApply.UseVisualStyleBackColor = true;
        buttonApply.Click += Gui_buttonApply_Click;
        // 
        // panelOpenJonesDirPath
        // 
        panelOpenJonesDirPath.Controls.Add(buttonBrowseOpenJonesDirPath);
        panelOpenJonesDirPath.Controls.Add(richTextBoxOpenJonesDirPath);
        panelOpenJonesDirPath.Controls.Add(labelOpenJonesDirPath);
        panelOpenJonesDirPath.Location = new Point(3, 74);
        panelOpenJonesDirPath.Name = "panelOpenJonesDirPath";
        panelOpenJonesDirPath.Size = new Size(676, 65);
        panelOpenJonesDirPath.TabIndex = 3;
        // 
        // buttonBrowseOpenJonesDirPath
        // 
        buttonBrowseOpenJonesDirPath.AutoSize = true;
        buttonBrowseOpenJonesDirPath.Location = new Point(589, 23);
        buttonBrowseOpenJonesDirPath.Name = "buttonBrowseOpenJonesDirPath";
        buttonBrowseOpenJonesDirPath.Size = new Size(84, 35);
        buttonBrowseOpenJonesDirPath.TabIndex = 0;
        buttonBrowseOpenJonesDirPath.Text = "Browse...";
        buttonBrowseOpenJonesDirPath.UseVisualStyleBackColor = true;
        buttonBrowseOpenJonesDirPath.Click += Gui_buttonBrowseOpenJonesDirPath_Click;
        // 
        // richTextBoxOpenJonesDirPath
        // 
        richTextBoxOpenJonesDirPath.Location = new Point(3, 23);
        richTextBoxOpenJonesDirPath.Name = "richTextBoxOpenJonesDirPath";
        richTextBoxOpenJonesDirPath.ScrollBars = RichTextBoxScrollBars.None;
        richTextBoxOpenJonesDirPath.Size = new Size(580, 35);
        richTextBoxOpenJonesDirPath.TabIndex = 1;
        richTextBoxOpenJonesDirPath.Text = "";
        richTextBoxOpenJonesDirPath.WordWrap = false;
        richTextBoxOpenJonesDirPath.TextChanged += Gui_richTextBoxOpenJonesDirPath_TextChanged;
        // 
        // labelOpenJonesDirPath
        // 
        labelOpenJonesDirPath.AutoSize = true;
        labelOpenJonesDirPath.Location = new Point(0, 0);
        labelOpenJonesDirPath.Name = "labelOpenJonesDirPath";
        labelOpenJonesDirPath.Size = new Size(320, 20);
        labelOpenJonesDirPath.TabIndex = 3;
        labelOpenJonesDirPath.Text = "Select path to OpenJones3D installation folder:";
        // 
        // panelGamePath
        // 
        panelGamePath.Controls.Add(buttonBrowseGamePath);
        panelGamePath.Controls.Add(richTextBoxGamePath);
        panelGamePath.Controls.Add(labelGamePath);
        panelGamePath.Location = new Point(3, 3);
        panelGamePath.Name = "panelGamePath";
        panelGamePath.Size = new Size(676, 65);
        panelGamePath.TabIndex = 2;
        // 
        // buttonBrowseGamePath
        // 
        buttonBrowseGamePath.AutoSize = true;
        buttonBrowseGamePath.Location = new Point(589, 23);
        buttonBrowseGamePath.Name = "buttonBrowseGamePath";
        buttonBrowseGamePath.Size = new Size(84, 35);
        buttonBrowseGamePath.TabIndex = 0;
        buttonBrowseGamePath.Text = "Browse...";
        buttonBrowseGamePath.UseVisualStyleBackColor = true;
        buttonBrowseGamePath.Click += Gui_buttonBrowseGamePath_Click;
        // 
        // richTextBoxGamePath
        // 
        richTextBoxGamePath.Location = new Point(3, 23);
        richTextBoxGamePath.Name = "richTextBoxGamePath";
        richTextBoxGamePath.ScrollBars = RichTextBoxScrollBars.None;
        richTextBoxGamePath.Size = new Size(580, 35);
        richTextBoxGamePath.TabIndex = 1;
        richTextBoxGamePath.Text = "";
        richTextBoxGamePath.WordWrap = false;
        richTextBoxGamePath.TextChanged += Gui_richTextBoxGamePath_TextChanged;
        // 
        // labelGamePath
        // 
        labelGamePath.AutoSize = true;
        labelGamePath.Location = new Point(0, 0);
        labelGamePath.Name = "labelGamePath";
        labelGamePath.Size = new Size(452, 20);
        labelGamePath.TabIndex = 3;
        labelGamePath.Text = "Select path to Resource folder in your Infernal Machine installation:";
        // 
        // folderBrowserDialogGamePath
        // 
        folderBrowserDialogGamePath.ShowNewFolderButton = false;
        // 
        // SettingsGui
        // 
        AcceptButton = buttonApply;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = buttonCancel;
        ClientSize = new Size(682, 353);
        Controls.Add(panelContentWrapper);
        MaximizeBox = false;
        MaximumSize = new Size(9999, 960);
        MinimumSize = new Size(700, 385);
        Name = "SettingsGui";
        Text = "Settings";
        Resize += Gui_window_Resize;
        panelContentWrapper.ResumeLayout(false);
        panelOpenJonesControls.ResumeLayout(false);
        panelOpenJonesControls.PerformLayout();
        flowLayoutPanelCheckBoxes.ResumeLayout(false);
        flowLayoutPanelCheckBoxes.PerformLayout();
        flowLayoutPanelButtonPane.ResumeLayout(false);
        panelOpenJonesDirPath.ResumeLayout(false);
        panelOpenJonesDirPath.PerformLayout();
        panelGamePath.ResumeLayout(false);
        panelGamePath.PerformLayout();
        ResumeLayout(false);
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
    private ProgressBar progressBarOpenJonesInstallation;
}