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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FilmDAO fDAO = new FilmDAO();

            if (Naziv.Text == String.Empty || Sifra.Text == String.Empty)
                return;

            Film f = new Film(Naziv.Text, Convert.ToInt32(Sifra.Text));

            fDAO.create(f);
            
        }
    }
}
