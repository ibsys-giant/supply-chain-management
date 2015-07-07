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
using SupplyChainManagement.Services;
using SupplyChainManagement.Models.ItemManagement;
using SupplyChainManagement.Models;

namespace SupplyChainManagementUI
{
    public partial class OutputTableForm : Form
    {
        private SupplyChainPlanner Planner;
        private DataTable dtItems;
        private DataTable dtOvertime;
        private List<Item> AllItems;
        private List<Workplace> AllWorkplaces;

        public DecisionTableForm ParentForm;

        private Dictionary<int, Dictionary<int, bool>> EnableCellInItemList = new Dictionary<int, Dictionary<int, bool>>();
        private Dictionary<int, Dictionary<int, bool>> EnableCellInWorkplaceList = new Dictionary<int, Dictionary<int, bool>>();

        public OutputTableForm(DecisionTableForm parent, SupplyChainPlanner planner)
        {
            InitializeComponent();
            ParentForm = parent;
            Planner = planner;
            
            SetCalculatedData();
            itemsDataGrid.CellFormatting += itemsDataGrid_CellFormatting;
            overTimeDataGrid.CellFormatting += overTimeDataGrid_CellFormatting;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            CloseParentWindows();
        }

        public void CloseParentWindows() 
        {
            ParentForm.Close();
            ParentForm.CloseParentWindows();
        }

        private void overTimeDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 0 && !EnableCellInItemList[e.RowIndex][e.ColumnIndex]) {
                itemsDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                itemsDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
        }

        private void itemsDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        public void SetCalculatedData() {
            dtItems = new DataTable();
            dtItems.Columns.Add("Item");
            dtItems.Columns.Add("Production orders");
            dtItems.Columns.Add("Procurement orders");
            dtItems.Columns.Add("Order type");

            AllItems = Planner.DataSource.GetAllItems();

            for (var row = 0; row < AllItems.Count; row++)
            {

                var item = AllItems[row];

                string productionOrders;
                string procurementOrders;
                string orderType;

                bool disableProductionOrders = false;
                bool disableProcurementOrders = false;


                try
                {
                    productionOrders = Planner.ProcurementPlanning.ProductionOrders[0][(Product)item].ToString();
                }
                catch (InvalidCastException) {
                    productionOrders = "Not a product";
                    disableProcurementOrders = true;
                }

                try
                {
                    procurementOrders = Planner.ProcurementPlanning.ProcurementOrders[(ProcuredItem) item].Quantity.ToString();
                    orderType = Planner.ProcurementPlanning.ProcurementOrders[(ProcuredItem) item].Type.ToString();
                }
                catch (Exception exc)
                {
                    if (exc is InvalidCastException)
                    {
                        procurementOrders = "Not procured";
                        orderType = "Not procured";
                    }
                    else if (exc is KeyNotFoundException)
                    {
                        procurementOrders = 0.ToString();
                        orderType = ProcurementOrder.OrderType.NORMAL.ToString();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                dtItems.Rows.Add(item.ToString(), productionOrders, procurementOrders, orderType);

                EnableCellInItemList[row] = new Dictionary<int, bool>();

                EnableCellInItemList[row][1] = !disableProductionOrders;
                EnableCellInItemList[row][2] = !disableProcurementOrders;
            }
            itemsDataGrid.DataSource = dtItems;
            itemsDataGrid.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            itemsDataGrid.Columns[0].ReadOnly = true;
            itemsDataGrid.AllowUserToAddRows = false;


            dtOvertime = new DataTable();
            dtOvertime.Columns.Add("Workplace");
            dtOvertime.Columns.Add("Shifts");
            dtOvertime.Columns.Add("Overtime");

            AllWorkplaces = Planner.DataSource.GetAllWorkplaces();

            for (var row = 0; row < AllWorkplaces.Count; row++)
            {
                var workplace = AllWorkplaces[row];
                dtOvertime.Rows.Add(workplace.Id, Planner.ProcurementPlanning.Shifts[workplace], Planner.ProcurementPlanning.Overtime[workplace]);
            }
            overTimeDataGrid.DataSource = dtOvertime;
            overTimeDataGrid.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            overTimeDataGrid.Columns[0].ReadOnly = true;
            overTimeDataGrid.AllowUserToAddRows = false;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            var dialog = new SaveFileDialog();

            dialog.FileName = "output.xml";

            if (dialog.ShowDialog() == DialogResult.OK) {

                for (var i = 0; i < itemsDataGrid.Rows.Count; i++)
                {

                    var item = AllItems[i];
                    var row = itemsDataGrid.Rows[i];

                    try
                    {
                        if (item is Product && Planner.ProcurementPlanning.ProductionOrders[0].ContainsKey(item as Product))
                        {

                            Planner.ProcurementPlanning.ProductionOrders[0][item as Product] = int.Parse(row.Cells[1].Value.ToString());
                        }


                        var quantity = int.Parse(row.Cells[2].Value.ToString());
                        if (item is ProcuredItem && quantity > 0)
                        {


                            if (!Planner.ProcurementPlanning.ProcurementOrders.ContainsKey(item as ProcuredItem)) {
                                Planner.ProcurementPlanning.ProcurementOrders[item as ProcuredItem] = new ProcurementOrder();
                            }

                            Planner.ProcurementPlanning.ProcurementOrders[item as ProcuredItem].Quantity = quantity;

                            var orderTypeValue = row.Cells[3].Value.ToString();

                            if (orderTypeValue.ToUpper() == "FAST")
                            {
                                Planner.ProcurementPlanning.ProcurementOrders[item as ProcuredItem].Type = ProcurementOrder.OrderType.FAST;
                            }
                            else
                            {
                                Planner.ProcurementPlanning.ProcurementOrders[item as ProcuredItem].Type = ProcurementOrder.OrderType.NORMAL;
                            }
                        }
                    }
                    catch (FormatException) { }
                }


                for (var i = 0; i < overTimeDataGrid.Rows.Count; i++)
                {

                    var workplace = AllWorkplaces[i];
                    var row = overTimeDataGrid.Rows[i];

                    try
                    {
                        Planner.ProcurementPlanning.Shifts[workplace] = int.Parse(row.Cells[1].Value.ToString());
                        Planner.ProcurementPlanning.Overtime[workplace] = int.Parse(row.Cells[2].Value.ToString());
                    }
                    catch (FormatException) { }
                }


                var xml = Planner.Export();
                File.WriteAllText(dialog.FileName, xml);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OutputTableForm_Load(object sender, EventArgs e)
        {

        }

        private void overTimeDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            SetCalculatedData();
        }
    }
}
