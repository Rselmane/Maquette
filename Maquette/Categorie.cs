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
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into CATEGORIE_MATERIEL   (IDCATEGORIE,CATEGORIE_MATERIEL)  VALUES({this.IdCategorie},'{this.NomCategorie});";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE  FROM  CATEGORIE_MATERIEL where IDCATEGORIE = {this.IdCategorie};";
            accesBD.SetData(requete);
        }

        public ObservableCollection<Categorie> FindAll()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select * from CATEGORIE_MATERIEL  ;";
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
            DataAccess accesBD = new DataAccess();
            String requete = $"update  materiel SET  CATEGORIE_MATERIEL  = {this.NomCategorie}  where IDCATEGORIE = {this.IdCategorie};";
            accesBD.SetData(requete);
        }
    }
}
