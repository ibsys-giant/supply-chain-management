using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyChainManagementUI
{
    public partial class DynamischeTabelle : Form
    {
        DataTable dt = new DataTable();
        public DynamischeTabelle()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
            dt.Columns.Add("Product", System.Type.GetType("System.String"));
            dt.Columns.Add("Demand", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Planed Warehouse", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            // Füllen der Zeile
            dr["Product"] = "p1";
            dr["Demand"] = "200";
            dr["Planed Warehouse"] = "50";
            // Anfügen der Zeile an Tabelle
            dt.Rows.Add(dr);

            // Erzeugen der 2. Zeile
            dr = dt.NewRow();
            // Füllen der Zeile
            dr["Product"] = "p2";
            dr["Demand"] = "100";
            dr["Planed Warehouse"] = "50";
            // Anfügen der Zeile an Tabelle
            dt.Rows.Add(dr);

            // Erzeugen der 3. Zeile
            dr = dt.NewRow();
            // Füllen der Zeile
            dr["Product"] = "p3";
            dr["Demand"] = "50";
            dr["Planed Warehouse"] = "50";
            // Anfügen der Zeile an Tabelle
            dt.Rows.Add(dr);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

















































































































































































































































































































        }
    }
}
