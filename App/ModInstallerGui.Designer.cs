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
        labelModPath.Size = new Size(273, 20);
        labelModPath.TabIndex = 4;
        labelModPath.Text = "Select path to a mod you wish to install:";
        // 
        // richTextBoxModPath
        // 
        richTextBoxModPath.Location = new Point(3, 23);
        richTextBoxModPath.Name = "richTextBoxModPath";
        richTextBoxModPath.ScrollBars = RichTextBoxScrollBars.None;
        richTextBoxModPath.Size = new Size(590, 35);
        richTextBoxModPath.TabIndex = 5;
        richTextBoxModPath.Text = "";
        richTextBoxModPath.WordWrap = false;
        richTextBoxModPath.TextChanged += Gui_richTextBoxModPath_TextChanged;
        // 
        // buttonBrowseModPath
        // 
        buttonBrowseModPath.AutoSize = true;
        buttonBrowseModPath.Location = new Point(599, 23);
        buttonBrowseModPath.Name = "buttonBrowseModPath";
        buttonBrowseModPath.Size = new Size(84, 35);
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
        labelFeedback.Size = new Size(471, 20);
        labelFeedback.TabIndex = 2;
        labelFeedback.Text = "Log box: (When reporting issues, post the ENTIRE content of this box!)";
        // 
        // richTextFeedback
        // 
        richTextFeedback.Location = new Point(3, 23);
        richTextFeedback.Name = "richTextFeedback";
        richTextFeedback.ReadOnly = true;
        richTextFeedback.Size = new Size(680, 194);
        richTextFeedback.TabIndex = 0;
        richTextFeedback.Text = "";
        // 
        // progressBarFeedback
        // 
        progressBarFeedback.Location = new Point(3, 223);
        progressBarFeedback.Margin = new Padding(5, 3, 5, 3);
        progressBarFeedback.Name = "progressBarFeedback";
        progressBarFeedback.Size = new Size(680, 29);
        progressBarFeedback.Style = ProgressBarStyle.Marquee;
        progressBarFeedback.TabIndex = 1;
        // 
        // buttonUnpack
        // 
        buttonUnpack.AutoSize = true;
        buttonUnpack.Location = new Point(121, 14);
        buttonUnpack.Name = "buttonUnpack";
        buttonUnpack.Size = new Size(152, 30);
        buttonUnpack.TabIndex = 0;
        buttonUnpack.Text = "Unpack Game Files";
        buttonUnpack.UseVisualStyleBackColor = true;
        buttonUnpack.Click += Gui_buttonUnpack_Click;
        // 
        // buttonInstall
        // 
        buttonInstall.AutoSize = true;
        buttonInstall.Location = new Point(121, 50);
        buttonInstall.Name = "buttonInstall";
        buttonInstall.Size = new Size(152, 30);
        buttonInstall.TabIndex = 1;
        buttonInstall.Text = "Install Mod";
        buttonInstall.UseVisualStyleBackColor = true;
        buttonInstall.Click += Gui_buttonInstall_Click;
        // 
        // buttonSetDevMode
        // 
        buttonSetDevMode.AutoSize = true;
        buttonSetDevMode.Location = new Point(114, 50);
        buttonSetDevMode.Name = "buttonSetDevMode";
        buttonSetDevMode.Size = new Size(152, 30);
        buttonSetDevMode.TabIndex = 2;
        buttonSetDevMode.Text = "Toggle Dev Mode";
        buttonSetDevMode.UseVisualStyleBackColor = true;
        buttonSetDevMode.Click += Gui_buttonSetDevMode_Click;
        // 
        // buttonUninstall
        // 
        buttonUninstall.AutoSize = true;
        buttonUninstall.Location = new Point(121, 86);
        buttonUninstall.Name = "buttonUninstall";
        buttonUninstall.Size = new Size(152, 30);
        buttonUninstall.TabIndex = 3;
        buttonUninstall.Text = "Uninstall All Mods";
        buttonUninstall.UseVisualStyleBackColor = true;
        buttonUninstall.Click += Gui_buttonUninstall_Click;
        // 
        // buttonPlay
        // 
        buttonPlay.AutoSize = true;
        buttonPlay.Location = new Point(114, 86);
        buttonPlay.Name = "buttonPlay";
        buttonPlay.Size = new Size(152, 30);
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
        panelModPath.Location = new Point(3, 3);
        panelModPath.Name = "panelModPath";
        panelModPath.Size = new Size(720, 66);
        panelModPath.TabIndex = 2;
        // 
        // panelFeedback
        // 
        panelFeedback.Controls.Add(progressBarFeedback);
        panelFeedback.Controls.Add(richTextFeedback);
        panelFeedback.Controls.Add(labelFeedback);
        panelFeedback.Location = new Point(3, 75);
        panelFeedback.Name = "panelFeedback";
        panelFeedback.Size = new Size(720, 258);
        panelFeedback.TabIndex = 3;
        // 
        // splitPanelButtonPane
        // 
        splitPanelButtonPane.Location = new Point(3, 339);
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
        splitPanelButtonPane.Size = new Size(720, 125);
        splitPanelButtonPane.SplitterDistance = 358;
        splitPanelButtonPane.TabIndex = 4;
        // 
        // buttonSettings
        // 
        buttonSettings.AutoSize = true;
        buttonSettings.Location = new Point(114, 14);
        buttonSettings.Name = "buttonSettings";
        buttonSettings.Size = new Size(152, 30);
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
        panelContentWrapper.Name = "panelContentWrapper";
        panelContentWrapper.Size = new Size(702, 753);
        panelContentWrapper.TabIndex = 5;
        // 
        // ModInstallerGui
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(702, 753);
        Controls.Add(panelContentWrapper);
        Icon = (Icon) resources.GetObject("$this.Icon");
        MinimumSize = new Size(700, 600);
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