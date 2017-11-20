using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR
{
    public partial class Admin : Form
    {
        string next_code_number;
        public Admin(string code)
        {
            InitializeComponent();
            next_code_number = code;
            angajat_nou_button.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Angajat_Nou angajat_nou = new Angajat_Nou(next_code_number);
            angajat_nou.Show();
           
        }

        private void verify_button_Click(object sender, EventArgs e)
        {
            if (password_textBox.Text == "admin")
            {
                password_textBox.Visible = false;
                verify_button.Visible = false;
                angajat_nou_button.Visible = true;
            }
        }
    }
}
