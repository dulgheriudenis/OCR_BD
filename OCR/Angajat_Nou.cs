using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OCR
{
    public partial class Angajat_Nou : Form
    {
        string code_number;
        List<string> cod_angajat = new List<string>();
        
        public Angajat_Nou(string code)
        {
            InitializeComponent();
            code_number = code;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if(nume_textBox.Text != "" && prenume_textBox.Text != "" && CNP_textBox.Text.ToString() != "")
            {
                if (CNP_textBox.Text.Length == 13)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");

                        connection.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO Angajat ([Cod Angajat],[Nume Prenume],[CNP],[Inceput contract])  Values ('" + code_number + "','" + nume_textBox.Text.ToString() + " " + prenume_textBox.Text.ToString() + "','" + CNP_textBox.Text.ToString() + "','" + System.DateTime.Now + "')", connection);
                        command.ExecuteNonQuery();
                        connection.Close();

                        connection.Open();
                        SqlCommand command1 = new SqlCommand("INSERT INTO Salarii ([Cod Angajat],[Id functie])  Values ('" + code_number + "',1)", connection);
                        command1.ExecuteNonQuery();
                        connection.Close();

                        connection.Open();
                        SqlCommand command2 = new SqlCommand("INSERT INTO Master ([Cod Angajat])  Values ('" + code_number + "')", connection);
                        command2.ExecuteNonQuery();
                        connection.Close();
                        
                        MessageBox.Show("Succes !");

                        nume_textBox.Clear();
                        prenume_textBox.Clear();
                        CNP_textBox.Clear();

                        code_number = next_code_number(); 

                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show(exception.ToString(),"Error");
                    }
                }
                else MessageBox.Show("CNP ul are doar " + CNP_textBox.Text.Length, "Atentie");
            }
            else MessageBox.Show("Nu sunt completate toate campurile !", "Atentie");
        }

        private void refresh_codes()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");
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

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
