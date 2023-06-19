using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Maquette
{
    /// <summary>
    /// Logique d'interaction pour WindowCréer.xaml
    /// </summary>
    public partial class WindowCréer : Window
    {
        public WindowCréer(Window owner)
        {
            
            this.DataContext = owner.DataContext;
            InitializeComponent();
        }

        private void AnnulerCreation(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreerMat(object sender, RoutedEventArgs e)
        {
            Materiel m = new Materiel(tb_CodeBarreCreer.Text, tb_NomCreer.Text, tb_RefConstructeurCreer.Text, ((Categorie)CategorieMat.SelectedItem).IdCategorie);
            m.Create();
            Close();
        }

        private void CreerCat(object sender, RoutedEventArgs e)
        {
            Categorie c = new Categorie(tb_nomcate.Text);
            c.Create();
            Close();
        }

        private void CreerAtt(object sender, RoutedEventArgs e)
        {
            Attribution a = new Attribution(((Personnel)cb_AttPersCreer.SelectedItem).IdPersonnel, ((Materiel)cb_AttMatCreer.SelectedItem).IdMateriel, DateTime.Parse(Dp_DateAttCreer.Text), tb_AttCommCreer.Text);
            a.Create();
            Close();
        }

        private void CreerPers(object sender, RoutedEventArgs e)
        {
            Personnel p = new Personnel(NomPersCreer.Text, PrenomPersCreer.Text, MailPersCreer.Text);
            p.Create();
            Close();
        }

        private void FermetureFenetreCreation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow fenPrinc = new MainWindow();
            fenPrinc.Show();
        }
    }
}
