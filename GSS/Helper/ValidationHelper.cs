using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS.Helper
{
    public static class ValidationHelper
    {
        private static readonly MethodInfo onValidating = typeof(Control).GetMethod("OnValidating", BindingFlags.Instance | BindingFlags.NonPublic);
        private static readonly MethodInfo onValidated = typeof(Control).GetMethod("OnValidated", BindingFlags.Instance | BindingFlags.NonPublic);
        public static bool Validate(this Control control)
        {
            CancelEventArgs e = new CancelEventArgs();
            onValidating.Invoke(control, new object[] { e });
            if (e.Cancel) return false;
            onValidated.Invoke(control, new object[] { EventArgs.Empty });
            return true;
        }
    }
}
