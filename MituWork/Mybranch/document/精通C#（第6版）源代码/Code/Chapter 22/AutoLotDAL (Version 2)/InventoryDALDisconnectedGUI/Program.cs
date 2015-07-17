using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryDALDisconnectedGUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            DataTable table = new DataTable();
            List<int> il = new List<int>() { 1, 3, 4 };
            List<int> ill = new List<int> { 1, 3, 4, 3 };
            Stack<int> iss = new Stack<int>(){1,3,4};
        }
    }
}
