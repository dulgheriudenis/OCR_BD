using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Linq;

namespace OCR
{
    public partial class Istoric : Form
    {
        public Istoric()
        {
            InitializeComponent();

            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
        }

        private void Istoric_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Istoric_Load_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\OCR\Database1.mdf;Integrated Security=True");
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


        private string ExportToPDF(DataGridView dgv, string strHeader)
        {
            FolderBrowserDialog opf = new FolderBrowserDialog();
            opf.Description = "Destinatie pentru PDF";
            opf.ShowDialog();
            string strPdfPath = opf.SelectedPath.ToString() + strHeader + ".pdf";

            DataTable dtblTable = new DataTable();
            dtblTable = (DataTable)dgv.DataSource;

            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Author : Admin", fntAuthor));
            prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, iTextSharp.text.BaseColor.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();

            return strPdfPath;
        }


        private string ExportToExcel()
        {
            FolderBrowserDialog opf = new FolderBrowserDialog();
            opf.Description = "Destinatie pentru Excel";
            opf.ShowDialog();
            string cale = opf.SelectedPath.ToString() + "Intrari-Iesiri" + ".xls";

            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\Work\Anul III\Semestrul I\Baze de date\Proiect\OCR\OCR\OCR\Database1.mdf; Integrated Security = True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = "Select Angajat.[Nume Prenume],Intrari.[Ora intrare],Intrari.[Ora iesire] FROM Angajat INNER JOIN Intrari ON Intrari.[Cod angajat] = Angajat.[Cod angajat]";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    Excel.Range formatrange = xlWorkSheet.get_Range("a1", "f1");
                    formatrange.NumberFormat = "mm/dd/yyyy hh:mm:ss";
                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs(cale, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            return cale;
        }

        string ExportToCSV()
        {
            FolderBrowserDialog opf = new FolderBrowserDialog();
            opf.Description = "Destinatie pentru .csv";
            opf.ShowDialog();
            string cale = opf.SelectedPath.ToString() + "Intrari-Iesiri" + ".csv";

            var csv = new StringBuilder();
            using (var context = new Database1Entities() )
            {
                
                var query = from emp in context.Intraris
                            select new 
                            {
                                emp.Id,
                                emp.Cod_angajat,
                                emp.Ora_intrare,
                                emp.Ora_iesire
                            };


                foreach (var row in query)
                {
                    var newline = string.Format("{0},{1},{2},{3}", row.Id.ToString().Trim(),
                        row.Cod_angajat.ToString().Trim(), row.Ora_intrare.ToString().Trim(), row.Ora_iesire.ToString().Trim());
                    csv.AppendLine(newline);
                }
                File.WriteAllText(cale, csv.ToString());
            }

            return cale;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
                MessageBox.Show("Selecteaza un tip de fisier !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (checkBox1.Checked == true)
            {
                try
                {
                    string cale = ExportToPDF(this.dataGridView1, "Intrari-Iesiri");
                    DialogResult result = MessageBox.Show("PDF creat !" + Environment.NewLine + "Doriti sa deschidem fierul acum?",
                        "SUCCES", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        System.Diagnostics.Process.Start(cale);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fisierul PDF nu s-a putut crea !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if(checkBox2.Checked == true)
            {
                try
                {
                    string cale = ExportToExcel();
                    DialogResult result = MessageBox.Show("Fisier Excel creat !" + Environment.NewLine + "Doriti sa deschidem fierul acum?",
                        "SUCCES", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        System.Diagnostics.Process.Start(cale);
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Fisierul Excel nu s-a putut crea !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
             
            if(checkBox3.Checked == true)
            {
                try
                {
                    string cale = ExportToCSV();
                    DialogResult result = MessageBox.Show("Fisier .csv creat !" + Environment.NewLine + "Doriti sa deschidem fierul acum?",
                        "SUCCES", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        System.Diagnostics.Process.Start(cale);
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Fisierul .csv nu s-a putut crea !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
        }
    }
}
