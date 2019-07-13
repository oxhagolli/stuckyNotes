using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StuckyNotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size = new Size(
                Properties.Settings.Default.width,
                Properties.Settings.Default.height);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Properties.Settings.Default.width = Size.Width;
            Properties.Settings.Default.height = Size.Height;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset settings?",
                "Reset Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Properties.Settings.Default.Reset();
                Application.Restart();
            }
        }
    }
}
