using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Maquette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>






    public partial class MainWindow : Window
    {


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
            modifAtt.ShowDialog();
        }

        private void ModifierMateriel(object sender, MouseButtonEventArgs e)
        {
            WindowModifier modifMat = new WindowModifier();
            modifMat.TabModif.SelectedIndex = 0;
            modifMat.ShowDialog();
        }

        private void ModifierCategorie(object sender, MouseButtonEventArgs e)
        {
            WindowModifier modifCat = new WindowModifier();
            modifCat.TabModif.SelectedIndex = 1;
            modifCat.ShowDialog();
        }
    }
}
