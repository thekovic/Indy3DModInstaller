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
        this.labelModPath = new Label();
        this.richTextBoxModPath = new RichTextBox();
        this.buttonBrowseModPath = new Button();
        this.labelFeedback = new Label();
        this.richTextFeedback = new RichTextBox();
        this.progressBarFeedback = new ProgressBar();
        this.buttonUnpack = new Button();
        this.buttonInstall = new Button();
        this.buttonSetDevMode = new Button();
        this.buttonUninstall = new Button();
        this.buttonPlay = new Button();
        this.folderBrowserDialogModPath = new FolderBrowserDialog();
        this.panelModPath = new Panel();
        this.panelFeedback = new Panel();
        this.splitPanelButtonPane = new SplitContainer();
        this.buttonSettings = new Button();
        this.panelContentWrapper = new Panel();
        this.panelModPath.SuspendLayout();
        this.panelFeedback.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) this.splitPanelButtonPane).BeginInit();
        this.splitPanelButtonPane.Panel1.SuspendLayout();
        this.splitPanelButtonPane.Panel2.SuspendLayout();
        this.splitPanelButtonPane.SuspendLayout();
        this.panelContentWrapper.SuspendLayout();
        this.SuspendLayout();
        // 
        // labelModPath
        // 
        this.labelModPath.AutoSize = true;
        this.labelModPath.Location = new Point(0, 0);
        this.labelModPath.Name = "labelModPath";
        this.labelModPath.Size = new Size(273, 20);
        this.labelModPath.TabIndex = 4;
        this.labelModPath.Text = "Select path to a mod you wish to install:";
        // 
        // richTextBoxModPath
        // 
        this.richTextBoxModPath.Location = new Point(3, 23);
        this.richTextBoxModPath.Name = "richTextBoxModPath";
        this.richTextBoxModPath.ScrollBars = RichTextBoxScrollBars.None;
        this.richTextBoxModPath.Size = new Size(590, 35);
        this.richTextBoxModPath.TabIndex = 5;
        this.richTextBoxModPath.Text = "";
        this.richTextBoxModPath.WordWrap = false;
        this.richTextBoxModPath.TextChanged += this.Gui_richTextBoxModPath_TextChanged;
        // 
        // buttonBrowseModPath
        // 
        this.buttonBrowseModPath.AutoSize = true;
        this.buttonBrowseModPath.Location = new Point(599, 23);
        this.buttonBrowseModPath.Name = "buttonBrowseModPath";
        this.buttonBrowseModPath.Size = new Size(84, 35);
        this.buttonBrowseModPath.TabIndex = 6;
        this.buttonBrowseModPath.Text = "Browse...";
        this.buttonBrowseModPath.UseVisualStyleBackColor = true;
        this.buttonBrowseModPath.Click += this.Gui_buttonBrowseModPath_Click;
        // 
        // labelFeedback
        // 
        this.labelFeedback.AutoSize = true;
        this.labelFeedback.Location = new Point(0, 0);
        this.labelFeedback.Name = "labelFeedback";
        this.labelFeedback.Size = new Size(471, 20);
        this.labelFeedback.TabIndex = 2;
        this.labelFeedback.Text = "Log box: (When reporting issues, post the ENTIRE content of this box!)";
        // 
        // richTextFeedback
        // 
        this.richTextFeedback.Location = new Point(3, 23);
        this.richTextFeedback.Name = "richTextFeedback";
        this.richTextFeedback.ReadOnly = true;
        this.richTextFeedback.Size = new Size(680, 194);
        this.richTextFeedback.TabIndex = 0;
        this.richTextFeedback.Text = "";
        // 
        // progressBarFeedback
        // 
        this.progressBarFeedback.Location = new Point(3, 223);
        this.progressBarFeedback.Margin = new Padding(5, 3, 5, 3);
        this.progressBarFeedback.Name = "progressBarFeedback";
        this.progressBarFeedback.Size = new Size(680, 28);
        this.progressBarFeedback.Style = ProgressBarStyle.Marquee;
        this.progressBarFeedback.TabIndex = 1;
        // 
        // buttonUnpack
        // 
        this.buttonUnpack.AutoSize = true;
        this.buttonUnpack.Location = new Point(121, 14);
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
        this.buttonInstall.Location = new Point(121, 50);
        this.buttonInstall.Name = "buttonInstall";
        this.buttonInstall.Size = new Size(152, 30);
        this.buttonInstall.TabIndex = 1;
        this.buttonInstall.Text = "Install Mod";
        this.buttonInstall.UseVisualStyleBackColor = true;
        this.buttonInstall.Click += this.Gui_buttonInstall_Click;
        // 
        // buttonSetDevMode
        // 
        this.buttonSetDevMode.AutoSize = true;
        this.buttonSetDevMode.Location = new Point(114, 50);
        this.buttonSetDevMode.Name = "buttonSetDevMode";
        this.buttonSetDevMode.Size = new Size(152, 30);
        this.buttonSetDevMode.TabIndex = 2;
        this.buttonSetDevMode.Text = "Toggle Dev Mode";
        this.buttonSetDevMode.UseVisualStyleBackColor = true;
        this.buttonSetDevMode.Click += this.Gui_buttonSetDevMode_Click;
        // 
        // buttonUninstall
        // 
        this.buttonUninstall.AutoSize = true;
        this.buttonUninstall.Location = new Point(121, 86);
        this.buttonUninstall.Name = "buttonUninstall";
        this.buttonUninstall.Size = new Size(152, 30);
        this.buttonUninstall.TabIndex = 3;
        this.buttonUninstall.Text = "Uninstall All Mods";
        this.buttonUninstall.UseVisualStyleBackColor = true;
        this.buttonUninstall.Click += this.Gui_buttonUninstall_Click;
        // 
        // buttonPlay
        // 
        this.buttonPlay.AutoSize = true;
        this.buttonPlay.Location = new Point(114, 86);
        this.buttonPlay.Name = "buttonPlay";
        this.buttonPlay.Size = new Size(152, 30);
        this.buttonPlay.TabIndex = 4;
        this.buttonPlay.Text = "Launch Game";
        this.buttonPlay.UseVisualStyleBackColor = true;
        this.buttonPlay.Click += this.Gui_buttonPlay_Click;
        // 
        // panelModPath
        // 
        this.panelModPath.Controls.Add(this.buttonBrowseModPath);
        this.panelModPath.Controls.Add(this.richTextBoxModPath);
        this.panelModPath.Controls.Add(this.labelModPath);
        this.panelModPath.Location = new Point(3, 3);
        this.panelModPath.Name = "panelModPath";
        this.panelModPath.Size = new Size(720, 66);
        this.panelModPath.TabIndex = 2;
        // 
        // panelFeedback
        // 
        this.panelFeedback.Controls.Add(this.progressBarFeedback);
        this.panelFeedback.Controls.Add(this.richTextFeedback);
        this.panelFeedback.Controls.Add(this.labelFeedback);
        this.panelFeedback.Location = new Point(3, 75);
        this.panelFeedback.Name = "panelFeedback";
        this.panelFeedback.Size = new Size(720, 258);
        this.panelFeedback.TabIndex = 3;
        // 
        // splitPanelButtonPane
        // 
        this.splitPanelButtonPane.Location = new Point(3, 339);
        this.splitPanelButtonPane.Name = "splitPanelButtonPane";
        // 
        // splitPanelButtonPane.Panel1
        // 
        this.splitPanelButtonPane.Panel1.Controls.Add(this.buttonInstall);
        this.splitPanelButtonPane.Panel1.Controls.Add(this.buttonUninstall);
        this.splitPanelButtonPane.Panel1.Controls.Add(this.buttonUnpack);
        // 
        // splitPanelButtonPane.Panel2
        // 
        this.splitPanelButtonPane.Panel2.Controls.Add(this.buttonSettings);
        this.splitPanelButtonPane.Panel2.Controls.Add(this.buttonPlay);
        this.splitPanelButtonPane.Panel2.Controls.Add(this.buttonSetDevMode);
        this.splitPanelButtonPane.Size = new Size(720, 125);
        this.splitPanelButtonPane.SplitterDistance = 358;
        this.splitPanelButtonPane.TabIndex = 4;
        // 
        // buttonSettings
        // 
        this.buttonSettings.Location = new Point(114, 14);
        this.buttonSettings.Name = "buttonSettings";
        this.buttonSettings.Size = new Size(152, 28);
        this.buttonSettings.TabIndex = 5;
        this.buttonSettings.Text = "Settings...";
        this.buttonSettings.UseVisualStyleBackColor = true;
        this.buttonSettings.Click += this.Gui_buttonSettings_Click;
        // 
        // panelContentWrapper
        // 
        this.panelContentWrapper.Controls.Add(this.splitPanelButtonPane);
        this.panelContentWrapper.Controls.Add(this.panelModPath);
        this.panelContentWrapper.Controls.Add(this.panelFeedback);
        this.panelContentWrapper.Dock = DockStyle.Fill;
        this.panelContentWrapper.Location = new Point(0, 0);
        this.panelContentWrapper.Name = "panelContentWrapper";
        this.panelContentWrapper.Size = new Size(702, 753);
        this.panelContentWrapper.TabIndex = 5;
        // 
        // ModInstallerGui
        // 
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(702, 753);
        this.Controls.Add(this.panelContentWrapper);
        this.Icon = (Icon) resources.GetObject("$this.Icon");
        this.MinimumSize = new Size(700, 600);
        this.Name = "ModInstallerGui";
        this.Text = "Indy3D Mod Installer GUI";
        this.FormClosing += this.Gui_window_FormClosing;
        this.Resize += this.Gui_window_Resize;
        this.panelModPath.ResumeLayout(false);
        this.panelModPath.PerformLayout();
        this.panelFeedback.ResumeLayout(false);
        this.panelFeedback.PerformLayout();
        this.splitPanelButtonPane.Panel1.ResumeLayout(false);
        this.splitPanelButtonPane.Panel1.PerformLayout();
        this.splitPanelButtonPane.Panel2.ResumeLayout(false);
        this.splitPanelButtonPane.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize) this.splitPanelButtonPane).EndInit();
        this.splitPanelButtonPane.ResumeLayout(false);
        this.panelContentWrapper.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion
    private Label labelModPath;
    private RichTextBox richTextBoxModPath;
    private Button buttonBrowseModPath;
    private RichTextBox richTextFeedback;
    private ProgressBar progressBarFeedback;
    private Button buttonUnpack;
    private Button buttonInstall;
    private Button buttonSetDevMode;
    private Button buttonUninstall;
    private FolderBrowserDialog folderBrowserDialogModPath;
    private Button buttonPlay;
    private Label labelFeedback;
    private Panel panelModPath;
    private Panel panelFeedback;
    private SplitContainer splitPanelButtonPane;
    private Button buttonSettings;
    private Panel panelContentWrapper;
}