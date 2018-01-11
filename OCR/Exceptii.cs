using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR
{
    class Exceptii
    {
        string msg;

        
        public Exceptii()
        {
            msg = null;
        }

        public Exceptii(string mesaj)
        {
            msg = mesaj;
        }

        public void Print()
        {
            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}
