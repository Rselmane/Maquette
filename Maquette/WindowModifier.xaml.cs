﻿using System;
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
        public WindowModifier()
        {
            InitializeComponent();
        }

        private void AnnulerModification(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonSupMat_Click(object sender, RoutedEventArgs e)
        {


            Materiel m = new Materiel(tb_codebarre.Text,tb_nom.Text,tb_refConst.Text,cb_cate.SelectedIndex);
            MessageBoxResult delete = MessageBox.Show("Voulez-vous supprimer " + m.Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show("Matériel supprimé avec succès !", "Materiel", MessageBoxButton.OK,MessageBoxImage.Information) ;
                m.Delete();


            }

        }

        private void buttonModifMat_Click(object sender, RoutedEventArgs e)
        {

            Materiel m = new Materiel(tb_codebarre.Text, tb_nom.Text, tb_refConst.Text, cb_cate.SelectedIndex);
            MessageBoxResult delete = MessageBox.Show("Voulez-vous modifier  " + m.Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show("Matériel modfié  avec succès !", "Materiel", MessageBoxButton.OK, MessageBoxImage.Information);
                m.Update();


            }

        }

        private void buttonSupCat_Click(object sender, RoutedEventArgs e)
        {
             Categorie c = new Categorie(tbCateModif.Text);

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Surppimer   " + c.NomCategorie + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" Catégorie  Supprimé  avec succès !", "Categorie", MessageBoxButton.OK, MessageBoxImage.Information);
                c.Delete();


            }

        }

        private void buttonModifCat_Click(object sender, RoutedEventArgs e)
        {
            Categorie c = new Categorie(tbCateModif.Text);

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Modifier   " + c.NomCategorie + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" Catégorie  modifié  avec succès !", "Categorie", MessageBoxButton.OK, MessageBoxImage.Information);
                c.Delete();


            }

        }

        private void buttonSupAtt_Click(object sender, RoutedEventArgs e)
        {

            Attribution a = new Attribution();
        }

        private void tb_NomPers_TextChanged(object sender, TextChangedEventArgs e)
        {
            Personnel p = new Personnel(tb_NomPers.Text, tb_PrenomPers.Text, tb_MailPers.Text);

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Supprimer   " + p.Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" personnel  supprimé  avec succès !", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Delete();


            }


        }

        private void buttonModifPer_Click(object sender, RoutedEventArgs e)
        {
            Personnel p = new Personnel(tb_NomPers.Text, tb_PrenomPers.Text, tb_MailPers.Text);

            MessageBoxResult delete = MessageBox.Show("Voulez-vous Modifier   " + p.Nom + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (delete == MessageBoxResult.Yes)
            {
                MessageBox.Show(" personnel  modifié  avec succès !", "Personnel", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Update();


            }

        }
    }

        }
    

