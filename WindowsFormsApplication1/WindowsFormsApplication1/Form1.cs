using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=proje1.accdb");
        private void notgör()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * From ogrencinot";
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kayitno"].ToString();
                ekle.SubItems.Add(oku["ogrno"].ToString());
                ekle.SubItems.Add(oku["ograd"].ToString());
                ekle.SubItems.Add(oku["ogrsad"].ToString());
                ekle.SubItems.Add(oku["dersad"].ToString());
                ekle.SubItems.Add(oku["sinav1"].ToString());
                ekle.SubItems.Add(oku["sinav2"].ToString());
                ekle.SubItems.Add(oku["prf"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();


            
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            notgör();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("insert into ogrencinot (kayitno,ogrno,ograd,ogrsad,dersad,sinav1,sinav2,prf) values ('" + textBox1.Text.ToString() + "','"+ textBox2.Text.ToString() + "','"+ textBox3.Text.ToString() + "','"+ textBox5.Text.ToString() + "','"+ textBox4.Text.ToString() + "','"+ textBox6.Text.ToString() + "','"+ textBox7.Text.ToString() + "','"+ textBox8.Text.ToString() + "')");
            komut.ExecuteNonQuery();
            baglanti.Close();
            notgör();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete from ogrencinot where ogrno = '" + textBox2.Text + "'  ";
            komut.ExecuteNonQuery();
            baglanti.Close();
            notgör();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from ogrencinot where ogrno = '" + textBox2.Text.ToString() +"'";
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            textBox1.Text = oku["kayitno"].ToString();
            textBox3.Text = oku["ograd"].ToString();
            textBox4.Text = oku["ogrsad"].ToString();
            textBox5.Text = oku["dersad"].ToString();
            textBox6.Text = oku["sinav1"].ToString();
            textBox7.Text = oku["sinav2"].ToString();
            textBox8.Text = oku["prf"].ToString();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "update ogrencinot set kayitno = '" + textBox1.Text.ToString() + "', ogrno ='" + textBox2.Text.ToString() + "',  ograd = '" + textBox3.Text.ToString() + "', ogrsad = '" + textBox5.Text.ToString() + "', dersad='" + textBox4.Text.ToString() + "', sinav1 = '" + textBox6.Text.ToString() + "', sinav2 = '" + textBox7.Text.ToString() + "', prf = '" + textBox8.Text.ToString() + "' where ogrno = '"+textBox2.Text.ToString()+"'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            notgör();
        }
    }
}
