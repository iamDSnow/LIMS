using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIMS_system_Prototype
{
    public partial class complianceReportViewer : Form
    {
        public complianceReportViewer()
        {
            InitializeComponent();
        }

        private void complianceReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.compliance' table. You can move, or remove it, as needed.
            this.complianceDTTableAdapter.Fill(this.fullDATASET.complianceDT);

            this.reportViewer1.RefreshReport();
        }
    }
}
