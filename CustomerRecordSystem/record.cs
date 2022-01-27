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
    public partial class record : Form
    {
        public record()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-VM3M1KF4\SQLEXPRESS;Initial Catalog=RecordSystem;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();

        private void record_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtuid.Text == "") { MessageBox.Show("Please Enter a User ID", "User ID Required", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                string slecu = "Select uid from customerdet where uid='" + txtuid.Text + "' ";
                con.Open();
                sqlda = new SqlDataAdapter(slecu, con);
                con.Close();
                DataTable r1 = new DataTable();
                sqlda.Fill(r1);

                if (r1.Rows.Count > 0)
                {
                    try
                    {
                        string addrcrd = "insert into rcrdtbl values ('" + txtuid.Text + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "')";
                        cmd = new SqlCommand(addrcrd, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Recorded succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        record rcdfrm = new record();
                        this.Hide();
                        rcdfrm.Show();
                    }
                    catch (Exception ex)
                    { MessageBox.Show("Error While Recording," + Environment.NewLine + Environment.NewLine + ex); }
                }
                else
                {
                    MessageBox.Show("User ID not Recognized", "Incorrect User ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }

            }


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            land lndfrm = new land();
            this.Hide();
            lndfrm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}
