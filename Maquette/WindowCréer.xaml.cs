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

            if (String.IsNullOrEmpty(tb_CodeBarreCreer.Text) || String.IsNullOrEmpty(tb_NomCreer.Text) || string.IsNullOrEmpty(tb_RefConstructeurCreer.Text))
            {
                MessageBox.Show("Merci de remplir lee champs obligatoire ", "Attribution", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Materiel m = new Materiel(tb_CodeBarreCreer.Text, tb_NomCreer.Text, tb_RefConstructeurCreer.Text, ((Categorie)CategorieMat.SelectedItem).IdCategorie);
                m.Create();
                MessageBox.Show("Matériel créer avec succès", "Attribution", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void CreerCat(object sender, RoutedEventArgs e)
        {
         
            if (String.IsNullOrEmpty(tb_nomcate.Text))
            {
                MessageBox.Show("Merci de remplir les champs obligatoire ", "Attribution", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Categorie c = new Categorie(tb_nomcate.Text);
                c.Create();
                MessageBox.Show("Categorie créer avec succès", "Attribution", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void CreerAtt(object sender, RoutedEventArgs e)
        {
            if(cb_AttPersCreer.SelectedIndex == null ||cb_AttMatCreer.SelectedIndex == null)
            {
                MessageBox.Show("Veuillez selectioner un matériel ou  personne existante ", "Attribution", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (String.IsNullOrEmpty(tb_AttCommCreer.Text) || String.IsNullOrEmpty(Dp_DateAttCreer.Text))
            {
                MessageBox.Show("Merci de remplir les champs obligatoires ", "Attribution", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Attribution a = new Attribution(((Personnel)cb_AttPersCreer.SelectedItem).IdPersonnel, ((Materiel)cb_AttMatCreer.SelectedItem).IdMateriel, DateTime.Parse(Dp_DateAttCreer.Text), tb_AttCommCreer.Text);
                a.Create();
                MessageBox.Show("Attribution créer avec succès", "Attribution", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }

        }

        private void CreerPers(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NomPersCreer.Text) || String.IsNullOrEmpty(PrenomPersCreer.Text) || String.IsNullOrEmpty(MailPersCreer.Text))
            {
                MessageBox.Show("Merci de remplir les champs obligatoires ", "Personnels", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
              
           Personnel p = new Personnel(NomPersCreer.Text, PrenomPersCreer.Text, MailPersCreer.Text);

                p.Create();
                MessageBox.Show("Personnel créer avec succès", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void FermetureFenetreCreation(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow fenPrinc = new MainWindow();
            fenPrinc.Show();
        }
    }
}
