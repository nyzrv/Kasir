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
    public partial class Form_master_barang : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;
        Koneksi Konn = new Koneksi();

        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            MunculDataBarang();
        }
        void MunculDataBarang()
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from TableBarang", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "DB_makanan");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "DB_makanan";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();
        }
        public Form_master_barang()
        {
            InitializeComponent();
        }

        private void Form_master_barang_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" )
            {
                MessageBox.Show("Pastikan Form terisi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("insert into TableBarang values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil diinput");
                KondisiAwal();
                //SqlConnection conn = Konn.GetConn();
                //cmd = new SqlCommand("insert into TableBarang values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'" +"')", conn);
                //conn.Open();
                //cmd.ExecuteNonQuery();
                //MessageBox.Show("Data berhasil diinput");
                //KondisiAwal();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" 
                || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Form terisi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("Update TableBarang set KodeBarang='" + textBox1.Text
                    + "',NamaBarang='" + textBox2.Text + "',HargaBeli='" + textBox5.Text + "',HargaJual='" 
                    + textBox3.Text + "',JumlahBarang='" + textBox4.Text + "'where KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di edit");
                KondisiAwal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim()
                    == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox1.Text.Trim() == "") 
                {
                    MessageBox.Show("Pastikan Form terisi");
                }
                else
                {
                    SqlConnection conn = Konn.GetConn();
                    cmd = new SqlCommand("Delete TableBarang where KodeBarang='" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di hapus");
                    KondisiAwal();
                }
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
                    textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
                    textBox3.Text = row.Cells["HargaBeli"].Value.ToString();
                    textBox4.Text = row.Cells["HargaJual"].Value.ToString();
                    textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());
                }
            }



        }
    }
}
