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
        this.flowLayoutPanelCheckBoxes = new FlowLayoutPanel();
        this.checkBoxConvertCndToNdy = new CheckBox();
        this.flowLayoutPanelButtonPane = new FlowLayoutPanel();
        this.buttonCancel = new Button();
        this.buttonApply = new Button();
        this.panelExecutablePath = new Panel();
        this.buttonBrowseExecutablePath = new Button();
        this.richTextBoxExecutablePath = new RichTextBox();
        this.labelExecutablePath = new Label();
        this.panelGamePath = new Panel();
        this.buttonBrowseGamePath = new Button();
        this.richTextBoxGamePath = new RichTextBox();
        this.labelGamePath = new Label();
        this.folderBrowserDialogGamePath = new FolderBrowserDialog();
        this.openFileDialogExecutablePath = new OpenFileDialog();
        this.panelContentWrapper.SuspendLayout();
        this.flowLayoutPanelCheckBoxes.SuspendLayout();
        this.flowLayoutPanelButtonPane.SuspendLayout();
        this.panelExecutablePath.SuspendLayout();
        this.panelGamePath.SuspendLayout();
        this.SuspendLayout();
        // 
        // panelContentWrapper
        // 
        this.panelContentWrapper.Controls.Add(this.flowLayoutPanelCheckBoxes);
        this.panelContentWrapper.Controls.Add(this.flowLayoutPanelButtonPane);
        this.panelContentWrapper.Controls.Add(this.panelExecutablePath);
        this.panelContentWrapper.Controls.Add(this.panelGamePath);
        this.panelContentWrapper.Dock = DockStyle.Fill;
        this.panelContentWrapper.Location = new Point(0, 0);
        this.panelContentWrapper.Name = "panelContentWrapper";
        this.panelContentWrapper.Size = new Size(682, 233);
        this.panelContentWrapper.TabIndex = 0;
        // 
        // flowLayoutPanelCheckBoxes
        // 
        this.flowLayoutPanelCheckBoxes.Controls.Add(this.checkBoxConvertCndToNdy);
        this.flowLayoutPanelCheckBoxes.Location = new Point(3, 145);
        this.flowLayoutPanelCheckBoxes.Name = "flowLayoutPanelCheckBoxes";
        this.flowLayoutPanelCheckBoxes.Size = new Size(676, 30);
        this.flowLayoutPanelCheckBoxes.TabIndex = 5;
        // 
        // checkBoxConvertCndToNdy
        // 
        this.checkBoxConvertCndToNdy.AutoSize = true;
        this.checkBoxConvertCndToNdy.Location = new Point(3, 3);
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
        this.flowLayoutPanelButtonPane.Location = new Point(3, 180);
        this.flowLayoutPanelButtonPane.Name = "flowLayoutPanelButtonPane";
        this.flowLayoutPanelButtonPane.Size = new Size(676, 41);
        this.flowLayoutPanelButtonPane.TabIndex = 4;
        // 
        // buttonCancel
        // 
        this.buttonCancel.Location = new Point(579, 3);
        this.buttonCancel.Margin = new Padding(16, 3, 3, 3);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new Size(94, 35);
        this.buttonCancel.TabIndex = 1;
        this.buttonCancel.Text = "Cancel";
        this.buttonCancel.UseVisualStyleBackColor = true;
        this.buttonCancel.Click += this.Gui_buttonCancel_Click;
        // 
        // buttonApply
        // 
        this.buttonApply.Location = new Point(453, 3);
        this.buttonApply.Margin = new Padding(16, 3, 16, 3);
        this.buttonApply.Name = "buttonApply";
        this.buttonApply.Size = new Size(94, 35);
        this.buttonApply.TabIndex = 0;
        this.buttonApply.Text = "Apply";
        this.buttonApply.UseVisualStyleBackColor = true;
        this.buttonApply.Click += this.Gui_buttonApply_Click;
        // 
        // panelExecutablePath
        // 
        this.panelExecutablePath.Controls.Add(this.buttonBrowseExecutablePath);
        this.panelExecutablePath.Controls.Add(this.richTextBoxExecutablePath);
        this.panelExecutablePath.Controls.Add(this.labelExecutablePath);
        this.panelExecutablePath.Location = new Point(3, 74);
        this.panelExecutablePath.Name = "panelExecutablePath";
        this.panelExecutablePath.Size = new Size(676, 65);
        this.panelExecutablePath.TabIndex = 3;
        // 
        // buttonBrowseExecutablePath
        // 
        this.buttonBrowseExecutablePath.AutoSize = true;
        this.buttonBrowseExecutablePath.Location = new Point(589, 23);
        this.buttonBrowseExecutablePath.Name = "buttonBrowseExecutablePath";
        this.buttonBrowseExecutablePath.Size = new Size(84, 35);
        this.buttonBrowseExecutablePath.TabIndex = 0;
        this.buttonBrowseExecutablePath.Text = "Browse...";
        this.buttonBrowseExecutablePath.UseVisualStyleBackColor = true;
        this.buttonBrowseExecutablePath.Click += this.Gui_buttonBrowseExecutablePath_Click;
        // 
        // richTextBoxExecutablePath
        // 
        this.richTextBoxExecutablePath.Location = new Point(3, 23);
        this.richTextBoxExecutablePath.Name = "richTextBoxExecutablePath";
        this.richTextBoxExecutablePath.ScrollBars = RichTextBoxScrollBars.None;
        this.richTextBoxExecutablePath.Size = new Size(580, 35);
        this.richTextBoxExecutablePath.TabIndex = 1;
        this.richTextBoxExecutablePath.Text = "";
        this.richTextBoxExecutablePath.WordWrap = false;
        this.richTextBoxExecutablePath.TextChanged += this.Gui_richTextBoxExecutablePath_TextChanged;
        // 
        // labelExecutablePath
        // 
        this.labelExecutablePath.AutoSize = true;
        this.labelExecutablePath.Location = new Point(0, 0);
        this.labelExecutablePath.Name = "labelExecutablePath";
        this.labelExecutablePath.Size = new Size(294, 20);
        this.labelExecutablePath.TabIndex = 3;
        this.labelExecutablePath.Text = "Select path to Infernal Machine executable:";
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
        // openFileDialogExecutablePath
        // 
        this.openFileDialogExecutablePath.Filter = "Executable files|*.exe|All files|*.*";
        // 
        // SettingsGui
        // 
        this.AcceptButton = this.buttonApply;
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.CancelButton = this.buttonCancel;
        this.ClientSize = new Size(682, 233);
        this.Controls.Add(this.panelContentWrapper);
        this.MaximizeBox = false;
        this.MaximumSize = new Size(9999, 960);
        this.MinimumSize = new Size(700, 280);
        this.Name = "SettingsGui";
        this.Text = "SettingsGui";
        this.Resize += this.Gui_window_Resize;
        this.panelContentWrapper.ResumeLayout(false);
        this.flowLayoutPanelCheckBoxes.ResumeLayout(false);
        this.flowLayoutPanelCheckBoxes.PerformLayout();
        this.flowLayoutPanelButtonPane.ResumeLayout(false);
        this.panelExecutablePath.ResumeLayout(false);
        this.panelExecutablePath.PerformLayout();
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
    private Panel panelExecutablePath;
    private Button buttonBrowseExecutablePath;
    private RichTextBox richTextBoxExecutablePath;
    private Label labelExecutablePath;
    private FlowLayoutPanel flowLayoutPanelButtonPane;
    private Button buttonApply;
    private Button buttonCancel;
    private FolderBrowserDialog folderBrowserDialogGamePath;
    private OpenFileDialog openFileDialogExecutablePath;
    private FlowLayoutPanel flowLayoutPanelCheckBoxes;
    private CheckBox checkBoxConvertCndToNdy;
}