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
    public partial class MainForm : Form
    {

        private LoginForm _LoginForm;
        private SimulatorClient _Client;

        public MainForm(LoginForm parent, SimulatorClient client)
        {
            InitializeComponent();
            _Client = client;
        }


    }
}
