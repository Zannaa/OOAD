using DAO;
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
    /// Interaction logic for ObracunWindow.xaml
    /// </summary>
    public partial class ObracunWindow : Window
    {
        private List<ProdavacKarata> kprodavaci = new List<ProdavacKarata>();
        private List<ProdavacHrane> hprodavaci = new List<ProdavacHrane>();
        private List<FinansijskiMenadzer> racunovodje = new List<FinansijskiMenadzer>();
        public ObracunWindow()
        {
            InitializeComponent();
            ProdavacKarataDAO kdao = new ProdavacKarataDAO();
            kprodavaci = kdao.getAll();
            ProdavacHraneDAO hdao = new ProdavacHraneDAO();
            hprodavaci = hdao.getAll();
            FinansijskiMenadzerDAO fdao = new FinansijskiMenadzerDAO();
            racunovodje = fdao.getAll();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Lista != null)
            {
                Lista.Items.Clear();
            }

            foreach (ProdavacKarata p in kprodavaci)
            {
                if (p.Ime.ToLower().Contains(TextBox1.Text) || p.Prezime.ToLower().Contains(TextBox1.Text)
                    || p.Ime.Contains(TextBox1.Text) || p.Prezime.Contains(TextBox1.Text))
                    Lista.Items.Add(p);

            }

            foreach (ProdavacHrane p in hprodavaci)
            {
                if (p.Ime.ToLower().Contains(TextBox1.Text) || p.Prezime.ToLower().Contains(TextBox1.Text)
                    || p.Ime.Contains(TextBox1.Text) || p.Prezime.Contains(TextBox1.Text))
                    Lista.Items.Add(p);

            }

            foreach (FinansijskiMenadzer p in racunovodje)
            {
                if (p.Ime.ToLower().Contains(TextBox1.Text) || p.Prezime.ToLower().Contains(TextBox1.Text)
                    || p.Ime.Contains(TextBox1.Text) || p.Prezime.Contains(TextBox1.Text))
                    Lista.Items.Add(p);

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Lista.SelectedIndex != -1)
            {
                double plata = ListBox2.Items.Count * 8 * (Lista.SelectedItem as Uposlenik).Koeficijent;
                MessageBox.Show("Plata za evidentiranih " + ListBox2.Items.Count + " dana iznosi: " + plata + " KM.");
            }
        }

        RadnaEvidencijaDAO rdao = new RadnaEvidencijaDAO();
        RadnaEvidencija evidencija = new RadnaEvidencija();
        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            evidencija = rdao.getByEmpId((Lista.SelectedItem as Uposlenik).Id_uposlenika);
            ListBox2.ItemsSource = evidencija.Rad;

            if (Lista.SelectedItem is ProdavacKarata)
            {
                ProdavacKarataDAO kDAO = new ProdavacKarataDAO();
                List<ProdavacKarata> lista = new List<ProdavacKarata>();
                lista.Add(kDAO.getById((Lista.SelectedItem as ProdavacKarata).Id_uposlenika));
                Grid1.DataContext = lista;

            }

            if (Lista.SelectedItem is ProdavacHrane)
            {
                ProdavacHraneDAO hDAO = new ProdavacHraneDAO();
                List<ProdavacHrane> lista = new List<ProdavacHrane>();
                lista.Add(hDAO.getById((Lista.SelectedItem as ProdavacHrane).Id_uposlenika));
                Grid1.DataContext = lista;
            }

            if (Lista.SelectedItem is FinansijskiMenadzer)
            {
                FinansijskiMenadzerDAO mDAO = new FinansijskiMenadzerDAO();
                List<FinansijskiMenadzer> lista = new List<FinansijskiMenadzer>();
                lista.Add(mDAO.getById((Lista.SelectedItem as FinansijskiMenadzer).Id_uposlenika));
                Grid1.DataContext = lista;
            }

        }
    }
}
