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
            // récupération de tous les matériels de la base de donnée
            Materiel e = new Materiel();
            LesMateriels = e.FindAll();
            // récupération de toutes les catégories de la base de donnée
            Categorie c =new Categorie();
            LesCategories = c.FindAll();
            // récupération de toutes les attributions de la base de donnée
            Attribution a = new Attribution();
            LesAttributions = a.FindAll();
            // récupération de tous le personnels de la base de donnée
            Personnel p = new Personnel();
            LesPersonnels = p.FindAll();

            // chaque personnel récupère ses attributions
            foreach (Personnel unPerso in LesPersonnels.ToList())
            {
                unPerso.LesAttributions = new ObservableCollection<Attribution>(
                    LesAttributions.ToList().FindAll(a => a.IdPersonnel == unPerso.IdPersonnel));
            }
            // chaque matériel récupère ses attributions
            foreach (Materiel unMater in LesMateriels.ToList())
            {
                unMater.LesAttributions = new ObservableCollection<Attribution>(
                    LesAttributions.ToList().FindAll(a => a.IdMateriel == unMater.IdMateriel));
            }

            
            foreach (Attribution uneAttrib in LesAttributions.ToList())
            {
                uneAttrib.MaterielAttribution = LesMateriels.ToList().Find(m => m.IdMateriel == uneAttrib.IdMateriel); // chaque attribution récupère le matériel auquel il est lié
                uneAttrib.PersonnelAttribution = LesPersonnels.ToList().Find(m => m.IdPersonnel == uneAttrib.IdPersonnel); // chaque attribution récupère le personnel auquel il est lié
            }
            
            // pour chaque matériel, on affecte la référence de sa caterorie
            foreach (Materiel unMater in LesMateriels.ToList())
            {
                unMater.CategorieMat = LesCategories.ToList().Find(c => c.IdCategorie == unMater.FK_IdCategorie);
            }

            // pour chaque categrie, on affecte toutes les références des catégories appartenant au groupe
            foreach (Categorie uneCate in LesCategories.ToList())
            {
                uneCate.LesMateriels = new ObservableCollection<Materiel>(
                    LesMateriels.ToList().FindAll(m => m.FK_IdCategorie == uneCate.IdCategorie));
            }


        }
        
    }

}
