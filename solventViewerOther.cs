﻿using System;
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
    public partial class solventViewerOther : Form
    {
        public solventViewerOther()
        {
            InitializeComponent();
        }

        private void solventViewerOther_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.SolventDT' table. You can move, or remove it, as needed.
            this.solventDTTableAdapter.Fill(this.fullDATASET.SolventDT);

            this.reportViewer1.RefreshReport();
        }
    }
}
