using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAO;
using Models;
using System.Text.RegularExpressions;

namespace DejaView
{
    /// <summary>
    /// Interaction logic for ProdajaHrane.xaml
    /// </summary>
    public partial class ProdajaHrane : Window
    {
        PrehrambeniProduktDao pdao;
        List<PrehrambeniProdukt> produkti;
        List<PrehrambeniProdukt> kprodukti;

        int sifra;
        int id;

        public ProdajaHrane() { }


        public ProdajaHrane(int idp)
        {
            InitializeComponent();
            pdao = new PrehrambeniProduktDao();
            produkti = new List<PrehrambeniProdukt>();
            kprodukti = new List<PrehrambeniProdukt>();
            produkti = pdao.getAll();
            comboprodukti.Items.Clear();
            comboprodukti.ItemsSource = produkti;
            sifra = 0;
            id = idp;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sifracp.Opacity = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrehrambeniProdukt prod = new PrehrambeniProdukt();
            string uneseni = comboprodukti.Text;

            string[] tipovi = Regex.Split(uneseni, " ");

            foreach (PrehrambeniProdukt p in produkti)
            {
                if (p.Tip == tipovi[0])
                    prod = p;
            }

            listaproizvoda.Items.Add(prod);
            kprodukti.Add(prod);


            comboprodukti.SelectedIndex = -1;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            // sifracp.Opacity = 50;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // public Racun(int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacHrane prodavac, List<PrehrambeniProdukt> produkti)
            sifra++;
            MenadzerDAO m = new MenadzerDAO();
            ProdavacHraneDAO pk = new ProdavacHraneDAO();
            Menadzer menadzer = m.getById(id);
            ProdavacHrane prodavac = pk.getById(id);

            double cijena = 0;
            foreach (PrehrambeniProdukt p in kprodukti)
            {

                cijena += p.Cijena;

            }

            if (true == rb1.IsChecked)
            {
                cijena = cijena - cijena * 5 / 100;

            }



            Racun r = new Racun(sifra, DateTime.Now, menadzer, prodavac, kprodukti);
            RacunDAO rdao = new RacunDAO();
            kprodukti.Clear();

            string Datum = Convert.ToDateTime(Datump.SelectedDate).ToString("dd.MM.yyyy");
            string s = "     RACUN      " + Environment.NewLine + "Datum: " + Datum + Environment.NewLine + "Cijena: " + cijena;

            MessageBox.Show(s);



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}

