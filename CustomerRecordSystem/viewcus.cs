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
    public partial class viewcus : Form
    {
        public viewcus()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-VM3M1KF4\SQLEXPRESS;Initial Catalog=RecordSystem;Integrated Security=True");
        SqlDataAdapter sqlda = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet dset = new DataSet();
        string vacn;
        private void viewcus_Load(object sender, EventArgs e)
        {
            try
            {

                string viewlog = "Select * from customerdet";
                con.Open();
                sqlda = new SqlDataAdapter(viewlog, con);
                sqlda.Fill(dset, "customerdet");
                con.Close();

                dataGridView1.DataSource = dset.Tables["customerdet"];
                dataGridView1.Columns[0].HeaderCell.Value = "User ID";
                dataGridView1.Columns[1].HeaderCell.Value = "Name";
                dataGridView1.Columns[2].HeaderCell.Value = "NIC";
                dataGridView1.Columns[3].HeaderCell.Value = "Tel. No";
                dataGridView1.Columns[4].HeaderCell.Value = "Address";
                dataGridView1.Columns[5].HeaderCell.Value = "DOB";
                dataGridView1.Columns[6].HeaderCell.Value = "Gender";
                dataGridView1.Columns[7].HeaderCell.Value = "Email";
                dataGridView1.Columns[8].HeaderCell.Value = "No.of Family";
                dataGridView1.Columns[9].HeaderCell.Value = "Marital Stat";
                dataGridView1.Columns[10].HeaderCell.Value = "Vaccinated";

            }
            catch (Exception ex) { MessageBox.Show("Error While Loading..." + Environment.NewLine + Environment.NewLine + ex); }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            land lndfrm = new land();
            this.Hide();
            lndfrm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                editcus rcdfrm = new editcus();

                rcdfrm.Show();
            }
        }

        private void btnuid_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string slecu = "Select * from customerdet where uid='" + textBox1.Text + "'";
                con.Open();
                sqlda = new SqlDataAdapter(slecu, con);
                con.Close();
                DataTable r1 = new DataTable();
                sqlda.Fill(r1);

                if (r1.Rows.Count > 0)
                {
                    panel1.Visible = true;
                    lbluid.Text = textBox1.Text;
                    try
                    {


                        string loaddata = "Select * from customerdet where uid='" + textBox1.Text + "'";
                        con.Open();
                        cmd = new SqlCommand(loaddata, con);
                        SqlDataReader r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            txtname.Text = r[1].ToString();
                            txtnic.Text= r[2].ToString();
                            txttel.Text= r[3].ToString();
                            txtadrs.Text= r[4].ToString();
                            txtemail.Text= r[7].ToString();
                            
                          
                            string vcn = r[10].ToString();
                            if (vcn == "Yes")
                            {
                                rbvac.Checked = true;
                            }
                            else { rbnotvac.Checked = true; }

                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + Environment.NewLine + ex);
                    }
                }
                else
                {
                    
                }

               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            textBox1.Clear();
            txtadrs.Text = "";
            txtname.Text = "";
            txtnic.Text = "";
            txttel.Text = "";
            txtemail.Text = "";
            txtname.Focus();
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete this customer?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                string removeu = "delete from customerdet where uid='" + lbluid.Text + "' ";
                cmd = new SqlCommand(removeu, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Successfully Removed!", "Customer Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                viewcus cusvfrm = new viewcus();
                this.Hide();
                cusvfrm.Show();
            }

     
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            
            DialogResult sure = MessageBox.Show("Are You sure You want update the details ?", "Confirm To Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sure == DialogResult.Yes)

            {

                string updatedet = "update customerdet set fname='" + txtname.Text + "',nic='" + txtnic.Text + "',telno='" + txttel.Text+ "',adrs='" + txtadrs.Text + "',eml='" + txtemail.Text + "',vaccin='" + vacn + "' where uid='"+lbluid.Text+"'";
                cmd = new SqlCommand(updatedet, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Details updated succesfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewcus cusvfrm = new viewcus();
                this.Hide();
                cusvfrm.Show();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void rbvac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnotvac.Checked == true)
            {
                vacn = "No";
            }
            else { vacn = "Yes"; }
        }

        private void rbnotvac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnotvac.Checked == true)
            {
                vacn = "No";
            }
            else { vacn = "Yes"; }
        }
    }
}
