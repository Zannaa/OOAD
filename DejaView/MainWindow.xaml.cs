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
    {    private string user=null;
        private string pass=null;
        private string sesija=null ;

        public MainWindow()
        {
           // InitializeComponent();
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {  
            /*user=text1.Text;
            pass=text2.Text;

            if (r1.IsChecked==true) { 
            
             ProdavacKarata p=new ProdavacKarata() ;
            ProdavacKarataDAO d =new ProdavacKarataDAO() ;
            p = d.getById(Convert.ToInt32(user));
            if (p.Jmbg == pass && p != null) sesija = "logovan";

            
            }
            else if    (r2.IsChecked == true) {
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
            {*/
               MainWindow m = new MainWindow();
                m.Show(); 
            
           // }
            

        }
    }
}
