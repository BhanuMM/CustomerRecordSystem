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
    public partial class viewlog : Form
    {
        public viewlog()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-VM3M1KF4\SQLEXPRESS;Initial Catalog=RecordSystem;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();
        private void viewlog_Load(object sender, EventArgs e)
        {
           


            try
            {
               
                string viewlog = "Select uid as 'User ID', enterdate as 'Entered Date', entertime as 'Entered Time' from rcrdtbl";
                con.Open();
                sqlda = new SqlDataAdapter(viewlog, con);
                sqlda.Fill(dset, "rcrdtbl");
                con.Close();

                dgvlog.DataSource = dset.Tables["rcrdtbl"];

            }
            catch (Exception ex) { MessageBox.Show("Error While Loading..." + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void btnuid_Click(object sender, EventArgs e)
        {
            try
            {
                dset.Reset();
                string viewlog = "Select uid as 'User ID', enterdate as 'Entered Date', entertime as 'Entered Time' from rcrdtbl where uid= '" + textBox1.Text+"'";
                con.Open();
                sqlda = new SqlDataAdapter(viewlog, con);
                sqlda.Fill(dset, "rcrdtbl");
                con.Close();

                dgvlog.DataSource = dset.Tables["rcrdtbl"];

                
                string viewcus = "Select * from customerdet where uid= '" + textBox1.Text + "'";
                con.Open();
                sqlda = new SqlDataAdapter(viewcus, con);
                sqlda.Fill(dset, "customerdet");
                con.Close();
                dgvcus.Visible = true;
                dgvcus.DataSource = dset.Tables["customerdet"];
                dgvcus.Columns[0].HeaderCell.Value = "User ID";
                dgvcus.Columns[1].HeaderCell.Value = "Name";
                dgvcus.Columns[2].HeaderCell.Value = "NIC";
                dgvcus.Columns[3].HeaderCell.Value = "Tel. No";
                dgvcus.Columns[4].HeaderCell.Value = "Address";
                dgvcus.Columns[5].HeaderCell.Value = "DOB";
                dgvcus.Columns[6].HeaderCell.Value = "Gender";
                dgvcus.Columns[7].HeaderCell.Value = "Email";
                dgvcus.Columns[8].HeaderCell.Value = "No.of Family";
                dgvcus.Columns[9].HeaderCell.Value = "Marital Stat";
                dgvcus.Columns[10].HeaderCell.Value = "Vaccinated";

            }
            catch (Exception ex) { MessageBox.Show("Error While Loading..." + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void btndate_Click(object sender, EventArgs e)
        {
            try
            {
                dset.Reset();
                string viewlog = "Select uid as 'User ID', enterdate as 'Entered Date', entertime as 'Entered Time' from rcrdtbl where enterdate= '" + dateTimePicker1.Value+ "'";
                con.Open();
                sqlda = new SqlDataAdapter(viewlog, con);
                sqlda.Fill(dset, "rcrdtbl");
                con.Close();

                dgvlog.DataSource = dset.Tables["rcrdtbl"];


               
                dgvcus.Visible = false;

            }
            catch (Exception ex) { MessageBox.Show("Error While Loading..." + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            land lndfrm = new land();
            this.Hide();
            lndfrm.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnmonth_Click(object sender, EventArgs e)
        {
            try
            {
                dset.Reset();
                string viewlog = "Select * from rcrdtbl WHERE (DATEPART(mm,enterdate) = '"+ (dateTimePicker2.Value) + "')";
                con.Open();
                sqlda = new SqlDataAdapter(viewlog, con);
                sqlda.Fill(dset, "rcrdtbl");
                con.Close();

                dgvlog.DataSource = dset.Tables["rcrdtbl"];



                dgvcus.Visible = false;

            }
            catch (Exception ex) { con.Close(); MessageBox.Show("Error While Loading..." + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewlog viewfrm = new viewlog();
            this.Hide();
            viewfrm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("h:mm:ss tt");
            lbltime.Text = DateTime.Today.ToString("dd-MM-yyyy");
        }
    }
}
