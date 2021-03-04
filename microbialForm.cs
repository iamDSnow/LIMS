using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace LIMS_system_Prototype
{
    public partial class microbialForm : Form
    {
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;

        public microbialForm()
        {
            InitializeComponent();
        }

        private void microbialForm_Load(object sender, EventArgs e)
        {
            //Connects Cover Info

            sampleIDlbl_micro.Text = IndexForm.passSampleID;
            idLbl_micro.Text = IndexForm.passID;
            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM microbialDATA WHERE ID =" + idLbl_micro.Text, con);
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

                sampleIDlbl_micro.Text = dt.Rows[index][1].ToString();
                methodCB.Text = dt.Rows[index][2].ToString();
                techniqueCB.Text = dt.Rows[index][3].ToString();
                microWeightTB.Text = dt.Rows[index][4].ToString();
                aspergillusTB.Text = dt.Rows[index][5].ToString();
                shigaToxinTB.Text = dt.Rows[index][6].ToString();
                salmonellaTB.Text = dt.Rows[index][7].ToString();


            }
        }

        //add value to SQL
        private void Add(string SampleID, string Method, string Technique, string MicrobialWeight, string Aspergillus, string ShigaToxin, string Salmonella)
        {
            //SQL  

            string sql = "INSERT INTO microbialDATA(SampleID,Method,Technique,MicrobialWeight,Aspergillus,ShigaToxin,Salmonella) VALUES(@SAMPLEID,@Method,@Technique,@MicrobialWeight,@Aspergillus,@ShigaToxin,@Salmonella)";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SAMPLEID", SampleID);
            cmd.Parameters.AddWithValue("@Method", Method);
            cmd.Parameters.AddWithValue("@Technique", Technique);
            cmd.Parameters.AddWithValue("@MicrobialWeight", MicrobialWeight);
            cmd.Parameters.AddWithValue("@Aspergillus", Aspergillus);
            cmd.Parameters.AddWithValue("@ShigaToxin", ShigaToxin);
            cmd.Parameters.AddWithValue("@Salmonella", Salmonella);




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
        private void update(int IDnew, string SampleIDnew, string Methodnew, string Techniquenew, string MicrobialWeightnew, string Aspergillusnew, string ShigaToxinnew, string Salmonella)
        {
            //SQL
            string sql = "UPDATE microbialDATA SET SampleID= '" + sampleIDlbl_micro.Text + "', Method= '" + methodCB.Text + "', Technique= '" + techniqueCB.Text + "',MicrobialWeight= '" + microWeightTB.Text + "',Aspergillus='" + aspergillusTB.Text + "',ShigaToxin= '" + shigaToxinTB.Text + "',Salmonella= '" + salmonellaTB.Text + "' WHERE ID= " + idLbl_micro.Text;
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Add(sampleIDlbl_micro.Text,
            methodCB.Text,
            techniqueCB.Text,
            microWeightTB.Text,
            aspergillusTB.Text,
            shigaToxinTB.Text,
            salmonellaTB.Text);
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(idLbl_micro.Text);
            string SampleIDnew = sampleIDlbl_micro.Text;
            string Methodnew = methodCB.Text;
            string Techniquenew = techniqueCB.Text;
            string MicrobialWeightnew = microWeightTB.Text;
            string Aspergillusnew = aspergillusTB.Text;
            string ShigaToxinnew = shigaToxinTB.Text;
            string Salmonella = salmonellaTB.Text;

            update(IDnew, SampleIDnew, Methodnew, Techniquenew, MicrobialWeightnew, Aspergillusnew, ShigaToxinnew, Salmonella);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MicroWeightTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AspergillusTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ShigaToxinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SalmonellaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }
    }
}
