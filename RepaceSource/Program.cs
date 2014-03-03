using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RepaceSource
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new RepaceSource());
            Application.Run(new Form2());       
        }
    }
}
