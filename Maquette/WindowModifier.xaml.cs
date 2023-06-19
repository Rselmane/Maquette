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

namespace Maquette
{
    /// <summary>
    /// Logique d'interaction pour WindowModifier.xaml
    /// </summary>
    public partial class WindowModifier : Window
    {

        public WindowModifier(Object p)
        {
            this.DataContext = p;
            InitializeComponent();
        }

        private void AnnulerModification(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonSupMat_Click(object sender, RoutedEventArgs e)
        {


          
            MessageBoxResult delete = MessageBox.Show("Voulez-vous supprimer " + ((Materiel)this.DataContext).Nom  + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show("Matériel supprimé avec succès !", "Materiel", MessageBoxButton.OK,MessageBoxImage.Information) ;
                ((Materiel)this.DataContext).Delete();


            }

        }

        private void buttonModifMat_Click(object sender, RoutedEventArgs e)
        {
          


            MessageBoxResult delete = MessageBox.Show("Voulez-vous modifier  " + ((Materiel)this.DataContext).Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                ((Materiel)this.DataContext).Update();
                MessageBox.Show("Matériel modfié  avec succès !", "Materiel", MessageBoxButton.OK, MessageBoxImage.Information);
                


            }

        }

        private void buttonSupCat_Click(object sender, RoutedEventArgs e)
        {
             

              MessageBoxResult delete = MessageBox.Show("Voulez-vous Surppimer   " + ((Categorie)this.DataContext).NomCategorie + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" Catégorie  Supprimé  avec succès !", "Categorie", MessageBoxButton.OK, MessageBoxImage.Information);
                ((Categorie)this.DataContext).Delete();


            }

        }

        private void buttonModifCat_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Modifier   " + ((Attribution)this.DataContext).NomCategorie + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" Catégorie  modifié  avec succès !", "Categorie", MessageBoxButton.OK, MessageBoxImage.Information);
                ((Categorie)this.DataContext).Delete();


            }

        }

        private void buttonSupAtt_Click(object sender, RoutedEventArgs e)
        {

           
                MessageBoxResult delete = MessageBox.Show("Voulez-vous Modifier   " + ((Attribution)this.DataContext).MaterielAttribution.Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" Catégorie  modifié  avec succès !", "Categorie", MessageBoxButton.OK, MessageBoxImage.Information);
                ((Categorie)this.DataContext).Delete();


            }
        }

        private void tb_NomPers_TextChanged(object sender, TextChangedEventArgs e)
        {
         /*   Personnel p = new Personnel(idperso, tb_NomPers.Text, tb_PrenomPers.Text, tb_MailPers.Text);

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Supprimer   " + p.Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" personnel  supprimé  avec succès !", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Delete();


            }
         */

        }

        private void buttonModifPer_Click(object sender, RoutedEventArgs e)
        {
   

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Modifier   " + ((Personnel)this.DataContext).Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" personnel  modifié  avec succès !", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                ((Categorie)this.DataContext).Update();


            }

        }
    }

        }
    

