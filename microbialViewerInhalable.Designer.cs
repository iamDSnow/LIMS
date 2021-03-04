
namespace LIMS_system_Prototype
{
    partial class microbialViewerInhalable
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
            this.fullDATASET = new LIMS_system_Prototype.fullDATASET();
            this.microbialDTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.microbialDTTableAdapter = new LIMS_system_Prototype.fullDATASETTableAdapters.microbialDTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fullDATASET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.microbialDTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.microbialDTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LIMS_system_Prototype.microbialInhalableReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // fullDATASET
            // 
            this.fullDATASET.DataSetName = "fullDATASET";
            this.fullDATASET.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // microbialDTBindingSource
            // 
            this.microbialDTBindingSource.DataMember = "microbialDT";
            this.microbialDTBindingSource.DataSource = this.fullDATASET;
            // 
            // microbialDTTableAdapter
            // 
            this.microbialDTTableAdapter.ClearBeforeFill = true;
            // 
            // microbialViewerInhalable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "microbialViewerInhalable";
            this.Text = "microbialViewerInhalable";
            this.Load += new System.EventHandler(this.microbialViewerInhalable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fullDATASET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.microbialDTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource microbialDTBindingSource;
        private fullDATASET fullDATASET;
        private fullDATASETTableAdapters.microbialDTTableAdapter microbialDTTableAdapter;
    }
}