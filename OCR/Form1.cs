using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Aspose.OCR;
using WinFormCharpWebCam;
using System.Data.SqlClient;


namespace OCR
{
    public partial class Form1 : Form
    {   
            // Obiecte ale claselor ce ma ajuta la scanarea codului anagajatului
        OcrEngine ocr;
        WebCam webcam;
        
            // Crearea conexiunii intre aplicatie si baza de date
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");

            // Liste si variabile globale
        List<string> cod_angajat = new List<string>();
        List<string> id_intrare = new List<string>();
        List<string> cod_angajat_intrare = new List<string>();
        List<string> iesire_angajat = new List<string>();
        int incercari = 0;
        bool detectat = false;
        
            //Constructor
        public Form1()
        {
            InitializeComponent(); 
        }

            //Incarcare main-window-ului
        private void Form1_Load(object sender, EventArgs e)
        {            
            ocr = new OcrEngine();
            webcam = new WebCam();
            verify_if_payday_is_now();
            webcam.InitializeWebCam(ref pictureBox1);
            webcam.Start();
            refresh_codes();
        }

        //Metode auxiliare necesare implementarii functiilor programului
        private void refresh_codes()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select [Cod Angajat] From Angajat", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) cod_angajat.Add(reader["Cod Angajat"].ToString());
            con.Close();
        }
        private string next_code_number()
        {
            cod_angajat.Clear();
            refresh_codes();
            return "00" + (int.Parse(cod_angajat.Last()) + 1).ToString();
        }
        private bool scanare()
        {
            while (detectat == false) 
            {
                WebCam webcam1;
                webcam1 = new WebCam();
                webcam1.InitializeWebCam(ref pictureBox1);
                webcam1.Start();

                try
                {
                    pictureBox1.Image.Save(@"E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);                    
                    ocr.Image = ImageStream.FromFile(@"E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\1.jpeg");
                    ocr.Process();
                    foreach (string codul_angajatului in cod_angajat)
                    {
                        if (ocr.Text.ToString() == codul_angajatului)
                        {
                            detectat = true;
                            webcam1.Stop();
                            webcam.Start();
                            return detectat;
                        }
                    }
                }
                catch (Exception)
                { 
                    detectat = false; 
                }

                AutoClosingMessageBox.Show("Procesare","", 111);         // un delay necesar pt camera
                webcam1.Stop();
                webcam.InitializeWebCam(ref pictureBox1);
                webcam.Start();

                System.Threading.Thread.Sleep(1000);

                return detectat;
            }
            return detectat;
        }       
        private string pozition_in_table()
        {
            int contor = 0;


            con.Open();
            SqlCommand com = new SqlCommand("Select Id,[Cod Angajat] From Intrari", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) id_intrare.Add(reader["Id"].ToString());
            con.Close();


            con.Open();
            SqlCommand com2 = new SqlCommand("Select [Cod Angajat] From Intrari", con);
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read()) cod_angajat_intrare.Add(reader2["Cod Angajat"].ToString());
            con.Close();


            con.Open();
            SqlCommand com3 = new SqlCommand("Select Id,[Cod Angajat],[Ora iesire] From Intrari", con);
            SqlDataReader reader3 = com3.ExecuteReader();
            while (reader3.Read()) iesire_angajat.Add(reader3["Ora iesire"].ToString());
            con.Close();


            foreach (string s in cod_angajat_intrare)
            {
                if (s == ocr.Text.ToString())
                {
                    if (iesire_angajat[contor] == "")
                        return id_intrare[contor];
                }
                contor++;
            }

            return "Angajatul nu s-a logat in prealabil !";
        }
        private int ore_muncite_pe_intrare_iesire(string intrare, string iesire)
        {
            string numar_intrare = "", numar_iesire = "";

            numar_intrare += intrare[15];
            numar_intrare += intrare[16];

            numar_iesire += iesire[15];
            numar_iesire += iesire[16];

            if (int.Parse(numar_intrare) < int.Parse(numar_iesire))
                return int.Parse(numar_iesire) - int.Parse(numar_intrare);
            else return 60 - int.Parse(numar_intrare) + int.Parse(numar_iesire);

        }
      
            // Metodele din spatele butoanelor

