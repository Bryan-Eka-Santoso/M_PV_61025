using Database.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds=new DataSet();
        MySqlDataAdapter da;
        MySqlCommandBuilder builder;

        public void loaddata()
        {
            ds=new DataSet();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = koneksi.getConn();
            cmd.CommandText = "select * from produk";

            da = new MySqlDataAdapter(cmd);
            builder = new MySqlCommandBuilder(da);
            da.Fill(ds, "produk");

            dataGridView1.DataSource = ds.Tables["produk"];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            koneksi.open();

            loaddata();
        }
        int index;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            lblID.Text = ds.Tables["produk"].
                Rows[index][0].ToString();

            textBox1.Text = ds.Tables["produk"].
                Rows[index][1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Tables["produk"].Rows[index][1] 
                = textBox1.Text;
            da.Update(ds, "produk");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ds.Tables["produk"].Rows.RemoveAt(index);
            //da.Update(ds, "produk");
            MySqlCommand command = new MySqlCommand();
            command.Connection=koneksi.getConn();
            command.CommandText = "delete from produk where " +
                "id_produk=@id_produk";
            command.Parameters.AddWithValue("@id_produk",
                lblID.Text);
            command.ExecuteNonQuery();

            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand command=new MySqlCommand();
            command.CommandText
                = "select kategori from produk where " +
                "id_produk=@id_produk";
            command.Connection = koneksi.getConn();
            command.Parameters.AddWithValue("@id_produk",lblID.Text);

            string hasil = command.ExecuteScalar().ToString() ;
            MessageBox.Show(hasil);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandText
                = "select * from produk where " +
                "id_produk=@id_produk";
            command.Connection = koneksi.getConn();
            command.Parameters.AddWithValue("@id_produk", lblID.Text);

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetValue(0));
                Console.WriteLine(reader.GetValue(1));
                Console.WriteLine(reader.GetValue(2));
                Console.WriteLine(reader.GetValue(3));
            }
            reader.Close();

        }
    }
}
