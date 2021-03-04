using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LIMS_system_Prototype
{
    public partial class mycotoxinsForm : Form
    {
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;

        public mycotoxinsForm()
        {
            InitializeComponent();
        }

        private void mycotoxinsForm_Load(object sender, EventArgs e)
        {
            //Connects Cover Info

            sampleIDlbl.Text = IndexForm.passSampleID;
            iDlbl.Text = IndexForm.passID;
            dateLbl.Text = IndexForm.passDate;
            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM mycotoxinsDATA WHERE ID =" + iDlbl.Text, con);
            adapter.Fill(dt);
            showData(pos);
            methodCB.SelectedIndex = 0;
            techniqueCB.SelectedIndex = 0;
        }
        public void showData(int index)
        {

            var a = 0;
            for (a = 0; a < dt.Rows.Count; a++)
            {

                dateLbl.Text = dt.Rows[index][1].ToString();
                sampleIDlbl.Text = dt.Rows[index][2].ToString();
                methodCB.Text = dt.Rows[index][3].ToString();
                techniqueCB.Text = dt.Rows[index][4].ToString();
                LCMSIDTB.Text = dt.Rows[index][5].ToString();
                mycoWtTB.Text = dt.Rows[index][6].ToString();
                AB1TB.Text = dt.Rows[index][7].ToString();
                AB2TB.Text = dt.Rows[index][8].ToString();
                AG1TB.Text = dt.Rows[index][9].ToString();
                AG2TB.Text = dt.Rows[index][10].ToString();
                OTATB.Text = dt.Rows[index][11].ToString();


            }
        }

        //add value to SQL
        private void Add(string Date, string SampleID, string Method, string Technique, string LCMSID, string MycoWeight, string AB1, string AB2, string AG1, string AG2, string OTA)
        {
            //SQL  

            string sql = "INSERT INTO mycotoxinsDATA(Date,SampleID,Method,Technique,LCMSID,MycoWeight,AB1,AB2,AG1,AG2,OTA) VALUES(@Date,@SAMPLEID,@Method,@Technique,@LCMSID,@MycoWeight,@AB1,@AB2,@AG1,@AG2,@OTA)";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@SAMPLEID", SampleID);
            cmd.Parameters.AddWithValue("@Method", Method);
            cmd.Parameters.AddWithValue("@Technique", Technique);
            cmd.Parameters.AddWithValue("@LCMSID", LCMSID);
            cmd.Parameters.AddWithValue("@MycoWeight", MycoWeight);
            cmd.Parameters.AddWithValue("@AB1", AB1);
            cmd.Parameters.AddWithValue("@AB2", AB2);
            cmd.Parameters.AddWithValue("@AG1", AG1);
            cmd.Parameters.AddWithValue("@AG2", AG2);
            cmd.Parameters.AddWithValue("@OTA", OTA);




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
        private void update(int IDnew, string SampleIDnew, string Methodnew, string Techniquenew, string LCMSIDnew, string MycoWeightnew, string AB1new, string AB2new, string AG1new, string AG2new, string OTAnew)
        {
            //SQL
            string sql = "UPDATE mycotoxinsDATA SET SampleID= '" + sampleIDlbl.Text + "', Method= '" + methodCB.Text + "', Technique= '" + techniqueCB.Text + "',LCMSID= '" + LCMSIDTB.Text + "',MycoWeight='" + mycoWtTB.Text + "',AB1= '" + AB1TB.Text + "',AB2= '" + AB2TB.Text + "', AG1= '" + AG1TB.Text + "', AG2= '" + AG2TB.Text + "', OTA= '" + OTATB.Text + "' WHERE ID= " + iDlbl.Text;
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
            OpenFileDialog openFileDialog3 = new OpenFileDialog
            {
                // Openfile Parameters
                InitialDirectory = "",
                Filter = "Xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Add(dateLbl.Text,
                        sampleIDlbl.Text,
                        methodCB.Text,
                        techniqueCB.Text,
                        LCMSIDTB.Text,
                        mycoWtTB.Text,
                        AB1TB.Text,
                        AB2TB.Text,
                        AG1TB.Text,
                        AG2TB.Text,
                        OTATB.Text);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(iDlbl.Text);
            string SampleIDnew = sampleIDlbl.Text;
            string Methodnew = methodCB.Text;
            string Techniquenew = techniqueCB.Text;
            string LCMSIDnew = LCMSIDTB.Text;
            string MycoWeightnew = mycoWtTB.Text;
            string AB1new = AB1TB.Text;
            string AB2new = AB2TB.Text;
            string AG1new = AG1TB.Text;
            string AG2new = AG2TB.Text;
            string OTAnew = OTATB.Text;

            update(IDnew, SampleIDnew, Methodnew, Techniquenew, LCMSIDnew, MycoWeightnew, AB1new, AB2new, AG1new, AG2new, OTAnew);
        }
        private void MycoWtTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AB1TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AB2TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AG1TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AG2TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void OTATB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }
    }
}
