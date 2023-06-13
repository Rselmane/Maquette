using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquette
{
    public class Enseignant : Crud<Enseignant>
    {
        public Enseignant()
        {
        }

        public Enseignant(int idenseignant, string nom, string prenom, string adresseMail)
        {
            this.Idenseignant = idenseignant;
            this.Nom = nom;
            this.Prenom = prenom;
            this.AdresseMail = adresseMail;
        }

        public int Idenseignant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Enseignant> FindAll()
        {
            ObservableCollection<Enseignant> lesEnseignants = new ObservableCollection<Enseignant>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDENSEIGNANT,  NOMENSEIGNANT, PRENOMENSEIGNANT, EMAIL from ENSEIGNANT ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Enseignant e = new Enseignant(int.Parse(row["IDENSEIGNANT"].ToString()),(String)row["NOMENSEIGNANT"], (String)row["PRENOMENSEIGNANT"], (String)row["EMAIL"]);
                    lesEnseignants.Add(e);
                }
            }
            return lesEnseignants;
        }

        public ObservableCollection<Enseignant> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
