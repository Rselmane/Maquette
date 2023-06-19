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

        public Categorie(int idCategorie, string nomCategorie)
        {
            this.NomCategorie = nomCategorie;
            this.IdCategorie = idCategorie;
        }
        public Categorie(string nomCategorie) : this(0, nomCategorie) { }

        public string NomCategorie { get; set; }
        public int IdCategorie { get; set; }
        public ObservableCollection<Materiel> LesMateriels { get; set; }
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into CATEGORIE_MATERIEL (NOMCATEGORIE) VALUES('{this.NomCategorie}');";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            Materiel m = new Materiel();
            ObservableCollection<Materiel> matListe = m.FindBySelection($"IDCATEGORIE = {this.IdCategorie}");
            foreach (Materiel matsup in matListe)
            {
                matsup.Delete();
            }
            String requete = $"DELETE FROM CATEGORIE_MATERIEL where IDCATEGORIE = {this.IdCategorie};";
            accesBD.SetData(requete);
        }

        public ObservableCollection<Categorie> FindAll()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select * from CATEGORIE_MATERIEL;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie c = new Categorie(int.Parse(row["IDCATEGORIE"].ToString()),(String)row["NOMCATEGORIE"]);
                    lesCategories.Add(c);
                }
            }
            return lesCategories;
        }

        public ObservableCollection<Categorie> FindBySelection(string criteres)
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            DataAccess accesBD = new DataAccess();
            String requete = "select * from CATEGORIE_MATERIEL where " + criteres + " ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Categorie c = new Categorie(int.Parse(row["IDCATEGORIE"].ToString()), (String)row["NOMCATEGORIE"]);
                    lesCategories.Add(c);
                }
            }
            return lesCategories;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"update CATEGORIE_MATERIEL SET NOMCATEGORIE = '{this.NomCategorie}' where IDCATEGORIE = {this.IdCategorie};";
            accesBD.SetData(requete);
        }

        public override string ToString()
        {
            return this.NomCategorie;
        }
    }
}
