using GSS.Model;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS
{
    public partial class FrmMarkSegments : MaterialForm
    {
        public FrmMarkSegments()
        {
            InitializeComponent();

            webBrowser1.Url = new Uri(Application.StartupPath + "\\Map_MarkSegments.html");
            webBrowser1.ObjectForScripting = new ScriptingObject(this);
        }


        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            DialogResult = DialogResult.OK;
        }


        private void EvalCode(string code)
        {
            webBrowser1.Document.InvokeScript("eval", new object[] { code });
        }


        [ComVisible(true)]
        public class ScriptingObject
        {
            private readonly FrmMarkSegments frm;

            public ScriptingObject(FrmMarkSegments FrmMarkSegments)
            {
                this.frm = FrmMarkSegments;
            }

            // can be called from JavaScript
            public void SetLatLng(double lat, double lng)
            {
                
            }
        }

        private void BtnNewSegment_Click(object sender, EventArgs e)
        {
            EvalCode("N");
        }
    }
}
