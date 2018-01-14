using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OCR
{
    public partial class Admin : Form
    {
        string next_code_number;
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\stefa\Desktop\OCR\OCR\OCR\Database1.mdf;Integrated Security = True");

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
            try
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
                else
                {
                    password_textBox.Text = "";
                    throw new Exception("Parola introdusa este gresita! Te rugam sa mai incerci.");
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Tabel_cu_salarii tabel_Cu_Salarii = new Tabel_cu_salarii();
            tabel_Cu_Salarii.Show();
        }
    }
}

