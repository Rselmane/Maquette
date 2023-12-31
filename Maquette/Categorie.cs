﻿using System;
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
        /// <summary>
        /// Obtient  le nom de la categorie
        /// il doit pas être vide
        /// </summary>
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
        /// <summary>
        /// Obtient l'id de la categorie
        /// </summary>

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
        /// <summary>
        /// Obtient  la liste des Materiaux 
        /// </summary>
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
        /// <summary>
        ///créer la catégorie dans la base de données
        /// </summary>
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into CATEGORIE_MATERIEL (NOMCATEGORIE) VALUES('{this.NomCategorie}');";
            accesBD.SetData(requete);
        }
        /// <summary>
        ///créer la catégorie dans la base de données
        /// </summary>

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
        /// <summary>
        /// recupère la liste  des  categories   de la base de donnés filtrée 
        /// </summary>
        /// <returns> une liste avec  la ou  donnés des  personnels filtré </returns>
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
        /// <summary>
        /// recupère la liste  des categories  de la base de donnés filtré 
        /// </summary>
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
