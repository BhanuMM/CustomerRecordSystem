using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CustomerRecordSystem
{
    public partial class addnew : Form
    {
        public addnew()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-VM3M1KF4\SQLEXPRESS;Initial Catalog=RecordSystem;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        string gen, mstat, vacn;
        private void btnback_Click(object sender, EventArgs e)
        {
            land frm = new land();
            frm.Show();
            this.Hide();
        }

        private void rbmarried_CheckedChanged(object sender, EventArgs e)
        {
            if (rbmarried.Checked == true)
            {
                mstat = "Married";
            }
            else { mstat = "Single"; }
        }

        private void rbvac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbvac.Checked == true)
            {
                vacn = "Yes";
            }
            else { vacn = "No"; }
        }

        private void rbnotvac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnotvac.Checked == true)
            {
                vacn = "No";
            }
            else { vacn = "Yes"; }
        }

        private void rbsingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbsingle.Checked == true)
            {
                mstat = "Single";
                
            }
            else { mstat = "Married"; }
        }

        private void rbfemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbfemale.Checked == true)
            {
                gen = "Female";
            }
            else
                {
                    gen = "Male";
                
            }
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtadrs.Text = "";
            txtname.Text = "";
            txtnic.Text = "";
            txttel.Text = "";
            txtemail.Text = "";
            rbfemale.Checked = false;
            rbmale.Checked = false;
            rbvac.Checked = false;
            rbnotvac.Checked = false;
            rbmarried.Checked = false;
            rbsingle.Checked = false;
            numericUpDown1.ResetText();
            dtpdob.ResetText();
            txtname.Focus();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (dtpdob.Value.Date == DateTime.Now.Date)
            { MessageBox.Show("Please Enter a Valid Birthday!", "DOB not Valid!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                try
                {
                    string addnewemp = "insert into customerdet values ('" + txtname.Text + "','" + txtnic.Text + "','" + txttel.Text + "','" + txtadrs.Text + "','" + dtpdob.Value.ToString() + "','" + gen + "','" + txtemail.Text + "','" + numericUpDown1.Value.ToString() + "','" + mstat+ "','" + vacn + "')";
                    cmd = new SqlCommand(addnewemp, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer Details added succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    addnew addfrm = new addnew();
                    this.Hide();
                    addfrm.Show();
                }
                catch (Exception ex)
                { MessageBox.Show("Error While adding new employer details," + Environment.NewLine + Environment.NewLine + ex); }
            }
        }

        private void rbmale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbmale.Checked == true)
            {
                gen = "Male";
            }
            else { gen = "Female"; }
        }
    }
}
