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


    }
}
