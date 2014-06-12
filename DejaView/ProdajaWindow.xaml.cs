using DAO;
using Microsoft.Win32;
using Models;
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
using System.Text.RegularExpressions;

namespace DejaView
{

    /// <summary>
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {

        private string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));


            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {

                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }
        private ClanDAO cdao = new ClanDAO();
        List<Clan> clanovi = new List<Clan>();
        private ProjekcijaDAO pdao = new ProjekcijaDAO();
        private List<Projekcija> projekcije = new List<Projekcija>();
        private FilmDAO fdao = new FilmDAO();
        private int id;
        private KartaDAO kdao = new KartaDAO();
        private List<int> list;
        private List<int> sjedista;

        public ProdajaWindow(int id)
        {
            this.id = id;
            InitializeComponent();

            projekcije = pdao.getAll();
            clanovi = cdao.getAll();
            ___combclan_.Items.Clear();
            list = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                list.Add(0);
            }

            ___combclan_.ItemsSource = clanovi;
            sjedista = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                sjedista.Add(i);
            }

            listsjedista.Items.Clear();
            listsjedista.ItemsSource = sjedista;
            rezsjedista.Items.Clear();
            rezsjedista.ItemsSource = sjedista;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image Files|*.jpg";
            dialog.Title = "Select an Image";

            if (dialog.ShowDialog() == true)
            {

            }

        }



        private void ListaFilmovaUProdaji_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string f = ListaFilmovaUProdaji.SelectedValue.ToString();
            List<Projekcija> termini = new List<Projekcija>();

            List<string> datumi = new List<string>();

            foreach (Projekcija p in projekcije)
            {

                if (p.Film.Naziv == f)
                {
                    termini.Add(p);
                    datumi.Add(p.Pocetak.ToString("dd:mm:yyy"));
                }
            }

            ___listatermini_.ItemsSource = termini;
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string sifra = RandomString(15);


            Clan c = new Clan(sifra, DateTime.Now, Imec.Text, Prezimec.Text);

            ClanDAO cl = new ClanDAO();

            long i = cl.create(c);
            MessageBox.Show(Convert.ToString(i));

        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }




        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Clan postojeci = new Clan();
            string sifra = ___combclan_.Text;
            string[] rijeci = Regex.Split(sifra, " ");


            foreach (Clan c in clanovi)
            {
                if (String.Compare(c.Sifra.Trim(), rijeci[2]) == 0)
                    postojeci = c;
                //}
                cdao.update(postojeci);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }



        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }



        private void ___Datump__SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            List<Film> filmovi = new List<Film>();
            string datump = (Convert.ToDateTime(___Datump_1.SelectedDate)).ToString("dd/MM/yyyy");




            foreach (Projekcija p in projekcije)
            {
                {
                    if (datump == p.Pocetak.ToString("dd/MM/yyyy"))
                        filmovi.Add(p.Film);

                }
            }


            ListaFilmovaUProdaji.ItemsSource = filmovi;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {  //    public Karta(int sifra, DateTime vrijeme, Menadzer menadzer, ProdavacKarata prodavac, Kupac kupac, Projekcija termin )
            string sifra_karte = RandomString(10);
            string sifra_kupca = RandomString(10);
            Kupac k;
            if (true == ___clanda_.IsChecked)
            {
                ClanDAO clan = new ClanDAO();
                k = clan.getById(Convert.ToInt32(___clanid_.Text));

            }
            else

                k = new ObicniKupac(sifra_kupca, null, null);
            Projekcija p = new Projekcija();
            MenadzerDAO m = new MenadzerDAO();
            ProdavacKarataDAO pk = new ProdavacKarataDAO();
            Menadzer menadzer = m.getById(id);
            ProdavacKarata prodavac = pk.getById(id);

            Karta karta = new Karta(sifra_karte, DateTime.Now, menadzer, prodavac, k, p);
            kdao.create(karta);

        }

        private void ___clanda__Checked(object sender, RoutedEventArgs e)
        {
            ___clanid_.Visibility = System.Windows.Visibility.Visible;
        }

        private void ___clanne__Checked(object sender, RoutedEventArgs e)
        {
            ___clanid_.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Film> filmovi = new List<Film>();
            string datump = (Convert.ToDateTime(Datum.SelectedDate)).ToString("dd/MM/yyyy");




            foreach (Projekcija p in projekcije)
            {
                {
                    if (datump == p.Pocetak.ToString("dd/MM/yyyy"))
                        filmovi.Add(p.Film);

                }
            }
            ListaFilmovaZaRezervaciju.ItemsSource = filmovi;



        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string f = ListaFilmovaZaRezervaciju.SelectedValue.ToString();



            List<Projekcija> termini = new List<Projekcija>();

            List<string> datumi = new List<string>();

            foreach (Projekcija p in projekcije)
            {

                if (p.Film.Naziv == f)
                {

                    termini.Add(p);
                    datumi.Add(p.Pocetak.ToString("dd:mm:yyy"));
                }
            }

            ___listatermina_.ItemsSource = termini;
        }

        private void ListaFilmovaZaRezervaciju_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string f = ListaFilmovaZaRezervaciju.SelectedValue.ToString();



            List<Projekcija> termini = new List<Projekcija>();


            List<string> datumi = new List<string>();

            foreach (Projekcija p in projekcije)
            {

                if (p.Film.Naziv == f)
                {
                    termini.Add(p);
                    datumi.Add(p.Pocetak.ToString("dd:mm:yyy"));
                }
            }

            ___listatermina_.ItemsSource = termini;



        }

        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            int sjediste = Convert.ToInt32(listsjedista.SelectedValue);
            if (list[sjediste - 1] == 0) list[sjediste - 1] = 1;
            else list[sjediste - 1] = 1;

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // public Rezervacija(Projekcija projekcija,Kupac k, int sjediste)

            Rezervacija r = new Rezervacija(new Projekcija(), new ObicniKupac(), 1);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            int sjediste = Convert.ToInt32(listsjedista.SelectedValue);
            if (list[sjediste - 1] == 0) list[sjediste - 1] = 1;
            else list[sjediste - 1] = 1;


        }



    }




}



