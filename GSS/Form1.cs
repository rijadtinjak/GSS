using GSS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GSS
{
    public partial class Form1 : Form
    {
        private int numOfZones;

        private List<Zone> Zones = new List<Zone>();
        private List<Manager> managers;


        public Form1(int numOfZones, List<Manager> managers)
        {
            InitializeComponent();
            this.numOfZones = numOfZones;
            this.managers = managers;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < numOfZones; i++)
            {
                Dictionary<Manager, double> consensus = new Dictionary<Manager, double>();
                foreach (var item in managers)
                {
                    consensus.Add(item, 0);
                }

                Zones.Add(new Zone {
                    Name = "Zone " + Convert.ToChar(65 + i),
                    Consensus = consensus
                });
            }


        }

    }
}
