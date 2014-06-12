using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Filmovi.xaml
    /// </summary>
    public partial class Filmovi : Window
    {
        public Filmovi()
        {
            InitializeComponent();

            FilmDAO fDAO = new FilmDAO();

            this.DataContext = fDAO.getAll();

            ComboBox1.ItemsSource = fDAO.getAll();
            ComboBox2.ItemsSource = fDAO.getAll();

            PrehrambeniProduktDao pDAO = new PrehrambeniProduktDao();
            ListBox1.ItemsSource = pDAO.getAll();
            ComboBox3.ItemsSource = pDAO.getAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilmDAO fDAO = new FilmDAO();

            if (Naziv.Text == String.Empty || Sifra.Text == String.Empty)
                return;

            Film f = new Film(Naziv.Text, Convert.ToInt32(Sifra.Text));

            fDAO.create(f);

            this.DataContext = fDAO.getAll();

            ComboBox1.ItemsSource = fDAO.getAll();
            ComboBox2.ItemsSource = fDAO.getAll();


            Naziv.Clear();
            Sifra.Clear();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex != -1)
            {
                TextBox1.Text = (ComboBox1.SelectedItem as Film).Naziv;
                TextBox2.Text = Convert.ToString((ComboBox1.SelectedItem as Film).Sifra);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FilmDAO fDAO = new FilmDAO();

            if (TextBox1.Text == String.Empty || TextBox2.Text == String.Empty)
                return;

            Film f = new Film(TextBox1.Text, Convert.ToInt32(TextBox2.Text));

            fDAO.update(f);

            this.DataContext = fDAO.getAll();
            ComboBox1.ItemsSource = fDAO.getAll();
            ComboBox2.ItemsSource = fDAO.getAll();

            TextBox1.Clear();
            TextBox2.Clear();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ComboBox2.SelectedIndex != -1)
            {
                FilmDAO fDAO = new FilmDAO();

                Film f = ComboBox2.SelectedItem as Film;

                fDAO.delete(f);

                this.DataContext = fDAO.getAll();
                ComboBox1.ItemsSource = fDAO.getAll();
                ComboBox2.ItemsSource = fDAO.getAll();

            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PrehrambeniProduktDao pDAO = new PrehrambeniProduktDao();

            if (Naziv1.Text == String.Empty)
                return;

            PrehrambeniProdukt p = new PrehrambeniProdukt(Naziv1.Text, Convert.ToDouble(Cijena.Text));

            pDAO.create(p);

            ListBox1.ItemsSource = pDAO.getAll();

            ComboBox3.ItemsSource = pDAO.getAll();

            Naziv1.Clear();
            Cijena.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ComboBox3.SelectedIndex != -1)
            {
                PrehrambeniProduktDao pDAO = new PrehrambeniProduktDao();
                PrehrambeniProdukt p = ComboBox3.SelectedItem as PrehrambeniProdukt;
                pDAO.delete(p);
                ListBox1.ItemsSource = pDAO.getAll();
                ComboBox3.ItemsSource = pDAO.getAll();

            }
        }
    }
}
