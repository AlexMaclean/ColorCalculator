using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorCalculator
{
    public partial class ErrorDlg : Form
    {
        public ErrorDlg(string message)
        {
 
            InitializeComponent();
            label1.Text = message;
        }

        private void ErrorDlg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var gr = e.Graphics;
            var ico = SystemIcons.Error;
            gr.DrawIconUnstretched(ico, new Rectangle(25, 25, ico.Width, ico.Height));   
        }
    }
}
