using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace pansiyonKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=musteriler.accdb");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select * from kullanicilar", baglanti);
            
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                //veritabanındaki veriler liswievde ki ilgili yerlere eklendi
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Gtarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
                


            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Textbox ve datetimepicker daki değerler tabloya eklenicek
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into kullanicilar(id,Ad,Soyad,OdaNo,GTarih,Telefon,Hesap,CTarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + dateTimePicker2.Text.ToString()+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();
        }
    }
}
