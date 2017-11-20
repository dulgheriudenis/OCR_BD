using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");

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
            webcam.InitializeWebCam(ref pictureBox1);
            webcam.Start();
            refresh_codes();
            update_day_work();
        }


        //Metode auxiliare necesare implementarii functiilor programului
       
        // START ZONE
        private void refresh_codes()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select [Cod Angajat] From Angajat", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) cod_angajat.Add(reader["Cod Angajat"].ToString());
            con.Close();
        }

        public string next_code_number()
        {
            cod_angajat.Clear();
            refresh_codes();
            return "00" + (int.Parse(cod_angajat.Last()) + 1).ToString();
        }

        public bool scanare()
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
        // FINISH ZONE





        // Metodele principale din spatele butoanelor

        //Intrare
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

        //Iesire
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

        //Statistici
        private void button4_Click(object sender, EventArgs e)
        {
            Bilant show = new Bilant();
            show.Show();
        }

        //Admin zone    Atentie ! Adauga o referinta in Master la adaugarea unui nou anagajat !!
        private void button2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(next_code_number());
            admin.Show();
        }
                  
        





        // Update database per day

        // verifica daca s-a inchis aplicatia si actualizeaza master-ul si dupa se apeleaza cele trei metode de mai jos

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
            while (reader.Read()) { index++; ore_muncite.Add(reader["Ore muncite"].ToString());};
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
                command.ExecuteNonQuery(); //asndasd
                con.Close(); ///dfsfds
            }
        }
        
        private void erase_hours_for_today()
        {
            con.Open();
            SqlCommand command = new SqlCommand("UPDATE Angajat SET [Ore muncite]='0'", con);
            command.ExecuteNonQuery();
            con.Close();
        }

        private List<string> merit_spor()
        {
            List<string> merit = new List<string>();
            List<string> ore_muncite = new List<string>();
            List<string> program = new List<string>();


            // pune in listele de mai sus informatiile din tabelele
            con.Open();
            SqlCommand command = new SqlCommand("Select [Ore muncite] from Angajat");

            return merit;
        }

        // salariu method - calcul salariu pe zi din hartie
        // trebuie sa facem update si de salariu in master !!!

    }
}
