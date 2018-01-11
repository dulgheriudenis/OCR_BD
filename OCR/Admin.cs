using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OCR
{
    public partial class Admin : Form
    {
        string next_code_number;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");

        public Admin(string code)
        {
            InitializeComponent();
            next_code_number = code;
            angajat_nou_button.Visible = false;
            concediu_angajat_button.Visible = false;
            avanasare_button.Visible = false;
            stergere_anagajat_button.Visible = false;
            calcul_salarii_button.Visible = false;
        }

        private void verify_button_Click(object sender, EventArgs e)
        {
            if (password_textBox.Text == "admin")
            {
                password_textBox.Visible = false;
                verify_button.Visible = false;
                introduceti_parola_label.Visible = false;
                angajat_nou_button.Visible = true;
                concediu_angajat_button.Visible = true;
                avanasare_button.Visible = true;
                stergere_anagajat_button.Visible = true;
                calcul_salarii_button.Visible = true;
            }
        }

        //Angajat nou
        private void button1_Click(object sender, EventArgs e)
        {
            Angajat_Nou angajat_nou = new Angajat_Nou(next_code_number);
            angajat_nou.Show();

        }

        private void retrogradare_button_Click(object sender, EventArgs e)
        {
            Retrogradare retrogradare = new Retrogradare();
            retrogradare.Show();
        }

        private void concediu_angajat_button_Click(object sender, EventArgs e)
        {
            ConcediuAngajat concediuAngajat = new ConcediuAngajat();
            concediuAngajat.Show();
        }

        private void avanasare_button_Click(object sender, EventArgs e)
        {
            Avansare avansare = new Avansare();
            avansare.Show();
        }

        private void stergere_anagajat_button_Click(object sender, EventArgs e)
        {
            StergereAngajat stergereAngajat = new StergereAngajat();
            stergereAngajat.Show();
        }

        private void calcul_salarii_button_Click(object sender, EventArgs e)
        {
            List<string> salariu = new List<string>();

            con.Open();
            SqlCommand command = new SqlCommand("Select * FROM VedereSalariiNet", con);
            SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            
            while (reader.Read())
                list.Add(reader["Salariu"].ToString());
            
            con.Close();

            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Functii.[Salariu de baza] FROM Functii INNER JOIN Salarii ON Salarii.[Id functie]=Functii.Id", con);
            SqlDataReader reader1 = command1.ExecuteReader();
            List<string> list1 = new List<string>();

            while (reader1.Read())
                salariu.Add(reader1["Salariu de baza"].ToString());

            con.Close();

            List<float> salariul = new List<float>();

            for (int i = 0; i < salariu.Count; i++)
                salariul.Add(float.Parse(salariu[i].ToString()) * 20);
            // pune in data grid view nume angajat / sold curent / sold de baza
        }
    }
}

