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
    public partial class solventViewerInhalable : Form
    {
        public solventViewerInhalable()
        {
            InitializeComponent();
        }

        private void solventViewerInhalable_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.SolventDT' table. You can move, or remove it, as needed.
            this.SolventDTTableAdapter.Fill(this.fullDATASET.SolventDT);

            this.reportViewer1.RefreshReport();
        }
    }
}
