using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OCR
{
    public partial class ConcediuAngajat : Form
    {
        static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");
        static string cod_angajat = "";

        public ConcediuAngajat()
        {
            InitializeComponent();
        }

        static private bool exista(string nume_si_prenume)
        {            
            SqlCommand com = new SqlCommand("Select [Cod angajat] From Angajat Where [Nume Prenume]=@nume_prenume", connection);
            
            connection.Open();
            var parameter = com.CreateParameter();
            parameter.ParameterName = "@nume_prenume";
            parameter.Value = nume_si_prenume;
            com.Parameters.Add(parameter);
            
            SqlDataReader reader = com.ExecuteReader();
            string exist = reader.Read().ToString();
            if (exist != "False")
            {
                cod_angajat = reader["Cod angajat"].ToString();
                connection.Close();
                return true;
            }
            else { connection.Close(); return false; }
        }
                
        static private void proceseaza(string nume_si_prenume, string de_la, string pana_la)
        {
            
            DateTime datime_intrare = DateTime.ParseExact(de_la, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture); 
            DateTime datime_sfarsit = DateTime.ParseExact(pana_la, "MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            int rezult = DateTime.Compare(datime_intrare, datime_sfarsit);

            if (rezult == -1)
            {
                
                SqlCommand com = new SqlCommand("Select Concedii.[Data inceput de concediu],Concedii.[Data sfarsit de concediu] From Concedii INNER JOIN Angajat ON Concedii.[Cod angajat]=Angajat.[Cod angajat] WHERE Angajat.[Nume Prenume]=@nume_prenume", connection);

                connection.Open();
                var parameter = com.CreateParameter();
                parameter.ParameterName = "@nume_prenume";
                parameter.Value = nume_si_prenume;
                com.Parameters.Add(parameter);

                SqlDataReader reader = com.ExecuteReader();
                string exist = reader.Read().ToString();
                if (exist != "False")
                {

                    string s = reader["Data inceput de concediu"].ToString();
                    DateTime datime_intrare_in_concediu = (DateTime)reader["Data inceput de concediu"];
                    DateTime datime_iesire_din_concediu = (DateTime)reader["Data sfarsit de concediu"];

                    int rez = DateTime.Compare(datime_sfarsit, datime_intrare_in_concediu);
                    int rez2 = DateTime.Compare(datime_sfarsit, datime_iesire_din_concediu);

                    int rez3 = DateTime.Compare(datime_intrare_in_concediu, datime_intrare);
                    int rez4 = DateTime.Compare(datime_iesire_din_concediu, datime_intrare);

                    if (rez == -1 && rez2 == -1 || rez3 == -1 && rez4 == -1)
                    {
                        connection.Close();
                        connection.Open();
                        SqlCommand command2 = new SqlCommand("INSERT INTO Concedii ([Cod angajat],[Data inceput de concediu],[Data sfarsit de concediu]) VALUES (@cod,@first_date,@second_date)", connection);

                        var param1 = command2.CreateParameter();
                        param1.ParameterName = "@cod";
                        connection.Close();
                        exista(nume_si_prenume);
                        connection.Open();
                        param1.Value = cod_angajat;
                        command2.Parameters.Add(param1);

                        var param2 = command2.CreateParameter();
                        param2.ParameterName = "@first_date";
                        param2.Value = datime_intrare;
                        command2.Parameters.Add(param2);

                        var param3 = command2.CreateParameter();
                        param3.ParameterName = "@second_date";
                        param3.Value = datime_sfarsit;
                        command2.Parameters.Add(param3);


                        command2.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Concediu inregistrat cu succes !");
                    }
                    else MessageBox.Show("Perioada aleasa coincide cu un alt concediu inregistrat pentru angajatul : " + nume_si_prenume);

                    connection.Close();
                }
                else
                {
                    connection.Close();
                    connection.Open();
                    SqlCommand command2 = new SqlCommand("INSERT INTO Concedii ([Cod angajat],[Data inceput de concediu],[Data sfarsit de concediu]) VALUES (@cod,@first_date,@second_date)", connection);

                    var param1 = command2.CreateParameter();
                    param1.ParameterName = "@cod";
                    connection.Close();
                    exista(nume_si_prenume);
                    connection.Open();
                    param1.Value = cod_angajat;
                    command2.Parameters.Add(param1);

                    var param2 = command2.CreateParameter();
                    param2.ParameterName = "@first_date";
                    param2.Value = datime_intrare;
                    command2.Parameters.Add(param2);

                    var param3 = command2.CreateParameter();
                    param3.ParameterName = "@second_date";
                    param3.Value = datime_sfarsit;
                    command2.Parameters.Add(param3);


                    command2.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Concediu inregistrat cu succes !");
                }
            }
            else MessageBox.Show("Nu ati ales perioada corect !");
        }

        private void proceseaza_button_Click(object sender, EventArgs e)
        {
            if (nume_prenume_text_box.Text.ToString() != "")
                if (exista(nume_prenume_text_box.Text.ToString()) == true)
                {
                    proceseaza(nume_prenume_text_box.Text.ToString(), de_la_time_picker.Value.ToString("MM/dd/yyyy"), pana_la_time_picker.Value.ToString("MM/dd/yyyy"));

                }
                else MessageBox.Show("Angajatul nu exista in baza de date !");
            else MessageBox.Show("Introduceti numele si prenumele anagajatului !");
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
