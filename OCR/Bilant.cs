using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace OCR
{
    public partial class Bilant : Form
    {
        List<string> nume_angajat = new List<string>();
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\OCR\Database1.mdf;Integrated Security=True");
        static private bool ok = false;

        public Bilant()
        {
            InitializeComponent();
            cuprins_functii_domain.Items.Add("Entry");
            cuprins_functii_domain.Items.Add("Standard");
            cuprins_functii_domain.Items.Add("Manager");
            cuprins_functii_domain.Items.Add("Director");
            cuprins_functii_domain.Items.Add("CEO");
        }
        
        private void Bilant_Load(object sender, EventArgs e)
        {
            

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void istoric_button_Click(object sender, EventArgs e)
        {
            Istoric istoric = new Istoric();
            istoric.Show();
        }

        private void acum_button_Click(object sender, EventArgs e)
        {
            if (nume_prenume_TextBox.Text != "")
            {
                try
                {
                    int contor = 0;
                    List<string> ore = new List<string>();
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");
                    nume_angajat.Clear();
                    connection.Open();
                    SqlCommand com = new SqlCommand("Select [Nume Prenume] From Angajat", connection);
                    SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read()) nume_angajat.Add(reader["Nume Prenume"].ToString());
                    connection.Close();
                    bool working = false;

                    foreach (string s in nume_angajat)
                    {
                        if (s == nume_prenume_TextBox.Text.ToString())
                        {
                            connection.Open();
                            SqlCommand com2 = new SqlCommand("Select [Ore muncite] From Angajat", connection);
                            SqlDataReader reader2 = com2.ExecuteReader();
                            while (reader2.Read()) ore.Add(reader2["Ore muncite"].ToString());
                            connection.Close();
                            working = true;
                            MessageBox.Show(s + " a lucrat : " + ore[contor] + " ore .");
                        }
                        contor++;
                    }
                    if (working == false)
                        throw new Exception("Numele introdus este scris gresit sau angajatul nu lucreaza in aceasta institutie .");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void calcul_salarii_button_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM VedereSalarii", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["Nume Prenume"].ToString());
                list2.Add(reader["Salariu"].ToString());
            }

            con.Close();

            string show = "";
            for (int i = 0; i < list.Count; i++) 
            {
                show += list[i];
                show += " are salariu : ";
                show += list2[i];
                show += "\n";
            }

            MessageBox.Show(show, "SALARII", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void top_angajati_button_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT [Nume Prenume] FROM TopAngajati Order by [Id functie] desc;", con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader["Nume Prenume"].ToString());
            }

            con.Close();

            string show = "";
            for (int i = 0; i < 3; i++)
            {
                show += list[i]; 
                show += "\n";
            }

            MessageBox.Show(show, "Top 3 angajati", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cauta_functie_button_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            if (ok == false)
                MessageBox.Show("Alegeti una din functii !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    int functie = 0;

                    if (cuprins_functii_domain.Text.ToString() == "Entry")
                        functie = 1;
                    if (cuprins_functii_domain.Text.ToString() == "Standard")
                        functie = 2;
                    if (cuprins_functii_domain.Text.ToString() == "Manager")
                        functie = 3;
                    if (cuprins_functii_domain.Text.ToString() == "String")
                        functie = 4;
                    if (cuprins_functii_domain.Text.ToString() == "CEO")
                        functie = 5;

                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.AngajatiDupaFunctii", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    var parameter = cmd.CreateParameter();
                    parameter.ParameterName = "@functie";
                    parameter.Value = functie;
                    cmd.Parameters.Add(parameter);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        list.Add(sqlDataReader["Nume Prenume"].ToString());
                    }

                    string show = "";
                    foreach (string s in list)
                    {
                        show += s;
                        show += "\n";
                    }


                    if (show != "")
                        MessageBox.Show(show);
                    else throw new Exception("Momentan niciun angajat nu detine aceasta functie .");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();

                cuprins_functii_domain.Text = "";
                ok = false;
            }
        }

        private void concediu_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (nume_angajat_text_box.Text != "")
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("dbo.VerificaConcediuAngajat", con);
                    command.CommandType = CommandType.StoredProcedure;

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@nume_angajat";
                    parameter.Value = nume_angajat_text_box.Text.ToString();

                    command.Parameters.Add(parameter);

                    SqlDataReader reader1 = command.ExecuteReader();
                    ok = false;

                    while (reader1.Read())
                    {
                        ok = true;
                        MessageBox.Show("Angajatul : " + nume_angajat_text_box.Text.ToString() + " are concediu din " + reader1["Data inceput de concediu"].ToString() + " pana la " + reader1["Data sfarsit de concediu"].ToString() + " .");
                    }

                    if (ok == false)
                        throw new Exception("Numele introdus este scris gresit sau angajatul nu are concediu .");

                    nume_angajat_text_box.Text = "";

                    con.Close();

                }
                else throw new Exception("Completati campul cu numele si prenumele angajatului .");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void vechime_button_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>(); 
            con.Open();
            SqlCommand command = new SqlCommand("Select [Nume Prenume] FROM ListaVechimeAngajat Order BY [Inceput contract]", con);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                list.Add(sqlDataReader["Nume Prenume"].ToString());
            }

            string show = "";
            foreach (string s in list)
            {
                show += s;
                show += "\n";
            }

            MessageBox.Show(show, "VECHIMI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void cuprins_functii_domain_SelectedItemChanged(object sender, EventArgs e)
        {
            ok = true;
        }
    }
}
