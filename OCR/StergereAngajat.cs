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
    public partial class StergereAngajat : Form
    {
        static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\OCR\Database1.mdf;Integrated Security=True");
        static string cod_angajat = "";

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

        public StergereAngajat()
        {
            InitializeComponent();
        }

        private void StergereAngajat_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (nume_textBox.Text.ToString() != "")
                {
                    if (exista(nume_textBox.Text.ToString()) == true)
                    {
                        connection.Open();
                        SqlCommand command1 = new SqlCommand("DELETE FROM Angajat WHERE [Cod Angajat]=@cod", connection);

                        var parameter = command1.CreateParameter();
                        parameter.ParameterName = "@cod";
                        parameter.Value = cod_angajat;
                        command1.Parameters.Add(parameter);

                        command1.ExecuteNonQuery();
                        connection.Close();

                        connection.Open();
                        SqlCommand command2 = new SqlCommand("DELETE FROM Concedii WHERE [Cod angajat]=@cod", connection);
                        var parameter1 = command2.CreateParameter();
                        parameter1.ParameterName = "@cod";
                        parameter1.Value = cod_angajat;
                        command2.Parameters.Add(parameter1);

                        command2.ExecuteNonQuery();
                        connection.Close();

                        connection.Open();
                        SqlCommand command3 = new SqlCommand("DELETE FROM Intrari WHERE [Cod angajat]=@cod", connection);
                        var parameter3 = command3.CreateParameter();
                        parameter3.ParameterName = "@cod";
                        parameter3.Value = cod_angajat;
                        command3.Parameters.Add(parameter3);

                        command3.ExecuteNonQuery();
                        connection.Close();

                        connection.Open();
                        SqlCommand command4 = new SqlCommand("DELETE FROM Master WHERE [Cod angajat]=@cod", connection);
                        var parameter4 = command4.CreateParameter();
                        parameter4.ParameterName = "@cod";
                        parameter4.Value = cod_angajat;
                        command4.Parameters.Add(parameter4);

                        command4.ExecuteNonQuery();
                        connection.Close();

                        connection.Open();
                        SqlCommand command5 = new SqlCommand("DELETE FROM Salarii WHERE [Cod angajat]=@cod", connection);
                        var parameter5 = command5.CreateParameter();
                        parameter5.ParameterName = "@cod";
                        parameter5.Value = cod_angajat;
                        command5.Parameters.Add(parameter5);

                        command5.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Angajatul a fost sters !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else throw new Exception("Angajatul nu se afla in baza de date !");
                }
                else throw new Exception("Completati campul cu numele si prenumele angajatului");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
