using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<DateTime> Datumy = new List<DateTime>();
        List<string> Rodna_Cisla = new List<string>();
        int baby = 0;
        int chlapy = 0;

        DateTime datum = new DateTime();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                datum = dateTimePicker1.Value;
                string Datum = datum.ToString();
                if (Datum.Contains("  "))
                {
                    Datum.Replace("  ", " ");
                }
                string[] Datum_Rozdelene = Datum.Split(' ');
                string[] Datum_vice_rozdelene = Datum_Rozdelene[0].Split('.');
                if (radioButton1.Checked)
                {
                    chlapy += 1;
                }
                else if (radioButton2.Checked)
                {
                    int X = int.Parse(Datum_vice_rozdelene[1]);
                    X += 50;
                    Datum_vice_rozdelene[1] = X.ToString();
                    baby += 1;
                }
                string str = Datum_vice_rozdelene[2];
                string vysledek = str.Substring(str.Length - 2);
                string Rodne_cislo = " ";
                Rodne_cislo = Datum_vice_rozdelene[0] + Datum_vice_rozdelene[1] + vysledek;

                bool delitelne3 = false;
                bool Delitelne3 = false;

                string Rodne_cislo_delitelne_tremi_Stare = " ";
                string Rodne_cislo_delitelne_tremi_Nove = " ";

                Random rng = new Random();
                while (delitelne3 == false)
                {
                    int num = rng.Next(110, 990);
                    Rodne_cislo_delitelne_tremi_Stare = Rodne_cislo + num;
                    if ((Int64.Parse(Rodne_cislo_delitelne_tremi_Stare) % 3) == 0)
                    {
                        delitelne3 = true;
                    }
                }

                while (Delitelne3 == false)
                {
                    int num = rng.Next(1100, 9900);
                    Rodne_cislo_delitelne_tremi_Nove = Rodne_cislo + num;
                    if ((Int64.Parse(Rodne_cislo_delitelne_tremi_Nove) % 3) == 0)
                    {
                        Delitelne3 = true;
                    }
                }

                maskedTextBox1.Text = Rodne_cislo_delitelne_tremi_Stare;
                maskedTextBox2.Text = Rodne_cislo_delitelne_tremi_Nove;

                Rodna_Cisla.Add(Rodne_cislo_delitelne_tremi_Nove);
                Datumy.Add(datum);
            } catch
            {
                MessageBox.Show("neco se pokazilo, jedna z verzí je že jste nezadal žádné datum");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime Nejstarsi = Datumy[0];
                DateTime Nejmladsi = Datumy[0];
                foreach (DateTime x in Datumy)
                {
                    if (x > Nejmladsi)
                    {
                        Nejmladsi = x;
                    }
                    else if (x < Nejstarsi)
                    {
                        Nejstarsi = x;
                    }
                }

                string[] Nejstarsi_lepsi_vize = Nejstarsi.ToString().Split(' ');
                label5.Text = "Datum narozeni: " + Nejstarsi_lepsi_vize[0];
                int stari = Datumy.IndexOf(Nejstarsi);
                maskedTextBox3.Text = Rodna_Cisla[stari];

                string[] Nejmladsi_lepsi_vize = Nejmladsi.ToString().Split(' ');
                label8.Text = "Datum narozeni: " + Nejmladsi_lepsi_vize[0];
                int mlady = Datumy.IndexOf(Nejmladsi);
                maskedTextBox4.Text = Rodna_Cisla[mlady];
            }
            catch
            {
                MessageBox.Show("neco se pokazilo, jedna z verzí je že jste nezadal žádné datum");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
