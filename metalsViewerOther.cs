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
    public partial class metalsViewerOther : Form
    {
        public metalsViewerOther()
        {
            InitializeComponent();
        }

        private void metalsViewerOther_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.metalsDT' table. You can move, or remove it, as needed.
            this.metalsDTTableAdapter.Fill(this.fullDATASET.metalsDT);

            this.reportViewer1.RefreshReport();
        }
    }
}
