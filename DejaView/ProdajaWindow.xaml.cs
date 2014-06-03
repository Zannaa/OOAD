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
        public ProdajaWindow()
        {
            InitializeComponent();

            FilmDAO fdao = new FilmDAO();
            ProjekcijaDAO pdao = new ProjekcijaDAO();

            ListaFilmovaUProdaji.ItemsSource = fdao.getAll();
            ListaFilmovaZaRezervaciju.ItemsSource = fdao.getAll();

            List<Projekcija> projekcije = new List<Projekcija>();

            projekcije = pdao.getAll();
            List<string> termini = projekcije.Select(projekcija => projekcija.Pocetak.TimeOfDay.ToString()).ToList();

            KupovinaTermini.ItemsSource = termini;
            KupovinaTermini.SelectedIndex = 0;

            RezervacijaTermini.ItemsSource = termini;
            RezervacijaTermini.SelectedIndex = 0;




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
    }
}
