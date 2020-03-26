using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public void one(string a)
        {
            pictureBox1.Image= Image.FromFile(a);
            pictureBox2.Image = Image.FromFile(a);
            pictureBox3.Image = Image.FromFile(a);
            pictureBox4.Image = Image.FromFile(a);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
