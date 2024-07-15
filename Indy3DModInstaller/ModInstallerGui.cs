using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indy3DModInstaller;

public partial class ModInstallerGui : Form
{
    public ModInstallerGui()
    {
        this.InitializeComponent();
        string? installPath = Indy3DModInstaller.GetInstallPathFromRegistry();
        if (installPath != null)
        {
            richTextBoxGamePath.Text = Path.Combine(installPath, "Resource");
        }
    }

    private void buttonBrowseGamePath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogGamePath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxGamePath.Text = folderBrowserDialogGamePath.SelectedPath;
        }
    }

    private void richTextBoxGamePath_TextChanged(object sender, EventArgs e)
    {
        Program._installPath = richTextBoxGamePath.Text;
    }

    private void buttonUnpack_Click(object sender, EventArgs e)
    {
        Debug.WriteLine(Program._installPath);
    }

    private void buttonBrowseModPath_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialogModPath.ShowDialog() == DialogResult.OK)
        {
            richTextBoxModPath.Text = folderBrowserDialogModPath.SelectedPath;
        }
    }

    private void richTextBoxModPath_TextChanged(object sender, EventArgs e)
    {
        Program._modPath = richTextBoxModPath.Text;
    }
}
