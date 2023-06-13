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
        public ObservableCollection<Etudiant> LesEtudiants { get; set; }
        public ObservableCollection<Groupe> LesGroupes { get; set; }
        public ApplicationData()
        {
            Etudiant e = new Etudiant();
            Groupe g = new Groupe();
            LesEtudiants = e.FindAll();
            LesGroupes = g.FindAll();

            // pour chaque étudiant, on affecte la référence de son groupe
            foreach (Etudiant unEtud in LesEtudiants.ToList())
                unEtud.UnGroupe = LesGroupes.ToList().Find(g => g.Id == unEtud.FK_IdGroupe);

            // pour chaque groupe, on affecte toutes les références des étudiants appartenant au groupe  
            foreach (Groupe unGroupe in LesGroupes.ToList())
                unGroupe.LesEtudiants = new ObservableCollection<Etudiant>(LesEtudiants.ToList().FindAll(e => e.FK_IdGroupe == unGroupe.Id));
        }
    }
}
