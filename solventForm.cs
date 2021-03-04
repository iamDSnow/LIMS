using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LIMS_system_Prototype
{
    public partial class solventForm : Form
    {
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;

        public solventForm()
        {
            InitializeComponent();
        }

        private void solventForm_Load(object sender, EventArgs e)
        {
            //Connects Cover Info

            sampleIDlbl.Text = IndexForm.passSampleID;
            iDlbl.Text = IndexForm.passID;
            datelbl.Text = IndexForm.passDate;

            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM SolventsDATA WHERE ID =" + iDlbl.Text, con);
            adapter.Fill(dt);
            showData(pos);
        }

        public void showData(int index)
        {

            var a = 0;
            for (a = 0; a < dt.Rows.Count; a++)
            {

                iDlbl.Text = dt.Rows[index][0].ToString();
                datelbl.Text = dt.Rows[index][1].ToString();
                sampleIDlbl.Text = dt.Rows[index][2].ToString();
                gcmsIDTB.Text = dt.Rows[index][3].ToString();
                SolvInputTB.Text = dt.Rows[index][4].ToString();
                DichloroethaneTB.Text = dt.Rows[index][5].ToString();
                benzeneTB.Text = dt.Rows[index][6].ToString();
                chloroformTB.Text = dt.Rows[index][7].ToString();
                ethyleneOxideTB.Text = dt.Rows[index][8].ToString();
                methyleneChlorideTB.Text = dt.Rows[index][9].ToString();
                trichloroethyleneTB.Text = dt.Rows[index][10].ToString();
                acetoneTB.Text = dt.Rows[index][11].ToString();
                acetonitirileTB.Text = dt.Rows[index][12].ToString();
                butaneTB.Text = dt.Rows[index][13].ToString();
                ethanolTB.Text = dt.Rows[index][14].ToString();
                ethylAcetateTB.Text = dt.Rows[index][15].ToString();
                ethylEtherTB.Text = dt.Rows[index][16].ToString();
                heptaneTB.Text = dt.Rows[index][17].ToString();
                hexaneTB.Text = dt.Rows[index][18].ToString();
                isopropylAlcoholTB.Text = dt.Rows[index][19].ToString();
                methanolTB.Text = dt.Rows[index][20].ToString();
                PentaneTB.Text = dt.Rows[index][21].ToString();
                propaneTB.Text = dt.Rows[index][22].ToString();
                tolueneTB.Text = dt.Rows[index][23].ToString();
                oXyleneTB.Text = dt.Rows[index][24].ToString();
                mXyleneTB.Text = dt.Rows[index][25].ToString();
                pXyleneTB.Text = dt.Rows[index][26].ToString();
                isobutaneTB.Text = dt.Rows[index][27].ToString();
                nHexaneTB.Text = dt.Rows[index][28].ToString();
                diethylEtherTb.Text = dt.Rows[index][29].ToString();

            }

        }

        private void openbtn_Click(object sender, EventArgs e)
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

                XmlNode dichloroethane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Dichloroethane']//Amount");
                XmlNode benzene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Benzene']//Amount");
                XmlNode chloroform = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Chloroform']//Amount");
                XmlNode ethyleneOxide = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Ethylene Oxide']//Amount");
                XmlNode methyleneChloride = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Methylene Chloride']//Amount");
                XmlNode trichloroethylene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Trichloroethylene']//Amount");
                XmlNode acetone = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Acetone']//Amount");
                XmlNode acetonitirile = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Acetonitirile']//Amount");
                XmlNode butane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='n-Butane']//Amount");
                XmlNode ethanol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Ethanol']//Amount");
                XmlNode ethylAcetate = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Ethyl Acetate']//Amount");
                XmlNode ethylEther = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Ethyl Ether']//Amount");
                XmlNode heptane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Heptane']//Amount");
                XmlNode hexane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Hexane']//Amount");
                XmlNode isopropylAlcohol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Isopropyl Alcohol']//Amount");
                XmlNode methanol = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Methanol']//Amount");
                XmlNode pentane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='n-Pentane']//Amount");
                XmlNode propane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Propane']//Amount");
                XmlNode toluene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Toluene']//Amount");
                XmlNode oXylene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='o-Xylene']//Amount");
                XmlNode mXylene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='m-Xylene']//Amount");
                XmlNode pXylene = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='p-Xylene']//Amount");
                XmlNode isobutane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Isobutane']//Amount");
                XmlNode nhexane = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='n-Hexane']//Amount");
                XmlNode diethylEther = xmlDoc1.DocumentElement.SelectSingleNode("/ChemStationResult/Results/ResultsGroup/Peak[Name='Diethyl Ether']//Amount");

                //Display Solvent info if not NULL



                if (dichloroethane != null)
                {

                    double dichloroethanedec = Math.Round(double.Parse(dichloroethane.InnerText), 3);
                    DichloroethaneTB.Text = dichloroethanedec.ToString();

                }
                else
                {
                    DichloroethaneTB.Text = "0";
                }
                if (benzene != null)
                {

                    double benzenedec = Math.Round(double.Parse(benzene.InnerText), 3);
                    benzeneTB.Text = benzenedec.ToString();

                }
                else
                {
                    benzeneTB.Text = "0";
                }
                if (chloroform != null)
                {

                    double chloroformdec = Math.Round(double.Parse(chloroform.InnerText), 3);
                    chloroformTB.Text = chloroformdec.ToString();

                }
                else
                {
                    chloroformTB.Text = "0";
                }
                if (ethyleneOxide != null)
                {

                    double ethyleneOxidedec = Math.Round(double.Parse(ethyleneOxide.InnerText), 3);
                    ethyleneOxideTB.Text = ethyleneOxidedec.ToString();

                }
                else
                {
                    ethyleneOxideTB.Text = "0";
                }
                if (methyleneChloride != null)
                {

                    double methyleneChloridedec = Math.Round(double.Parse(methyleneChloride.InnerText), 3);
                    methyleneChlorideTB.Text = methyleneChloridedec.ToString();

                }
                else
                {
                    methyleneChlorideTB.Text = "0";
                }
                if (trichloroethylene != null)
                {

                    double trichloroethylenedec = Math.Round(double.Parse(trichloroethylene.InnerText), 3);
                    trichloroethyleneTB.Text = trichloroethylenedec.ToString();

                }
                else
                {
                    trichloroethyleneTB.Text = "0";
                }
                if (acetone != null)
                {

                    double acetonedec = Math.Round(double.Parse(acetone.InnerText), 3);
                    acetoneTB.Text = acetonedec.ToString();

                }
                else
                {
                    acetoneTB.Text = "0";
                }
                if (acetonitirile != null)
                {

                    double acetonitiriledec = Math.Round(double.Parse(acetonitirile.InnerText), 3);
                    acetonitirileTB.Text = acetonitiriledec.ToString();

                }
                else
                {
                    acetonitirileTB.Text = "0";
                }
                if (butane != null)
                {

                    double butanedec = Math.Round(double.Parse(butane.InnerText), 3);
                    butaneTB.Text = butanedec.ToString();

                }
                else
                {
                    butaneTB.Text = "0";
                }
                if (ethanol != null)
                {

                    double ethanoldec = Math.Round(double.Parse(ethanol.InnerText), 3);
                    ethanolTB.Text = ethanoldec.ToString();

                }
                else
                {
                    ethanolTB.Text = "0";
                }
                if (ethylAcetate != null)
                {

                    double ethylAcetatedec = Math.Round(double.Parse(ethylAcetate.InnerText), 3);
                    ethylAcetateTB.Text = ethylAcetatedec.ToString();

                }
                else
                {
                    ethylAcetateTB.Text = "0";
                }
                if (ethylEther != null)
                {

                    double ethylEtherdec = Math.Round(double.Parse(ethylEther.InnerText), 3);
                    ethylEtherTB.Text = ethylEtherdec.ToString();

                }
                else
                {
                    ethylEtherTB.Text = "0";
                }
                if (heptane != null)
                {

                    double heptanedec = Math.Round(double.Parse(heptane.InnerText), 3);
                    heptaneTB.Text = heptanedec.ToString();

                }
                else
                {
                    heptaneTB.Text = "0";
                }
                if (hexane != null)
                {

                    double hexanedec = Math.Round(double.Parse(hexane.InnerText), 3);
                    hexaneTB.Text = hexanedec.ToString();

                }
                else
                {
                    hexaneTB.Text = "0";
                }
                if (isopropylAlcohol != null)
                {

                    double isopropylAlcoholdec = Math.Round(double.Parse(isopropylAlcohol.InnerText), 3);
                    isopropylAlcoholTB.Text = isopropylAlcoholdec.ToString();

                }
                else
                {
                    isopropylAlcoholTB.Text = "0";
                }
                if (methanol != null)
                {

                    double methanoldec = Math.Round(double.Parse(methanol.InnerText), 3);
                    methanolTB.Text = methanoldec.ToString();

                }
                else
                {
                    methanolTB.Text = "0";
                }
                if (pentane != null)
                {

                    double pentanedec = Math.Round(double.Parse(pentane.InnerText), 3);
                    PentaneTB.Text = pentanedec.ToString();

                }
                else
                {
                    PentaneTB.Text = "0";
                }
                if (propane != null)
                {

                    double propanedec = Math.Round(double.Parse(propane.InnerText), 3);
                    propaneTB.Text = propanedec.ToString();

                }
                else
                {
                    propaneTB.Text = "0";
                }
                if (toluene != null)
                {

                    double toluenedec = Math.Round(double.Parse(toluene.InnerText), 3);
                    tolueneTB.Text = toluenedec.ToString();

                }
                else
                {
                    tolueneTB.Text = "0";
                }
                if (oXylene != null)
                {

                    double oXylenedec = Math.Round(double.Parse(oXylene.InnerText), 3);
                    oXyleneTB.Text = oXylenedec.ToString();

                }
                else
                {
                    oXyleneTB.Text = "0";
                }
                if (mXylene != null)
                {

                    double mXylenedec = Math.Round(double.Parse(mXylene.InnerText), 3);
                    mXyleneTB.Text = mXylenedec.ToString();

                }
                else
                {
                    mXyleneTB.Text = "0";
                }
                if (pXylene != null)
                {

                    double pXylenedec = Math.Round(double.Parse(pXylene.InnerText), 3);
                    pXyleneTB.Text = pXylenedec.ToString();

                }
                else
                {
                    pXyleneTB.Text = "0";
                }
                if (isobutane != null)
                {

                    double isobutanedec = Math.Round(double.Parse(isobutane.InnerText), 3);
                    isobutaneTB.Text = isobutanedec.ToString();

                }
                else
                {
                    isobutaneTB.Text = "0";
                }
                if (nhexane != null)
                {

                    double nhexanedec = Math.Round(double.Parse(nhexane.InnerText), 3);
                    nHexaneTB.Text = nhexanedec.ToString();

                }
                else
                {
                    nHexaneTB.Text = "0";
                }


                if (diethylEther != null)
                {

                    double diethylEtherdec = Math.Round(double.Parse(diethylEther.InnerText), 3);
                    diethylEtherTb.Text = diethylEtherdec.ToString();

                }
                else
                {
                    diethylEtherTb.Text = "0";
                }
            }
        }
        //add value to SQL
        private void Add(string Date, string SampleID, string GCMSID, string SolventInputWeight, string Dichloroethane, string Benzene, string Chloroform, string EthyleneOxide, string MethyleneChloride, string Trichloroethylene, string Acetone, string Acetonitrile, string Butane, string Ethanol, string EthylAcetate, string EthylEther, string Heptane, string Hexane, string IsopropylAlcohol, string Methanol, string Pentane, string Propane, string Toluene, string orthoXylene, string metaXylene, string paraXylene, string Isobutane, string nHexane, string DiethylEther)
        {
            //SQL  

            string sql = "INSERT INTO SolventsDATA(Date,SampleID,GCMSID,SolventInputWeight,Dichloroethane,Benzene,Chloroform,EthyleneOxide, MethyleneChloride, Trichloroethylene,Acetone, Acetonitrile,Butane, Ethanol, EthylAcetate,EthylEther,Heptane, Hexane, IsopropylAlcohol, Methanol, Pentane, Propane, Toluene,orthoXylene, metaXylene,paraXylene, Isobutane, nHexane, DiethylEther) VALUES(@Date,@SampleID,@GCMSID,@SolventInputWeight,@Dichloroethane,@Benzene,@Chloroform,@EthyleneOxide, @MethyleneChloride, @Trichloroethylene, @Acetone, @Acetonitrile, @Butane, @Ethanol, @EthylAcetate, @EthylEther, @Heptane, @Hexane, @IsopropylAlcohol, @Methanol, @Pentane, @Propane,@Toluene,@orthoXylene,@metaXylene,@paraXylene, @Isobutane, @nHexane, @DiethylEther)";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Date", Date);
            cmd.Parameters.AddWithValue("@SampleID", SampleID);
            cmd.Parameters.AddWithValue("@GCMSID", GCMSID);
            cmd.Parameters.AddWithValue("@SolventInputWeight", SolventInputWeight);
            cmd.Parameters.AddWithValue("@Dichloroethane", Dichloroethane);
            cmd.Parameters.AddWithValue("@Benzene", Benzene);
            cmd.Parameters.AddWithValue("@Chloroform", Chloroform);
            cmd.Parameters.AddWithValue("@EthyleneOxide", EthyleneOxide);
            cmd.Parameters.AddWithValue("@MethyleneChloride", MethyleneChloride);
            cmd.Parameters.AddWithValue("@Trichloroethylene", Trichloroethylene);
            cmd.Parameters.AddWithValue("@Acetone", Acetone);
            cmd.Parameters.AddWithValue("@Acetonitrile", Acetonitrile);
            cmd.Parameters.AddWithValue("@Butane", Butane);
            cmd.Parameters.AddWithValue("@Ethanol", Ethanol);
            cmd.Parameters.AddWithValue("@EthylAcetate", EthylAcetate);
            cmd.Parameters.AddWithValue("@EthylEther", EthylEther);
            cmd.Parameters.AddWithValue("@Heptane", Heptane);
            cmd.Parameters.AddWithValue("@Hexane", Hexane);
            cmd.Parameters.AddWithValue("@IsopropylAlcohol", IsopropylAlcohol);
            cmd.Parameters.AddWithValue("@Methanol", Methanol);
            cmd.Parameters.AddWithValue("@Pentane", Pentane);
            cmd.Parameters.AddWithValue("@Propane", Propane);
            cmd.Parameters.AddWithValue("@Toluene", Toluene);
            cmd.Parameters.AddWithValue("@orthoXylene", orthoXylene);
            cmd.Parameters.AddWithValue("@metaXylene", metaXylene);
            cmd.Parameters.AddWithValue("@paraXylene", paraXylene);
            cmd.Parameters.AddWithValue("@Isobutane", Isobutane);
            cmd.Parameters.AddWithValue("@nHexane", nHexane);
            cmd.Parameters.AddWithValue("@DiethylEther", DiethylEther);

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

        private void update(int IDnew, string Datenew, string SampleIDnew, string GCMSIDnew, string SolventInputWeightnew, string Dichloroethanenew, string Benzenenew, string Chloroformnew, string EthyleneOxidenew, string MethyleneChloridenew, string Trichloroethylenenew, string Acetonenew, string Acetonitrilenew, string Butanenew, string Ethanol, string EthylAcetatenew, string EthylEthernew, string Heptanenew, string Hexanenew, string IsopropylAlcoholnew, string Methanolnew, string Pentane, string Propane, string Toluenenew, string orthoXylenenew, string metaXylenenew, string paraXylenenew, string Isobutanenew, string nHexanenew, string DiethylEthernew)
        {
            //SQL
            string sql = "UPDATE SolventsDATA SET SampleID= '" + sampleIDlbl.Text + "', GCMSID= '" + gcmsIDTB.Text + "', SolventInputWeight= '" + SolvInputTB.Text + "',Dichloroethane= '" + DichloroethaneTB.Text + "',Benzene='" + benzeneTB.Text + "',Chloroform= '" + chloroformTB.Text + "',EthyleneOxide= '" + ethyleneOxideTB.Text + "', MethyleneChloride= '" + methyleneChlorideTB.Text + "', Trichloroethylene= '" + trichloroethyleneTB.Text + "', Acetone= '" + acetoneTB.Text + "',Acetonitrile= '" + acetonitirileTB.Text + "',Butane='" + butaneTB.Text + "',Ethanol= '" + ethanolTB.Text + "', EthylAcetate= '" + ethylAcetateTB.Text + "',EthylEther= '" + ethylEtherTB.Text + "', Heptane= '" + heptaneTB.Text + "',Hexane= '" + hexaneTB.Text + "', IsopropylAlcohol= '" + isopropylAlcoholTB.Text + "',Methanol= '" + methanolTB.Text + "',Pentane='" + PentaneTB.Text + "',Propane= '" + propaneTB.Text + "', Toluene= '" + tolueneTB.Text + "',orthoXylene= '" + oXyleneTB.Text + "', metaXylene= '" + mXyleneTB.Text + "',paraXylene= '" + pXyleneTB.Text + "',Isobutane= '" + isobutaneTB.Text + "',nHexane= '" + nHexaneTB.Text + "', DiethylEther= '" + diethylEtherTb.Text + "' WHERE ID= " + iDlbl.Text;
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int IDnew = Convert.ToInt32(iDlbl.Text);
            string Datenew = datelbl.Text;
            string SampleIDnew = sampleIDlbl.Text;
            string GCMSIDnew = gcmsIDTB.Text;
            string SolventInputWeightnew = SolvInputTB.Text;
            string Dichloroethanenew = DichloroethaneTB.Text;
            string Benzenenew = benzeneTB.Text;
            string Chloroformnew = chloroformTB.Text;
            string EthyleneOxidenew = ethyleneOxideTB.Text;
            string MethyleneChloridenew = methyleneChlorideTB.Text;
            string Trichloroethylenenew = trichloroethyleneTB.Text;
            string Acetonenew = acetoneTB.Text;
            string Acetonitrilenew = acetonitirileTB.Text;
            string Butanenew = butaneTB.Text;
            string Ethanol = ethanolTB.Text;
            string EthylAcetatenew = ethylAcetateTB.Text;
            string EthylEthernew = ethylEtherTB.Text;
            string Heptanenew = heptaneTB.Text;
            string Hexanenew = hexaneTB.Text;
            string IsopropylAlcoholnew = isopropylAlcoholTB.Text;
            string Methanolnew = methanolTB.Text;
            string Pentane = PentaneTB.Text;
            string Propane = propaneTB.Text;
            string Toluenenew = tolueneTB.Text;
            string orthoXylenenew = oXyleneTB.Text;
            string metaXylenenew = mXyleneTB.Text;
            string paraXylenenew = pXyleneTB.Text;
            string Isobutanenew = isobutaneTB.Text;
            string nHexanenew = nHexaneTB.Text;
            string DiethylEthernew = diethylEtherTb.Text;

            update(IDnew, Datenew, SampleIDnew, GCMSIDnew, SolventInputWeightnew, Dichloroethanenew, Benzenenew, Chloroformnew, EthyleneOxidenew, MethyleneChloridenew, Trichloroethylenenew, Acetonenew, Acetonitrilenew, Butanenew, Ethanol, EthylAcetatenew, EthylEthernew, Heptanenew, Hexanenew, IsopropylAlcoholnew, Methanolnew, Pentane, Propane, Toluenenew, orthoXylenenew, metaXylenenew, paraXylenenew, Isobutanenew, nHexanenew, DiethylEthernew);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            solventForm solventForm = this;
            solventForm.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Add(datelbl.Text,
           sampleIDlbl.Text,
           gcmsIDTB.Text,
           SolvInputTB.Text,
           DichloroethaneTB.Text,
           benzeneTB.Text,
           chloroformTB.Text,
           ethyleneOxideTB.Text,
           methyleneChlorideTB.Text,
           trichloroethyleneTB.Text,
           acetoneTB.Text,
           acetonitirileTB.Text,
           butaneTB.Text,
           ethanolTB.Text,
           ethylAcetateTB.Text,
           ethylEtherTB.Text,
           heptaneTB.Text,
           hexaneTB.Text,
           isopropylAlcoholTB.Text,
           methanolTB.Text,
           PentaneTB.Text,
           propaneTB.Text,
           tolueneTB.Text,
           oXyleneTB.Text,
           mXyleneTB.Text,
           pXyleneTB.Text,
           isobutaneTB.Text,
           nHexaneTB.Text,
           diethylEtherTb.Text);
        }

        private void SolvInputTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DichloroethaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BenzeneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ChloroformTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EthyleneOxideTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MethyleneChlorideTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void TrichloroethyleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void IsobutaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DiethylEtherTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void NHexaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AcetoneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AcetonitirileTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ButaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EthanolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EthylAcetateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EthylEtherTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void HeptaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void HexaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void IsopropylAlcoholTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MethanolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PentaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PropaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void TolueneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void OXyleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MXyleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PXyleneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

    }
}
