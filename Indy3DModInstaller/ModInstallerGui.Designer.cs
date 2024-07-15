namespace Indy3DModInstaller;

partial class ModInstallerGui
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ModInstallerGui));
        this.tableLayoutPanel1 = new TableLayoutPanel();
        this.flowLayoutGamePath = new FlowLayoutPanel();
        this.richTextBoxGamePath = new RichTextBox();
        this.buttonBrowseGamePath = new Button();
        this.labelGamePath = new Label();
        this.labelModPath = new Label();
        this.flowLayoutModPath = new FlowLayoutPanel();
        this.richTextBoxModPath = new RichTextBox();
        this.buttonBrowseModPath = new Button();
        this.flowLayoutFeedbackArea = new FlowLayoutPanel();
        this.richTextFeedback = new RichTextBox();
        this.progressBar1 = new ProgressBar();
        this.flowLayoutButtonPane = new FlowLayoutPanel();
        this.buttonUnpack = new Button();
        this.buttonInstall = new Button();
        this.buttonSetDevMode = new Button();
        this.buttonUninstall = new Button();
        this.folderBrowserDialogGamePath = new FolderBrowserDialog();
        this.folderBrowserDialogModPath = new FolderBrowserDialog();
        this.tableLayoutPanel1.SuspendLayout();
        this.flowLayoutGamePath.SuspendLayout();
        this.flowLayoutModPath.SuspendLayout();
        this.flowLayoutFeedbackArea.SuspendLayout();
        this.flowLayoutButtonPane.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutGamePath, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.labelGamePath, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.labelModPath, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutModPath, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutFeedbackArea, 0, 4);
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutButtonPane, 0, 5);
        this.tableLayoutPanel1.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Location = new Point(0, 0);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 6;
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
        this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
        this.tableLayoutPanel1.Size = new Size(702, 673);
        this.tableLayoutPanel1.TabIndex = 0;
        // 
        // flowLayoutGamePath
        // 
        this.flowLayoutGamePath.Controls.Add(this.richTextBoxGamePath);
        this.flowLayoutGamePath.Controls.Add(this.buttonBrowseGamePath);
        this.flowLayoutGamePath.Dock = DockStyle.Fill;
        this.flowLayoutGamePath.Location = new Point(3, 36);
        this.flowLayoutGamePath.Name = "flowLayoutGamePath";
        this.flowLayoutGamePath.Size = new Size(696, 61);
        this.flowLayoutGamePath.TabIndex = 2;
        // 
        // richTextBoxGamePath
        // 
        this.richTextBoxGamePath.Location = new Point(3, 3);
        this.richTextBoxGamePath.Name = "richTextBoxGamePath";
        this.richTextBoxGamePath.Size = new Size(600, 35);
        this.richTextBoxGamePath.TabIndex = 1;
        this.richTextBoxGamePath.Text = "";
        this.richTextBoxGamePath.TextChanged += this.Gui_richTextBoxGamePath_TextChanged;
        // 
        // buttonBrowseGamePath
        // 
        this.buttonBrowseGamePath.Location = new Point(609, 3);
        this.buttonBrowseGamePath.Name = "buttonBrowseGamePath";
        this.buttonBrowseGamePath.Size = new Size(84, 35);
        this.buttonBrowseGamePath.TabIndex = 0;
        this.buttonBrowseGamePath.Text = "Browse...";
        this.buttonBrowseGamePath.UseVisualStyleBackColor = true;
        this.buttonBrowseGamePath.Click += this.Gui_buttonBrowseGamePath_Click;
        // 
        // labelGamePath
        // 
        this.labelGamePath.AutoSize = true;
        this.labelGamePath.Location = new Point(3, 3);
        this.labelGamePath.Margin = new Padding(3);
        this.labelGamePath.Name = "labelGamePath";
        this.labelGamePath.Size = new Size(452, 20);
        this.labelGamePath.TabIndex = 3;
        this.labelGamePath.Text = "Select path to Resource folder in your Infernal Machine installation:";
        // 
        // labelModPath
        // 
        this.labelModPath.AutoSize = true;
        this.labelModPath.Location = new Point(3, 100);
        this.labelModPath.Name = "labelModPath";
        this.labelModPath.Size = new Size(273, 20);
        this.labelModPath.TabIndex = 4;
        this.labelModPath.Text = "Select path to a mod you wish to install:";
        // 
        // flowLayoutModPath
        // 
        this.flowLayoutModPath.Controls.Add(this.richTextBoxModPath);
        this.flowLayoutModPath.Controls.Add(this.buttonBrowseModPath);
        this.flowLayoutModPath.Dock = DockStyle.Fill;
        this.flowLayoutModPath.Location = new Point(3, 136);
        this.flowLayoutModPath.Name = "flowLayoutModPath";
        this.flowLayoutModPath.Size = new Size(696, 61);
        this.flowLayoutModPath.TabIndex = 6;
        // 
        // richTextBoxModPath
        // 
        this.richTextBoxModPath.Location = new Point(3, 3);
        this.richTextBoxModPath.Name = "richTextBoxModPath";
        this.richTextBoxModPath.Size = new Size(600, 35);
        this.richTextBoxModPath.TabIndex = 5;
        this.richTextBoxModPath.Text = "";
        this.richTextBoxModPath.TextChanged += this.Gui_richTextBoxModPath_TextChanged;
        // 
        // buttonBrowseModPath
        // 
        this.buttonBrowseModPath.Location = new Point(609, 3);
        this.buttonBrowseModPath.Name = "buttonBrowseModPath";
        this.buttonBrowseModPath.Size = new Size(84, 35);
        this.buttonBrowseModPath.TabIndex = 6;
        this.buttonBrowseModPath.Text = "Browse...";
        this.buttonBrowseModPath.UseVisualStyleBackColor = true;
        this.buttonBrowseModPath.Click += this.Gui_buttonBrowseModPath_Click;
        // 
        // flowLayoutFeedbackArea
        // 
        this.flowLayoutFeedbackArea.Controls.Add(this.richTextFeedback);
        this.flowLayoutFeedbackArea.Controls.Add(this.progressBar1);
        this.flowLayoutFeedbackArea.Dock = DockStyle.Fill;
        this.flowLayoutFeedbackArea.FlowDirection = FlowDirection.TopDown;
        this.flowLayoutFeedbackArea.Location = new Point(3, 203);
        this.flowLayoutFeedbackArea.Name = "flowLayoutFeedbackArea";
        this.flowLayoutFeedbackArea.Size = new Size(696, 397);
        this.flowLayoutFeedbackArea.TabIndex = 8;
        // 
        // richTextFeedback
        // 
        this.richTextFeedback.Location = new Point(3, 3);
        this.richTextFeedback.Name = "richTextFeedback";
        this.richTextFeedback.Size = new Size(690, 355);
        this.richTextFeedback.TabIndex = 0;
        this.richTextFeedback.Text = "";
        // 
        // progressBar1
        // 
        this.progressBar1.Location = new Point(5, 364);
        this.progressBar1.Margin = new Padding(5, 3, 5, 3);
        this.progressBar1.Name = "progressBar1";
        this.progressBar1.Size = new Size(686, 28);
        this.progressBar1.Style = ProgressBarStyle.Marquee;
        this.progressBar1.TabIndex = 1;
        // 
        // flowLayoutButtonPane
        // 
        this.flowLayoutButtonPane.Controls.Add(this.buttonUnpack);
        this.flowLayoutButtonPane.Controls.Add(this.buttonInstall);
        this.flowLayoutButtonPane.Controls.Add(this.buttonSetDevMode);
        this.flowLayoutButtonPane.Controls.Add(this.buttonUninstall);
        this.flowLayoutButtonPane.Dock = DockStyle.Fill;
        this.flowLayoutButtonPane.Location = new Point(3, 606);
        this.flowLayoutButtonPane.Name = "flowLayoutButtonPane";
        this.flowLayoutButtonPane.Padding = new Padding(80, 0, 0, 0);
        this.flowLayoutButtonPane.Size = new Size(696, 64);
        this.flowLayoutButtonPane.TabIndex = 7;
        // 
        // buttonUnpack
        // 
        this.buttonUnpack.AutoSize = true;
        this.buttonUnpack.Location = new Point(83, 3);
        this.buttonUnpack.Name = "buttonUnpack";
        this.buttonUnpack.Size = new Size(152, 30);
        this.buttonUnpack.TabIndex = 0;
        this.buttonUnpack.Text = "Unpack Game Files";
        this.buttonUnpack.UseVisualStyleBackColor = true;
        this.buttonUnpack.Click += this.Gui_buttonUnpack_Click;
        // 
        // buttonInstall
        // 
        this.buttonInstall.AutoSize = true;
        this.buttonInstall.Location = new Point(241, 3);
        this.buttonInstall.Name = "buttonInstall";
        this.buttonInstall.Size = new Size(94, 30);
        this.buttonInstall.TabIndex = 1;
        this.buttonInstall.Text = "Install Mod";
        this.buttonInstall.UseVisualStyleBackColor = true;
        this.buttonInstall.Click += this.Gui_buttonInstall_Click;
        // 
        // buttonSetDevMode
        // 
        this.buttonSetDevMode.AutoSize = true;
        this.buttonSetDevMode.Location = new Point(341, 3);
        this.buttonSetDevMode.Name = "buttonSetDevMode";
        this.buttonSetDevMode.Size = new Size(138, 30);
        this.buttonSetDevMode.TabIndex = 2;
        this.buttonSetDevMode.Text = "Toggle Dev Mode";
        this.buttonSetDevMode.UseVisualStyleBackColor = true;
        this.buttonSetDevMode.Click += this.Gui_buttonSetDevMode_Click;
        // 
        // buttonUninstall
        // 
        this.buttonUninstall.AutoSize = true;
        this.buttonUninstall.Location = new Point(485, 3);
        this.buttonUninstall.Name = "buttonUninstall";
        this.buttonUninstall.Size = new Size(139, 30);
        this.buttonUninstall.TabIndex = 3;
        this.buttonUninstall.Text = "Uninstall All Mods";
        this.buttonUninstall.UseVisualStyleBackColor = true;
        this.buttonUninstall.Click += this.Gui_buttonUninstall_Click;
        // 
        // folderBrowserDialogGamePath
        // 
        this.folderBrowserDialogGamePath.ShowNewFolderButton = false;
        // 
        // ModInstallerGui
        // 
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(702, 673);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Icon = (Icon) resources.GetObject("$this.Icon");
        this.Name = "ModInstallerGui";
        this.Text = "Indy3D Mod Installer GUI";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.flowLayoutGamePath.ResumeLayout(false);
        this.flowLayoutModPath.ResumeLayout(false);
        this.flowLayoutFeedbackArea.ResumeLayout(false);
        this.flowLayoutButtonPane.ResumeLayout(false);
        this.flowLayoutButtonPane.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private FolderBrowserDialog folderBrowserDialogGamePath;
    private FlowLayoutPanel flowLayoutGamePath;
    private RichTextBox richTextBoxGamePath;
    private Button buttonBrowseGamePath;
    private Label labelGamePath;
    private Label labelModPath;
    private FlowLayoutPanel flowLayoutModPath;
    private RichTextBox richTextBoxModPath;
    private Button buttonBrowseModPath;
    private FlowLayoutPanel flowLayoutButtonPane;
    private FlowLayoutPanel flowLayoutFeedbackArea;
    private RichTextBox richTextFeedback;
    private ProgressBar progressBar1;
    private Button buttonUnpack;
    private Button buttonInstall;
    private Button buttonSetDevMode;
    private Button buttonUninstall;
    private FolderBrowserDialog folderBrowserDialogModPath;
}