namespace LIMS_system_Prototype
{
    partial class potencyViewerInhalable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullDATASET = new LIMS_system_Prototype.fullDATASET();
            this.dataDTTableAdapter = new LIMS_system_Prototype.fullDATASETTableAdapters.dataDTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataDTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullDATASET)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataDTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LIMS_system_Prototype.potencyInhalableReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1173, 555);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataDTBindingSource
            // 
            this.dataDTBindingSource.DataMember = "dataDT";
            this.dataDTBindingSource.DataSource = this.fullDATASET;
            // 
            // fullDATASET
            // 
            this.fullDATASET.DataSetName = "fullDATASET";
            this.fullDATASET.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataDTTableAdapter
            // 
            this.dataDTTableAdapter.ClearBeforeFill = true;
            // 
            // potencyViewerInhalable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 555);
            this.Controls.Add(this.reportViewer1);
            this.Name = "potencyViewerInhalable";
            this.Text = "potencyViewerInhalable";
            this.Load += new System.EventHandler(this.potencyViewerInhalable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataDTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fullDATASET)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataDTBindingSource;
        private fullDATASET fullDATASET;
        private fullDATASETTableAdapters.dataDTTableAdapter dataDTTableAdapter;
    }
}