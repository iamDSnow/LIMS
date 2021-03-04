using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace LIMS_system_Prototype
{
    public partial class IndexForm : Form
    {
       
        // need information to pass to other forms 
        public static string passID;
        public static string passCustomer;
        public static string passEmail;
        public static string passSampleID;
        public static string passDate;
       
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;


        
        public IndexForm()
        {
            InitializeComponent();
        }
  

        // Add Information to Database
        private void add(string date, string SAMPLEID, string chemist, string customer, string email, string sampleName, string sampleType, string distributor, string producer, string sampleDate, string location, string batchID, string batchSize, string sampleSize, string remarks, string SampleImage)
        {
              //SQL  

            string sql = "INSERT INTO indexDATA(DATE,SAMPLEID, CHEMIST, CUSTOMER,EMAIL, SAMPLENAME,SAMPLETYPE,DISTRIBUTOR,PRODUCER,SAMPLEDATE,LOCATION,BATCHID,BATCHSIZE,SAMPLESIZE, Remarks,SampleImage) VALUES(@DATE,@SAMPLEID,@CHEMIST,@CUSTOMER,@EMAIL,@SAMPLENAME,@SAMPLETYPE,@DISTRIBUTOR,@PRODUCER,@SAMPLEDATE,@LOCATION,@BATCHID,@BATCHSIZE,@SAMPLESIZE, @Remarks,@img)";

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Please insert a image");
            }

            else
            {
                Image img = null;
                img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr =(byte[])converter.ConvertTo(img, typeof(byte[]));


                try
                {
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@DATE", date);
                    cmd.Parameters.AddWithValue("@SAMPLEID", SAMPLEID);
                    cmd.Parameters.AddWithValue("@CHEMIST", chemist);
                    cmd.Parameters.AddWithValue("@CUSTOMER", customer);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SAMPLENAME", sampleName);
                    cmd.Parameters.AddWithValue("@SAMPLETYPE", sampleType);
                    cmd.Parameters.AddWithValue("@DISTRIBUTOR", distributor);
                    cmd.Parameters.AddWithValue("@PRODUCER", producer);
                    cmd.Parameters.AddWithValue("@SAMPLEDATE", sampleDate);
                    cmd.Parameters.AddWithValue("@LOCATION", location);
                    cmd.Parameters.AddWithValue("@BATCHID", batchID);
                    cmd.Parameters.AddWithValue("@BATCHSIZE", batchSize);
                    cmd.Parameters.AddWithValue("@SAMPLESIZE", sampleSize);
                    cmd.Parameters.AddWithValue("@Remarks", remarks);
                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = arr;

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
        }

        private void update(int IDnew, string DATEnew, string SampleIdnew, string CHEMISTnew, string CUSTOMERnew, string EMAILnew, string SAMPLENAMEnew, string SAMPLETYPEnew, string DISTRIBUTORnew, string PRODUCERnew, string SAMPLEDATEnew, string LOCATIONnew, string BATCHIDnew, string BATCHSIZEnew, string SAMPLESIZEnew, string SampleImagenew, string Remarksnew)
        {
            
            //SQL
            string sql = "UPDATE indexDATA SET SAMPLEID= '" + sampleID.Text + "', CHEMIST= '" + chemist.Text + "', CUSTOMER= '" + customerName.Text + "',EMAIL= '" + customerEmail.Text + "',SAMPLENAME='" + sampleName.Text + "',SAMPLETYPE= '" + sampleType.Text + "',DISTRIBUTOR= '" + distributor.Text + "', PRODUCER= '" + producer.Text + "', SAMPLEDATE= '" + sampleDate.Text + "',LOCATION= '" + location.Text + "',BATCHID='" + batchID.Text + "',BATCHSIZE= '" + batchSize.Text + "',SAMPLESIZE= '" + sampleSize.Text + "',Remarks= '" + remarksTB.Text + "',SampleImage= @img WHERE ID= " + iD.Text;


            Image img = null;
            img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@img", SqlDbType.Image).Value = arr;

            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Updated");
                }
                con.Close();


                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

       
        private void potencyEntryButton_Click_1(object sender, EventArgs e)
        {
            //Open Potency Input Menu 
            
            passID = iD.Text.ToString();
            passCustomer = customerName.Text.ToString();
            passSampleID = sampleID.Text.ToString();
            passEmail = customerEmail.Text.ToString();
            //passDate = date.Text.ToString();

            potencyForm potForm = new potencyForm();
            potForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                // Openfile Parameters
                InitialDirectory = "",
                Filter = "*Choose a photo(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif",

                FilterIndex = 2,
                RestoreDirectory = true,
                Title = " Select Sample Photo"
              
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //imgLoc = openFileDialog1.FileName.ToString();
                //pictureBox1.ImageLocation = imgLoc;


            }
        }

        private void cusomerList_Click(object sender, EventArgs e)
        {
            //Open CustomerList Menu

            customersList F2 = new customersList();

            F2.Show();
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fullDATASET.customerDATA' table. You can move, or remove it, as needed.
            this.customerDATATableAdapter.Fill(this.fullDATASET.customerDATA);
            // TODO: This line of code loads data into the 'fullDATASET.indexDATA' table. You can move, or remove it, as needed.
            this.indexDATATableAdapter.Fill(this.fullDATASET.indexDATA);
            currentDate.Text = DateTime.Now.Date.ToLongDateString();
            currentTime.Text = DateTime.Now.ToShortTimeString();
            date.Text = DateTime.Now.Date.ToShortDateString();

            //SQL Load
            loaddata();
            
        }
        void loaddata()
        {
            adapter = new SqlDataAdapter("SELECT * FROM indexDATA", con);
            adapter.Fill(dt);
            showData(pos); 
            
        }
        public void showData(int index)
        {
            
            foreach (DataRow row in dt.Rows)
            {
                DateTime dFormat = Convert.ToDateTime(dt.Rows[index][1].ToString());
                DateTime sDateFormat = Convert.ToDateTime(dt.Rows[index][10].ToString());
               
                
                
                iD.Text = dt.Rows[index][0].ToString();
                date.Text = dFormat.ToString("MM/dd/yyyy");
                sampleID.Text = dt.Rows[index][2].ToString();
                chemist.Text = dt.Rows[index][3].ToString();
                customerName.Text = dt.Rows[index][4].ToString();
                customerEmail.Text = dt.Rows[index][5].ToString();
                sampleName.Text = dt.Rows[index][6].ToString();
                sampleType.Text = dt.Rows[index][7].ToString();
                distributor.Text = dt.Rows[index][8].ToString();
                producer.Text = dt.Rows[index][9].ToString();
                sampleDate.Text = sDateFormat.ToString("MM/dd/yyyy");
                location.Text = dt.Rows[index][11].ToString();
                batchID.Text = dt.Rows[index][12].ToString();
                batchSize.Text = dt.Rows[index][13].ToString();
                sampleSize.Text = dt.Rows[index][14].ToString();
                remarksTB.Text = dt.Rows[index][15].ToString();
                








                //Image pic = Base64toImage(imag);
                //pic = Image.FromStream(ms);
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                //string imag = dt.Rows[index][16].ToString();

            }
            

        }

        private void pestbtn_Click(object sender, EventArgs e)
        {
            pesticideForm pestform = new pesticideForm();
            pestform.Show();
        }

        private void solventbtn_Click(object sender, EventArgs e)
        {
            solventForm solvform = new solventForm();
            solvform.Show();
        }

        private void metalbtn_Click(object sender, EventArgs e)
        {
            metalsForm metals = new metalsForm();
            metals.Show();
        }

        private void microbialbtn_Click(object sender, EventArgs e)
        {
            microbialForm micro = new microbialForm();
            micro.Show();
        }

        private void mycotoxinbtn_Click(object sender, EventArgs e)
        {
            mycotoxinsForm myco = new mycotoxinsForm();
            myco.Show();
        }

        private void waterActbtn_Click(object sender, EventArgs e)
        {
            waterActivityForm Aw = new waterActivityForm();
            Aw.Show();
        }

        private void terpenebtn_Click(object sender, EventArgs e)
        {
            terpenesForm terps = new terpenesForm();
            terps.Show();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            add(date.Text, sampleID.Text, chemist.Text, customerName.Text, customerEmail.Text, sampleName.Text, sampleType.Text, distributor.Text, producer.Text, sampleDate.Text, location.Text, batchID.Text, batchSize.Text, sampleSize.Text, remarksTB.Text, pictureBox1.Name);

            


        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            


        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
           


        }

        private void UpdateStripButton_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(iD.Text);
            string DATEnew = date.Text;
            string SampleIdnew = sampleID.Text;
            string CHEMISTnew = chemist.Text;
            string CUSTOMERnew = customerName.Text;
            string EMAILnew = customerEmail.Text;
            string SAMPLENAMEnew = sampleName.Text;
            string SAMPLETYPEnew = sampleType.Text;
            string DISTRIBUTORnew = distributor.Text;
            string PRODUCERnew = producer.Text;
            string SAMPLEDATEnew = sampleDate.Text;
            string LOCATIONnew = location.Text;
            string BATCHIDnew = batchID.Text;
            string BATCHSIZEnew = batchSize.Text;
            string SAMPLESIZEnew = sampleSize.Text;
            string Remarksnew = remarksTB.Text;
            string SampleImagenew = pictureBox1.Name;

            update(IDnew, DATEnew, SampleIdnew, CHEMISTnew, CUSTOMERnew, EMAILnew, SAMPLENAMEnew, SAMPLETYPEnew, DISTRIBUTORnew, PRODUCERnew, SAMPLEDATEnew, LOCATIONnew, BATCHIDnew, BATCHSIZEnew, SAMPLESIZEnew, Remarksnew, SampleImagenew);
        }

        private void Report_Click(object sender, EventArgs e)
        {
            potencyViewerInhalable potInhalableView = new potencyViewerInhalable();
            potInhalableView.Show();
        }

        private void potencyNonReport_Click(object sender, EventArgs e)
        {
            potencyViewerNonInhalable potNonInhalableView = new potencyViewerNonInhalable();
            potNonInhalableView.Show();
        }

        private void potencyOtherReport_Click(object sender, EventArgs e)
        {
            potencyViewerOther potOtherView = new potencyViewerOther();
            potOtherView.Show();

        }

        private void pesticidesReport_Click(object sender, EventArgs e)
        {
            pestiViewerInhalable pestiInhaleView = new pestiViewerInhalable();
            pestiInhaleView.Show();
        }

        private void pesticideNonReport_Click(object sender, EventArgs e)
        {
            pestiViewerNonInhalable pestiNonInhaleView = new pestiViewerNonInhalable();
            pestiNonInhaleView.Show();
        }

        private void solventsReport_Click(object sender, EventArgs e)
        {
            solventViewerInhalable solventInhaleView = new solventViewerInhalable();
            solventInhaleView.Show();
        }

        private void solventNonReport_Click(object sender, EventArgs e)
        {
            solventViewerNonInhalable solventNonInhaleView = new solventViewerNonInhalable();
            solventNonInhaleView.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            solventViewerOther solventOtherView = new solventViewerOther();
            solventOtherView.Show();
        }

        private void metalsInhalableBtn_Click(object sender, EventArgs e)
        {
            metalsViewerInhalable metalsInhaleView = new metalsViewerInhalable();
            metalsInhaleView.Show();
        }

        private void metalsOtherReport_Click(object sender, EventArgs e)
        {
            metalsViewerOther metalsOtherView = new metalsViewerOther();
            metalsOtherView.Show();
        }

        private void microbialInhalableReport_Click(object sender, EventArgs e)
        {
            microbialViewerInhalable microbialInhaleView = new microbialViewerInhalable();
            microbialInhaleView.Show();
        }

        private void microNonReport_Click(object sender, EventArgs e)
        {
            microbialNonInhalableReport microbialNonInhaleView = new microbialNonInhalableReport();
            microbialNonInhaleView.Show();
        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
           mycotoxinsViewer mycotoxinsView = new mycotoxinsViewer();
            mycotoxinsView.Show();
        }

        private void waFlowerReport_Click(object sender, EventArgs e)
        {
           aWFlowerReport AWReportView = new aWFlowerReport();
            AWReportView.Show();
        }

        private void waEdibleReport_Click(object sender, EventArgs e)
        {
            wAEdibleReportViewer wADReport = new wAEdibleReportViewer();
            wADReport.Show();
        }

        private void terpenesReport_Click(object sender, EventArgs e)
        {
            terpeneViewer terpViewer = new terpeneViewer();
            terpViewer.Show();
        }

        private void inhaleBCCReport_Click(object sender, EventArgs e)
        {
            complianceReportViewer comReport = new complianceReportViewer();
            comReport.Show();
        }
    }
}
