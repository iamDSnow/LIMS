using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LIMS_system_Prototype
{
    public partial class terpenesForm : Form
    {
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;

        public terpenesForm()
        {
            InitializeComponent();
        }

        private void terpenesForm_Load(object sender, EventArgs e)
        {
            //Connects Cover Info

            sampleIDLbl.Text = IndexForm.passSampleID;
            iDLbl.Text = IndexForm.passID;
            dateLbl.Text = IndexForm.passDate;
            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM terpenesDATA WHERE ID =" + iDLbl.Text, con);
            adapter.Fill(dt);
            showData(pos);
        }

        public void showData(int index)
        {

            var a = 0;
            for (a = 0; a < dt.Rows.Count; a++)
            {

                iDLbl.Text = dt.Rows[index][0].ToString();
                dateLbl.Text = dt.Rows[index][1].ToString();
                sampleIDLbl.Text = dt.Rows[index][2].ToString();
                methodCB.Text = dt.Rows[index][5].ToString();
                techniqueCB.Text = dt.Rows[index][6].ToString();
                GCMSIDTB.Text = dt.Rows[index][3].ToString();
                TerpWtTB.Text = dt.Rows[index][4].ToString();
                aPineneTB.Text = dt.Rows[index][7].ToString();
                campheneTB.Text = dt.Rows[index][8].ToString();
                bMyrceneTB.Text = dt.Rows[index][9].ToString();
                bPineneTB.Text = dt.Rows[index][10].ToString();
                d3CareneTB.Text = dt.Rows[index][11].ToString();
                aTerpineneTB.Text = dt.Rows[index][12].ToString();
                ocimeneTB.Text = dt.Rows[index][13].ToString();
                limoneneTB.Text = dt.Rows[index][14].ToString();
                pCymeneTB.Text = dt.Rows[index][15].ToString();
                yTerpineneTB.Text = dt.Rows[index][16].ToString();
                terpinoleneTB.Text = dt.Rows[index][17].ToString();
                linaloolTB.Text = dt.Rows[index][18].ToString();
                IsopulegolTB.Text = dt.Rows[index][19].ToString();
                geraniolTB.Text = dt.Rows[index][20].ToString();
                bCaryophylleneTB.Text = dt.Rows[index][21].ToString();
                aHumuleneTB.Text = dt.Rows[index][22].ToString();
                NerolidolTB.Text = dt.Rows[index][23].ToString();
                GuaiolTB.Text = dt.Rows[index][24].ToString();
                aBisabololTB.Text = dt.Rows[index][25].ToString();
            }
        }

        //add value to SQL
        private void Add(string Date, string SampleID, string GCMSID, string TerpWT, string Method, string Technique, string aPinene, string Camphene, string bMyrcene, string bPinene, string d3Carene, string aTerpinene, string Ocimene, string Limonene, string pCymene, string yTerpinene, string Terpinolene, string Linalool, string Isopulegol, string Geraniol, string bCaryophyllene, string aHumulene, string Nerolidol, string Guaiol, string aBisabolol)
        {
            //SQL  

            string sql = "INSERT INTO terpenesDATA(Date,SampleID,GCMSID,Method,Technique,TerpWT,aPinene,Camphene,bMyrcene, bPinene, d3Carene,aTerpinene, Ocimene,Limonene, pCymene, yTerpinene,Terpinolene,Linalool, Isopulegol, Geraniol, bCaryophyllene, aHumulene,Nerolidol,Guaiol,aBisabolol) VALUES(@Date,@SampleID,@GCMSID,@Method,@Technique,@TerpWT,@aPinene,@Camphene,@bMyrcene, @bPinene, @d3Carene, @aTerpinene, @Ocimene, @Limonene, @pCymene, @yTerpinene, @Terpinolene, @Linalool, @Isopulegol, @Geraniol, @bCaryophyllene, @aHumulene, @Nerolidol,@Guaiol,@aBisabolol)";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@SampleID", SampleID);
            cmd.Parameters.AddWithValue("@GCMSID", GCMSID);
            cmd.Parameters.AddWithValue("@Method", Method);
            cmd.Parameters.AddWithValue("@Technique", Technique);
            cmd.Parameters.AddWithValue("@TerpWT", TerpWT);
            cmd.Parameters.AddWithValue("@aPinene", aPinene);
            cmd.Parameters.AddWithValue("@Camphene", Camphene);
            cmd.Parameters.AddWithValue("@bMyrcene", bMyrcene);
            cmd.Parameters.AddWithValue("@bPinene", bPinene);
            cmd.Parameters.AddWithValue("@d3Carene", d3Carene);
            cmd.Parameters.AddWithValue("@aTerpinene", aTerpinene);
            cmd.Parameters.AddWithValue("@Ocimene", Ocimene);
            cmd.Parameters.AddWithValue("@Limonene", Limonene);
            cmd.Parameters.AddWithValue("@pCymene", pCymene);
            cmd.Parameters.AddWithValue("@yTerpinene", yTerpinene);
            cmd.Parameters.AddWithValue("@Terpinolene", Terpinolene);
            cmd.Parameters.AddWithValue("@Linalool", Linalool);
            cmd.Parameters.AddWithValue("@Isopulegol", Isopulegol);
            cmd.Parameters.AddWithValue("@Geraniol", Geraniol);
            cmd.Parameters.AddWithValue("@bCaryophyllene", bCaryophyllene);
            cmd.Parameters.AddWithValue("@aHumulene", aHumulene);
            cmd.Parameters.AddWithValue("@Nerolidol", Nerolidol);
            cmd.Parameters.AddWithValue("@Guaiol", Guaiol);
            cmd.Parameters.AddWithValue("@aBisabolol", aBisabolol);


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

        private void update(int IDnew, string Datenew, string SampleIDnew, string Methodnew, string Techniquenew, string GCMSIDnew, string TerpWTnew, string aPinenenew, string Camphene, string bMyrcene, string bPinene, string d3Carene, string aTerpinene, string Ocimene, string Limonene, string pCymene, string yTerpinenenew, string Terpinolenenew, string Linaloolnew, string Isopulegolnew, string Geraniolnew, string bCaryophyllenenew, string aHumulenenew, string Nerolidolnew, string Guaiolnew, string aBisabololnew)
        {
            //SQL
            string sql = "UPDATE terpenesDATA SET SampleID= '" + sampleIDLbl.Text + "', Method= '" + methodCB.Text + "', Technique= '" + techniqueCB.Text + "',GCMSID= '" + GCMSIDTB.Text + "',TerpWT='" + TerpWtTB.Text + "',aPinene= '" + aPineneTB.Text + "',Camphene= '" + campheneTB.Text + "', bMyrcene= '" + bMyrceneTB.Text + "', bPinene= '" + bPineneTB.Text + "', d3Carene= '" + d3CareneTB.Text + "',aTerpinene= '" + aTerpineneTB.Text + "',Ocimene='" + ocimeneTB.Text + "',Limonene= '" + limoneneTB.Text + "', pCymene= '" + pCymeneTB.Text + "',yTerpinene= '" + yTerpineneTB.Text + "', Terpinolene= '" + terpinoleneTB.Text + "',Linalool= '" + linaloolTB.Text + "', Isopulegol= '" + IsopulegolTB.Text + "',Geraniol= '" + geraniolTB.Text + "',bCaryophyllene='" + bCaryophylleneTB.Text + "',aHumulene= '" + aHumuleneTB.Text + "', Nerolidol= '" + NerolidolTB.Text + "',Guaiol= '" + GuaiolTB.Text + "', aBisabolol= '" + aBisabololTB.Text + "' WHERE ID= " + iDLbl.Text;
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
            OpenFileDialog openFileDialog4 = new OpenFileDialog
            {
                InitialDirectory = "",
                Filter = "Xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };


            //Open file & Load XML

            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = new StreamReader(openFileDialog4.FileName, Encoding.Default);
                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.Load(sr);
                //Save XML to Node

                XmlNode aPinene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='a-Pinene']//Amount");
                XmlNode Camphene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Camphene']//Amount");
                XmlNode bMyrcene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='B-Myrcene']//Amount");
                XmlNode bPinene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='B-Pinene']//Amount");
                XmlNode d3Carene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='D3-Carene']//Amount");
                XmlNode aTerpinene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='a-Terpinene']//Amount");
                XmlNode Limonene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Limonene']//Amount");
                XmlNode Ocimene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Ocimene']//Amount");
                XmlNode pCymene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='p-Cymene']//Amount");
                XmlNode yTerpinene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='y-Terpinene*']//Amount");
                XmlNode Terpinolene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Terpinolene']//Amount");
                XmlNode Linalool = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Linalool']//Amount");
                XmlNode Isopulegol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Isopulegol']//Amount");
                XmlNode Geraniol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Geraniol']//Amount");
                XmlNode bCaryophyllene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='B-Caryophyllene']//Amount");
                XmlNode aHumulene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='a-Humulene']//Amount");
                XmlNode Nerolidol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Nerolidol']//Amount");
                XmlNode NerolidolX2 = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Nerolidol X2']//Amount");
                XmlNode Guaiol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Guaiol']//Amount");
                XmlNode aBisabolol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='a-Bisabolol']//Amount");

                //Display Solvent info if not NULL



                if (aPinene != null)
                {

                    double aPinenedec = Math.Round(double.Parse(aPinene.InnerText), 3);
                    aPineneTB.Text = aPinenedec.ToString();

                }
                else
                {
                    aPineneTB.Text = "0";
                }
                if (Camphene != null)
                {

                    double Camphenedec = Math.Round(double.Parse(Camphene.InnerText), 3);
                    campheneTB.Text = Camphenedec.ToString();

                }
                else
                {
                    campheneTB.Text = "0";
                }
                if (bMyrcene != null)
                {

                    double bMyrcenedec = Math.Round(double.Parse(bMyrcene.InnerText), 3);
                    bMyrceneTB.Text = bMyrcenedec.ToString();

                }
                else
                {
                    bMyrceneTB.Text = "0";
                }
                if (bPinene != null)
                {

                    double bPinenedec = Math.Round(double.Parse(bPinene.InnerText), 3);
                    bPineneTB.Text = bPinenedec.ToString();

                }
                else
                {
                    bPineneTB.Text = "0";
                }
                if (d3Carene != null)
                {

                    double d3Carenedec = Math.Round(double.Parse(d3Carene.InnerText), 3);
                    d3CareneTB.Text = d3Carenedec.ToString();

                }
                else
                {
                    d3CareneTB.Text = "0";
                }
                if (aTerpinene != null)
                {

                    double aTerpinenedec = Math.Round(double.Parse(aTerpinene.InnerText), 3);
                    aTerpineneTB.Text = aTerpinenedec.ToString();

                }
                else
                {
                    aTerpineneTB.Text = "0";
                }
                if (Limonene != null)
                {

                    double Limonenedec = Math.Round(double.Parse(Limonene.InnerText), 3);
                    limoneneTB.Text = Limonenedec.ToString();

                }
                else
                {
                    limoneneTB.Text = "0";
                }
                if (Ocimene != null)
                {

                    double Ocimenedec = Math.Round(double.Parse(Ocimene.InnerText), 3);
                    ocimeneTB.Text = Ocimenedec.ToString();

                }
                else
                {
                    ocimeneTB.Text = "0";
                }
                if (pCymene != null)
                {

                    double pCymenedec = Math.Round(double.Parse(pCymene.InnerText), 3);
                    pCymeneTB.Text = pCymenedec.ToString();

                }
                else
                {
                    pCymeneTB.Text = "0";
                }
                if (yTerpinene != null)
                {

                    double yTerpinenedec = Math.Round(double.Parse(yTerpinene.InnerText), 3);
                    yTerpineneTB.Text = yTerpinenedec.ToString();

                }
                else
                {
                    yTerpineneTB.Text = "0";
                }
                if (Terpinolene != null)
                {

                    double Terpinolenedec = Math.Round(double.Parse(Terpinolene.InnerText), 3);
                    terpinoleneTB.Text = Terpinolenedec.ToString();

                }
                else
                {
                    terpinoleneTB.Text = "0";
                }
                if (Linalool != null)
                {

                    double Linalooldec = Math.Round(double.Parse(Linalool.InnerText), 3);
                    linaloolTB.Text = Linalooldec.ToString();

                }
                else
                {
                    linaloolTB.Text = "0";
                }
                if (Isopulegol != null)
                {

                    double Isopulegoldec = Math.Round(double.Parse(Isopulegol.InnerText), 3);
                    IsopulegolTB.Text = Isopulegoldec.ToString();

                }
                else
                {
                    IsopulegolTB.Text = "0";
                }
                if (Geraniol != null)
                {

                    double Geranioldec = Math.Round(double.Parse(Geraniol.InnerText), 3);
                    geraniolTB.Text = Geranioldec.ToString();

                }
                else
                {
                    geraniolTB.Text = "0";
                }
                if (bCaryophyllene != null)
                {

                    double bCaryophyllenedec = Math.Round(double.Parse(bCaryophyllene.InnerText), 3);
                    bCaryophylleneTB.Text = bCaryophyllenedec.ToString();

                }
                else
                {
                    bCaryophylleneTB.Text = "0";
                }
                if (aHumulene != null)
                {

                    double aHumulenedec = Math.Round(double.Parse(aHumulene.InnerText), 3);
                    aHumuleneTB.Text = aHumulenedec.ToString();

                }
                else
                {
                    bCaryophylleneTB.Text = "0";
                }
                if (Nerolidol != null || NerolidolX2 != null)
                {

                    double Nerolidoldec = Math.Round(double.Parse(Nerolidol.InnerText), 3);
                    double NerolidolX2dec = Math.Round(double.Parse(NerolidolX2.InnerText), 3);
                    double Nerolidolsum = Nerolidoldec + NerolidolX2dec;
                    NerolidolTB.Text = Nerolidolsum.ToString();

                }
                else if (Nerolidol != null)
                {
                    double Nerolidoldec = Math.Round(double.Parse(Nerolidol.InnerText), 3);
                    NerolidolTB.Text = Nerolidoldec.ToString();
                }
                else if (NerolidolX2 != null)
                {
                    double NerolidolX2dec = Math.Round(double.Parse(NerolidolX2.InnerText), 3);
                    NerolidolTB.Text = NerolidolX2dec.ToString();
                }
                else
                {
                    NerolidolTB.Text = "0";
                }
                if (Guaiol != null)
                {

                    double Guaioldec = Math.Round(double.Parse(Guaiol.InnerText), 3);
                    GuaiolTB.Text = Guaioldec.ToString();

                }
                else
                {
                    GuaiolTB.Text = "0";
                }
                if (aBisabolol != null)
                {

                    double aBisabololdec = Math.Round(double.Parse(aBisabolol.InnerText), 3);
                    aBisabololTB.Text = aBisabololdec.ToString();

                }
                else
                {
                    aBisabololTB.Text = "0";
                }

            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(iDLbl.Text);
            string Datenew = dateLbl.Text;
            string SampleIDnew = sampleIDLbl.Text;
            string Methodnew = methodCB.Text;
            string Techniquenew = techniqueCB.Text;
            string GCMSIDnew = GCMSIDTB.Text;
            string TerpWTnew = TerpWtTB.Text;
            string aPinenenew = aPineneTB.Text;
            string Camphene = campheneTB.Text;
            string bMyrcene = bMyrceneTB.Text;
            string bPinene = bPineneTB.Text;
            string d3Carene = d3CareneTB.Text;
            string aTerpinene = aTerpineneTB.Text;
            string Ocimene = ocimeneTB.Text;
            string Limonene = limoneneTB.Text;
            string pCymene = pCymeneTB.Text;
            string yTerpinenenew = yTerpineneTB.Text;
            string Terpinolenenew = terpinoleneTB.Text;
            string Linaloolnew = linaloolTB.Text;
            string Isopulegolnew = IsopulegolTB.Text;
            string Geraniolnew = geraniolTB.Text;
            string bCaryophyllenenew = bCaryophylleneTB.Text;
            string aHumulenenew = aHumuleneTB.Text;
            string Nerolidolnew = NerolidolTB.Text;
            string Guaiolnew = GuaiolTB.Text;
            string aBisabololnew = aBisabololTB.Text;

            update(IDnew, Datenew, SampleIDnew, Methodnew, Techniquenew, GCMSIDnew, TerpWTnew, aPinenenew, Camphene, bMyrcene, bPinene, d3Carene, aTerpinene, Ocimene, Limonene, pCymene, yTerpinenenew, Terpinolenenew, Linaloolnew, Isopulegolnew, Geraniolnew, bCaryophyllenenew, aHumulenenew, Nerolidolnew, Guaiolnew, aBisabololnew);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Add(dateLbl.Text,
               sampleIDLbl.Text,
               methodCB.Text,
               techniqueCB.Text,
               GCMSIDTB.Text,
               TerpWtTB.Text,
               aPineneTB.Text,
               campheneTB.Text,
               bMyrceneTB.Text,
               bPineneTB.Text,
               d3CareneTB.Text,
               aTerpineneTB.Text,
               ocimeneTB.Text,
               limoneneTB.Text,
               pCymeneTB.Text,
               yTerpineneTB.Text,
               terpinoleneTB.Text,
               linaloolTB.Text,
               IsopulegolTB.Text,
               geraniolTB.Text,
               bCaryophylleneTB.Text,
               aHumuleneTB.Text,
               NerolidolTB.Text,
               GuaiolTB.Text,
               aBisabololTB.Text);
        }

        private void TerpWtTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void APineneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CampheneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BMyrceneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BPineneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void D3CareneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ATerpineneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void OcimeneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void LimoneneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PCymeneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void YTerpineneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void TerpinoleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void LinaloolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void IsopulegolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void GeraniolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BCaryophylleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AHumuleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void NerolidolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void GuaiolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ABisabololTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }


    }
}
