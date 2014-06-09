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

namespace DejaView
{

    /// <summary>
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {

        public string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
            if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

            const int byteSize = 0x100;
            var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
            if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

            // Guid.NewGuid and System.Random are not particularly random. By using a
            // cryptographically-secure random number generator, the caller is always
            // protected, regardless of use.
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                var result = new StringBuilder();
                var buf = new byte[128];
                while (result.Length < length)
                {
                    rng.GetBytes(buf);
                    for (var i = 0; i < buf.Length && result.Length < length; ++i)
                    {
                        // Divide the byte into allowedCharSet-sized groups. If the
                        // random value falls into the last group and the last group is
                        // too small to choose from the entire allowedCharSet, ignore
                        // the value in order to avoid biasing the result.
                        var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                        if (outOfRangeStart <= buf[i]) continue;
                        result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
                    }
                }
                return result.ToString();
            }
        }




        public ProdajaWindow()
        {



            InitializeComponent();

            FilmDAO fdao = new FilmDAO();
            ProjekcijaDAO pdao = new ProjekcijaDAO();

            ListaFilmovaUProdaji.ItemsSource = fdao.getAll();
            ListaFilmovaZaRezervaciju.ItemsSource = fdao.getAll();

            /*   List<Projekcija> projekcije = new List<Projekcija>();

               projekcije = pdao.getAll();
               List<string> termini = projekcije.Select(projekcija => projekcija.Pocetak.TimeOfDay.ToString()).ToList(); *

               KupovinaTermini.ItemsSource = termini;
               KupovinaTermini.SelectedIndex = 0; 

               RezervacijaTermini.ItemsSource = termini;
               RezervacijaTermini.SelectedIndex = 0; */




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



            List<string> termini = new List<string>();

            ProjekcijaDAO pdao = new ProjekcijaDAO();
            List<Projekcija> projekcije = new List<Projekcija>();

            /*  projekcije = pdao.getAll();
              MessageBox.Show(projekcije[1].Film.Naziv);
           
              /*foreach (Projekcija p in projekcije) {
                 string  f=ListaFilmovaUProdaji.SelectedValue.ToString();
                  if (p.Film.Naziv ==f)
                  { 
                      //string sDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
                      string pr=p.Pocetak.ToString ("hh:mm:ss") ;
                      termini.Add(pr);
                  }
              }
              KupovinaTermini.ItemsSource = termini; */
        }

      

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string sifra = RandomString(15);
            MessageBox.Show(sifra);
            
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

        }




    }
}

