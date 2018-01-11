using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OCR
{
    public partial class Avansare : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");

        public Avansare()
        {
            InitializeComponent();
        }

        private int avansare_in_grad(string nume_si_prenume,int grad)
        {
            List<string> nume_angajat = new List<string>();
            List<string> functie_angajat = new List<string>();
            List<string> cod_angajat_ = new List<string>();
            bool recunoscut = false;

            con.Open();
            SqlCommand com = new SqlCommand("Select Angajat.[Nume Prenume],Salarii.[Id functie],Angajat.[Cod Angajat] FROM Angajat INNER JOIN Salarii ON Angajat.[Cod Angajat]=Salarii.[Cod angajat]", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read()) { nume_angajat.Add(reader["Nume Prenume"].ToString()); functie_angajat.Add(reader["Id functie"].ToString()); cod_angajat_.Add(reader["Cod Angajat"].ToString());}
            con.Close();

            for (int i = 0; i < nume_angajat.Count; i++) 
            {
                if(nume_angajat[i] == nume_si_prenume)
                {
                    if (int.Parse(functie_angajat[i]) < grad)
                    {
                        con.Open();
                        SqlCommand commandu = new SqlCommand("UPDATE Salarii SET [Id functie]=@id_functie WHERE [Cod angajat]=@cod_angajat", con);

                        DbParameter parameter = commandu.CreateParameter();
                        parameter.ParameterName = "@id_functie";
                        parameter.Value = grad;
                        commandu.Parameters.Add(parameter);

                        DbParameter parameter1 = commandu.CreateParameter();
                        parameter1.ParameterName = "@cod_angajat";
                        parameter1.Value = cod_angajat_[i];
                        commandu.Parameters.Add(parameter1);

                        commandu.ExecuteNonQuery();

                        con.Close();

                        return 100; // avanasare cu succes !
                    }
                    else { if(int.Parse(functie_angajat[i]) >= grad) return int.Parse(functie_angajat[1]); } // intoarece gradul angajatului

                    recunoscut = true;
                }
            }


            if(recunoscut == false)
            {
                return -199;//nu exita in baza de date 
            }
            return -200; //ceva nu a mers bine
        }

        private void procesare_button_Click(object sender, EventArgs e)
        {
            if (nume_angajat_textbox.Text != "")
            {
                
                if(entry_radio_button.Checked)
                {
                    // mai fa inca o metoda de gestiune a mesajelor din metoda avansare in grad 
                    avansare_in_grad(nume_angajat_textbox.Text, 4);
                }
                else if(standard_radio_button.Checked)
                     {

                     }
                     else if(manager_radio_button.Checked)
                           {

                           }
                           else  if(director_radio_button.Checked)
                                {

                                }
                                 else MessageBox.Show("Va rugam sa selectati una din nivelurile profesionale oferite !");


            }
            else MessageBox.Show("Nu ati completat numele anagajatului !");
        }

        private void renuntare_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
