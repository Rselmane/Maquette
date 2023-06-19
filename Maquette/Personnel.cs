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
        public Personnel()
        {
        }

        public Personnel(int idPersonnel, string nom, string prenom, string adresseMail)
        {
            this.IdPersonnel = idPersonnel;
            this.Nom = nom;
            this.Prenom = prenom;
            this.AdresseMail = adresseMail;
        }

        public Personnel(string nom, string prenom, string adresseMail, ObservableCollection<Attribution> lesAttributions) : this (0, nom, prenom, adresseMail) { }

        public int IdPersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }
        public ObservableCollection<Attribution> LesAttributions { get; set; }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into PERSONNEL (IDPERSONNEL, NOMPERSONNEL, PRENOMPERSONNEL, EMAILPERSONNEL)  VALUES({this.IdPersonnel}, '{this.Nom}','{this.Prenom}, '{this.AdresseMail}');";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"DELETE  FROM  Personnel  where IDPersonnel = {this.IdPersonnel};";
            accesBD.SetData(requete);
        }

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

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"UPDATE  PERSONNEL  SET  NOMPERSONNEL  = '{this.Nom}' , SET PRENOMPERSONNEL = '{this.Prenom}', SET EMAILPERSONNEL = {this.AdresseMail} where IDPersonnel = {this.IdPersonnel};";
            accesBD.SetData(requete);
        }
    }
}
