using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// <summary>
        /// Stocke 2 infomations :
        /// 1 entier : ID de la  Categorie 
        /// 1 string : nom de la categorie
        /// </summary>
        public Categorie(int idCategorie, string nomCategorie)
        {
            this.NomCategorie = nomCategorie;
            this.IdCategorie = idCategorie;
        }
        public Categorie(string nomCategorie) : this(0, nomCategorie) { }

      
        private string nomCategorie;
        private int  idCategorie;
        private ObservableCollection<Materiel> lesMateriels;

        public string NomCategorie
        {
            get
            {
                return this.nomCategorie;
            }

            set
            {
                this.nomCategorie = value;
            }
        }

        public int IdCategorie
        {
            get
            {
                return this.idCategorie;
            }

            set
            {
                this.idCategorie = value;
            }
        }

        public ObservableCollection<Materiel> LesMateriels
        {
            get
            {
                return this.lesMateriels;
            }

            set
            {
                this.lesMateriels = value;
            }
        }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into CATEGORIE_MATERIEL (NOMCATEGORIE) VALUES('{this.NomCategorie}');";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            foreach (Materiel matsup in this.LesMateriels)
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
