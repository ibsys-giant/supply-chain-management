using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SupplyChainManagement.Services;

namespace SupplyChainManagementUI
{
    public partial class LoginForm : Form
    {

        private MainForm _MainForm;

        public LoginForm()
        {
            InitializeComponent();
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void loginAction(object sender, EventArgs e)
        {
            
            System.Net.WebProxy proxy = null;
            if (proxyCheckBox.Checked)
            {

                var host = proxyHostTextBox.Text;
                var port = proxyPortTextBox.Text;
                var uri = new Uri("http://" + host + ":" + port);

                
                string username = null;
                string password = null;

                if (!String.IsNullOrEmpty(proxyUsernameTextBox.Text)) 
                {
                    username = proxyUsernameTextBox.Text;
                }
                if (!String.IsNullOrEmpty(proxyPasswordTextBox.Text))
                {
                    password = proxyPasswordTextBox.Text;
                }

                if (username != null && password != null)
                {
                    proxy = new System.Net.WebProxy(uri, true, null, new System.Net.NetworkCredential(username, password));
                }
                else {
                    proxy = new System.Net.WebProxy(uri, true);
                }
            }


            try
            {
                var planner = new SupplyChainPlanner(new Uri(serverUriTextBox.Text),
                    usernameTextBox.Text, 
                    passwordTextBox.Text, 
                    proxy);
                _MainForm = new MainForm(this, planner);
                _MainForm.Show();
                this.Hide();
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelAction(object sender, EventArgs e)
        {
            this.Close();
        }

        private void serverUriTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (proxyCheckBox.Checked)
            {
                proxyHostTextBox.Enabled = true;
                proxyPortTextBox.Enabled = true;
                proxyUsernameTextBox.Enabled = true;
                proxyPasswordTextBox.Enabled = true;
            }
            else 
            {
                proxyHostTextBox.Enabled = false;
                proxyPortTextBox.Enabled = false;
                proxyUsernameTextBox.Enabled = false;
                proxyPasswordTextBox.Enabled = false;
            }
        }

        private void proxyHostTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
