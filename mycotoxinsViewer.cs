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
    public partial class mycotoxinsViewer : Form
    {
        public mycotoxinsViewer()
        {
            InitializeComponent();
        }

        private void mycotoxinsViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.mycotoxinDT' table. You can move, or remove it, as needed.
            this.mycotoxinDTTableAdapter.Fill(this.fullDATASET.mycotoxinDT);

            this.reportViewer1.RefreshReport();
        }
    }
}
