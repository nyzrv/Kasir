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

namespace WindowsFormsApp3
{
    public partial class FormMasterKasir : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;
        Koneksi Konn = new Koneksi();

        void munculLevel()
        {
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("USER");
        }
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            munculLevel();
            MunculDataKasir();
        } 
        public FormMasterKasir()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void MunculDataKasir()
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from TableKasir", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "DB_makanan");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "DB_makanan";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }

        private void FormMasterKasir_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Form terisi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("insert into TableKasir values('"+ textBox1.Text + "','" + textBox2.Text +
                    "','" + textBox3.Text + "','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diinput");
                KondisiAwal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("select * from TableKasir where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    comboBox1.Text = rd[3].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Form terisi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("Update TableKasir set NamaKasir='" + textBox2.Text + "',PasswordKasir='" + textBox3.Text + "',Levelkasir='" + comboBox1.Text + "'where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di edit");
                KondisiAwal();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Form terisi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("Delete TableKasir where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di hapus");
                KondisiAwal();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells["KodeKasir"].Value.ToString();
                    textBox2.Text = row.Cells["NamaKasir"].Value.ToString();
                    textBox3.Text = row.Cells["PasswordKasir"].Value.ToString();
                    
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }

        }
    }
}
