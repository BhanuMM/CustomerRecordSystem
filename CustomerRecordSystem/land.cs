using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRecordSystem
{
    public partial class land : Form
    {
        public land()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            record rcdfrm = new record();
            this.Hide();
            rcdfrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addnew addfrm = new addnew();
            this.Hide();
            addfrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewlog viewfrm = new viewlog();
            this.Hide();
            viewfrm.Show();
        }

        private void btncus_Click(object sender, EventArgs e)
        {
            viewcus cusvfrm = new viewcus();
            this.Hide();
            cusvfrm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
