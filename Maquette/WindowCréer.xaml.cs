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
        public WindowCréer()
        {
            InitializeComponent();
            object obj = new object();
        }

        private void AnnulerCreation(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreerMat(object sender, RoutedEventArgs e)
        {
            ((Materiel)this.DataContext).Create();
        }

        private void CreerCat(object sender, RoutedEventArgs e)
        {
            Categorie c = new Categorie(tb_nomcate.Text);
            c.Create();
            Close();
        }

        private void CreerAtt(object sender, RoutedEventArgs e)
        {
            Attribution a = new Attribution(cb_AttPersCreer.SelectedIndex, cb_AttMatCreer.SelectedIndex, DateTime.Parse(Dp_DateAttCreer.Text), tb_AttCommCreer.Text);
            a.Create();
            Close();
        }
    }
}
