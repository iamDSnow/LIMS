using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LIMS_system_Prototype
{
    public partial class metalsForm : Form
    {
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;

        public metalsForm()
        {
            InitializeComponent();
        }
        // create Class to get and store text file information
        class SolventGC
        {
            public string AASID { get; set; }
            public string Arsenic { get; set; }
            public string Cadmium { get; set; }
            public string Lead { get; set; }
            public string Mercury { get; set; }


            //clear class when new file load
            public void Clear()
            {
                this.AASID = string.Empty;
                this.Arsenic = string.Empty;
                this.Cadmium = string.Empty;
                this.Lead = string.Empty;
                this.Mercury = string.Empty;

            }

        }

        private void metalsForm_Load(object sender, EventArgs e)
        {
            //Connects Cover Info

            sampleID_metals.Text = IndexForm.passSampleID;
            iDlbl_metals.Text = IndexForm.passID;
            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM metalsDATA WHERE ID =" + iDlbl_metals.Text, con);
            adapter.Fill(dt);
            showData(pos);
            methodCB_metals.SelectedIndex = 0;
            techniqueCB.SelectedIndex = 0;
        }
        public void showData(int index)
        {

            var a = 0;
            for (a = 0; a < dt.Rows.Count; a++)
            {

                sampleID_metals.Text = dt.Rows[index][1].ToString();
                aasIDTB.Text = dt.Rows[index][2].ToString();
                methodCB_metals.Text = dt.Rows[index][3].ToString();
                techniqueCB.Text = dt.Rows[index][4].ToString();
                metalsWeightTB.Text = dt.Rows[index][5].ToString();
                arsenicTB.Text = dt.Rows[index][6].ToString();
                cadmiumTB.Text = dt.Rows[index][7].ToString();
                leadTB.Text = dt.Rows[index][8].ToString();
                mercuryTB.Text = dt.Rows[index][9].ToString();

            }

        }
        private void Add(string SampleID, string AASID, string Method, string Technique, string MetalsWeight, string Arsenic, string Cadmium, string Lead, string Mercury)
        {
            //SQL  

            string sql = "INSERT INTO metalsDATA(SampleID,AASID,Method,Technique,MetalsWeight,Arsenic,Cadmium,Lead, Mercury) VALUES(@SAMPLEID,@AASID,@Method,@Technique,@MetalsWeight,@Arsenic,@Cadmium,@Lead,@Mercury)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SAMPLEID", SampleID);
            cmd.Parameters.AddWithValue("@AASID", AASID);
            cmd.Parameters.AddWithValue("@Method", Method);
            cmd.Parameters.AddWithValue("@Technique", Technique);
            cmd.Parameters.AddWithValue("@MetalsWeight", MetalsWeight);
            cmd.Parameters.AddWithValue("@Arsenic", Arsenic);
            cmd.Parameters.AddWithValue("@Cadmium", Cadmium);
            cmd.Parameters.AddWithValue("@Lead", Lead);
            cmd.Parameters.AddWithValue("@Mercury", Mercury);



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
        private void update(int IDnew, string SampleIDnew, string AASIDnew, string Methodnew, string Techniquenew, string MetalsWeightnew, string Arsenicnew, string Cadmiumnew, string Leadnew, string Mercurynew)
        {
            //SQL
            string sql = "UPDATE metalsDATA SET SampleID= '" + sampleID_metals.Text + "', AASID= '" + aasIDTB.Text + "', Method= '" + methodCB_metals.Text + "',Technique= '" + techniqueCB.Text + "',MetalsWeight='" + metalsWeightTB.Text + "',Arsenic= '" + arsenicTB.Text + "',Cadmium= '" + cadmiumTB.Text + "', Lead= '" + leadTB.Text + "', Mercury= '" + mercuryTB.Text + "' WHERE ID= " + iDlbl_metals.Text;
            cmd = new SqlCommand(sql, con);

            //UPDATE
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

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog5 = new OpenFileDialog
            {
                // Openfile Parameters
                InitialDirectory = "",
                Filter = "TEXT files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            //Open file & Load XML
            if (openFileDialog5.ShowDialog() == DialogResult.OK)
            {

                aasIDTB.Text = "0";
                metalsWeightTB.Text = "0";
                arsenicTB.Text = "0";
                cadmiumTB.Text = "0";
                leadTB.Text = "0";
                mercuryTB.Text = "0";

                StreamReader sr2 = new StreamReader(openFileDialog5.FileName, Encoding.Default);
                string[] line;
                line = sr2.ReadToEnd().Split('	');

                SolventGC sGC = new SolventGC();


                sGC.AASID = line[40];
                sGC.Arsenic = line[41];
                sGC.Cadmium = line[43];
                sGC.Lead = line[45];
                sGC.Mercury = line[47];

                if (sGC.AASID != null)
                {

                    aasIDTB.Text = sGC.AASID.ToString();

                }
                if (sGC.Arsenic != null)

                {

                    arsenicTB.Text = sGC.Arsenic.ToString();

                }

                if (sGC.Cadmium != null)
                {

                    cadmiumTB.Text = sGC.Cadmium.ToString();
                }
                if (sGC.Lead != null)
                {

                    leadTB.Text = sGC.Lead.ToString();

                }
                if (sGC.Mercury != null)
                {

                    mercuryTB.Text = sGC.Mercury.ToString();
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Add(sampleID_metals.Text,
                       aasIDTB.Text,
                       methodCB_metals.Text,
                       techniqueCB.Text,
                       metalsWeightTB.Text,
                       arsenicTB.Text,
                       cadmiumTB.Text,
                       leadTB.Text,
                       mercuryTB.Text);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(iDlbl_metals.Text);
            string SampleIDnew = sampleID_metals.Text;
            string AASIDnew = aasIDTB.Text;
            string Methodnew = methodCB_metals.Text;
            string Techniquenew = techniqueCB.Text;
            string MetalsWeightnew = metalsWeightTB.Text;
            string Arsenicnew = arsenicTB.Text;
            string Cadmiumnew = cadmiumTB.Text;
            string Leadnew = leadTB.Text;
            string Mercurynew = mercuryTB.Text;

            update(IDnew, SampleIDnew, AASIDnew, Methodnew, Techniquenew, MetalsWeightnew, Arsenicnew, Cadmiumnew, Leadnew, Mercurynew);

        }

        private void MetalsWeightTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ArsenicTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CadmiumTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void LeadTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MercuryTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }
    }
}
