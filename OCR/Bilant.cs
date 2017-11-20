using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR
{
    public partial class Bilant : Form
    {
        List<string> nume_angajat = new List<string>();

        public Bilant()
        {
            InitializeComponent();
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
            if(nume_prenume_TextBox.Text != "")
            {
                int contor = 0;
                List<string> ore = new List<string>();
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");

                connection.Open();
                SqlCommand com = new SqlCommand("Select [Nume Prenume] From Angajat", connection);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) nume_angajat.Add(reader["Nume Prenume"].ToString());
                connection.Close();
                bool working = false;
                foreach(string s in nume_angajat)
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
                    MessageBox.Show("Numele introdus este scris gresit sau angajatul nu lucreaza in aceasta institutie .");
                
                //      view salariu 
                //      concediu sporuri etc
                //      atentionare la cat a lucrat pe o zi
                
            }
        }
    }
}
