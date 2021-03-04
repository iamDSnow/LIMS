using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIMS_system_Prototype
{
    public partial class potencyViewerOther : Form
    {
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        public potencyViewerOther()
        {
            InitializeComponent();
        }

        private void potencyViewerOther_Load(object sender, EventArgs e)
        {
         
            this.dataDTTableAdapter.Fill(this.fullDATASET.dataDT);

            this.reportViewer1.RefreshReport();

        }
    }
}
