using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dialog = new FrmLogin();
            if (dialog.ShowDialog() == DialogResult.OK)
                Application.Run(new frmOverView());

            //var dialog = new FrmInitial();
            //if (dialog.ShowDialog() == DialogResult.OK)
            //    Application.Run(new FrmAnalysis(dialog.NumOfZones, dialog.Managers));
        }
    }
}
