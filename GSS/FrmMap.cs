using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS
{
    public partial class FrmMap : Form
    {
        public FrmMap()
        {
            InitializeComponent();

            webBrowser1.Url = new Uri(Application.StartupPath + "\\map.html");
            
        }
    }
}
