namespace LIMS_system_Prototype
{
    partial class mycotoxinsForm
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
            this.updateBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.techniqueCB = new System.Windows.Forms.ComboBox();
            this.methodCB = new System.Windows.Forms.ComboBox();
            this.mycoWtTB = new System.Windows.Forms.TextBox();
            this.OTATB = new System.Windows.Forms.TextBox();
            this.AG2TB = new System.Windows.Forms.TextBox();
            this.AG1TB = new System.Windows.Forms.TextBox();
            this.AB2TB = new System.Windows.Forms.TextBox();
            this.AB1TB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.sampleIDlbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iDlbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LCMSIDTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.updateBtn.Location = new System.Drawing.Point(694, 431);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(100, 28);
            this.updateBtn.TabIndex = 37;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 59);
            this.label2.TabIndex = 36;
            this.label2.Text = "Mycotoxins Form";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(64, 46);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.closeBtn.Location = new System.Drawing.Point(694, 377);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 28);
            this.closeBtn.TabIndex = 34;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.saveBtn.Location = new System.Drawing.Point(694, 318);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 28);
            this.saveBtn.TabIndex = 33;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.openBtn.Location = new System.Drawing.Point(804, 237);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(100, 28);
            this.openBtn.TabIndex = 32;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = false;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // techniqueCB
            // 
            this.techniqueCB.FormattingEnabled = true;
            this.techniqueCB.Items.AddRange(new object[] {
            "LC-MS/MS"});
            this.techniqueCB.Location = new System.Drawing.Point(346, 238);
            this.techniqueCB.Margin = new System.Windows.Forms.Padding(4);
            this.techniqueCB.Name = "techniqueCB";
            this.techniqueCB.Size = new System.Drawing.Size(160, 24);
            this.techniqueCB.TabIndex = 31;
            // 
            // methodCB
            // 
            this.methodCB.FormattingEnabled = true;
            this.methodCB.Items.AddRange(new object[] {
            "Cannabis Mycotoxins"});
            this.methodCB.Location = new System.Drawing.Point(346, 208);
            this.methodCB.Margin = new System.Windows.Forms.Padding(4);
            this.methodCB.Name = "methodCB";
            this.methodCB.Size = new System.Drawing.Size(160, 24);
            this.methodCB.TabIndex = 30;
            // 
            // mycoWtTB
            // 
            this.mycoWtTB.Location = new System.Drawing.Point(663, 239);
            this.mycoWtTB.Margin = new System.Windows.Forms.Padding(4);
            this.mycoWtTB.Name = "mycoWtTB";
            this.mycoWtTB.Size = new System.Drawing.Size(132, 22);
            this.mycoWtTB.TabIndex = 28;
            // 
            // OTATB
            // 
            this.OTATB.Location = new System.Drawing.Point(348, 425);
            this.OTATB.Margin = new System.Windows.Forms.Padding(4);
            this.OTATB.Name = "OTATB";
            this.OTATB.Size = new System.Drawing.Size(132, 22);
            this.OTATB.TabIndex = 27;
            // 
            // AG2TB
            // 
            this.AG2TB.Location = new System.Drawing.Point(348, 397);
            this.AG2TB.Margin = new System.Windows.Forms.Padding(4);
            this.AG2TB.Name = "AG2TB";
            this.AG2TB.Size = new System.Drawing.Size(132, 22);
            this.AG2TB.TabIndex = 26;
            // 
            // AG1TB
            // 
            this.AG1TB.Location = new System.Drawing.Point(348, 369);
            this.AG1TB.Margin = new System.Windows.Forms.Padding(4);
            this.AG1TB.Name = "AG1TB";
            this.AG1TB.Size = new System.Drawing.Size(132, 22);
            this.AG1TB.TabIndex = 25;
            // 
            // AB2TB
            // 
            this.AB2TB.Location = new System.Drawing.Point(348, 342);
            this.AB2TB.Margin = new System.Windows.Forms.Padding(4);
            this.AB2TB.Name = "AB2TB";
            this.AB2TB.Size = new System.Drawing.Size(132, 22);
            this.AB2TB.TabIndex = 24;
            // 
            // AB1TB
            // 
            this.AB1TB.Location = new System.Drawing.Point(348, 315);
            this.AB1TB.Margin = new System.Windows.Forms.Padding(4);
            this.AB1TB.Name = "AB1TB";
            this.AB1TB.Size = new System.Drawing.Size(132, 22);
            this.AB1TB.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(552, 243);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Sample Wieght";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(295, 431);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "OTA";
            // 
            // sampleIDlbl
            // 
            this.sampleIDlbl.AutoSize = true;
            this.sampleIDlbl.Location = new System.Drawing.Point(184, 266);
            this.sampleIDlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sampleIDlbl.Name = "sampleIDlbl";
            this.sampleIDlbl.Size = new System.Drawing.Size(18, 17);
            this.sampleIDlbl.TabIndex = 20;
            this.sampleIDlbl.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Technique";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 209);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "LCMSID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(294, 403);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "AG2";
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Location = new System.Drawing.Point(184, 233);
            this.dateLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(18, 17);
            this.dateLbl.TabIndex = 16;
            this.dateLbl.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Method";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(295, 376);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "AG1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 266);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Sample ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 346);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "AB2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 233);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Date";
            // 
            // iDlbl
            // 
            this.iDlbl.AutoSize = true;
            this.iDlbl.Location = new System.Drawing.Point(184, 206);
            this.iDlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iDlbl.Name = "iDlbl";
            this.iDlbl.Size = new System.Drawing.Size(18, 17);
            this.iDlbl.TabIndex = 10;
            this.iDlbl.Text = "--";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 318);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "AB1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 206);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID";
            // 
            // LCMSIDTB
            // 
            this.LCMSIDTB.Location = new System.Drawing.Point(663, 206);
            this.LCMSIDTB.Margin = new System.Windows.Forms.Padding(4);
            this.LCMSIDTB.Name = "LCMSIDTB";
            this.LCMSIDTB.Size = new System.Drawing.Size(132, 22);
            this.LCMSIDTB.TabIndex = 23;
            // 
            // mycotoxinsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 644);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.techniqueCB);
            this.Controls.Add(this.methodCB);
            this.Controls.Add(this.mycoWtTB);
            this.Controls.Add(this.OTATB);
            this.Controls.Add(this.AG2TB);
            this.Controls.Add(this.AG1TB);
            this.Controls.Add(this.AB2TB);
            this.Controls.Add(this.AB1TB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.sampleIDlbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dateLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iDlbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LCMSIDTB);
            this.Name = "mycotoxinsForm";
            this.Text = "mycotoxinsForm";
            this.Load += new System.EventHandler(this.mycotoxinsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.ComboBox techniqueCB;
        private System.Windows.Forms.ComboBox methodCB;
        private System.Windows.Forms.TextBox mycoWtTB;
        private System.Windows.Forms.TextBox OTATB;
        private System.Windows.Forms.TextBox AG2TB;
        private System.Windows.Forms.TextBox AG1TB;
        private System.Windows.Forms.TextBox AB2TB;
        private System.Windows.Forms.TextBox AB1TB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label sampleIDlbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label iDlbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LCMSIDTB;
    }
}