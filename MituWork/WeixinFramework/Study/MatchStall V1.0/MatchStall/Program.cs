using System;
using Application = System.Windows.Forms.Application;

namespace MatchStall
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            XiaoHan.LogWriter.Register(Application.StartupPath + "\\Log");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppForm());
        }
    }
}
