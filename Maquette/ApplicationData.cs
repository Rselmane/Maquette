using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maquette
{
    internal class ApplicationData
    {
        public ObservableCollection<Materiel> LesMateriels { get; set; }
        public ObservableCollection<Categorie> LesCategories { get; set; }
        public ObservableCollection<Personnel> LesPersonnels{ get; set; }
        public ObservableCollection<Attribution> LesAttributions { get; set; }
        public ApplicationData()
         {
            Materiel e = new Materiel();
            LesMateriels = e.FindAll();
            Categorie c =new Categorie();
            LesCategories = c.FindAll();
            Attribution a = new Attribution();
            LesAttributions = a.FindAll();
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();

            
         }
        
    }

}
