using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace LIMS_system_Prototype
{
    public partial class pesticideForm : Form
    {
        //Open SQL connection 
        static string conString = @"Data Source=COASTALTHINKPAD;Initial Catalog=PrototypeDB;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        int pos = 0;

        class PestiGC
        {
            public string GCMSIDcsv { get; set; }
            public string captan { get; set; }
            public string chlordane { get; set; }
            public string chlorfenapyr { get; set; }
            public string cyfluthrin { get; set; }
            public string cypermethrin { get; set; }
            public string flonicamid { get; set; }
            public string methylParathion { get; set; }
            public string methiocarb { get; set; }
            public string pentachloronitrobenzene { get; set; }


            //clear class when new file load
            public void Clear()
            {
                this.captan = string.Empty;
                this.chlordane = string.Empty;
                this.chlorfenapyr = string.Empty;
                this.cyfluthrin = string.Empty;
                this.cypermethrin = string.Empty;
                this.flonicamid = string.Empty;
                this.methylParathion = string.Empty;
                this.methiocarb = string.Empty;
                this.pentachloronitrobenzene = string.Empty;
                this.GCMSIDcsv = string.Empty;

            }

        }

        public pesticideForm()
        {
            InitializeComponent();
        }

        private void pesticideForm_Load(object sender, EventArgs e)
        {

            //Connects Cover Info

            SAMPLEIDlbl.Text = IndexForm.passSampleID;

            iDlbl.Text = IndexForm.passID;

            //SQL adapter
            adapter = new SqlDataAdapter("SELECT * FROM pesticidesDATA WHERE Id =" + iDlbl.Text, con);
            adapter.Fill(dt);
            showData(pos);
        }
        //add value to SQL
        private void add(string SAMPLEID,
                         string PestInputWt,
                         string LCMSID,
                         string GCMSID,
                         string Abamectin,
                         string Acephate,
                         string Acequinocyl,
                         string Acetamiprid,
                         string Aldicarb,
                         string Azoxystrobin,
                         string Bifenazate,
                         string Bifenthrin,
                         string Boscalid,
                         string Captan,
                         string Carbaryl,
                         string Carbofuran,
                         string Chlorantranilprole,
                         string Chlordane,
                         string Chlorfenapyr,
                         string Chlorpyrifos,
                         string Clofentezine,
                         string Coumaphos,
                         string Cyfluthrin,
                         string Cypermethrin,
                         string Daminozide,
                         string Dichlorvos,
                         string Diazinon,
                         string Dimethoate,
                         string Dimethomorph,
                         string Ethoprophos,
                         string Etofenprox,
                         string Etoxazole,
                         string Fenhexamid,
                         string Fenoxycarb,
                         string Fenpyroximate,
                         string Fipronil,
                         string Flonicamid,
                         string Hexythiazox,
                         string Fludioxonil,
                         string Imazalil,
                         string Imidacloprid,
                         string KresoximMethyl,
                         string Malathion,
                         string Metalaxyl,
                         string Methiocarb,
                         string Methomyl,
                         string MethylParathion,
                         string Mevinphos,
                         string Myclobutanil,
                         string Naled,
                         string Oxamyl,
                         string Pentachloronitrobenzene,
                         string Permethrins,
                         string Phosmet,
                         string PiperonylButoxide,
                         string Prallethrin,
                         string Propiconazole,
                         string Propoxur,
                         string Pyrethrins,
                         string Pyridaben,
                         string SpinetoramJ,
                         string SpinetoramL,
                         string SpinosadA,
                         string SpinosadD,
                         string Spiromesifen,
                         string Spirotetramat,
                         string Spiroxamine,
                         string Tebuconazole,
                         string Thiacloprid,
                         string Thiamethoxam,
                         string Trifloxystrobin,
                         string Paclobutrazol)
        {
            //SQL  

            string sql = "INSERT INTO pesticidesDATA(SAMPLEID,PestInputWt,LCMSID,GCMSID,Abamectin,Acephate,Acequinocyl,Aldicarb,Acetamiprid,Azoxystrobin,Bifenazate,Bifenthrin,Boscalid,Captan,Carbaryl,Carbofuran,Chlorantranilprole,Chlordane,Chlorfenapyr,Chlorpyrifos,Clofentezine,Coumaphos,Cyfluthrin,Cypermethrin,Daminozide,Dichlorvos,Diazinon,Dimethoate,Dimethomorph,Ethoprophos,Etofenprox,Etoxazole,Fenhexamid,Fenoxycarb,Fenpyroximate,Fipronil,Flonicamid,Fludioxonil,Hexythiazox,Imazalil,Imidacloprid,KresoximMethyl,Malathion,Metalaxyl,Methiocarb,Methomyl,MethylParathion,Mevinphos,Myclobutanil,Naled,Oxamyl,Pentachloronitrobenzene,Permethrins,Phosmet,PiperonylButoxide,Prallethrin,Propiconazole,Propoxur,Pyrethrins,Pyridaben,SpinetoramJ,SpinetoramL,SpinosadA,SpinosadD,Spiromesifen,Spirotetramat,Spiroxamine, Tebuconazole,Thiacloprid,Thiamethoxam,Trifloxystrobin, Paclobutrazol) VALUES(@SAMPLEID,@PestInputWt,@LCMSID,@GCMSID,@Abamectin,@Acephate,@Acequinocyl,@Acetamiprid,@Aldicarb,@Azoxystrobin,@Bifenazate,@Bifenthrin,@Boscalid,@Captan,@Carbaryl,@Carbofuran,@Chlorantranilprole,@Chlordane,@Chlorfenapyr,@Chlorpyrifos,@Clofentezine,@Coumaphos,@Cyfluthrin,@Cypermethrin,@Daminozide,@Dichlorvos,@Diazinon,@Dimethoate,@Dimethomorph,@Ethoprophos,@Etofenprox,@Etoxazole,@Fenhexamid,@Fenoxycarb,@Fenpyroximate,@Fipronil,@Flonicamid,@Fludioxonil,@Hexythiazox,@Imazalil,@Imidacloprid,@KresoximMethyl,@Malathion,@Metalaxyl,@Methiocarb,@Methomyl,@MethylParathion,@Mevinphos,@Myclobutanil,@Naled,@Oxamyl,@Pentachloronitrobenzene,@Permethrins,@Phosmet,@PiperonylButoxide,@Prallethrin,@Propiconazole,@Propoxur,@Pyrethrins,@Pyridaben,@SpinetoramJ,@SpinetoramL,@SpinosadA,@SpinosadD,@Spiromesifen, @Spirotetramat,@Spiroxamine,@Tebuconazole,@Thiacloprid,@Thiamethoxam,@Trifloxystrobin, @Paclobutrazol)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SAMPLEID", SAMPLEID);
            cmd.Parameters.AddWithValue("@PestInputWt", PestInputWt);
            cmd.Parameters.AddWithValue("@LCMSID", LCMSID);
            cmd.Parameters.AddWithValue("@GCMSID", GCMSID);
            cmd.Parameters.AddWithValue("@Abamectin", Abamectin);
            cmd.Parameters.AddWithValue("@Acephate", Acephate);
            cmd.Parameters.AddWithValue("@Acequinocyl", Acequinocyl);
            cmd.Parameters.AddWithValue("@Acetamiprid", Acetamiprid);
            cmd.Parameters.AddWithValue("@Aldicarb", Aldicarb);
            cmd.Parameters.AddWithValue("@Azoxystrobin", Azoxystrobin);
            cmd.Parameters.AddWithValue("@Bifenazate", Bifenazate);
            cmd.Parameters.AddWithValue("@Bifenthrin", Bifenthrin);
            cmd.Parameters.AddWithValue("@Boscalid", Boscalid);
            cmd.Parameters.AddWithValue("@Captan", Captan);
            cmd.Parameters.AddWithValue("@Carbaryl", Carbaryl);
            cmd.Parameters.AddWithValue("@Carbofuran", Carbofuran);
            cmd.Parameters.AddWithValue("@Chlorantranilprole", Chlorantranilprole);
            cmd.Parameters.AddWithValue("@Chlordane", Chlordane);
            cmd.Parameters.AddWithValue("@Chlorfenapyr", Chlorfenapyr);
            cmd.Parameters.AddWithValue("@Chlorpyrifos", Chlorpyrifos);
            cmd.Parameters.AddWithValue("@Clofentezine", Clofentezine);
            cmd.Parameters.AddWithValue("@Coumaphos", Coumaphos);
            cmd.Parameters.AddWithValue("@Cyfluthrin", Cyfluthrin);
            cmd.Parameters.AddWithValue("@Cypermethrin", Cypermethrin);
            cmd.Parameters.AddWithValue("@Daminozide", Daminozide);
            cmd.Parameters.AddWithValue("@Dichlorvos", Dichlorvos);
            cmd.Parameters.AddWithValue("@Diazinon", Diazinon);
            cmd.Parameters.AddWithValue("@Dimethoate", Dimethoate);
            cmd.Parameters.AddWithValue("@Dimethomorph", Dimethomorph);
            cmd.Parameters.AddWithValue("@Ethoprophos", Ethoprophos);
            cmd.Parameters.AddWithValue("@Etofenprox", Etofenprox);
            cmd.Parameters.AddWithValue("@Etoxazole", Etoxazole);
            cmd.Parameters.AddWithValue("@Fenhexamid", Fenhexamid);
            cmd.Parameters.AddWithValue("@Fenoxycarb", Fenoxycarb);
            cmd.Parameters.AddWithValue("@Fenpyroximate", Fenpyroximate);
            cmd.Parameters.AddWithValue("@Fipronil", Fipronil);
            cmd.Parameters.AddWithValue("@Flonicamid", Flonicamid);
            cmd.Parameters.AddWithValue("@Fludioxonil", Fludioxonil);
            cmd.Parameters.AddWithValue("@Hexythiazox", Hexythiazox);
            cmd.Parameters.AddWithValue("@Imazalil", Imazalil);
            cmd.Parameters.AddWithValue("@Imidacloprid", Imidacloprid);
            cmd.Parameters.AddWithValue("@KresoximMethyl", KresoximMethyl);
            cmd.Parameters.AddWithValue("@Malathion", Malathion);
            cmd.Parameters.AddWithValue("@Metalaxyl", Metalaxyl);
            cmd.Parameters.AddWithValue("@Methiocarb", Methiocarb);
            cmd.Parameters.AddWithValue("@Methomyl", Methomyl);
            cmd.Parameters.AddWithValue("@Mevinphos", Mevinphos);
            cmd.Parameters.AddWithValue("@MethylParathion", MethylParathion);
            cmd.Parameters.AddWithValue("@Myclobutanil", Myclobutanil);
            cmd.Parameters.AddWithValue("@Naled", Naled);
            cmd.Parameters.AddWithValue("@Oxamyl", Oxamyl);
            cmd.Parameters.AddWithValue("@Pentachloronitrobenzene", Pentachloronitrobenzene);
            cmd.Parameters.AddWithValue("@Permethrins", Permethrins);
            cmd.Parameters.AddWithValue("@Phosmet", Phosmet);
            cmd.Parameters.AddWithValue("@PiperonylButoxide", PiperonylButoxide);
            cmd.Parameters.AddWithValue("@Prallethrin", Prallethrin);
            cmd.Parameters.AddWithValue("@Propiconazole", Propiconazole);
            cmd.Parameters.AddWithValue("@Propoxur", Propoxur);
            cmd.Parameters.AddWithValue("@Pyrethrins", Pyrethrins);
            cmd.Parameters.AddWithValue("@Pyridaben", Pyridaben);
            cmd.Parameters.AddWithValue("@SpinetoramJ", SpinetoramJ);
            cmd.Parameters.AddWithValue("@SpinetoramL", SpinetoramL);
            cmd.Parameters.AddWithValue("@SpinosadA", SpinosadA);
            cmd.Parameters.AddWithValue("@SpinosadD", SpinosadD);
            cmd.Parameters.AddWithValue("@Spiromesifen", Spiromesifen);
            cmd.Parameters.AddWithValue("@Spirotetramat", Spirotetramat);
            cmd.Parameters.AddWithValue("@Spiroxamine", Spiroxamine);
            cmd.Parameters.AddWithValue("@Tebuconazole", Tebuconazole);
            cmd.Parameters.AddWithValue("@Thiacloprid", Thiacloprid);
            cmd.Parameters.AddWithValue("@Thiamethoxam", Thiamethoxam);
            cmd.Parameters.AddWithValue("@Trifloxystrobin", Trifloxystrobin);
            cmd.Parameters.AddWithValue("@Paclobutrazol", Paclobutrazol);
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
        private void update(int Idnew, string SampleIDnew, string LCMSIDnew, string GCMSIDnew, string PestInputWtnew, string Abamectinnew, string Acephatenew, string Acequinocylnew, string Acetamipridnew, string Aldicarbnew, string Azoxystrobinnew, string Bifenazatenew, string Bifenthrinnew, string Boscalidnew, string Captannew, string Carbarylnew, string Carbofurannew, string Chlorantranilprolenew, string Chlordanenew, string Chlorfenapyrnew, string Chlorpyrifosnew, string Clofentezinenew, string Coumaphosnew, string Cyfluthrinnew, string Cypermethrinnew, string Daminozidenew, string Dichlorvosnew, string Diazinonnew, string Dimethoatenew, string Dimethomorphnew, string Ethoprophosnew, string Etofenproxnew, string Etoxazolenew, string Fenhexamidnew, string Fenoxycarbnew, string Fenpyroximatenew, string Fipronilnew, string Flonicamidnew, string Fludioxonilnew, string Hexythiazoxnew, string Imazalilnew, string Imidacloprid, string KresoximMethylnew, string Malathionnew, string Metalaxylnew, string Methiocarbnew, string Methomylnew, string Mevinphosnew, string MethylParathionnew, string Myclobutanilnew, string Nalednew, string Oxamylnew, string Pentachloronitrobenzenenew, string Permethrinsnew, string Phosmetnew, string PiperonylButoxidenew, string Prallethrinnew, string Propiconazolenew, string Propoxurnew, string Pyrethrinsnew, string Pyridabennew, string SpinetoramJnew, string SpinetoramL, string SpinosadAnew, string SpinosadDnew, string Spiromesifennew, string Spirotetramatnew, string Spiroxaminenew, string Tebuconazolenew, string Thiaclopridnew, string Thiamethoxamnew, string Trifloxystrobinnew, string Paclobutrazolnew)
        {
            //SQL
            string sql = "UPDATE pesticidesDATA SET SAMPLEID= '" + SAMPLEIDlbl.Text + "', LCMSID= '" + lcmsIDtb.Text + "', GCMSID= '" + gcmsIDtb.Text + "',PestInputWt= '" + pestInputWtTB.Text + "',Abamectin='" + AbamectinTB.Text + "',Acephate= '" + AcephateTB.Text + "', Acequinocyl= '" + AcequinocylTB.Text + "', Acetamiprid= '" + AcetamipridTB.Text + "', Aldicarb= '" + AldicarbTB.Text + "', Azoxystrobin= '" + AzoxystrobinTB.Text + "',Bifenazate= '" + BifenazateTB.Text + "',Bifenthrin='" + BifenthrinTB.Text + "',Boscalid= '" + BoscalidTB.Text + "', Captan= '" + CaptanTB.Text + "',Carbaryl= '" + CarbarylTB.Text + "', Carbofuran= '" + CarbofuranTB.Text + "', Chlorantranilprole= '" + ChlorantraniliproleTB.Text + "', Chlordane= '" + ChlordaneTB.Text + "', Chlorfenapyr= '" + ChlorfenapyrTB.Text + "',Chlorpyrifos='" + ChlorpyrifosTB.Text + "',Clofentezine= '" + ClofentezineTB.Text + "', Coumaphos= '" + CoumaphosTB.Text + "',Cyfluthrin= '" + CyfluthrinTB.Text + "',Cypermethrin='" + CypermethrinTB.Text + "',Daminozide= '" + DaminozideTB.Text + "', Dichlorvos= '" + DichlorvosTB.Text + "', Diazinon= '" + DiazinonTB.Text + "', Dimethoate= '" + DimethoateTB.Text + "',Dimethomorph= '" + DimethomorphTB.Text + "', Ethoprophos= '" + EthoprophosTB.Text + "', Etofenprox= '" + EtofenproxTB.Text + "', Etoxazole= '" + EtoxazoleTB.Text + "',Fenhexamid= '" + FenhexamidTB.Text + "', Fenoxycarb= '" + FenoxycarbTB.Text + "', Fenpyroximate= '" + FenpyroximateTB.Text + "', Fipronil= '" + FipronilTB.Text + "', Flonicamid= '" + FlonicamidTB.Text + "',Fludioxonil='" + FludioxonilTB.Text + "',Hexythiazox= '" + HexythiazoxTB.Text + "', Imazalil= '" + ImazalilTB.Text + "',Imidacloprid= '" + ImidaclopridTB.Text + "',KresoximMethyl='" + KresoximMethylTB.Text + "',Malathion= '" + MalathionTB.Text + "', Metalaxyl= '" + MetalaxylTB.Text + "', Methiocarb= '" + MethiocarbTB.Text + "', Methomyl= '" + MethomylTB.Text + "',Mevinphos= '" + MevinphosTB.Text + "', MethylParathion= '" + MethylParathionTB.Text + "', Myclobutanil= '" + MyclobutanilTB.Text + "', Naled= '" + NaledTB.Text + "',Oxamyl= '" + OxamylTB.Text + "',Pentachloronitrobenzene='" + PentachloronitrobenzeneTB.Text + "',Permethrins= '" + PermethrinsTB.Text + "', Phosmet= '" + PhosmetTB.Text + "',PiperonylButoxide= '" + PiperonylButoxideTB.Text + "', Prallethrin= '" + PrallethrinTB.Text + "', Propiconazole= '" + PropiconazoleTB.Text + "', Propoxur= '" + PropoxurTB.Text + "', Pyrethrins= '" + PyrethrinsTB.Text + "',Pyridaben='" + PyridabenTB.Text + "',SpinetoramJ= '" + SpinetoramJTB.Text + "', SpinetoramL= '" + SpinetoramLTB.Text + "',SpinosadA= '" + SpinosadATB.Text + "',SpinosadD='" + SpinosadDTB.Text + "',Spiromesifen= '" + SpiromesifenTB.Text + "', Spirotetramat= '" + SpirotetramatTB.Text + "', Spiroxamine= '" + SpiroxamineTB.Text + "', Tebuconazole= '" + TebuconazoleTB.Text + "',Thiacloprid= '" + ThiaclopridTB.Text + "', Thiamethoxam= '" + ThiamethoxamTB.Text + "', Trifloxystrobin= '" + TrifloxystrobinTB.Text + "', Paclobutrazol= '" + PaclobutrazolTB.Text + "' WHERE Id= " + iDlbl.Text;
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
        //Class to call data back from SQL
        public void showData(int index)
        {

            var a = 0;
            for (a = 0; a < dt.Rows.Count; a++)
            {
                iDlbl.Text = dt.Rows[index][0].ToString();
                SAMPLEIDlbl.Text = dt.Rows[index][1].ToString();
                lcmsIDtb.Text = dt.Rows[index][2].ToString();
                gcmsIDtb.Text = dt.Rows[index][3].ToString();
                pestInputWtTB.Text = dt.Rows[index][4].ToString();
                AbamectinTB.Text = dt.Rows[index][5].ToString();
                AcephateTB.Text = dt.Rows[index][6].ToString();
                AcequinocylTB.Text = dt.Rows[index][7].ToString();
                AcetamipridTB.Text = dt.Rows[index][8].ToString();
                AldicarbTB.Text = dt.Rows[index][9].ToString();
                AzoxystrobinTB.Text = dt.Rows[index][10].ToString();
                BifenazateTB.Text = dt.Rows[index][11].ToString();
                BifenthrinTB.Text = dt.Rows[index][12].ToString();
                BoscalidTB.Text = dt.Rows[index][13].ToString();
                CaptanTB.Text = dt.Rows[index][14].ToString();
                CarbarylTB.Text = dt.Rows[index][15].ToString();
                CarbofuranTB.Text = dt.Rows[index][16].ToString();
                ChlorantraniliproleTB.Text = dt.Rows[index][17].ToString();
                ChlordaneTB.Text = dt.Rows[index][18].ToString();
                ChlorfenapyrTB.Text = dt.Rows[index][19].ToString();
                ChlorpyrifosTB.Text = dt.Rows[index][20].ToString();
                ClofentezineTB.Text = dt.Rows[index][21].ToString();
                CoumaphosTB.Text = dt.Rows[index][22].ToString();
                CyfluthrinTB.Text = dt.Rows[index][23].ToString();
                CypermethrinTB.Text = dt.Rows[index][24].ToString();
                DaminozideTB.Text = dt.Rows[index][25].ToString();
                DichlorvosTB.Text = dt.Rows[index][26].ToString();
                DiazinonTB.Text = dt.Rows[index][27].ToString();
                DimethoateTB.Text = dt.Rows[index][28].ToString();
                DimethomorphTB.Text = dt.Rows[index][29].ToString();
                EthoprophosTB.Text = dt.Rows[index][30].ToString();
                EtofenproxTB.Text = dt.Rows[index][31].ToString();
                EtoxazoleTB.Text = dt.Rows[index][32].ToString();
                FenhexamidTB.Text = dt.Rows[index][33].ToString();
                FenoxycarbTB.Text = dt.Rows[index][34].ToString();
                FenpyroximateTB.Text = dt.Rows[index][35].ToString();
                FipronilTB.Text = dt.Rows[index][36].ToString();
                FlonicamidTB.Text = dt.Rows[index][37].ToString();
                FludioxonilTB.Text = dt.Rows[index][38].ToString();
                HexythiazoxTB.Text = dt.Rows[index][39].ToString();
                ImazalilTB.Text = dt.Rows[index][40].ToString();
                ImidaclopridTB.Text = dt.Rows[index][41].ToString();
                KresoximMethylTB.Text = dt.Rows[index][42].ToString();
                MalathionTB.Text = dt.Rows[index][43].ToString();
                MetalaxylTB.Text = dt.Rows[index][44].ToString();
                MethiocarbTB.Text = dt.Rows[index][45].ToString();
                MethomylTB.Text = dt.Rows[index][46].ToString();
                MethylParathionTB.Text = dt.Rows[index][47].ToString();
                MevinphosTB.Text = dt.Rows[index][48].ToString();
                MyclobutanilTB.Text = dt.Rows[index][49].ToString();
                NaledTB.Text = dt.Rows[index][50].ToString();
                OxamylTB.Text = dt.Rows[index][51].ToString();
                PentachloronitrobenzeneTB.Text = dt.Rows[index][52].ToString();
                PermethrinsTB.Text = dt.Rows[index][53].ToString();
                PhosmetTB.Text = dt.Rows[index][54].ToString();
                PiperonylButoxideTB.Text = dt.Rows[index][55].ToString();
                PrallethrinTB.Text = dt.Rows[index][56].ToString();
                PropiconazoleTB.Text = dt.Rows[index][57].ToString();
                PropoxurTB.Text = dt.Rows[index][58].ToString();
                PyrethrinsTB.Text = dt.Rows[index][59].ToString();
                PyridabenTB.Text = dt.Rows[index][60].ToString();
                SpinetoramJTB.Text = dt.Rows[index][61].ToString();
                SpinetoramLTB.Text = dt.Rows[index][62].ToString();
                SpinosadATB.Text = dt.Rows[index][63].ToString();
                SpinosadDTB.Text = dt.Rows[index][64].ToString();
                SpiromesifenTB.Text = dt.Rows[index][65].ToString();
                SpirotetramatTB.Text = dt.Rows[index][66].ToString();
                SpiroxamineTB.Text = dt.Rows[index][67].ToString();
                TebuconazoleTB.Text = dt.Rows[index][68].ToString();
                ThiaclopridTB.Text = dt.Rows[index][69].ToString();
                ThiamethoxamTB.Text = dt.Rows[index][70].ToString();
                TrifloxystrobinTB.Text = dt.Rows[index][71].ToString();
                PaclobutrazolTB.Text = dt.Rows[index][72].ToString();

            }

        }

        private void openLCbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog
            {
                // Openfile Parameters
                InitialDirectory = "",
                Filter = "Xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            //Open file & Load XML

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {

                AbamectinTB.Text = "0";
                AcephateTB.Text = "0";
                AcequinocylTB.Text = "0";
                AcetamipridTB.Text = "0";
                AldicarbTB.Text = "0";
                AzoxystrobinTB.Text = "0";
                BifenazateTB.Text = "0";
                BifenthrinTB.Text = "0";
                BoscalidTB.Text = "0";
                CarbarylTB.Text = "0";
                CarbofuranTB.Text = "0";
                ChlorantraniliproleTB.Text = "0";
                ChlorpyrifosTB.Text = "0";
                ClofentezineTB.Text = "0";
                CoumaphosTB.Text = "0";
                DaminozideTB.Text = "0";
                DiazinonTB.Text = "0";
                DichlorvosTB.Text = "0";
                DimethoateTB.Text = "0";
                DimethomorphTB.Text = "0";
                EthoprophosTB.Text = "0";
                EtofenproxTB.Text = "0";
                EtoxazoleTB.Text = "0";
                FenhexamidTB.Text = "0";
                FenoxycarbTB.Text = "0";
                FenpyroximateTB.Text = "0";
                FipronilTB.Text = "0";
                FludioxonilTB.Text = "0";
                HexythiazoxTB.Text = "0";
                ImazalilTB.Text = "0";
                ImidaclopridTB.Text = "0";
                KresoximMethylTB.Text = "0";
                MalathionTB.Text = "0";
                MetalaxylTB.Text = "0";
                MethomylTB.Text = "0";
                MevinphosTB.Text = "0";
                MyclobutanilTB.Text = "0";
                NaledTB.Text = "0";
                OxamylTB.Text = "0";
                PermethrinsTB.Text = "0";
                PhosmetTB.Text = "0";
                PiperonylButoxideTB.Text = "0";
                PrallethrinTB.Text = "0";
                PropiconazoleTB.Text = "0";
                PropoxurTB.Text = "0";
                PyrethrinsTB.Text = "0";
                PyridabenTB.Text = "0";
                SpinetoramJTB.Text = "0";
                SpinetoramLTB.Text = "0";
                SpinosadATB.Text = "0";
                SpinosadDTB.Text = "0";
                SpiromesifenTB.Text = "0";
                SpirotetramatTB.Text = "0";
                SpiroxamineTB.Text = "0";
                TebuconazoleTB.Text = "0";
                ThiaclopridTB.Text = "0";
                ThiamethoxamTB.Text = "0";
                TrifloxystrobinTB.Text = "0";
                PaclobutrazolTB.Text = "0";

                StreamReader sr = new StreamReader(openFileDialog3.FileName, Encoding.Default);
                XmlDocument xmlDoc1 = new XmlDocument();
                xmlDoc1.Load(sr);
                //Save XML to Node

                XmlNode abamectin = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Abamectin']//PEAK");
                XmlNode acephate = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Acephate']//PEAK");
                XmlNode acequinocyl = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Acequinocyl']//PEAK");
                XmlNode acetamiprid = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Acetamiprid']//PEAK");
                XmlNode aldicarb = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Aldicarb']//PEAK");
                XmlNode azoxystrobin = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Azoxystrobin']//PEAK");
                XmlNode bifenazate = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Bifenazate']//PEAK");
                XmlNode bifenthrin = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Bifenthrin']//PEAK");
                XmlNode boscalid = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Boscalid']//PEAK");
                XmlNode carbaryl = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Carbaryl']//PEAK");
                XmlNode carbofuran = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Carbofuran']//PEAK");
                XmlNode chlorantranilprole = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Chlorantraniliprole']//PEAK");
                XmlNode chlorpyrifos = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Chlorpyrifos']//PEAK");
                XmlNode clofentezine = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Clofentazine']//PEAK");
                XmlNode coumaphos = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Coumaphos']//PEAK");
                XmlNode daminozide = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Daminozide']//PEAK");
                XmlNode dichlorvos = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='DDVP Dichlorvos']//PEAK");
                XmlNode diazinon = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Diazinon']//PEAK");
                XmlNode dimethoate = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Dimethoate']//PEAK");
                XmlNode dimethomorph = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Dimethomorph']//PEAK");
                XmlNode ethoprophos = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Ethoprophos']//PEAK");
                XmlNode etofenprox = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Etofenprox']//PEAK");
                XmlNode etoxazole = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Etoxazole']//PEAK");
                XmlNode fenhexamid = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Fenhexamid']//PEAK");
                XmlNode fenoxycarb = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Fenoxycarb']//PEAK");
                XmlNode fenpyroximate = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Fenpyroximate']//PEAK");
                XmlNode fipronil = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Fipronil']//PEAK");
                XmlNode fludioxinil = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Fludioxinil']//PEAK");
                XmlNode hexythiazox = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Hexythiazox']//PEAK");
                XmlNode imazalil = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Imazalil']//PEAK");
                XmlNode imidacloprid = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Imidacloprid']//PEAK");
                XmlNode kresoximMethyl = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Kresoxim-methyl']//PEAK");
                XmlNode malathion = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Malathion']//PEAK");
                XmlNode metalaxyl = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Metalaxyl']//PEAK");
                XmlNode methomyl = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Methomyl']//PEAK");
                XmlNode mevinphos = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Mevinphos']//PEAK");
                XmlNode myclobutanil = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Myclobutanil']//PEAK");
                XmlNode naled = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Naled']//PEAK");
                XmlNode oxamyl = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Oxamyl']//PEAK");
                XmlNode permethrin = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Permethrin']//PEAK");
                XmlNode phosmet = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Phosmet']//PEAK");
                XmlNode piperonylButoxide = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Piperonyl Butoxide']//PEAK");
                XmlNode prallethrin = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Prallethrin']//PEAK");
                XmlNode propiconazole = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Propiconazole']//PEAK");
                XmlNode propoxur = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Propoxur']//PEAK");
                XmlNode pyrethrins = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Pyrethrins']//PEAK");
                XmlNode pyridaben = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Pyridaben']//PEAK");
                XmlNode spinetoramJ = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spinetoram J']//PEAK");
                XmlNode spinetoramL = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spinetoram L']//PEAK");
                XmlNode spinosadA = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spinosad A']//PEAK");
                XmlNode spinosadD = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spinosad D']//PEAK");
                XmlNode spirotetramat = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spirotetramat']//PEAK");
                XmlNode spiromesifen = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spiromesifen']//PEAK");
                XmlNode spiroxamine = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Spiroxamine']//PEAK");
                XmlNode Tebuconazole = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Tebucanozole']//PEAK");
                XmlNode thiacloprid = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Thiacloprid']//PEAK");
                XmlNode thiamethoxam = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Thiamethoxam']//PEAK");
                XmlNode trifloxystrobin = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Trifloxystrobin']//PEAK");
                XmlNode paclobutrazol = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA/SAMPLE/COMPOUND[@name='Paclobutrazole']//PEAK");
                XmlNode LCMSIDxml = xmlDoc1.DocumentElement.SelectSingleNode("/QUANDATASET/GROUPDATA/GROUP/SAMPLELISTDATA//SAMPLE");



                //Display Potency info if not NULL



                if (abamectin != null)
                {


                    double abamectindec = Math.Round(double.Parse(abamectin.Attributes["analconc"].Value), 3);
                    AbamectinTB.Text = abamectindec.ToString();

                }
                if (acephate != null)

                {
                    double acephatedec = Math.Round(double.Parse(acephate.Attributes["analconc"].Value), 3);
                    AcephateTB.Text = acephatedec.ToString();
                }


                if (acequinocyl != null)

                {
                    double acequinocyldec = Math.Round(double.Parse(acequinocyl.Attributes["analconc"].Value), 3);
                    AcequinocylTB.Text = acequinocyldec.ToString();

                }

                if (acetamiprid != null)
                {
                    double acetamipriddec = Math.Round(double.Parse(acetamiprid.Attributes["analconc"].Value), 3);
                    AcetamipridTB.Text = acetamipriddec.ToString();
                }

                if (aldicarb != null)
                {
                    double aldicarbdec = Math.Round(double.Parse(aldicarb.Attributes["analconc"].Value), 3);
                    AldicarbTB.Text = aldicarbdec.ToString();

                }

                if (azoxystrobin != null)
                {
                    double azoxystrobindec = Math.Round(double.Parse(azoxystrobin.Attributes["analconc"].Value), 3);
                    AzoxystrobinTB.Text = azoxystrobindec.ToString();

                }

                if (bifenazate != null)
                {
                    double bifenazatedec = Math.Round(double.Parse(bifenazate.Attributes["analconc"].Value), 3);
                    BifenazateTB.Text = bifenazatedec.ToString();

                }
                if (bifenthrin != null)
                {
                    double bifenthrindec = Math.Round(double.Parse(bifenthrin.Attributes["analconc"].Value), 3);
                    BifenthrinTB.Text = bifenthrindec.ToString();

                }
                if (boscalid != null)
                {
                    double boscaliddec = Math.Round(double.Parse(boscalid.Attributes["analconc"].Value), 3);
                    BoscalidTB.Text = boscaliddec.ToString();

                }

                if (carbaryl != null)
                {
                    double carbaryldec = Math.Round(double.Parse(carbaryl.Attributes["analconc"].Value), 3);
                    CarbarylTB.Text = carbaryldec.ToString();

                }
                if (carbofuran != null)
                {


                    double carbofurandec = Math.Round(double.Parse(carbofuran.Attributes["analconc"].Value), 3);
                    CarbofuranTB.Text = carbofurandec.ToString();

                }
                if (chlorantranilprole != null)

                {
                    double chlorantranilproledec = Math.Round(double.Parse(chlorantranilprole.Attributes["analconc"].Value), 3);
                    ChlorantraniliproleTB.Text = chlorantranilproledec.ToString();
                }
                if (chlorpyrifos != null)
                {
                    double chlorpyrifosdec = Math.Round(double.Parse(chlorpyrifos.Attributes["analconc"].Value), 3);
                    ChlorpyrifosTB.Text = chlorpyrifosdec.ToString();

                }

                if (clofentezine != null)
                {
                    double clofentezinendec = Math.Round(double.Parse(clofentezine.Attributes["analconc"].Value), 3);
                    ClofentezineTB.Text = clofentezinendec.ToString();

                }

                if (coumaphos != null)
                {
                    double coumaphosdec = Math.Round(double.Parse(coumaphos.Attributes["analconc"].Value), 3);
                    CoumaphosTB.Text = coumaphosdec.ToString();

                }

                if (daminozide != null)
                {
                    double daminozidedec = Math.Round(double.Parse(daminozide.Attributes["analconc"].Value), 3);
                    DaminozideTB.Text = daminozidedec.ToString();

                }

                if (dichlorvos != null)
                {
                    double dichlorvosdec = Math.Round(double.Parse(dichlorvos.Attributes["analconc"].Value), 3);
                    DichlorvosTB.Text = dichlorvosdec.ToString();

                }
                if (diazinon != null)
                {


                    double diazinondec = Math.Round(double.Parse(diazinon.Attributes["analconc"].Value), 3);
                    DiazinonTB.Text = diazinondec.ToString();

                }
                if (dimethoate != null)

                {
                    double dimethoatedec = Math.Round(double.Parse(dimethoate.Attributes["analconc"].Value), 3);
                    DimethoateTB.Text = dimethoatedec.ToString();
                }


                if (dimethomorph != null)

                {
                    double dimethomorphdec = Math.Round(double.Parse(dimethomorph.Attributes["analconc"].Value), 3);
                    DimethomorphTB.Text = dimethomorphdec.ToString();

                }

                if (ethoprophos != null)
                {
                    double ethoprophosdec = Math.Round(double.Parse(ethoprophos.Attributes["analconc"].Value), 3);
                    EthoprophosTB.Text = ethoprophosdec.ToString();
                }

                if (etofenprox != null)
                {
                    double etofenproxdec = Math.Round(double.Parse(etofenprox.Attributes["analconc"].Value), 3);
                    EtofenproxTB.Text = etofenproxdec.ToString();

                }

                if (etoxazole != null)
                {
                    double etoxazoledec = Math.Round(double.Parse(etoxazole.Attributes["analconc"].Value), 3);
                    EtoxazoleTB.Text = etoxazoledec.ToString();

                }

                if (fenhexamid != null)
                {
                    double fenhexamiddec = Math.Round(double.Parse(fenhexamid.Attributes["analconc"].Value), 3);
                    FenhexamidTB.Text = fenhexamiddec.ToString();

                }
                if (fenoxycarb != null)
                {
                    double fenoxycarbdec = Math.Round(double.Parse(fenoxycarb.Attributes["analconc"].Value), 3);
                    FenoxycarbTB.Text = fenoxycarbdec.ToString();

                }
                if (fenpyroximate != null)
                {
                    double fenpyroximatedec = Math.Round(double.Parse(fenpyroximate.Attributes["analconc"].Value), 3);
                    FenpyroximateTB.Text = fenpyroximatedec.ToString();

                }

                if (fipronil != null)
                {
                    double fipronildec = Math.Round(double.Parse(fipronil.Attributes["analconc"].Value), 3);
                    FipronilTB.Text = fipronildec.ToString();

                }
                if (fludioxinil != null)
                {


                    double fludioxinildec = Math.Round(double.Parse(fludioxinil.Attributes["analconc"].Value), 3);
                    FludioxonilTB.Text = fludioxinildec.ToString();

                }
                if (hexythiazox != null)

                {
                    double hexythiazoxdec = Math.Round(double.Parse(hexythiazox.Attributes["analconc"].Value), 3);
                    HexythiazoxTB.Text = hexythiazoxdec.ToString();
                }


                if (imazalil != null)

                {
                    double imazalildec = Math.Round(double.Parse(imazalil.Attributes["analconc"].Value), 3);
                    ImazalilTB.Text = imazalildec.ToString();

                }

                if (imidacloprid != null)
                {
                    double imidaclopriddec = Math.Round(double.Parse(imidacloprid.Attributes["analconc"].Value), 3);
                    ImidaclopridTB.Text = imidaclopriddec.ToString();
                }

                if (kresoximMethyl != null)
                {
                    double kresoximMethyldec = Math.Round(double.Parse(kresoximMethyl.Attributes["analconc"].Value), 3);
                    KresoximMethylTB.Text = kresoximMethyldec.ToString();

                }

                if (malathion != null)
                {
                    double malathiondec = Math.Round(double.Parse(malathion.Attributes["analconc"].Value), 3);
                    MalathionTB.Text = malathiondec.ToString();

                }

                if (metalaxyl != null)
                {
                    double metalaxyldec = Math.Round(double.Parse(metalaxyl.Attributes["analconc"].Value), 3);
                    MetalaxylTB.Text = metalaxyldec.ToString();

                }
                if (methomyl != null)
                {
                    double methomyldec = Math.Round(double.Parse(methomyl.Attributes["analconc"].Value), 3);
                    MethomylTB.Text = methomyldec.ToString();

                }
                if (mevinphos != null)
                {
                    double mevinphosdec = Math.Round(double.Parse(mevinphos.Attributes["analconc"].Value), 3);
                    MevinphosTB.Text = mevinphosdec.ToString();

                }
                if (myclobutanil != null)
                {


                    double myclobutanildec = Math.Round(double.Parse(myclobutanil.Attributes["analconc"].Value), 3);
                    MyclobutanilTB.Text = myclobutanildec.ToString();

                }
                if (naled != null)

                {
                    double naleddec = Math.Round(double.Parse(naled.Attributes["analconc"].Value), 3);
                    NaledTB.Text = naleddec.ToString();
                }


                if (oxamyl != null)

                {
                    double oxamyldec = Math.Round(double.Parse(oxamyl.Attributes["analconc"].Value), 3);
                    OxamylTB.Text = oxamyldec.ToString();

                }
                if (paclobutrazol != null)

                {
                    double pacdec = Math.Round(double.Parse(paclobutrazol.Attributes["analconc"].Value), 3);
                    PaclobutrazolTB.Text = pacdec.ToString();
                }

                if (permethrin != null)
                {
                    double permethrinsdec = Math.Round(double.Parse(permethrin.Attributes["analconc"].Value), 3);
                    PermethrinsTB.Text = permethrinsdec.ToString();

                }

                if (phosmet != null)
                {
                    double phosmetdec = Math.Round(double.Parse(phosmet.Attributes["analconc"].Value), 3);
                    PhosmetTB.Text = phosmetdec.ToString();

                }

                if (piperonylButoxide != null)
                {
                    double piperonylButoxidedec = Math.Round(double.Parse(piperonylButoxide.Attributes["analconc"].Value), 3);
                    PiperonylButoxideTB.Text = piperonylButoxidedec.ToString();

                }
                if (prallethrin != null)
                {
                    double prallethrindec = Math.Round(double.Parse(prallethrin.Attributes["analconc"].Value), 3);
                    PrallethrinTB.Text = prallethrindec.ToString();

                }
                if (propiconazole != null)
                {
                    double propiconazoledec = Math.Round(double.Parse(propiconazole.Attributes["analconc"].Value), 3);
                    PropiconazoleTB.Text = propiconazoledec.ToString();

                }

                if (propoxur != null)
                {
                    double propoxurdec = Math.Round(double.Parse(propoxur.Attributes["analconc"].Value), 3);
                    PropoxurTB.Text = propoxurdec.ToString();

                }

                if (pyrethrins != null)
                {
                    double pyrethrinsdec = Math.Round(double.Parse(pyrethrins.Attributes["analconc"].Value), 3);
                    PyrethrinsTB.Text = pyrethrinsdec.ToString();

                }
                if (pyridaben != null)
                {

                    double pyridabendec = Math.Round(double.Parse(pyridaben.Attributes["analconc"].Value), 3);
                    PyridabenTB.Text = pyridabendec.ToString();

                }
                if (spinetoramJ != null)

                {
                    double spinetoramJdec = Math.Round(double.Parse(spinetoramJ.Attributes["analconc"].Value), 3);
                    SpinetoramJTB.Text = spinetoramJdec.ToString();
                }


                if (spinetoramL != null)

                {
                    double spinetoramLdec = Math.Round(double.Parse(spinetoramL.Attributes["analconc"].Value), 3);
                    SpinetoramLTB.Text = spinetoramLdec.ToString();

                }

                if (spinosadA != null)
                {
                    double spinosadAdec = Math.Round(double.Parse(spinosadA.Attributes["analconc"].Value), 3);
                    SpinosadATB.Text = spinosadAdec.ToString();
                }
                if (spinosadD != null)
                {
                    double spinosadDdec = Math.Round(double.Parse(spinosadD.Attributes["analconc"].Value), 3);
                    SpinosadDTB.Text = spinosadDdec.ToString();
                }
                if (spiromesifen != null)
                {
                    double spiromesifendec = Math.Round(double.Parse(spiromesifen.Attributes["analconc"].Value), 3);
                    SpiromesifenTB.Text = spiromesifendec.ToString();
                }
                if (spirotetramat != null)
                {
                    double spirotetramatdec = Math.Round(double.Parse(spirotetramat.Attributes["analconc"].Value), 3);
                    SpirotetramatTB.Text = spirotetramatdec.ToString();

                }

                if (spiroxamine != null)
                {
                    double spiroxaminedec = Math.Round(double.Parse(spiroxamine.Attributes["analconc"].Value), 3);
                    SpiroxamineTB.Text = spiroxaminedec.ToString();

                }

                if (Tebuconazole != null)
                {
                    double Tebuconazoledec = Math.Round(double.Parse(Tebuconazole.Attributes["analconc"].Value), 3);
                    TebuconazoleTB.Text = Tebuconazoledec.ToString();

                }
                if (thiacloprid != null)
                {
                    double thiaclopriddec = Math.Round(double.Parse(thiacloprid.Attributes["analconc"].Value), 3);
                    ThiaclopridTB.Text = thiaclopriddec.ToString();

                }
                if (thiamethoxam != null)
                {
                    double thiamethoxamdec = Math.Round(double.Parse(thiamethoxam.Attributes["analconc"].Value), 3);
                    ThiamethoxamTB.Text = thiamethoxamdec.ToString();

                }

                if (trifloxystrobin != null)
                {
                    double trifloxystrobindec = Math.Round(double.Parse(trifloxystrobin.Attributes["analconc"].Value), 3);
                    TrifloxystrobinTB.Text = trifloxystrobindec.ToString();

                }

                if (LCMSIDxml != null)
                {

                    lcmsIDtb.Text = LCMSIDxml.Attributes["name"].Value;

                }

            }
        }

        private void openGCbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog4 = new OpenFileDialog
            {
                // Openfile Parameters
                InitialDirectory = "",
                Filter = "CSV files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true
            };



            //Open file & Load
            if (openFileDialog4.ShowDialog() == DialogResult.OK)
            {
                CaptanTB.Text = "0";
                ChlordaneTB.Text = "0";
                ChlorfenapyrTB.Text = "0";
                CyfluthrinTB.Text = "0";
                CypermethrinTB.Text = "0";
                FlonicamidTB.Text = "0";
                MethylParathionTB.Text = "0";
                MethiocarbTB.Text = "0";
                PentachloronitrobenzeneTB.Text = "0";


                StreamReader sr2 = new StreamReader(openFileDialog4.FileName, Encoding.Default);
                string[] line;
                line = sr2.ReadToEnd().Split(',', '"');

                PestiGC pGC = new PestiGC();


                pGC.GCMSIDcsv = line[1];
                pGC.captan = line[53];
                pGC.chlordane = line[58];
                pGC.chlorfenapyr = line[63];
                pGC.cyfluthrin = line[68];
                pGC.cypermethrin = line[73];
                pGC.flonicamid = line[38];
                pGC.methylParathion = line[48];
                pGC.methiocarb = line[33];
                pGC.pentachloronitrobenzene = line[43];
                if (pGC.captan != null)
                {

                    CaptanTB.Text = pGC.captan.ToString();

                }
                if (pGC.chlordane != null)

                {

                    ChlordaneTB.Text = pGC.chlordane.ToString();

                }

                if (pGC.chlorfenapyr != null)
                {

                    ChlorfenapyrTB.Text = pGC.chlorfenapyr.ToString();
                }
                if (pGC.cyfluthrin != null)
                {

                    CyfluthrinTB.Text = pGC.cyfluthrin.ToString();

                }
                if (pGC.cypermethrin != null)
                {

                    CypermethrinTB.Text = pGC.cypermethrin.ToString();
                }
                if (pGC.flonicamid != null)
                {

                    FlonicamidTB.Text = pGC.flonicamid.ToString();

                }
                if (pGC.methiocarb != null)
                {

                    MethiocarbTB.Text = pGC.methiocarb.ToString();

                }

                if (pGC.methylParathion != null)
                {

                    MethylParathionTB.Text = pGC.methylParathion.ToString();

                }

                if (pGC.pentachloronitrobenzene != null)
                {

                    PentachloronitrobenzeneTB.Text = pGC.pentachloronitrobenzene.ToString();
                }
                if (pGC.GCMSIDcsv != null)
                {

                    gcmsIDtb.Text = pGC.GCMSIDcsv.ToString();
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            add(SAMPLEIDlbl.Text,
               lcmsIDtb.Text,
               gcmsIDtb.Text,
               pestInputWtTB.Text,
               AbamectinTB.Text,
               AcephateTB.Text,
               AcequinocylTB.Text,
               AcetamipridTB.Text,
               AldicarbTB.Text,
               AzoxystrobinTB.Text,
               BifenazateTB.Text,
               BifenthrinTB.Text,
               BoscalidTB.Text,
               CaptanTB.Text,
               CarbarylTB.Text,
               CarbofuranTB.Text,
               ChlorantraniliproleTB.Text,
               ChlordaneTB.Text,
               ChlorfenapyrTB.Text,
               ChlorpyrifosTB.Text,
               ClofentezineTB.Text,
               CoumaphosTB.Text,
               CyfluthrinTB.Text,
               CypermethrinTB.Text,
               DaminozideTB.Text,
               DichlorvosTB.Text,
               DiazinonTB.Text,
               DimethoateTB.Text,
               DimethomorphTB.Text,
               EthoprophosTB.Text,
               EtofenproxTB.Text,
               EtoxazoleTB.Text,
               FenhexamidTB.Text,
               FenoxycarbTB.Text,
               FenpyroximateTB.Text,
               FipronilTB.Text,
               FlonicamidTB.Text,
               FludioxonilTB.Text,
               HexythiazoxTB.Text,
               ImazalilTB.Text,
               ImidaclopridTB.Text,
               KresoximMethylTB.Text,
               MalathionTB.Text,
               MetalaxylTB.Text,
               MethiocarbTB.Text,
               MethomylTB.Text,
               MethylParathionTB.Text,
               MevinphosTB.Text,
               MyclobutanilTB.Text,
               NaledTB.Text,
               OxamylTB.Text,
               PentachloronitrobenzeneTB.Text,
               PermethrinsTB.Text,
               PhosmetTB.Text,
               PiperonylButoxideTB.Text,
               PrallethrinTB.Text,
               PropiconazoleTB.Text,
               PropoxurTB.Text,
               PyrethrinsTB.Text,
               PyridabenTB.Text,
               SpinetoramJTB.Text,
               SpinetoramLTB.Text,
               SpinosadATB.Text,
               SpinosadDTB.Text,
               SpiromesifenTB.Text,
               SpirotetramatTB.Text,
               SpiroxamineTB.Text,
               TebuconazoleTB.Text,
               ThiaclopridTB.Text,
               ThiamethoxamTB.Text,
               TrifloxystrobinTB.Text,
               PaclobutrazolTB.Text);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int Idnew = Convert.ToInt32(iDlbl.Text);
            string SampleIDnew = SAMPLEIDlbl.Text;
            string LCMSIDnew = lcmsIDtb.Text;
            string GCMSIDnew = gcmsIDtb.Text;
            string PestInputWtnew = pestInputWtTB.Text;
            string Abamectinnew = AbamectinTB.Text;
            string Acephatenew = AcephateTB.Text;
            string Acequinocylnew = AcequinocylTB.Text;
            string Acetamipridnew = AcetamipridTB.Text;
            string Aldicarbnew = AldicarbTB.Text;
            string Azoxystrobinnew = AzoxystrobinTB.Text;
            string Bifenazatenew = BifenazateTB.Text;
            string Bifenthrinnew = BifenthrinTB.Text;
            string Boscalidnew = BoscalidTB.Text;
            string Captannew = CaptanTB.Text;
            string Carbarylnew = CarbarylTB.Text;
            string Carbofurannew = CarbofuranTB.Text;
            string Chlorantranilprolenew = ChlorantraniliproleTB.Text;
            string Chlordanenew = ChlordaneTB.Text;
            string Chlorfenapyrnew = ChlorfenapyrTB.Text;
            string Chlorpyrifosnew = ChlorpyrifosTB.Text;
            string Clofentezinenew = ClofentezineTB.Text;
            string Coumaphosnew = CoumaphosTB.Text;
            string Cyfluthrinnew = CyfluthrinTB.Text;
            string Cypermethrinnew = CypermethrinTB.Text;
            string Daminozidenew = DaminozideTB.Text;
            string Dichlorvosnew = DichlorvosTB.Text;
            string Diazinonnew = DiazinonTB.Text;
            string Dimethoatenew = DimethoateTB.Text;
            string Dimethomorphnew = DimethomorphTB.Text;
            string Ethoprophosnew = EthoprophosTB.Text;
            string Etofenproxnew = EtofenproxTB.Text;
            string Etoxazolenew = EtoxazoleTB.Text;
            string Fenhexamidnew = FenhexamidTB.Text;
            string Fenoxycarbnew = FenoxycarbTB.Text;
            string Fenpyroximatenew = FenpyroximateTB.Text;
            string Fipronilnew = FipronilTB.Text;
            string Flonicamidnew = FlonicamidTB.Text;
            string Fludioxonilnew = FludioxonilTB.Text;
            string Hexythiazoxnew = HexythiazoxTB.Text;
            string Imazalilnew = ImazalilTB.Text;
            string Imidacloprid = ImidaclopridTB.Text;
            string KresoximMethylnew = KresoximMethylTB.Text;
            string Malathionnew = MalathionTB.Text;
            string Metalaxylnew = MetalaxylTB.Text;
            string Methiocarbnew = MethiocarbTB.Text;
            string Methomylnew = MethomylTB.Text;
            string Mevinphosnew = MevinphosTB.Text;
            string MethylParathionnew = MethylParathionTB.Text;
            string Myclobutanilnew = MyclobutanilTB.Text;
            string Nalednew = NaledTB.Text;
            string Oxamylnew = OxamylTB.Text;
            string Pentachloronitrobenzenenew = PentachloronitrobenzeneTB.Text;
            string Permethrinsnew = PermethrinsTB.Text;
            string Phosmetnew = PhosmetTB.Text;
            string PiperonylButoxidenew = PiperonylButoxideTB.Text;
            string Prallethrinnew = PrallethrinTB.Text;
            string Propiconazolenew = PropiconazoleTB.Text;
            string Propoxurnew = PropoxurTB.Text;
            string Pyrethrinsnew = PyrethrinsTB.Text;
            string Pyridabennew = PyridabenTB.Text;
            string SpinetoramJnew = SpinetoramJTB.Text;
            string SpinetoramL = SpinetoramLTB.Text;
            string SpinosadAnew = SpinosadATB.Text;
            string SpinosadDnew = SpinosadDTB.Text;
            string Spiromesifennew = SpiromesifenTB.Text;
            string Spirotetramatnew = SpirotetramatTB.Text;
            string Spiroxaminenew = SpiroxamineTB.Text;
            string Tebuconazolenew = TebuconazoleTB.Text;
            string Thiaclopridnew = ThiaclopridTB.Text;
            string Thiamethoxamnew = ThiamethoxamTB.Text;
            string Trifloxystrobinnew = TrifloxystrobinTB.Text;
            string Paclobutrazolnew = PaclobutrazolTB.Text;

            update(Idnew, SampleIDnew, LCMSIDnew, GCMSIDnew, PestInputWtnew, Abamectinnew, Acephatenew, Acequinocylnew, Acetamipridnew, Aldicarbnew, Azoxystrobinnew, Bifenazatenew, Bifenthrinnew, Boscalidnew, Captannew, Carbarylnew, Carbofurannew, Chlorantranilprolenew, Chlordanenew, Chlorfenapyrnew, Chlorpyrifosnew, Clofentezinenew, Coumaphosnew, Cyfluthrinnew, Cypermethrinnew, Daminozidenew, Dichlorvosnew, Diazinonnew, Dimethoatenew, Dimethomorphnew, Ethoprophosnew, Etofenproxnew, Etoxazolenew, Fenhexamidnew, Fenoxycarbnew, Fenpyroximatenew, Fipronilnew, Flonicamidnew, Fludioxonilnew, Hexythiazoxnew, Imazalilnew, Imidacloprid, KresoximMethylnew, Malathionnew, Metalaxylnew, Methiocarbnew, Methomylnew, Mevinphosnew, MethylParathionnew, Myclobutanilnew, Nalednew, Oxamylnew, Pentachloronitrobenzenenew, Permethrinsnew, Phosmetnew, PiperonylButoxidenew, Prallethrinnew, Propiconazolenew, Propoxurnew, Pyrethrinsnew, Pyridabennew, SpinetoramJnew, SpinetoramL, SpinosadAnew, SpinosadDnew, Spiromesifennew, Spirotetramatnew, Spiroxaminenew, Tebuconazolenew, Thiaclopridnew, Thiamethoxamnew, Trifloxystrobinnew, Paclobutrazolnew);
        }
        private void AbamectinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AcephateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AcequinocylTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PestInputWtTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AldicarbTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void AzoxystrobinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BifenazateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BifenthrinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void BoscalidTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CaptanTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CarbarylTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CarbofuranTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ChlorantraniliproleTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ChlordaneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ChlorfenapyrTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ChlorpyrifosTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ClofentezineTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CoumaphosTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CyfluthrinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void CypermethrinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DaminozideTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DichlorvosTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DiazinonTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DimethoateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void DimethomorphTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EthoprophosTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EtofenproxTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void EtoxazoleTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Lock Textbox to only accept numbers

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void FenhexamidTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }

        }

        private void FenoxycarbTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void FenpyroximateTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void FipronilTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void FlonicamidTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void FludioxonilTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void HexythiazoxTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ImazalilTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ImidaclopridTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void KresoximMethylTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MalathionTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MetalaxylTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MethiocarbTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MethomylTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MethylParathionTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MevinphosTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void MyclobutanilTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void NaledTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void OxamylTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PentachloronitrobenzeneTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PermethrinsTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PhosmetTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PiperonylButoxideTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PrallethrinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PropiconazoleTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PropoxurTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PyrethrinsTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PyridabenTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpinetoramJTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpinetoramLTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpinosadATB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpinosadDTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpiromesifenTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpirotetramatTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void SpiroxamineTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void TebuconazoleTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ThiaclopridTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void ThiamethoxamTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void TrifloxystrobinTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
        }

        private void PaclobutrazolTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }

        }
    }
}
        
    
