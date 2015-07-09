using SupplyChainManagement.Models.ItemManagement;
using SupplyChainManagement.Services;
using SupplyChainManagementUI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupplyChainManagementUI
{
    public partial class DecisionTableForm : Form
    {
        public SupplyChainPlanner Planner;


        public InputXmlForm ParentForm;

        public List<FinishedProduct> FinishedProducts = new List<FinishedProduct>();
        private int[,] StartValues;


        public DecisionTableForm(InputXmlForm parent, string xml)
        {
            InitializeComponent();
            Planner = parent.Planner; ;
            ParentForm = parent;

            if (!String.IsNullOrEmpty(xml))
            {
                Planner.Import(xml);
            }

            StartValues = new int[3, 5];
            StartValues[0, 0] = 100;
            StartValues[0, 1] = 150;
            StartValues[0, 2] = 150;
            StartValues[0, 3] = 150;
            StartValues[0, 4] = 150;

            StartValues[1, 0] = 100;
            StartValues[1, 1] = 150;
            StartValues[1, 2] = 150;
            StartValues[1, 3] = 100;
            StartValues[1, 4] = 50;

            StartValues[2, 0] = 100;
            StartValues[2, 1] = 150;
            StartValues[2, 2] = 100;
            StartValues[2, 3] = 50;
            StartValues[2, 4] = 50;

            DataTable dt = new DataTable();
            dt.Columns.Add(strings.columnFinishedProduct, typeof(string));
            dt.Columns.Add(strings.columnWarehouseStock, typeof(int));
            dt.Columns.Add(strings.columnDemandN, typeof(int));
            dt.Columns.Add(strings.columnDemandN1, typeof(int));
            dt.Columns.Add(strings.columnDemandN2, typeof(int));
            dt.Columns.Add(strings.columnDemandN3, typeof(int));

            var allItems = Planner.DataSource.GetAllItems();
            FinishedProducts = new List<FinishedProduct>(from item in allItems where item is FinishedProduct select item as FinishedProduct);


            for (var i = 0; i < FinishedProducts.Count; i++ )
            {
                var product = FinishedProducts[i];
                dt.Rows.Add(product.ToString(), StartValues[i, 0], StartValues[i, 1], StartValues[i, 2], StartValues[i, 3], StartValues[i, 4]);
            }

            dataGridView.DataSource = dt;
            dataGridView.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            CloseParentWindows();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text  = strings.DecisionTableFormTitle;
            this.calcButton.Text = strings.DecisionTableFormButtonCalculate;

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
            //try {

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

                var outputTableForm = new OutputTableForm(this, Planner);
                outputTableForm.Show();
                this.Hide();
           // }
            //catch (Exception exc) {
            //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        public void CloseParentWindows()
        {
            ParentForm.Close();

        }
    }
}
