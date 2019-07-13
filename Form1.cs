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
        public static string DonationURL =
            "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=LX8ZV8V3PHUX6&source=url";

        public static string Entertainment =
            "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void DonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(DonationURL);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.text;
            textBox1.WordWrap = Properties.Settings.Default.wrap;
            wordWrapToolStripMenuItem.Checked = Properties.Settings.Default.wrap;
            textBox1.UseSystemPasswordChar = !Properties.Settings.Default.protect;
            protectTextToolStripMenuItem.Checked = Properties.Settings.Default.protect;
            TopMost = Properties.Settings.Default.always;
            lockToolStripMenuItem.Checked = Properties.Settings.Default.always;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.text = textBox1.Text;
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.wrap = !Properties.Settings.Default.wrap;
            textBox1.WordWrap = Properties.Settings.Default.wrap;
        }

        private void ProtectTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.protect = !Properties.Settings.Default.protect;
            textBox1.UseSystemPasswordChar = !Properties.Settings.Default.protect;
        }

        private void LockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.always = !Properties.Settings.Default.always;
            TopMost = Properties.Settings.Default.always;
        }
    }
}