            //Intrare                           Atentie ! Verifica daca nu este in concediu
        private void button1_Click(object sender, EventArgs e)
        {
            webcam.Stop();  
            if (scanare() == true)
            {
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Intrari ([Cod Angajat],[Ora intrare])  Values ('" + ocr.Text.ToString() + "','" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "')", con);
                command.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Bine ati venit la serviciu !","Recunoscut");
                incercari = 0;
                detectat = false;
            }
            else
            {
                if (incercari != 5)
                {
                    incercari++;
                    button1_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Nu s-a identificat codul angajatului !", "Nerecunoscut");
                    incercari = 0;
                }
            }
             

        }
            //Iesire                            Atentie ! Verifica daca nu este in concediu
        private void button3_Click_1(object sender, EventArgs e)
        {
            webcam.Stop();
            if (scanare() == true)
            {
                string pozitie = pozition_in_table();
                if (pozitie != "Angajatul nu s-a logat in prealabil !")
                {

                    con.Open();
                    SqlCommand command = new SqlCommand("UPDATE Intrari SET [Ora iesire]='" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Day.ToString() + " " + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "' WHERE Id=" + pozitie, con);
                    command.ExecuteNonQuery();
                    con.Close();

                    string intrare, iesire, ore_muncite_curente;

                    con.Open();
                    SqlCommand command2 = new SqlCommand("Select [Ora intrare] FROM Intrari WHERE Id=" + pozitie, con);
                    SqlDataReader sqlDataReader = command2.ExecuteReader();
                    sqlDataReader.Read();
                    intrare = sqlDataReader["Ora intrare"].ToString();
                    con.Close();


                    con.Open();
                    SqlCommand command3 = new SqlCommand("Select [Ora iesire] FROM Intrari WHERE Id=" + pozitie, con);
                    SqlDataReader sqlDataReader2 = command3.ExecuteReader();
                    sqlDataReader2.Read();
                    iesire = sqlDataReader2["Ora iesire"].ToString();
                    con.Close();

                    con.Open();
                    SqlCommand command4 = new SqlCommand("Select [Ore muncite] FROM Angajat WHERE [Cod angajat]='" + ocr.Text.ToString() + "'", con);
                    SqlDataReader sqlDataReader3 = command4.ExecuteReader();
                    sqlDataReader3.Read();
                    ore_muncite_curente = sqlDataReader3["Ore muncite"].ToString();
                    con.Close();

                    int noua_suma_de_ore = int.Parse(ore_muncite_curente) + ore_muncite_pe_intrare_iesire(intrare, iesire);

                    con.Open();
                    SqlCommand command5 = new SqlCommand("UPDATE Angajat SET [Ore muncite]=" + noua_suma_de_ore + "WHERE [Cod angajat]='" + ocr.Text.ToString() + "'", con);
                    command5.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("O zi buna !", "Recunoscut");

                    incercari = 0;
                    detectat = false;
                }
                else
                {
                    MessageBox.Show(pozitie);
                }
            }
            else
            {
                if (incercari != 5)
                {
                    incercari++;
                    button3_Click_1(sender, e);
                }
                else
                {
                    MessageBox.Show("Nu s-a identificat codul angajatului !", "Nerecunoscut");
                    incercari = 0;
                }
            }
        }
            //Statistici                        Atentie ! La cautarea orelor lucrate de x angajat mesajul apare de cate ori cauti !!
        private void button4_Click(object sender, EventArgs e)
        {
            Bilant show = new Bilant();
            show.Show();
        }
            //Admin zone                         Atentie ! Adauga o referinta in Master si Salarii la adaugarea unui nou anagajat !!
        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(next_code_number());
            admin.Show();
        }

                
            //Matoda de actualizare a salariului si a totalului orelor muncite de catre angajati
        private void update_salariu_master()
        {
            List<string> salariu = new List<string>();
            List<string> cod_angajati = new List<string>();

            con.Open();
            SqlCommand command = new SqlCommand("Select Salariu From Salarii", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) salariu.Add(reader["Salariu"].ToString());
            con.Close();

            con.Open();
            SqlCommand command1 = new SqlCommand("Select [Cod angajat] From Master", con);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read()) cod_angajati.Add(reader1["Cod angajat"].ToString());
            con.Close();

            for (int i = 0; i < salariu.Count(); i++)
            {
                con.Open();
                SqlCommand command2 = new SqlCommand("UPDATE Master SET Salariu='" + salariu[i] + "' WHERE [Cod angajat]='" + cod_angajat[i] + "'", con);
                command2.ExecuteNonQuery();
                con.Close();
            }

        }
        private void update_day_work()
        {
            //     update total ore in master
            List<string> ore_muncite = new List<string>();
            List<string> total_ore = new List<string>();
            List<string> index_inregistrare = new List<string>();

            int index = -1;

            con.Open();
            SqlCommand com1 = new SqlCommand("Select [Id] From Angajat", con);
            SqlDataReader reader1 = com1.ExecuteReader();
            while (reader1.Read()) index_inregistrare.Add(reader1["Id"].ToString());
            con.Close();


            con.Open();
            SqlCommand com = new SqlCommand("Select [Ore muncite] From Angajat", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) { index++; ore_muncite.Add(reader["Ore muncite"].ToString()); };
            con.Close();

            con.Open();
            SqlCommand com2 = new SqlCommand("Select [Total ore] From Master", con);
            SqlDataReader reader2 = com2.ExecuteReader();
            while (reader2.Read()) total_ore.Add(reader2["Total ore"].ToString());
            con.Close();

            con.Open();
            SqlCommand command1 = new SqlCommand("UPDATE Master SET [Total ore]='0'", con);
            command1.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i <= index; i++)
            {
                int update_hours = int.Parse(total_ore[i]) + int.Parse(ore_muncite[i]);
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE Master SET [Total ore]='" + update_hours.ToString() + "'WHERE Id=" + int.Parse(index_inregistrare[i]), con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

            //Metode de actualizare a campurilor tabelei Salarii
        private void update_spor_in_salariu(List<string> merit_spor)
        {
            for (int i = 0; i < merit_spor.Count(); i++)
            {
                if (int.Parse(merit_spor[i]) > 0)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UPDATE Salarii SET [Id spor]='2' WHERE Id=" + (i + 1), con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                if (int.Parse(merit_spor[i]) == 0)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UPDATE Salarii SET [Id spor]='0' WHERE Id=" + (i + 1), con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                if (int.Parse(merit_spor[i]) < 0)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("UPDATE Salarii SET [Id spor]='3' WHERE Id=" + (i + 1), con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void update_concediu()
        {
            List<string> angajat = new List<string>();

            con.Open();
            SqlCommand command = new SqlCommand("Select [Cod angajat] from Salarii", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) angajat.Add(reader["Cod angajat"].ToString());
            con.Close();

            for (int i = 0; i < angajat.Count(); i++)
            {
                if (in_concediu(angajat[i].ToString()) == true)
                {
                    con.Open();
                    SqlCommand command2 = new SqlCommand("UPDATE Salarii SET Concediu=1 WHERE [Cod angajat]='" + angajat[i].ToString() + "'", con);
                    command2.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        private void update_salariu(string salariu, string cod_angajat)
        {
            con.Open();
            SqlCommand command2 = new SqlCommand("UPDATE Salarii SET Salariu='" + salariu + "' WHERE [Cod angajat]='" + cod_angajat + "'", con);
            command2.ExecuteNonQuery();
            con.Close();
        }

            //Metode auxiliare ce ajuta la buna functionare a bazei de date
        private List<string> merit_spor()
        {
            //merit in functie de ordinea in angajat
            List<string> merit = new List<string>();
            List<string> ore_muncite = new List<string>();
            List<string> program = new List<string>();

            
            con.Open();
            SqlCommand command = new SqlCommand("Select [Ore muncite] from Angajat",con);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read()) ore_muncite.Add(reader["Ore muncite"].ToString());
            con.Close();

            con.Open();
            SqlCommand command1 = new SqlCommand("Select Functii.[Program] From Functii INNER JOIN Salarii ON Salarii.[Id functie]=Functii.[Id]", con);
            SqlDataReader reader2 = command1.ExecuteReader();
            while (reader2.Read()) program.Add(reader2["Program"].ToString());
            con.Close();

            for (int i = 0; i < ore_muncite.Count(); i++)
                merit.Add((int.Parse(ore_muncite[i].ToString()) - int.Parse(program[i].ToString())).ToString());
            
            return merit;
        }
        private void erase_hours_for_today()
        {
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE Angajat SET [Ore muncite]='0'", con);
            command.ExecuteNonQuery();
            con.Close();
        }
        private bool in_concediu(string codul_angajatului)
        {
            List<string> angajati_in_concediu = new List<string>();
            string data_inceput, data_sfarsit;

            con.Open();
            SqlCommand command0 = new SqlCommand("Select [Cod angajat] from Concedii", con);
            SqlDataReader reader0 = command0.ExecuteReader();
            while (reader0.Read())
            angajati_in_concediu.Add(reader0["Cod angajat"].ToString());
            con.Close();

            foreach(string s in angajati_in_concediu)
            {
                if (s == codul_angajatului)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Select [Data inceput de concediu] from Concedii WHERE [Cod angajat]=" + codul_angajatului, con);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    data_inceput = reader["Data inceput de concediu"].ToString();
                    con.Close();

                    con.Open();
                    SqlCommand command2 = new SqlCommand("Select [Data sfarsit de concediu] from Concedii WHERE [Cod angajat]=" + codul_angajatului, con);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    reader2.Read();
                    data_sfarsit = reader2["Data sfarsit de concediu"].ToString();
                    con.Close();

                    DateTime datime_intrare = Convert.ToDateTime(data_inceput);
                    DateTime datime_sfarsit = Convert.ToDateTime(data_sfarsit);

                    DateTime curent = DateTime.Now;

                    int rezult = DateTime.Compare(datime_intrare, curent);
                    int rezult1 = DateTime.Compare(curent, datime_sfarsit);

                    if (rezult == -1 && rezult1 == -1)
                        return true;
                    else return false;
                }
            }
            return false; 
        }
        private void calculare_completare_salariu()
        { 
            List<string> angajati_in_concediu = new List<string>();
            List<string> angajati = new List<string>();
            List<string> spor_meritat = new List<string>();

            string salariu;
            int contor = -1;

            spor_meritat = merit_spor();
            
            update_day_work();
            update_spor_in_salariu(spor_meritat);
            update_concediu();

            con.Open(); 
            SqlCommand command0 = new SqlCommand("Select [Cod angajat] from Salarii Where Concediu=1", con);
            SqlDataReader reader0 = command0.ExecuteReader();
            while (reader0.Read()) angajati_in_concediu.Add(reader0["Cod angajat"].ToString());
            con.Close();

            con.Open();
            SqlCommand command1 = new SqlCommand("Select [Cod angajat] from Salarii", con);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read()) angajati.Add(reader1["Cod angajat"].ToString());
            con.Close();

            foreach(string s in angajati)
            { contor++;
                foreach(string e in angajati_in_concediu)
                {
                    if (s == e)
                    {
                        con.Open();
                        SqlCommand command2 = new SqlCommand("UPDATE Salarii SET Salariu=20 WHERE [Cod angajat]='" + e.ToString() + "'", con);
                        command2.ExecuteNonQuery();
                        con.Close();
                    }

                    else
                    {
                        string functie, salariu_de_baza, renumeratie_pe_spor, spor_de_stres;

                        con.Open();
                        SqlCommand command3 = new SqlCommand("Select [Id functie] from Salarii WHERE [Cod angajat]='" + s.ToString() + "'", con);
                        SqlDataReader reader3 = command3.ExecuteReader();
                        reader3.Read();
                        functie =reader3["Id functie"].ToString();
                        con.Close();

                        if(functie == "4" || functie == "5")
                        {
                            salariu_de_baza = "";
                            renumeratie_pe_spor = "";

                            con.Open();
                            SqlCommand command4 = new SqlCommand("Select Functii.[Salariu de baza] From Functii INNER JOIN Salarii ON Salarii.[Id functie]=Functii.[Id] WHERE Salarii.[Cod angajat]='" + s.ToString() + "'", con);
                            SqlDataReader reader4 = command4.ExecuteReader();
                            reader4.Read();
                            salariu_de_baza = reader4["Salariu de baza"].ToString();
                            con.Close();

                            con.Open();
                            SqlCommand command5 = new SqlCommand("Select Sporuri.[Renumeratie] From Sporuri INNER JOIN Salarii ON Salarii.[Id spor]=Sporuri.[Id] WHERE Salarii.[Cod angajat]='" + s.ToString() + "'", con);
                            SqlDataReader reader5 = command5.ExecuteReader();
                            reader5.Read();
                            renumeratie_pe_spor = reader5["Renumeratie"].ToString();
                            con.Close();

                            con.Open();
                            SqlCommand command6 = new SqlCommand("Select Sporuri.[Renumeratie] From Sporuri Where Sporuri.[Id]=1", con);
                            SqlDataReader reader6 = command6.ExecuteReader();
                            reader6.Read();
                            spor_de_stres = reader6["Renumeratie"].ToString();
                            con.Close();
                             
                            salariu = (float.Parse(salariu_de_baza) + float.Parse(spor_de_stres) + (float.Parse(renumeratie_pe_spor) * int.Parse(spor_meritat[contor]))).ToString();

                            update_salariu(salariu, s.ToString());
                        }
                        else
                        {

                            salariu_de_baza = "";
                            renumeratie_pe_spor = "";

                            con.Open();
                            SqlCommand command4 = new SqlCommand("Select Functii.[Salariu de baza] From Functii INNER JOIN Salarii ON Salarii.[Id functie]=Functii.[Id] WHERE Salarii.[Cod angajat]='" + s.ToString() + "'", con);
                            SqlDataReader reader4 = command4.ExecuteReader();
                            reader4.Read();
                            salariu_de_baza = reader4["Salariu de baza"].ToString();
                            con.Close();

                            con.Open();
                            SqlCommand command5 = new SqlCommand("Select Sporuri.[Renumeratie] From Sporuri INNER JOIN Salarii ON Salarii.[Id spor]=Sporuri.[Id] WHERE Salarii.[Cod angajat]='" + s.ToString() + "'", con);
                            SqlDataReader reader5 = command5.ExecuteReader();
                            reader5.Read();
                            renumeratie_pe_spor = reader5["Renumeratie"].ToString();
                            con.Close();

                            salariu = (float.Parse(salariu_de_baza) + (float.Parse(renumeratie_pe_spor) * int.Parse(spor_meritat[contor]))).ToString();

                            update_salariu(salariu, s.ToString());
                        }


                    }
                }
            }
        }
        private void set_the_flags()
        {
            //verifica daca ziua scadenta difera de ziua de azi si atunci seteaza flag-ul pe 1

            List<string> zi_scadenta = new List<string>();
            List<string> cod_angajat = new List<string>();

            con.Open();
            SqlCommand command = new SqlCommand("Select [Zi scadenta] from Master", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) zi_scadenta.Add(reader["Zi scadenta"].ToString());
            con.Close();

            con.Open();
            SqlCommand command3 = new SqlCommand("Select [Cod angajat] from Master", con);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read()) cod_angajat.Add(reader3["Cod angajat"].ToString());
            con.Close();

            for (int i = 0; i < zi_scadenta.Count(); i++)
            {
                if (zi_scadenta[i] != System.DateTime.Now.Day.ToString() && zi_scadenta[i] == "0")
                {
                    con.Open();
                    SqlCommand command5 = new SqlCommand("UPDATE Master SET [Flag]='1' WHERE [Cod angajat]=" + cod_angajat[i], con);
                    command5.ExecuteNonQuery();
                    con.Close();
                }

            }
        }

            //Metoda prin care se platesc angajatii
        private void verify_if_payday_is_now()
        {
            List<string> zi_scadenta = new List<string>();
            List<string> flag = new List<string>();
            List<string> cod_angajat = new List<string>();

            con.Open();
            SqlCommand command = new SqlCommand("Select [Zi scadenta] from Master",con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) zi_scadenta.Add(reader["Zi scadenta"].ToString());
            con.Close();

            con.Open();
            SqlCommand command2 = new SqlCommand("Select [Flag] from Master", con);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read()) flag.Add(reader2["Flag"].ToString());
            con.Close();

            con.Open();
            SqlCommand command3 = new SqlCommand("Select [Cod angajat] from Master", con);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read()) cod_angajat.Add(reader3["Cod angajat"].ToString());
            con.Close();

            for (int i = 0; i < flag.Count(); i++)
            {
                if(zi_scadenta[i] == System.DateTime.Now.Day.ToString() && flag[i] == "1")
                {
                    con.Open();
                    SqlCommand command1 = new SqlCommand("UPDATE Master SET [Total ore]='0' WHERE [Cod angajat]="+ cod_angajat[i], con); 
                    command1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand command4 = new SqlCommand("UPDATE Master SET [Salariu]='0' WHERE [Cod angajat]=" + cod_angajat[i], con);
                    command4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand command5 = new SqlCommand("UPDATE Master SET [Flag]='0' WHERE [Cod angajat]=" + cod_angajat[i], con);
                    command5.ExecuteNonQuery();
                    con.Close();
                    
                }
                
            }
            set_the_flags();
        }

            //Actualizare zilnica
        private void memory_today()
        {
            calculare_completare_salariu();
            update_salariu_master();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //memory_today();
            MessageBox.Show("goodbye");
        }
    }
}
