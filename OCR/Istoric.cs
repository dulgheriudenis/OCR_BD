using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OCR
{
    public partial class Istoric : Form
    {
        public Istoric()
        {
            InitializeComponent();
        }

        private void Istoric_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Istoric_Load_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\Database1.mdf;Integrated Security=True");
            connection.Open();
            SqlCommand sCommand = new SqlCommand("Select Angajat.[Nume Prenume],Intrari.[Ora intrare],Intrari.[Ora iesire] FROM Angajat INNER JOIN Intrari ON Intrari.[Cod angajat] = Angajat.[Cod angajat]", connection);
            SqlDataAdapter sAdapter = new SqlDataAdapter(sCommand);
            DataSet sDs = new DataSet();


            sAdapter.Fill(sDs, "Intrari");
            DataTable sTable = sDs.Tables["Intrari"];
            connection.Close();
            dataGridView1.DataSource = sDs.Tables["Intrari"];
            dataGridView1.ReadOnly = true;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
    }
}
