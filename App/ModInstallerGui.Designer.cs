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
        labelModPath = new Label();
        richTextBoxModPath = new RichTextBox();
        buttonBrowseModPath = new Button();
        labelFeedback = new Label();
        richTextFeedback = new RichTextBox();
        progressBarFeedback = new ProgressBar();
        buttonUnpack = new Button();
        buttonInstall = new Button();
        buttonSetDevMode = new Button();
        buttonUninstall = new Button();
        buttonPlay = new Button();
        folderBrowserDialogModPath = new FolderBrowserDialog();
        panelModPath = new Panel();
        panelFeedback = new Panel();
        splitPanelButtonPane = new SplitContainer();
        buttonSettings = new Button();
        panelContentWrapper = new Panel();
        panelModPath.SuspendLayout();
        panelFeedback.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize) splitPanelButtonPane).BeginInit();
        splitPanelButtonPane.Panel1.SuspendLayout();
        splitPanelButtonPane.Panel2.SuspendLayout();
        splitPanelButtonPane.SuspendLayout();
        panelContentWrapper.SuspendLayout();
        SuspendLayout();
        // 
        // labelModPath
        // 
        labelModPath.AutoSize = true;
        labelModPath.Location = new Point(0, 0);
        labelModPath.Name = "labelModPath";
        labelModPath.Size = new Size(217, 15);
        labelModPath.TabIndex = 4;
        labelModPath.Text = "Select path to a mod you wish to install:";
        // 
        // richTextBoxModPath
        // 
        richTextBoxModPath.Location = new Point(3, 17);
        richTextBoxModPath.Margin = new Padding(3, 2, 3, 2);
        richTextBoxModPath.Name = "richTextBoxModPath";
        richTextBoxModPath.ScrollBars = RichTextBoxScrollBars.None;
        richTextBoxModPath.Size = new Size(517, 27);
        richTextBoxModPath.TabIndex = 5;
        richTextBoxModPath.Text = "";
        richTextBoxModPath.WordWrap = false;
        richTextBoxModPath.TextChanged += Gui_richTextBoxModPath_TextChanged;
        // 
        // buttonBrowseModPath
        // 
        buttonBrowseModPath.AutoSize = true;
        buttonBrowseModPath.Location = new Point(524, 17);
        buttonBrowseModPath.Margin = new Padding(3, 2, 3, 2);
        buttonBrowseModPath.Name = "buttonBrowseModPath";
        buttonBrowseModPath.Size = new Size(74, 26);
        buttonBrowseModPath.TabIndex = 6;
        buttonBrowseModPath.Text = "Browse...";
        buttonBrowseModPath.UseVisualStyleBackColor = true;
        buttonBrowseModPath.Click += Gui_buttonBrowseModPath_Click;
        // 
        // labelFeedback
        // 
        labelFeedback.AutoSize = true;
        labelFeedback.Location = new Point(0, 0);
        labelFeedback.Name = "labelFeedback";
        labelFeedback.Size = new Size(375, 15);
        labelFeedback.TabIndex = 2;
        labelFeedback.Text = "Log box: (When reporting issues, post the ENTIRE content of this box!)";
        // 
        // richTextFeedback
        // 
        richTextFeedback.Location = new Point(3, 17);
        richTextFeedback.Margin = new Padding(3, 2, 3, 2);
        richTextFeedback.Name = "richTextFeedback";
        richTextFeedback.ReadOnly = true;
        richTextFeedback.Size = new Size(596, 146);
        richTextFeedback.TabIndex = 0;
        richTextFeedback.Text = "";
        // 
        // progressBarFeedback
        // 
        progressBarFeedback.Location = new Point(3, 167);
        progressBarFeedback.Margin = new Padding(4, 2, 4, 2);
        progressBarFeedback.Name = "progressBarFeedback";
        progressBarFeedback.Size = new Size(595, 22);
        progressBarFeedback.Style = ProgressBarStyle.Marquee;
        progressBarFeedback.TabIndex = 1;
        // 
        // buttonUnpack
        // 
        buttonUnpack.AutoSize = true;
        buttonUnpack.Location = new Point(106, 10);
        buttonUnpack.Margin = new Padding(3, 2, 3, 2);
        buttonUnpack.Name = "buttonUnpack";
        buttonUnpack.Size = new Size(133, 25);
        buttonUnpack.TabIndex = 0;
        buttonUnpack.Text = "Unpack Game Files";
        buttonUnpack.UseVisualStyleBackColor = true;
        buttonUnpack.Click += Gui_buttonUnpack_Click;
        // 
        // buttonInstall
        // 
        buttonInstall.AutoSize = true;
        buttonInstall.Location = new Point(106, 38);
        buttonInstall.Margin = new Padding(3, 2, 3, 2);
        buttonInstall.Name = "buttonInstall";
        buttonInstall.Size = new Size(133, 25);
        buttonInstall.TabIndex = 1;
        buttonInstall.Text = "Install Mod";
        buttonInstall.UseVisualStyleBackColor = true;
        buttonInstall.Click += Gui_buttonInstall_Click;
        // 
        // buttonSetDevMode
        // 
        buttonSetDevMode.AutoSize = true;
        buttonSetDevMode.Location = new Point(100, 38);
        buttonSetDevMode.Margin = new Padding(3, 2, 3, 2);
        buttonSetDevMode.Name = "buttonSetDevMode";
        buttonSetDevMode.Size = new Size(133, 25);
        buttonSetDevMode.TabIndex = 2;
        buttonSetDevMode.Text = "Toggle Dev Mode";
        buttonSetDevMode.UseVisualStyleBackColor = true;
        buttonSetDevMode.Click += Gui_buttonSetDevMode_Click;
        // 
        // buttonUninstall
        // 
        buttonUninstall.AutoSize = true;
        buttonUninstall.Location = new Point(106, 64);
        buttonUninstall.Margin = new Padding(3, 2, 3, 2);
        buttonUninstall.Name = "buttonUninstall";
        buttonUninstall.Size = new Size(133, 25);
        buttonUninstall.TabIndex = 3;
        buttonUninstall.Text = "Uninstall All Mods";
        buttonUninstall.UseVisualStyleBackColor = true;
        buttonUninstall.Click += Gui_buttonUninstall_Click;
        // 
        // buttonPlay
        // 
        buttonPlay.AutoSize = true;
        buttonPlay.Location = new Point(100, 64);
        buttonPlay.Margin = new Padding(3, 2, 3, 2);
        buttonPlay.Name = "buttonPlay";
        buttonPlay.Size = new Size(133, 25);
        buttonPlay.TabIndex = 4;
        buttonPlay.Text = "Launch Game";
        buttonPlay.UseVisualStyleBackColor = true;
        buttonPlay.Click += Gui_buttonPlay_Click;
        // 
        // panelModPath
        // 
        panelModPath.Controls.Add(buttonBrowseModPath);
        panelModPath.Controls.Add(richTextBoxModPath);
        panelModPath.Controls.Add(labelModPath);
        panelModPath.Location = new Point(3, 2);
        panelModPath.Margin = new Padding(3, 2, 3, 2);
        panelModPath.Name = "panelModPath";
        panelModPath.Size = new Size(630, 50);
        panelModPath.TabIndex = 2;
        // 
        // panelFeedback
        // 
        panelFeedback.Controls.Add(progressBarFeedback);
        panelFeedback.Controls.Add(richTextFeedback);
        panelFeedback.Controls.Add(labelFeedback);
        panelFeedback.Location = new Point(3, 56);
        panelFeedback.Margin = new Padding(3, 2, 3, 2);
        panelFeedback.Name = "panelFeedback";
        panelFeedback.Size = new Size(630, 194);
        panelFeedback.TabIndex = 3;
        // 
        // splitPanelButtonPane
        // 
        splitPanelButtonPane.IsSplitterFixed = true;
        splitPanelButtonPane.Location = new Point(3, 254);
        splitPanelButtonPane.Margin = new Padding(3, 2, 3, 2);
        splitPanelButtonPane.Name = "splitPanelButtonPane";
        // 
        // splitPanelButtonPane.Panel1
        // 
        splitPanelButtonPane.Panel1.Controls.Add(buttonInstall);
        splitPanelButtonPane.Panel1.Controls.Add(buttonUninstall);
        splitPanelButtonPane.Panel1.Controls.Add(buttonUnpack);
        // 
        // splitPanelButtonPane.Panel2
        // 
        splitPanelButtonPane.Panel2.Controls.Add(buttonSettings);
        splitPanelButtonPane.Panel2.Controls.Add(buttonPlay);
        splitPanelButtonPane.Panel2.Controls.Add(buttonSetDevMode);
        splitPanelButtonPane.Size = new Size(630, 94);
        splitPanelButtonPane.SplitterDistance = 313;
        splitPanelButtonPane.TabIndex = 4;
        // 
        // buttonSettings
        // 
        buttonSettings.AutoSize = true;
        buttonSettings.Location = new Point(100, 10);
        buttonSettings.Margin = new Padding(3, 2, 3, 2);
        buttonSettings.Name = "buttonSettings";
        buttonSettings.Size = new Size(133, 25);
        buttonSettings.TabIndex = 5;
        buttonSettings.Text = "Settings...";
        buttonSettings.UseVisualStyleBackColor = true;
        buttonSettings.Click += Gui_buttonSettings_Click;
        // 
        // panelContentWrapper
        // 
        panelContentWrapper.Controls.Add(splitPanelButtonPane);
        panelContentWrapper.Controls.Add(panelModPath);
        panelContentWrapper.Controls.Add(panelFeedback);
        panelContentWrapper.Dock = DockStyle.Fill;
        panelContentWrapper.Location = new Point(0, 0);
        panelContentWrapper.Margin = new Padding(3, 2, 3, 2);
        panelContentWrapper.Name = "panelContentWrapper";
        panelContentWrapper.Size = new Size(614, 565);
        panelContentWrapper.TabIndex = 5;
        // 
        // ModInstallerGui
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(614, 565);
        Controls.Add(panelContentWrapper);
        Icon = (Icon) resources.GetObject("$this.Icon");
        Margin = new Padding(3, 2, 3, 2);
        MinimumSize = new Size(614, 460);
        Name = "ModInstallerGui";
        Text = "Indy3D Mod Installer";
        FormClosing += Gui_window_FormClosing;
        Shown += Gui_window_Shown;
        Resize += Gui_window_Resize;
        panelModPath.ResumeLayout(false);
        panelModPath.PerformLayout();
        panelFeedback.ResumeLayout(false);
        panelFeedback.PerformLayout();
        splitPanelButtonPane.Panel1.ResumeLayout(false);
        splitPanelButtonPane.Panel1.PerformLayout();
        splitPanelButtonPane.Panel2.ResumeLayout(false);
        splitPanelButtonPane.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize) splitPanelButtonPane).EndInit();
        splitPanelButtonPane.ResumeLayout(false);
        panelContentWrapper.ResumeLayout(false);
        ResumeLayout(false);
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