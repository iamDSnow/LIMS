using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace LIMS_system_Prototype
{
    public partial class potencyForm : Form
    {
        //SQL connection
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;
        double cbdvAmount;
        double cbdAmount;
        double cbgAmount;
        double thcvAmount;
        double cbdaAmount;
        double cbgaAmount;
        double cbnAmount;
        double d9thcAmount;
        double d8thcAmount;
        double cbcAmount;
        double thcaAmount;

        public potencyForm()
        {
            InitializeComponent();
        }
      

        private void potencyForm_Load(object sender, EventArgs e)
        {
            //Connects Cover Info

            sampleID.Text = IndexForm.passSampleID;
            ID.Text = IndexForm.passID;
            customerlabel.Text = IndexForm.passCustomer;
            emaillabel.Text = IndexForm.passEmail;
            datelabel.Text = DateTime.Now.ToShortDateString();

            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM PotencyDATA WHERE ID =" + ID.Text, con);
            adapter.Fill(dt);
            showData(pos);
            //set box to first entry
            method.SelectedIndex = 0;
            test.SelectedIndex = 0;
        }


        public void showData(int index)
        {

            var a = 0;
            for (a = 0; a < dt.Rows.Count; a++)
            {


                potencyId.Text = dt.Rows[index][1].ToString();
                sampleID.Text = dt.Rows[index][2].ToString();
                cbdvtb.Text = dt.Rows[index][3].ToString();
                cbdtb.Text = dt.Rows[index][4].ToString();
                cbgtb.Text = dt.Rows[index][5].ToString();
                thcvtb.Text = dt.Rows[index][6].ToString();
                cbdatb.Text = dt.Rows[index][7].ToString();
                cbntb.Text = dt.Rows[index][8].ToString();
                cbgatb.Text = dt.Rows[index][9].ToString();
                d9thctb.Text = dt.Rows[index][10].ToString();
                d8thctb.Text = dt.Rows[index][11].ToString();
                thcatb.Text = dt.Rows[index][12].ToString();
                cbctb.Text = dt.Rows[index][13].ToString();
                dryWeight.Text = dt.Rows[index][14].ToString();
                hplcwieght.Text = dt.Rows[index][15].ToString();
                wetWeight.Text = dt.Rows[index][16].ToString();
                targetTHC.Text = dt.Rows[index][17].ToString();
                targetCBD.Text = dt.Rows[index][18].ToString();
                cbdvP.Text = dt.Rows[index][19].ToString();
                cbdP.Text = dt.Rows[index][20].ToString();
                cbgP.Text = dt.Rows[index][21].ToString();
                thcvP.Text = dt.Rows[index][22].ToString();
                cbdaP.Text = dt.Rows[index][23].ToString();
                cbnP.Text = dt.Rows[index][24].ToString();
                cbgaP.Text = dt.Rows[index][25].ToString();
                d9thcP.Text = dt.Rows[index][26].ToString();
                d8thcP.Text = dt.Rows[index][27].ToString();
                thcaP.Text = dt.Rows[index][28].ToString();
                cbcP.Text = dt.Rows[index][29].ToString();
                method.Text = dt.Rows[index][30].ToString();
                test.Text = dt.Rows[index][31].ToString();
                thcTotalTB.Text = dt.Rows[index][32].ToString();
                cbdTotalTB.Text = dt.Rows[index][33].ToString();

            }

        }
        //add value to SQL
        private void add(string SampleID, string PotencyID, string CBD, string CBDV, string CBG, string THCV, string CBDA, string D9THC, string D8THC, string CBN, string CBGA, string THCA, string CBC, string wetWeight, string dryWeight, string HPLCWeight, string targetCBD, string targetTHC, string CBDP, string CBDVP, string CBGP, string THCVP, string CBDAP, string D9THCP, string D8THCP, string CBNP, string CBGAP, string THCAP, string CBCP, string method, string test, string TotalTHC, string TotalCBD)
        {
            //SQL  

            string sql = "INSERT INTO PotencyDATA(SampleID,PotencyID,CBD,CBDV,CBG,THCV,CBDA,D9THC,D8THC,CBN,CBGA,THCA,CBC,wetWeight,dryWeight,HPLCWeight,targetCBD,targetTHC,CBDP,CBDVP,CBGP,THCVP,CBDAP,D9THCP,D8THCP,CBNP,CBGAP,THCAP,CBCP,METHOD,TEST,TotalTHC,TotalCBD) VALUES(@SAMPLEID,@POTENCYID,@CBD,@CBDV,@CBG,@THCV,@CBDA,@D9THC,@D8THC,@CBN,@CBGA,@THCA,@CBC,@WETWEIGHT,@DRYWEIGHT,@HPLCWEIGHT,@TARGETCBD,@TARGETTHC,@CBDP,@CBDVP,@CBGP,@THCVP,@CBDAP,@D9THCP,@D8THCP,@CBNP,@CBGAP,@THCAP,@CBCP,@METHOD,@TEST,@TotalTHC,@TotalCBD)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SAMPLEID", SampleID);
            cmd.Parameters.AddWithValue("@POTENCYID", PotencyID);
            cmd.Parameters.AddWithValue("@CBD", CBD);
            cmd.Parameters.AddWithValue("@CBDV", CBDV);
            cmd.Parameters.AddWithValue("@CBG", CBG);
            cmd.Parameters.AddWithValue("@THCV", THCV);
            cmd.Parameters.AddWithValue("@CBDA", CBDA);
            cmd.Parameters.AddWithValue("@D9THC", D9THC);
            cmd.Parameters.AddWithValue("@D8THC", D8THC);
            cmd.Parameters.AddWithValue("@CBN", CBN);
            cmd.Parameters.AddWithValue("@CBGA", CBGA);
            cmd.Parameters.AddWithValue("@THCA", THCA);
            cmd.Parameters.AddWithValue("@CBC", CBC);
            cmd.Parameters.AddWithValue("@WETWEIGHT", wetWeight);
            cmd.Parameters.AddWithValue("@DRYWEIGHT", dryWeight);
            cmd.Parameters.AddWithValue("@HPLCWEIGHT", HPLCWeight);
            cmd.Parameters.AddWithValue("@TARGETCBD", targetCBD);
            cmd.Parameters.AddWithValue("@TARGETTHC", targetTHC);
            cmd.Parameters.AddWithValue("@CBDP", CBDP);
            cmd.Parameters.AddWithValue("@CBDVP", CBDVP);
            cmd.Parameters.AddWithValue("@CBGP", CBGP);
            cmd.Parameters.AddWithValue("@THCVP", THCVP);
            cmd.Parameters.AddWithValue("@CBDAP", CBDAP);
            cmd.Parameters.AddWithValue("@D9THCP", D9THCP);
            cmd.Parameters.AddWithValue("@D8THCP", D8THCP);
            cmd.Parameters.AddWithValue("@CBNP", CBNP);
            cmd.Parameters.AddWithValue("@CBGAP", CBGAP);
            cmd.Parameters.AddWithValue("@THCAP", THCAP);
            cmd.Parameters.AddWithValue("@CBCP", CBCP);
            cmd.Parameters.AddWithValue("@METHOD", method);
            cmd.Parameters.AddWithValue("@TEST", test);
            cmd.Parameters.AddWithValue("@TotalTHC", TotalTHC);
            cmd.Parameters.AddWithValue("@TotalCBD", TotalCBD);



            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Inserted");
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void update(int IDnew, string SampleIDnew, string PotencyIDnew, string CBDVnew, string CBDnew, string CBGnew, string THCVnew, string CBDAnew, string D9THCnew, string D8THCnew, string CBNnew, string CBGAnew, string THCAnew, string CBCnew, string wetWeightnew, string dryWeightnew, string HPLCWeightnew, string targetCBDnew, string targetTHCnew, string CBDPnew, string CBDVPnew, string CBGPnew, string THCVPnew, string CBDAPnew, string D9THCPnew, string D8THCPnew, string CBNPnew, string CBGAPnew, string THCAPnew, string CBCPnew, string methodnew, string testnew, string TotalTHCnew, string TotalCBDnew)
        {
            //SQL
            string sql = "UPDATE PotencyDATA SET SampleId= '" + sampleID.Text + "',PotencyID= '" + potencyId.Text + "', CBDV= '" + cbdvtb.Text + "', CBD= '" + cbdtb.Text + "',CBG='" + cbgtb.Text + "',THCV= '" + thcvtb.Text + "', CBDA= '" + cbdatb.Text + "', CBN= '" + cbntb.Text + "', CBGA= '" + cbgatb.Text + "', D9THC= '" + d9thctb.Text + "',D8THC= '" + d8thctb.Text + "',THCA='" + thcatb.Text + "',CBC= '" + cbctb.Text + "', DRYWEIGHT= '" + dryWeight.Text + "',HPLCWEIGHT= '" + hplcwieght.Text + "', WETWEIGHT= '" + wetWeight.Text + "', targetTHC= '" + targetTHC.Text + "', targetCBD= '" + targetCBD.Text + "', CBDVP= '" + cbdvP.Text + "',CBDP='" + cbdP.Text + "',CBGP= '" + cbgP.Text + "', THCVP= '" + thcvP.Text + "',CBDAP= '" + cbdaP.Text + "',CBNP='" + cbnP.Text + "',CBGAP= '" + cbgaP.Text + "', D9THCP= '" + d9thcP.Text + "', D8THCP= '" + d8thcP.Text + "', THCAP= '" + thcaP.Text + "',CBCP= '" + cbcP.Text + "', METHOD= '" + method.Text + "', TEST= '" + test.Text + "', TotalTHC= '" + thcTotalTB.Text + "', TotalCBD= '" + cbdTotalTB.Text + "' WHERE ID= " + ID.Text;
            cmd = new SqlCommand(sql, con);

            //OPEN CON, RETRIEVE FILL ListView
            try
            {
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {

                    MessageBox.Show("Successfull Updated");
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


        //Open file


        private void openbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                // Openfile Parameters
                InitialDirectory = "C:\\ ",
                Filter = "Xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true

            };
            //Open file & Load XML

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {

                cbdtb.Text = "0";
                cbdvtb.Text = "0";
                cbgtb.Text = "0";
                cbdatb.Text = "0";
                thcvtb.Text = "0";
                d9thctb.Text = "0";
                d8thctb.Text = "0";
                thcatb.Text = "0";
                cbntb.Text = "0";
                cbctb.Text = "0";
                cbgatb.Text = "0";
                cbdP.Text = "0";
                cbdvP.Text = "0";
                cbgP.Text = "0";
                cbdaP.Text = "0";
                thcvP.Text = "0";
                d9thcP.Text = "0";
                d8thcP.Text = "0";
                thcaP.Text = "0";
                cbnP.Text = "0";
                cbcP.Text = "0";
                cbgaP.Text = "0";


                StreamReader sr = new StreamReader(openFileDialog2.FileName, System.Text.Encoding.Default);

                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.Load(sr);

                //Save XML to Node

                XmlNode cbdv = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBDV']//Amount");
                XmlNode cbd = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBD']//Amount");
                XmlNode cbg = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBG']//Amount");
                XmlNode cbga = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBGA']//Amount");
                XmlNode cbda = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBDA']//Amount");
                XmlNode thcv = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='THCV']//Amount");
                XmlNode d9thc = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='D9THC']//Amount");
                XmlNode d8thc = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='D8THC']//Amount");
                XmlNode thca = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='THCA']//Amount");
                XmlNode cbn = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBN']//Amount");
                XmlNode cbc = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='CBC']//Amount");

                //Display Potency info if not NULL
                
                    if (cbd != null)
                    {
                        double cbddec = Math.Round(double.Parse(cbd.InnerText), 3);
                        cbdtb.Text = cbddec.ToString();

                        cbdAmount = (cbddec * .00022) / double.Parse(hplcwieght.Text);
                        cbdP.Text = cbdAmount.ToString("N5");
                    }


                    if (cbdv != null)

                    {
                        double cbdvdec = Math.Round(double.Parse(cbdv.InnerText), 3);
                        cbdvtb.Text = cbdvdec.ToString();


                        cbdvAmount = (cbdvdec * .00022) / double.Parse(hplcwieght.Text);
                        cbdvP.Text = cbdvAmount.ToString("N5");
                    }


                    if (cbg != null)

                    {
                        double cbgdec = Math.Round(double.Parse(cbg.InnerText), 3);
                        cbgtb.Text = cbgdec.ToString();


                        cbgAmount = (double.Parse(cbg.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        cbgP.Text = cbgAmount.ToString("N5");

                    }

                    if (cbga != null)
                    {
                        double cbgadec = Math.Round(double.Parse(cbga.InnerText), 3);
                        cbgatb.Text = cbgadec.ToString();


                        cbgaAmount = (double.Parse(cbga.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        cbgaP.Text = cbgaAmount.ToString("N5");

                    }

                    if (thcv != null)
                    {
                        double thcvdec = Math.Round(double.Parse(thcv.InnerText), 3);
                        thcvtb.Text = thcvdec.ToString();



                        thcvAmount = (double.Parse(thcv.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        thcvP.Text = thcvAmount.ToString("N5");
                    }

                    if (cbda != null)
                    {
                        double cbdadec = Math.Round(double.Parse(cbda.InnerText), 3);
                        cbdatb.Text = cbdadec.ToString();



                        cbdaAmount = (double.Parse(cbda.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        cbdaP.Text = cbdaAmount.ToString("N5");

                    }


                    if (cbn != null)
                    {
                        double cbndec = Math.Round(double.Parse(cbn.InnerText), 3);
                        cbntb.Text = cbndec.ToString();

                        cbnAmount = (double.Parse(cbn.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        cbnP.Text = cbnAmount.ToString("N5");

                    }
                    if (d9thc != null)
                    {
                        double d9thcdec = Math.Round(double.Parse(d9thc.InnerText), 3);
                        d9thctb.Text = d9thcdec.ToString();

                        d9thcAmount = (double.Parse(d9thc.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        d9thcP.Text = d9thcAmount.ToString("N5");

                    }
                    if (d8thc != null)
                    {
                        double d8thcdec = Math.Round(double.Parse(d8thc.InnerText), 3);
                        d8thctb.Text = d8thcdec.ToString();

                        d8thcAmount = (double.Parse(d8thc.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        d8thcP.Text = d8thcAmount.ToString("N5");
                    }

                    if (cbc != null)
                    {
                        double cbcdec = Math.Round(double.Parse(cbc.InnerText), 3);
                        cbctb.Text = cbcdec.ToString();



                        cbcAmount = (double.Parse(cbc.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        cbcP.Text = cbcAmount.ToString("N5");

                    }

                    if (thca != null)
                    {
                        double thcadec = Math.Round(double.Parse(thca.InnerText), 3);
                        thcatb.Text = thcadec.ToString();

                        thcaAmount = (double.Parse(thca.InnerText) * .00022) / double.Parse(hplcwieght.Text);
                        thcaP.Text = thcaAmount.ToString("N5");

                    }

                    double totalCBD = (cbdAmount + cbdvAmount + cbdaAmount);
                    double totalTHC = (d9thcAmount + thcvAmount + cbnAmount + d8thcAmount + thcaAmount);

                    cbdTotalTB.Text = totalCBD.ToString("N4");
                    thcTotalTB.Text = totalTHC.ToString("N4");

            }
               
        }

        
        private void WetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }



        }

        private void DryWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Hplcwieght_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void WetWeight_Leave(object sender, EventArgs e)
        {
            //Format decimal on exit textbox
            wetWeight.Text = string.Format("{0:#0.##0}", double.Parse(wetWeight.Text));
        }

        private void DryWeight_Leave(object sender, EventArgs e)
        {   //Format decimal on exit textbox
            dryWeight.Text = string.Format("{0:#0.##0}", double.Parse(dryWeight.Text));
        }

        private void Hplcwieght_Leave(object sender, EventArgs e)
        {   //Format decimal on exit textbox
            hplcwieght.Text = string.Format("{0:#0.##0}", double.Parse(hplcwieght.Text));
        }

        private void TargetTHC_KeyPress(object sender, KeyPressEventArgs e)
        {

            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void TargetCBD_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbdvtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbdtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbgtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Thcvtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbdatb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbgatb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbntb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void D9thctb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void D8thctb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void Cbctb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }


        private void ThcaP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbdvP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbdP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbgP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ThcvP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbdaP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbgaP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbnP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void D9thcP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void D8thcP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CbcP_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            add(potencyId.Text, sampleID.Text, cbdtb.Text, cbdvtb.Text, cbgtb.Text, thcvtb.Text, cbdatb.Text, d9thctb.Text, d8thctb.Text, cbntb.Text, cbgatb.Text, thcatb.Text, cbctb.Text, wetWeight.Text, dryWeight.Text, hplcwieght.Text, targetTHC.Text, targetCBD.Text, cbdP.Text, cbdvP.Text, cbgP.Text, thcvP.Text, cbdaP.Text, d9thcP.Text, d8thcP.Text, cbnP.Text, cbgaP.Text, thcaP.Text, cbcP.Text, method.Text, test.Text, thcTotalTB.Text, cbdTotalTB.Text);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {

            // adds textbox entries to SQL database          \
            Close();
        }

        private void updateBtn_pot_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(ID.Text);
            string SampleIDnew = sampleID.Text;
            string PotencyIDnew = potencyId.Text;
            string CBDVnew = cbdvtb.Text;
            string CBDnew = cbdtb.Text;
            string CBGnew = cbgtb.Text;
            string THCVnew = thcvtb.Text;
            string CBDAnew = cbdatb.Text;
            string CBNnew = cbntb.Text;
            string CBGAnew = cbgatb.Text;
            string D9THCnew = d9thctb.Text;
            string D8THCnew = d8thctb.Text;
            string THCAnew = thcatb.Text;
            string CBCnew = cbctb.Text;
            string dryWeightnew = dryWeight.Text;
            string HPLCWeightnew = hplcwieght.Text;
            string wetWeightnew = wetWeight.Text;
            string targetTHCnew = targetTHC.Text;
            string targetCBDnew = targetCBD.Text;
            string CBDVPnew = cbdvP.Text;
            string CBDPnew = cbdP.Text;
            string CBGPnew = cbgP.Text;
            string THCVPnew = thcvP.Text;
            string CBDAPnew = cbdaP.Text;
            string CBNPnew = cbnP.Text;
            string CBGAPnew = cbgaP.Text;
            string D9THCPnew = d9thcP.Text;
            string D8THCPnew = d8thcP.Text;
            string THCAPnew = thcaP.Text;
            string CBCPnew = cbcP.Text;
            string methodnew = method.Text;
            string testnew = test.Text;
            string TotalTHCnew = thcTotalTB.Text;
            string TotalCBDnew = cbdTotalTB.Text;


            update(IDnew, SampleIDnew, PotencyIDnew, CBDVnew, CBDnew, CBGnew, THCVnew, CBDAnew, CBNnew, CBGAnew, D9THCnew, D8THCnew, THCAnew, CBCnew, dryWeightnew, HPLCWeightnew, wetWeightnew, targetTHCnew, targetCBDnew, CBDVPnew, CBDPnew, CBGPnew, THCVPnew, CBDAPnew, CBNPnew, CBGAPnew, D9THCPnew, D8THCPnew, THCAPnew, CBCPnew, methodnew, testnew, TotalTHCnew, TotalCBDnew);


            if (cbdvtb.Text != null)
            {
                double cbdvdec = Math.Round(double.Parse(cbdvtb.Text), 3);
                double cbdvAmount = (cbdvdec * .00022) / double.Parse(hplcwieght.Text);
                cbdvP.Text = cbdvAmount.ToString("N5");
            }


            if (cbdtb.Text != null)

            {
                double cbddec = Math.Round(double.Parse(cbdtb.Text), 3);
                double cbdAmount = (cbddec * .00022) / double.Parse(hplcwieght.Text);
                cbdP.Text = cbdAmount.ToString("N5");
            }


            if (cbgtb.Text != null)

            {
                double cbgdec = Math.Round(double.Parse(cbgtb.Text), 3);
                double cbgAmount = (cbgdec * .00022) / double.Parse(hplcwieght.Text);
                cbgP.Text = cbgAmount.ToString("N5");

            }

            if (thcvtb.Text != null)
            {
                double thcvdec = Math.Round(double.Parse(thcvtb.Text), 3);
                double thcvAmount = (thcvdec * .00022) / double.Parse(hplcwieght.Text);
                thcvP.Text = thcvAmount.ToString("N5");

            }


            if (cbdatb.Text != null)
            {
                double cbdadec = Math.Round(double.Parse(cbdatb.Text), 3);
                double cbdaAmount = (cbdadec * .00022) / double.Parse(hplcwieght.Text);
                cbdaP.Text = cbdaAmount.ToString("N5");
            }

            if (cbntb.Text != null)
            {
                double cbndec = Math.Round(double.Parse(cbntb.Text), 3);
                double cbnAmount = (cbndec * .00022) / double.Parse(hplcwieght.Text);
                cbnP.Text = cbnAmount.ToString("N5");

            }


            if (cbgatb.Text != null)
            {
                double cbgadec = Math.Round(double.Parse(cbgatb.Text), 3);
                double cbgaAmount = (cbgadec * .00022) / double.Parse(hplcwieght.Text);
                cbgaP.Text = cbgaAmount.ToString("N5");

            }
            if (d9thctb.Text != null)
            {
                double d9thcdec = Math.Round(double.Parse(d9thctb.Text), 3);
                double d9thcAmount = (d9thcdec * .00022) / double.Parse(hplcwieght.Text);
                d9thcP.Text = d9thcAmount.ToString("N5");

            }
            if (d8thctb.Text != null)
            {
                double d8thcdec = Math.Round(double.Parse(d8thctb.Text), 3);
                double d8thcAmount = (d8thcdec * .00022) / double.Parse(hplcwieght.Text);
                d8thcP.Text = d8thcAmount.ToString("N5");
            }

            if (cbctb.Text != null)
            {
                double cbcdec = Math.Round(double.Parse(cbctb.Text), 3);
                double cbcAmount = (cbcdec * .00022) / double.Parse(hplcwieght.Text);
                cbcP.Text = cbcAmount.ToString("N5");


            }

            if (thcatb.Text != null)
            {
                double thcadec = Math.Round(double.Parse(thcatb.Text), 3);
                double thcaAmount = (thcadec * .00022) / double.Parse(hplcwieght.Text);
                thcaP.Text = thcaAmount.ToString("N5");

            }
        }
    }

}
