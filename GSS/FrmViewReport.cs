using GSS.Model;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmViewReport : MaterialForm
    {
        private List<Consensus> consensusList;
        private readonly List<List<SortedSegmentArchiveEntry>> SortedSegmentArchive;
        private readonly List<POSCumulativeArchiveEntry> POSCumulativeArchive;
        private readonly List<Segment> sortedSegments;
        private int currentPage = 1;

        public FrmViewReport(List<Consensus> consensusList, List<List<SortedSegmentArchiveEntry>> SortedSegmentArchive, List<POSCumulativeArchiveEntry> PosCumulativeArchive, List<Segment> sortedSegments, string SearchName)
        {
            InitializeComponent();
            this.consensusList = consensusList;
            this.SortedSegmentArchive = SortedSegmentArchive;
            this.POSCumulativeArchive = PosCumulativeArchive;
            this.sortedSegments = sortedSegments;

            this.Text += " of " + SearchName;
        }

        private void FrmViewReport_Load(object sender, EventArgs e)
        {
            RefreshReport();

            if (SortedSegmentArchive.Count < 2)
                btnNext.Enabled = false;
        }

        private void RefreshReport()
        {
            ReportDataSource rds1 = new ReportDataSource("Consensus", consensusList);
            ReportDataSource rds_chart = new ReportDataSource("SortedSegmentArchive", SortedSegmentArchive[currentPage - 1]);
            ReportDataSource rds_table = new ReportDataSource("SortedSegmentArchiveTable", SortedSegmentArchive[currentPage - 1].Take(5));

            double SuccessPercentage = 0.0;
            if (POSCumulativeArchive.Count > 0)
            {
                double Sum_PoA = sortedSegments.Sum(x => x.SegmentHistory[0].PoA);
                double TotalPosCum = POSCumulativeArchive[currentPage - 1].Value;
                SuccessPercentage = TotalPosCum / Sum_PoA * 100;
            }

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds_chart);
            this.reportViewer1.LocalReport.DataSources.Add(rds_table);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("SuccessPercentage", SuccessPercentage.ToString("0.00") + "%"));
            this.reportViewer1.RefreshReport();

            if (currentPage == 1)
                btnPrevious.Enabled = false;
            else
                btnPrevious.Enabled = true;

            if (currentPage >= SortedSegmentArchive.Count)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
        }

        private void txtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtCurrentPage.Text, out int value))
            {
                if (value < 1)
                {
                    value = 1;
                }
                else if (value > SortedSegmentArchive.Count)
                {
                    value = SortedSegmentArchive.Count;
                }
                else
                {
                    currentPage = value;
                    RefreshReport();
                    return;
                }
                txtCurrentPage.Text = value.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            txtCurrentPage.Text = (currentPage - 1).ToString();
        }
    }
}
