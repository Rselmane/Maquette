using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquette
{
    public class Categorie : Crud<Categorie>
    {
        public Categorie()
        {
        }

        public Categorie(string nomCategorie, int idCategorie)
        {
            this.NomCategorie = nomCategorie;
            this.IdCategorie = idCategorie;
        }

        public string NomCategorie { get; set; }
        public int IdCategorie { get; set; }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Categorie> FindAll()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDCATEGORIE, NOMCATEGORIE from CATEGORIE_DE_MATERIEL ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie c = new Categorie((String)row["NOMCATEGORIE"] , int.Parse(row["IDCATEGORIE"].ToString()));
                    lesCategories.Add(c);
                }
            }
            return lesCategories;
        }

        public ObservableCollection<Categorie> FindBySelection(string criteres)
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
