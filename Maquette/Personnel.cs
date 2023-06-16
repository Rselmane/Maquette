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

        public int IdPersonnel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }

        public void Create()
        {
            throw new NotImplementedException();
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
            String requete = "select IDPersonnel, NOMPERSONNEL,  EMAILPERSONNEL , PRENOMPERSONNEL from Personnel ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Personnel e = new Personnel(int.Parse(row["IDPersonnel"].ToString()),(String)row["NOMPersonnel"], (String)row["EMAILPERSONNEL"], (String)row["PRENOMPERSONNEL"]);
                    lesPersonnels.Add(e);
                }
            }
            return lesPersonnels;
        }

        public ObservableCollection<Personnel> FindBySelection(string criteres)
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
            String requete = $"update  PERSONNEL  SET  NOMPERSONNEL  = '{this.Nom}' , SET EMAILPERSONNEL = {this.AdresseMail}, SET PRENOMPERSONNEL = '{this.Prenom}'  where IDPersonnel = {this.IdPersonnel};";
            accesBD.SetData(requete);
        }
    }
}
