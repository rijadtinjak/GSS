using GSS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSS.Helper
{
    public static class ConsensusHelper
    {

        public static void EstimationInput(this Search search, TableLayoutPanel tlpZones, bool checkErrors = true)
        {
            for (int i = 0; i < search.Zones.Count; i++)
            {
                for (int j = 0; j < search.Managers.Count; j++)
                {
                    Control c = tlpZones.GetControlFromPosition(i + 1, j + 1);
                    string value = c.Text.ToString();

                    try
                    {
                        foreach (var consensus in search.Zones[i].Consensus)
                        {
                            if (consensus.Manager.Name == search.Managers[j].Name)
                            {
                                consensus.Value = InputHelper.ParseDouble(value);
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (checkErrors)
                            throw new Exception("Consensus invalid");
                    }
                }

                search.Zones[i].SumofConsensus = 0;
                foreach (var consensus in search.Zones[i].Consensus)
                {
                    search.Zones[i].SumofConsensus += consensus.Value;
                }
            }
            for (int i = 1; i < tlpZones.ColumnCount; i++)
            {
                Control c = tlpZones.GetControlFromPosition(i, tlpZones.RowCount - 1);
                string value = c.Text.ToString();
                try
                {
                    search.Zones[i - 1].Area = InputHelper.ParseDouble(value);

                }
                catch (Exception)
                {
                    if (checkErrors)
                        throw new Exception("Area invalid");
                }
            }
        }
        public static void ZonePoAPdenCalc(this Search search)
        {
            foreach (var zone in search.Zones)
            {
                if (search.SumOfAllConsensus != 0)
                    zone.PoA = (zone.SumofConsensus / search.SumOfAllConsensus * 100) / 100;
                else
                    zone.PoA = 0;

                if (zone.Area != 0)
                    zone.Pden = zone.PoA / zone.Area;
                else
                    zone.Pden = 0;
            }
        }


        public static void SortZones(this Search search, TableLayoutPanel tlpZones)
        {
            try
            {
                search.EstimationInput(tlpZones);
            }
            catch (Exception)
            {
                throw;
            }

            search.ZonePoAPdenCalc();
            List<double> sortZonePden = new List<double>();
            foreach (var zone in search.Zones)
            {
                sortZonePden.Add(zone.Pden);
            }
            sortZonePden.Sort();
            sortZonePden.Reverse();
        }

        public static void PopulateFields(this Search search, TableLayoutPanel tlpZones)
        {
            for (int i = 0; i < search.Zones.Count; i++)
            {
                for (int j = 0; j < search.Managers.Count; j++)
                {
                    Control c = tlpZones.GetControlFromPosition(i + 1, j + 1);

                    foreach (var consensus in search.Zones[i].Consensus)
                    {
                        if (consensus.Manager.Name == search.Managers[j].Name)
                        {
                            c.Text = consensus.Value.ToString();
                            break;
                        }
                    }

                }
            }
            for (int i = 1; i < tlpZones.ColumnCount; i++)
            {
                Control c = tlpZones.GetControlFromPosition(i, tlpZones.RowCount - 1);
                c.Text = search.Zones[i - 1].Area.ToString();
            }
        }

    }
}
