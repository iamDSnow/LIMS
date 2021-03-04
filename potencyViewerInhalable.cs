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
    public partial class potencyViewerInhalable : Form
    {
        public potencyViewerInhalable()
        {
            InitializeComponent( );

        }

        private void potencyViewerInhalable_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'fullDATASET.dataDT' table. You can move, or remove it, as needed.
            this.dataDTTableAdapter.Fill(this.fullDATASET.dataDT);

            this.reportViewer1.RefreshReport();

           

        }
    }
}
