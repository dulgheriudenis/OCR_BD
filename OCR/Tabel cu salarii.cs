using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OCR
{
    public partial class Tabel_cu_salarii : Form
    {
        public Tabel_cu_salarii()
        {
            InitializeComponent();
        }

        static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        private static DataTable ExecuteSqlTransaction(string connectionString)
        {
            List<string> list = new List<string>();
            List<string> angajat = new List<string>();
            List<string> salariu = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    //  Comanda nr. 1
                    command.CommandText =
                        "Select* FROM VedereSalariiNet";

                    SqlDataReader reader = command.ExecuteReader();               

                    while (reader.Read())
                        list.Add(reader["Salariu"].ToString());

                    reader.Close();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Commit Exception Type: {0} " + ex.GetType());
                   MessageBox.Show("  Message: {0} " + ex.Message);

                    // Rollback la tranzactie
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                        MessageBox.Show("Rollback Exception Type: {0} " + ex2.GetType());
                        MessageBox.Show("  Message: {0} " + ex2.Message);
                    }
                }

                connection.Close();
            }




            SqlConnection con = new SqlConnection(connectionString);

            // Comanda nr. 2
            con.Open();
            SqlCommand command2 = new SqlCommand("Select [Nume Prenume] from Angajat", con);
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
                angajat.Add(reader2["Nume Prenume"].ToString());

            con.Close();


            //  Comanda nr. 3
            con.Open();
            SqlCommand command1 = new SqlCommand("SELECT Functii.[Salariu de baza] FROM Functii INNER JOIN Salarii ON Salarii.[Id functie]=Functii.Id", con);
            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
                salariu.Add(reader1["Salariu de baza"].ToString());

            con.Close();


            // Pregatirea listei finale
            List<float> salariul = new List<float>();

            for (int i = 0; i < salariu.Count; i++)
                salariul.Add(float.Parse(salariu[i].ToString()) * 20);


            List<string[]> lista = new List<string[]>();
            for (int i = 0; i < list.Count; i++)
            { lista.Add(new string[] { angajat[i].ToString(), list[i].ToString(), salariu[i].ToString() }); }

            DataTable table = ConvertListToDataTable(lista);
            table.Columns["Column1"].ColumnName = "Nume angajat";
            table.Columns["Column2"].ColumnName = "Salariu NET";
            table.Columns["Column3"].ColumnName = "Salariu de baza";

            return table;            
        }

        private void Tabel_cu_salarii_Load(object sender, EventArgs e)
        {
            DataTable table = ExecuteSqlTransaction(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\OCR\Database1.mdf;Integrated Security=True");

            dataGridView1.DataSource = table;
            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
