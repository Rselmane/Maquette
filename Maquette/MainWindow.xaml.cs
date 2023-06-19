using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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

namespace Maquette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>






    public partial class MainWindow : Window
    {
        public ObservableCollection<Personnel> LesPersonnels { get; set; }

        public MainWindow()
        {
            InitializeComponent();


    }

        private void ClickAjouter(object sender, RoutedEventArgs e)
        {
            WindowCréer creation = new WindowCréer();
            creation.ShowDialog();
        }

        private void ModifierAttribution(object sender, MouseButtonEventArgs e)
        {
            WindowModifier modifAtt = new WindowModifier();
            modifAtt.TabModif.SelectedIndex = 2;
            Attribution a = (Attribution)(AttributionAff.SelectedItem);
            modifAtt.Owner = this;
            modifAtt.ContenuEnseignant.Content = a.PersonnelAttribution.Nom + " " + a.PersonnelAttribution.Prenom;
            modifAtt.ContenuMateriel.Content = a.MaterielAttribution.Nom;
            modifAtt.tb_commentaire.Text = a.Commentaire;
            modifAtt.dt_atribution.Text = ((DateTime)a.DateAttribution).ToString();

            int valeurvalid = 2;
            bool[] tabIndex = new bool[4];
            tabIndex[valeurvalid] = true;

            for(int i=0; i<tabIndex.Length; i++)
            {
                TabItem tabItem = modifAtt.TabModif.Items[i] as TabItem;
                tabItem.IsEnabled = tabIndex[i];
            }





            modifAtt.ShowDialog();
        }

        private void ModifierMateriel(object sender, MouseButtonEventArgs e)
        {
            WindowModifier modifMat = new WindowModifier();
            Materiel m = (Materiel)(MaterielList.SelectedItem);
            modifMat.TabModif.SelectedIndex = 0;
            modifMat.cb_cate.SelectedIndex = m.CategorieMat.IdCategorie -1;
            modifMat.tb_codebarre.Text = m.CodeBarre;
            modifMat.tb_refConst.Text = m.ReferenceConstr;
            modifMat.tb_nom.Text = m.Nom;
            modifMat.Owner = this;

            int valeurvalid = 0;
            bool[] tabIndex = new bool[4];
            tabIndex[valeurvalid] = true;

            for (int i = 0; i < tabIndex.Length; i++)
            {
                TabItem tabItem = modifMat.TabModif.Items[i] as TabItem;
                tabItem.IsEnabled = tabIndex[i];
            }





            modifMat.ShowDialog();
        }

        private void ModifierCategorie(object sender, MouseButtonEventArgs e)
        {
            WindowModifier modifCat = new WindowModifier();
            modifCat.TabModif.SelectedIndex = 1;
            Categorie a = (Categorie)(CateMateriel.SelectedItem);
            modifCat.Owner = this;
            modifCat.tbCateModif.Text = a.NomCategorie;
            int valeurvalid = 1;
            bool[] tabIndex = new bool[4];
            tabIndex[valeurvalid] = true;

            for (int i = 0; i < tabIndex.Length; i++)
            {
                TabItem tabItem = modifCat.TabModif.Items[i] as TabItem;
                tabItem.IsEnabled = tabIndex[i];
            }

            modifCat.ShowDialog();

        }
    }
}
