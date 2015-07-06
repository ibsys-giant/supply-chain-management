using SupplyChainManagement.Models.ItemManagement;
using SupplyChainManagement.Services;
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
    public partial class DecisionTableForm : Form
    {
        public SupplyChainPlanner Planner;

        public List<FinishedProduct> FinishedProducts = new List<FinishedProduct>();


        public DecisionTableForm(InputXmlForm parent, string xml)
        {
            InitializeComponent();
            Planner = parent.Planner; ;

            if (!String.IsNullOrEmpty(xml))
            {
                Planner.Import(xml);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Finished Product", typeof(string));
            dt.Columns.Add("Planned warehouse stock", typeof(int));
            dt.Columns.Add("Demand period n", typeof(int));
            dt.Columns.Add("Demand period n+1", typeof(int));
            dt.Columns.Add("Demand period n+2", typeof(int));
            dt.Columns.Add("Demand period n+3", typeof(int));

            var allItems = Planner.DataSource.GetAllItems();
            FinishedProducts = new List<FinishedProduct>(from item in allItems where item is FinishedProduct select item as FinishedProduct);

            foreach (var product in FinishedProducts)
            {
                dt.Rows.Add(product.ToString(), 0, 0, 0, 0, 0);
            }

            dataGridView.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void Berechnen_Click(object sender, EventArgs e)
        {
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calcButtonClick(object sender, EventArgs e)
        {
            try {

                var plannedWarehouseStocks = new Dictionary<FinishedProduct, int>();
                var demands = new Dictionary<FinishedProduct, List<int>>();
                for (var i = 0; i < FinishedProducts.Count; i++)
                {
                    var product = FinishedProducts[i];
                    var plannedWarehouseStock = int.Parse(dataGridView.Rows[i].Cells[1].Value.ToString());

                    var periodDemands = new List<int>();
                    periodDemands.Add(int.Parse(dataGridView.Rows[i].Cells[2].Value.ToString()));
                    periodDemands.Add(int.Parse(dataGridView.Rows[i].Cells[3].Value.ToString()));
                    periodDemands.Add(int.Parse(dataGridView.Rows[i].Cells[4].Value.ToString()));
                    periodDemands.Add(int.Parse(dataGridView.Rows[i].Cells[5].Value.ToString()));

                    demands.Add(product, periodDemands);
                    plannedWarehouseStocks.Add(product, plannedWarehouseStock);
                }

                Planner.Plan(demands, plannedWarehouseStocks);
                var xml = Planner.Export();

                var outputXmlForm = new OutputXmlForm(xml);
                outputXmlForm.Show();
                this.Hide();
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
