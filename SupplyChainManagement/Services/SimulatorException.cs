using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Services
{
    public class SimulatorException : Exception
    {
        public SimulatorException(string message) : base(message) { 
        
        }
    }
}
