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
            WindowCréer creation = new WindowCréer(this);
            creation.ShowDialog();
        }

        private void ModifierAttribution(object sender, MouseButtonEventArgs e)
        {
           
            Attribution a = (Attribution)(AttributionAff.SelectedItem);
            if (a != null)

            {
              WindowModifier modifAtt = new WindowModifier(a);
                int valeurvalid = 2;
                int idAttP = a.IdPersonnel;
                DateTime idAttD = a.DateAttribution;
                int idAttM = a.IdMateriel;
                modifAtt.TabModif.SelectedIndex = valeurvalid;
                modifAtt.Owner = this;
                modifAtt.ContenuEnseignant.Content = a.PersonnelAttribution.Nom + " " + a.PersonnelAttribution.Prenom;
                modifAtt.ContenuMateriel.Content = a.MaterielAttribution.Nom;
                modifAtt.tb_commentaire.Text = a.Commentaire;
                modifAtt.dt_atribution.Text = ((DateTime)a.DateAttribution).ToString();
                bool[] tabIndex = new bool[4];
                tabIndex[valeurvalid] = true;

                for (int i = 0; i < tabIndex.Length; i++)
                {
                    TabItem tabItem = modifAtt.TabModif.Items[i] as TabItem;
                    tabItem.IsEnabled = tabIndex[i];
                }
                modifAtt.ShowDialog();
            }
        }

        private void ModifierMateriel(object sender, MouseButtonEventArgs e)
        {
            Materiel m = (Materiel)(MaterielList.SelectedItem);
            if (m != null)
            {
                WindowModifier modifMat = new WindowModifier(m);
                int valeurvalid = 0;
                modifMat.TabModif.SelectedIndex = valeurvalid;
                modifMat.cb_cate.SelectedIndex = m.CategorieMat.IdCategorie - 1;
                modifMat.tb_codebarre.Text = m.CodeBarre;
                modifMat.tb_refConst.Text = m.ReferenceConstr;
                modifMat.tb_nom.Text = m.Nom;
                modifMat.Owner = this;

                bool[] tabIndex = new bool[4];
                tabIndex[valeurvalid] = true;

                for (int i = 0; i < tabIndex.Length; i++)
                {
                    TabItem tabItem = modifMat.TabModif.Items[i] as TabItem;
                    tabItem.IsEnabled = tabIndex[i];
                }
                modifMat.ShowDialog();
            }
        }

        private void ModifierCategorie(object sender, MouseButtonEventArgs e)
        {
            Categorie a = (Categorie)(CateMateriel.SelectedItem);
            if (a != null)
            {
                WindowModifier modifCat = new WindowModifier(a);
                int valeurvalid = 1;
                modifCat.TabModif.SelectedIndex = valeurvalid;
                modifCat.Owner = this;
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

        private void ModifPersonnel(object sender, MouseButtonEventArgs e)
        {
            Personnel p = (Personnel)(ListPers.SelectedItem);
            if (p != null)
            {
                WindowModifier modifPers = new WindowModifier(p);
                int valeurvalid = 3;
                modifPers.TabModif.SelectedIndex = valeurvalid;
                bool[] tabIndex = new bool[4];
                tabIndex[valeurvalid] = true;

                for (int i = 0; i < tabIndex.Length; i++)
                {
                    TabItem tabItem = modifPers.TabModif.Items[i] as TabItem;
                    tabItem.IsEnabled = tabIndex[i];
                }
           
                modifPers.ShowDialog();
            }
        }
        private void Refresh()
        {

        }
    }
}
