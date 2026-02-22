using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuraReworkV2
{
    public partial class Form2 : Form
    {
        string[] Keys = { "U3ByaW5neUtleTE", "U3ByaW5neUtleVNwcmluZ0tleUtleTI", "U3ByaW5neUtleVNwcmluZ", "neUtleVNU3ByaW5ne" };
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            var key = txtKey.Text.Trim();

            if (Array.Exists(Keys, k => k.Equals(key, StringComparison.OrdinalIgnoreCase)))
            {
                var mainexecutor = new Form1();

                mainexecutor.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Key, Please try again.");
            }
        }
    }
    }


