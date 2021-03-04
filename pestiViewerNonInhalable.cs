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
    public partial class pestiViewerNonInhalable : Form
    {
        public pestiViewerNonInhalable()
        {
            InitializeComponent();
        }

        private void pestiViewerNonInhalable_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.PestiDT' table. You can move, or remove it, as needed.
            this.PestiDTTableAdapter.Fill(this.fullDATASET.PestiDT);

            this.reportViewer1.RefreshReport();
        }
    }
}
