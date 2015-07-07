using System;
using System.IO;
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
    public partial class InputXmlForm : Form
    {
        public SupplyChainPlanner Planner;

        public InputXmlForm()
        {
            InitializeComponent();
            Planner = new SupplyChainPlanner();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DecisionTableForm dyn = new DecisionTableForm(this, xmlText.Text);
                dyn.Show();
                this.Hide();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SplNr_TextChanged(object sender, EventArgs e)
        {

        }

        private void GrpNr_TextChanged(object sender, EventArgs e)
        {

        }

        private void PerNr_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void firstPeriodCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            xmlText.Enabled = !firstPeriodCheckbox.Checked;
            loadXmlFileButton.Enabled = !firstPeriodCheckbox.Checked;
        }

        private void loadXmlFileButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = "input.xml";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                xmlText.Text = File.ReadAllText(dialog.FileName);
            }

        }

        private void InputXmlForm_Load(object sender, EventArgs e)
        {

        }
    }
}
