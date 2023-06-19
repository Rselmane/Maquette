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
            Close();
        }

        private void ModifierAttribution(object sender, MouseButtonEventArgs e)
        {
           
            Attribution a = (Attribution)(AttributionAff.SelectedItem);
            if (a != null)

            {
              WindowModifier modifAtt = new WindowModifier(a);
                int valeurvalid = 2;
                modifAtt.TabModif.SelectedIndex = valeurvalid;
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
                modifMat.cb_cate.DataContext = this.DataContext;
                modifMat.cb_cate.SelectedItem = m.CategorieMat;
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
        /*public void Refresh()
        {
            CateMateriel.Items.Refresh();
            MaterielList.Items.Refresh();
            ListPers.Items.Refresh();
            AttributionAff.Items.Refresh();
        }*/
    }
}
