using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace LIMS_system_Prototype
{
    public partial class customersList : Form
    {
        //SQL connection
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();

        public customersList()
        {
            InitializeComponent();
           
            //Create columns for list


            listView1.Columns.Add("ID", 40);
            listView1.Columns.Add("CUSTOMER NAME", 150);
            listView1.Columns.Add("EMAIL", 150);
            listView1.Columns.Add("LICENSE", 150);
            listView1.Columns.Add("ADDRESS", 200);

            //Properties
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
        }
        // populate ListView
        private void populateLV(string id, string customer, string email, string license, string address)
        {
            string[] row = { id, customer, email, license, address };

            listView1.Items.Add(new ListViewItem(row));

        }
        //INSERT
        private void add(string customer, string email, string license, string address)
        {
            //SQL  

            string sql = "INSERT INTO customerDATA(customer,email,license,address) VALUES(@CUSTOMERN, @EMAIL, @LICENSE, @ADDRESS)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@CUSTOMERN", customer);
            cmd.Parameters.AddWithValue("@EMAIL", email);
            cmd.Parameters.AddWithValue("@LICENSE", license);
            cmd.Parameters.AddWithValue("@ADDRESS", address);

            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Inserted");
                }
                con.Close();

                retrieved();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }



        //SELECTING
        private void retrieved()
        {
            listView1.Items.Clear();

            //SQL
            string sql = "SELECT * FROM customerDATA";
            cmd = new SqlCommand(sql, con);

            //OPEN CON, RETRIEVE FILL DGVIEW
            try
            {
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                //LOOP DT
                foreach (DataRow row in dt.Rows)
                {
                    populateLV(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                }
                con.Close();

                //Clear
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }


        // Update
        private void update(int id, string customerNew, string emailNew, string licenseNew, string addressNew)
        {
            //SQL
            string sql = "UPDATE customerDATA SET customer= '" + customerNew + "',email= '" + emailNew + "', license= '" + licenseNew + "', address= '" + addressNew + "' WHERE id= " + id + " ";
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
                    customer.Text = "";
                    email.Text = "";
                    license.Text = "";
                    address.Text = "";
                    MessageBox.Show("Successfull Updated");
                }
                con.Close();

                //Refresh
                retrieved();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        //Delete
        private void delete(int id)
        {
            //SQL
            string sql = "DELETE FROM customerDATA WHERE id= " + id + "";
            cmd = new SqlCommand(sql, con);

            //OPEN
            try
            {
                con.Open();

                adapter = new SqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                // Confirm delete

                if (MessageBox.Show("Are you sure you want to delete the record?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        customer.Text = "";
                        email.Text = "";
                        license.Text = "";
                        address.Text = "";
                        MessageBox.Show("Successfully Deleted");
                    }
                }
                con.Close();

                //Refresh
                retrieved();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            add(customer.Text, email.Text, license.Text, address.Text);
        }
    

        private void deleteBtn_Click(object sender, EventArgs e)
        {
        int id = Convert.ToInt16(listView1.SelectedItems[0].SubItems[0].Text);
        delete(id);
    }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
        listView1.Items.Clear();
        customer.Text = "";
        email.Text = "";
        license.Text = "";
        address.Text = "";
    }

        private void updatebtn_Click(object sender, EventArgs e)
        {
        int id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
        string customerNew = customer.Text;
        string emailNew = email.Text;
        string licenseNew = license.Text;
        string addressNew = address.Text;

        update(id, customerNew, emailNew, licenseNew, addressNew);
    }

        private void retrievebtn_Click(object sender, EventArgs e)
        {
            retrieved();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            customer.Text = listView1.SelectedItems[0].SubItems[1].Text;
            email.Text = listView1.SelectedItems[0].SubItems[2].Text;
            license.Text = listView1.SelectedItems[0].SubItems[3].Text;
            address.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void customersList_Load(object sender, EventArgs e)
        {
            retrieved();
        }
    }
}
