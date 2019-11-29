using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace NotePadMini
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Clear();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                MainRichTextBox.Text = File.ReadAllText(filename);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, MainRichTextBox.Text);
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        private void MainRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainRichTextBox.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                leftToolStripMenuItem.Enabled = true;
                rightToolStripMenuItem.Enabled = true;
                centerToolStripMenuItem.Enabled = true;
                selectFonttoolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                boldToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;
                toolStripButton4.Enabled = true;
                toolStripButton5.Enabled = true;
                toolStripButton6.Enabled = true;
                toolStripButton7.Enabled = true;
                toolStripButton8.Enabled = true;
                toolStripButton9.Enabled = true;
                toolStripButton10.Enabled = true;
                toolStripButton11.Enabled = true;
                toolStripButton12.Enabled = true;
                toolStripButton14.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                leftToolStripMenuItem.Enabled = false;
                rightToolStripMenuItem.Enabled = false;
                centerToolStripMenuItem.Enabled = false;
                selectFonttoolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled = false;
                boldToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
                toolStripButton4.Enabled = false;
                toolStripButton5.Enabled = false;
                toolStripButton6.Enabled = false;
                toolStripButton7.Enabled = false;
                toolStripButton8.Enabled = false;
                toolStripButton9.Enabled = false;
                toolStripButton10.Enabled = false;
                toolStripButton11.Enabled = false;
                toolStripButton12.Enabled = false;
                toolStripButton14.Enabled = false;
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }

        private void BoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Bold);
        }

        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Italic);
        }

        private void UnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Underline);
        }
        private void SelectFonttoolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK & !String.IsNullOrEmpty(MainRichTextBox.Text))
            {
                MainRichTextBox.SelectionFont = fontDialog.Font;
                MainRichTextBox.SelectionColor = fontDialog.Color;
            }
        }
        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
