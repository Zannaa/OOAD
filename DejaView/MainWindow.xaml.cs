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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Models;
using DAL;
using DAO;
using DAO.Interfaces;


namespace DejaView
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string user = null;
        private string pass = null;
        private string sesija = null;

        public MainWindow()
        {
            InitializeComponent();
        }


        /*private void Button_Click(object sender, RoutedEventArgs e)
                {   
                    MessageBox.Show("Test"); }

                   /* user=text1.Text;
                    pass = text2.Password;

                    if (r1.IsChecked==true) { 
            
                     ProdavacKarata p=new ProdavacKarata() ;
                    ProdavacKarataDAO d =new ProdavacKarataDAO() ;
                    p = d.getById(Convert.ToInt32(user));
                    if (p.Jmbg == pass && p != null) sesija = "logovan";
                    ProdajaWindow w = new ProdajaWindow();
                    w.Show();
            
                    }
                   /* else if    (r2.IsChecked == true) {
                        ProdavacHrane p = new ProdavacHrane();
                        ProdavacHraneDAO d = new ProdavacHraneDAO();
                        p = d.getById(Convert.ToInt32(user));
                        if (p.Jmbg == pass && p != null) sesija = "logovan";
                    }
                     else if    (r2.IsChecked == true) {
                         Menadzer p = new Menadzer();
                         MenadzerDAO d = new MenadzerDAO();
                         p = d.getById(Convert.ToInt32(user));
                         if (p.Jmbg == pass && p != null) sesija = "logovan";
                     }
                     else {
           
                         FinansijskiMenadzer p = new FinansijskiMenadzer();
                         FinansijskiMenadzerDAO d = new FinansijskiMenadzerDAO();
                         p = d.getById(Convert.ToInt32(user));
                         if (p.Jmbg == pass && p != null) sesija = "logovan";
                     }

                    if (sesija == "logovan")
                    {
                        sesija = null;
                    }
                    //   azrinprozor.Show() ;}
                    else
                    {
                       MainWindow m = new MainWindow();
                        m.Show();  
            
                    }
                }*/



        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (text1.Text == " " || text2.Password == " ") poruka.Text = "Niste unijeli sva polja!";


            else
            {
                user = text1.Text;
                pass = text2.Password;

                if (r1.IsChecked == true)
                {

                    ProdavacKarata p = new ProdavacKarata();
                    ProdavacKarataDAO d = new ProdavacKarataDAO();
                    p = d.getById(Convert.ToInt32(user));
                    //  if (p == null) MessageBox.Show("Ne postoji korisnik!");
                    if (p.Jmbg == pass && p != null) sesija = "logovan";
                    ProdajaWindow w = new ProdajaWindow(Convert.ToInt32(user));
                    w.Show();


                }

                else if (r2.IsChecked == true)
                {
                    ProdavacHrane p = new ProdavacHrane();
                    ProdavacHraneDAO d = new ProdavacHraneDAO();
                    p = d.getById(Convert.ToInt32(user));
                    if (p.Jmbg == pass && p != null) sesija = "logovan";
                    ProdajaHrane prodaja = new ProdajaHrane(Convert.ToInt32(user));
                    prodaja.Show();
                }

                else if (r3.IsChecked == true)
                {
                    FinansijskiMenadzer p = new FinansijskiMenadzer();
                    FinansijskiMenadzerDAO d = new FinansijskiMenadzerDAO();
                    p = d.getById(Convert.ToInt32(user));
                    if (p.Jmbg == pass && p != null) sesija = "logovan";



                }
                else if (r4.IsChecked == true)
                {
                    Menadzer p = new Menadzer();
                    MenadzerDAO d = new MenadzerDAO();
                    p = d.getById(Convert.ToInt32(user));
                    if (p.Jmbg == pass && p != null) sesija = "logovan";



                }

                else
                {
                    MainWindow m = new MainWindow();
                    m.Show();

                }
            }
        }


    }
}
