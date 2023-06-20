using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquette
{

    public class Personnel : Crud<Personnel>
    {
        /// <summary>
        /// Stocke 4 infomations :
        /// 1 entier : ID du personnel
        /// 3 string : Nom, prénom et l'adresse mail
        /// Il y a une Collection Observable
        /// </summary>
        public Personnel()
        {
        }

        //Constructeur complet
        public Personnel(int idPersonnel, string nom, string prenom, string adresseMail)
        {
            this.IdPersonnel = idPersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.AdresseMail = adresseMail;
        }
        //Constructeur sans ID
        public Personnel(string nom, string prenom, string adresseMail) : this (0, nom, prenom, adresseMail) { }


        private int idPersonnel;
         private string nom;
        private string prenom;
        private string adresseMail;
        private ObservableCollection<Attribution> lesAttributions;
        /// <summary>
        /// Obtient l'id du personel
        /// </summary>

        public int IdPersonnel
        {
            get
            {
                return this.idPersonnel;
            }

            set
            {
                this.idPersonnel = value;
            }
        }

        /// <summary>
        /// Obtient  le nom du Personnel
        /// il doit pas être vide
        /// </summary>
        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }
        /// <summary>
        /// Obtient  le prenom du Personnel
        /// il doit pas être vide
        /// </summary>
        public string Prenom
        {
            get
            {
                return this.prenom;
            }

            set
            {
                this.prenom = value;
            }
        }
        /// <summary>
        /// Obtient  l'adresse-Mail du personnel
        /// il doit pas être vide
        /// </summary>
        public string AdresseMail
        {
            get
            {
                return this.adresseMail;
            }

            set
            {
                this.adresseMail = value;
            }
        }
        /// <summary>
        /// Obtient  la liste des attriubtions du Personnel
        /// </summary>
        public ObservableCollection<Attribution> LesAttributions
        {
            get
            {
                return this.lesAttributions;
            }

            set
            {
                this.lesAttributions = value;
            }
        }
        /// <summary>
        /// créer un personnel dans la base de donnés
        /// </summary>

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into PERSONNEL (NOMPERSONNEL, PRENOMPERSONNEL, EMAILPERSONNEL)  VALUES('{this.Nom}','{this.Prenom}, '{this.AdresseMail}');";
            accesBD.SetData(requete);
        }
        /// <summary>
        ///supprime un personnel dans la base de donnés
        /// </summary>

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            foreach (Attribution attsup in this.LesAttributions)
            {
                attsup.Delete();
            }
            String requete = $"DELETE  FROM  Personnel  where IDPersonnel = {this.IdPersonnel};";
            accesBD.SetData(requete);
        }

        /// <summary>
        /// recupère la liste complète des personnels  de la base de donnés
        /// </summary>
        /// <returns> une liste avec  les donnés des  personnels </returns>

        public ObservableCollection<Personnel> FindAll()
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDPERSONNEL, NOMPERSONNEL, PRENOMPERSONNEL, EMAILPERSONNEL from Personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel e = new Personnel(int.Parse(row["IDPERSONNEL"].ToString()), (String)row["NOMPERSONNEL"], (String)row["PRENOMPERSONNEL"], (String)row["EMAILPERSONNEL"]);
                    lesPersonnels.Add(e);
                }
            }
            return lesPersonnels;
        }
        /// <summary>
        /// recupère la liste  des personnels  de la base de donnés filté 
        /// </summary>
        /// <returns> une liste avec  la ou  donnés des  personnels filté </returns>

        public ObservableCollection<Personnel> FindBySelection(string criteres)
        {
            ObservableCollection<Personnel> lesPersonnels = new ObservableCollection<Personnel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDPERSONNEL, NOMPERSONNEL, PRENOMPERSONNEL, EMAILPERSONNEL from Personnel where " + criteres + " ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel e = new Personnel(int.Parse(row["IDPERSONNEL"].ToString()), (String)row["NOMPERSONNEL"], (String)row["PRENOMPERSONNEL"], (String)row["EMAILPERSONNEL"]);
                    lesPersonnels.Add(e);
                }
            }
            return lesPersonnels;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// met à jour le personnel dans la base de données
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"UPDATE  PERSONNEL  SET  NOMPERSONNEL  = '{this.Nom}' , SET PRENOMPERSONNEL = '{this.Prenom}', SET EMAILPERSONNEL = {this.AdresseMail} where IDPersonnel = {this.IdPersonnel};";
            accesBD.SetData(requete);
        }
    }
}
