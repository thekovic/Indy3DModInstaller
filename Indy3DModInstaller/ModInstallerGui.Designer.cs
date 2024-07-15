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
        this.tableLayoutPanel1 = new TableLayoutPanel();
        this.flowLayoutPanel1 = new FlowLayoutPanel();
        this.richTextBoxGamePath = new RichTextBox();
        this.buttonBrowseGamePath = new Button();
        this.labelGamePath = new Label();
        this.labelModPath = new Label();
        this.flowLayoutPanel2 = new FlowLayoutPanel();
        this.richTextBoxModPath = new RichTextBox();
        this.buttonBrowseModPath = new Button();
        this.flowLayoutPanel3 = new FlowLayoutPanel();
        this.folderBrowserDialog1 = new FolderBrowserDialog();
        this.tableLayoutPanel1.SuspendLayout();
        this.flowLayoutPanel1.SuspendLayout();
        this.flowLayoutPanel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
        this.tableLayoutPanel1.Controls.Add(this.labelGamePath, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.labelModPath, 0, 2);
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 3);
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 5);
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
        // flowLayoutPanel1
        // 
        this.flowLayoutPanel1.Controls.Add(this.richTextBoxGamePath);
        this.flowLayoutPanel1.Controls.Add(this.buttonBrowseGamePath);
        this.flowLayoutPanel1.Dock = DockStyle.Fill;
        this.flowLayoutPanel1.Location = new Point(3, 36);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new Size(696, 61);
        this.flowLayoutPanel1.TabIndex = 2;
        // 
        // richTextBoxGamePath
        // 
        this.richTextBoxGamePath.Location = new Point(3, 3);
        this.richTextBoxGamePath.Name = "richTextBoxGamePath";
        this.richTextBoxGamePath.Size = new Size(600, 35);
        this.richTextBoxGamePath.TabIndex = 1;
        this.richTextBoxGamePath.Text = "";
        // 
        // buttonBrowseGamePath
        // 
        this.buttonBrowseGamePath.Location = new Point(609, 3);
        this.buttonBrowseGamePath.Name = "buttonBrowseGamePath";
        this.buttonBrowseGamePath.Size = new Size(84, 35);
        this.buttonBrowseGamePath.TabIndex = 0;
        this.buttonBrowseGamePath.Text = "Browse...";
        this.buttonBrowseGamePath.UseVisualStyleBackColor = true;
        // 
        // labelGamePath
        // 
        this.labelGamePath.AutoSize = true;
        this.labelGamePath.Location = new Point(3, 3);
        this.labelGamePath.Margin = new Padding(3);
        this.labelGamePath.Name = "labelGamePath";
        this.labelGamePath.Size = new Size(328, 20);
        this.labelGamePath.TabIndex = 3;
        this.labelGamePath.Text = "Select path to your Infernal Machine installation:";
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
        // flowLayoutPanel2
        // 
        this.flowLayoutPanel2.Controls.Add(this.richTextBoxModPath);
        this.flowLayoutPanel2.Controls.Add(this.buttonBrowseModPath);
        this.flowLayoutPanel2.Dock = DockStyle.Fill;
        this.flowLayoutPanel2.Location = new Point(3, 136);
        this.flowLayoutPanel2.Name = "flowLayoutPanel2";
        this.flowLayoutPanel2.Size = new Size(696, 61);
        this.flowLayoutPanel2.TabIndex = 6;
        // 
        // richTextBoxModPath
        // 
        this.richTextBoxModPath.Location = new Point(3, 3);
        this.richTextBoxModPath.Name = "richTextBoxModPath";
        this.richTextBoxModPath.Size = new Size(600, 35);
        this.richTextBoxModPath.TabIndex = 5;
        this.richTextBoxModPath.Text = "";
        // 
        // buttonBrowseModPath
        // 
        this.buttonBrowseModPath.Location = new Point(609, 3);
        this.buttonBrowseModPath.Name = "buttonBrowseModPath";
        this.buttonBrowseModPath.Size = new Size(84, 35);
        this.buttonBrowseModPath.TabIndex = 6;
        this.buttonBrowseModPath.Text = "Browse...";
        this.buttonBrowseModPath.UseVisualStyleBackColor = true;
        // 
        // flowLayoutPanel3
        // 
        this.flowLayoutPanel3.Dock = DockStyle.Fill;
        this.flowLayoutPanel3.Location = new Point(3, 606);
        this.flowLayoutPanel3.Name = "flowLayoutPanel3";
        this.flowLayoutPanel3.Size = new Size(696, 64);
        this.flowLayoutPanel3.TabIndex = 7;
        // 
        // folderBrowserDialog1
        // 
        this.folderBrowserDialog1.ShowNewFolderButton = false;
        // 
        // ModInstallerGui
        // 
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(702, 673);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "ModInstallerGui";
        this.Text = "Indy3D Mod Installer GUI";
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.flowLayoutPanel1.ResumeLayout(false);
        this.flowLayoutPanel2.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private FolderBrowserDialog folderBrowserDialog1;
    private FlowLayoutPanel flowLayoutPanel1;
    private RichTextBox richTextBoxGamePath;
    private Button buttonBrowseGamePath;
    private Label labelGamePath;
    private Label labelModPath;
    private FlowLayoutPanel flowLayoutPanel2;
    private RichTextBox richTextBoxModPath;
    private Button buttonBrowseModPath;
    private FlowLayoutPanel flowLayoutPanel3;
}