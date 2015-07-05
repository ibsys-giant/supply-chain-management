using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChainManagement.Util
{
    public class Constants
    {

        public static String MAIN_DIR = Environment.GetEnvironmentVariable("appdata") + "\\supply-chain-simulator";
        public static String DATA_DIR = MAIN_DIR + "\\data";
        public static String DATABASE_FILE = DATA_DIR + "\\scm.sqlite";
        public static String CONNECTION_URI="Data Source=" + Constants.DATABASE_FILE + ";Version=3";

        public static double SHIFT_DURATION = 2400.0;
    }
}
