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

namespace SupplyChainManagementUI
{
    public partial class OutputXmlForm : Form
    {
        public OutputXmlForm(string xml)
        {
            xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            xml = xml.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "");
            InitializeComponent();
            xmlText.Text = xml;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();

            dialog.FileName = "output.xml";
            if (dialog.ShowDialog() == DialogResult.OK) {

                File.WriteAllText(dialog.FileName, xmlText.Text);
            }
        }
    }
}
