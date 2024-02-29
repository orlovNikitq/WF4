using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Server;

namespace Homework
{
    public partial class Form1 : Form
    {
        public enum DateTimeFormat { ShowClock, ShowDate }
        DateTimeFormat format;
        private string filePath;

        public Form1()
        {
            InitializeComponent();
            menuStrip_ru.Visible = false;
            format = DateTimeFormat.ShowClock;
            toolStripStatusLabel2.Click += timer1_Tick;
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel1.Text = DateTime.Now.DayOfWeek.ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All files(*.*)|*.*| Text files(*.txt)|*.txt||";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = File.OpenText(open.FileName); 
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    filePath = save.FileName;
                }
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }

            
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog.Color;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = richTextBox1.SelectionColor;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.CompareTo("Русский") == 0)
            {
                button1.Text = "English";
                menuStrip1.Visible = false;
                menuStrip_ru.Visible = true;
                MainMenuStrip = menuStrip_ru;
            }
            else
            {
                button1.Text = "Русский";
                menuStrip1.Visible = true;
                menuStrip_ru.Visible = false;
                MainMenuStrip = menuStrip1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(format == DateTimeFormat.ShowClock)
            {
                toolStripStatusLabel2.Text = DateTime.Now.ToShortTimeString();
                format = DateTimeFormat.ShowDate;
            }
            else
            {
                toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
                format = DateTimeFormat.ShowClock;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
            else
            {
                richTextBox1.SelectAll();
                richTextBox1.Copy();
                richTextBox1.DeselectAll();
            }
        }

        private void pastleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; 
            save.FilterIndex = 1; 

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(save.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = richTextBox1.SelectionBackColor;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = cd.Color;
                richTextBox1.SelectionBackColor = selectedColor;
            }
            richTextBox1.Focus();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = richTextBox1.SelectionIndent + 10;
            richTextBox1.Focus();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = Math.Max(0, richTextBox1.SelectionIndent - 10);
            richTextBox1.Focus();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }
    }
}
