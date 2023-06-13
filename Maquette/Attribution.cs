﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquette
{
    public class Attribution:Crud<Attribution>
    {
        public Attribution()
        {
        }

        public Attribution(int idMateriel, int idEnseignant, DateTime dateAttribution, string commentaire)
        {
            this.idMateriel = idMateriel;
            this.idEnseignant = idEnseignant;
            this.DateAttribution = dateAttribution;
            this.Commentaire = commentaire;
        }

        public int idMateriel { get; set; }
        public int idEnseignant { get; set; }
        public DateTime DateAttribution { get; set; }
        public string Commentaire { get; set; }

        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into ATTRIBUTION (IDMATERIEL, IDENSEIGNANT, DATE, COMMENTAIRE) VALUES({this.idMateriel},{this.idEnseignant},{this.DateAttribution},{this.Commentaire});";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Delete from ATTRIBUTION where IDMATERIEL= {this.idMateriel} and IDENSEIGNANT= {this.idEnseignant} and DATE={this.DateAttribution};";
            accesBD.SetData(requete);
        }

        public ObservableCollection<Attribution> FindAll()
        {
            ObservableCollection<Attribution> lesAttributs = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDMATERIEL, IDENSEIGNANT, DATE, COMMENTAIRE from ATTRIBUTION ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Attribution a = new Attribution(int.Parse(row["IDMATERIEL"].ToString()), int.Parse(row["IDENSEIGNANT"].ToString()),DateTime.Parse(row["DATE"].ToString()), (String)row["COMMENTAIRE"]);
                    lesAttributs.Add(a);
                }
            }
            return lesAttributs;
        }

        public ObservableCollection<Attribution> FindBySelection(string criteres)
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
