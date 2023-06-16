using System;
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
            String requete = $"Insert into EST_ATTRIBUE (IDPERSONNEL, IDMATERIEL, DATEATTRIBUTION, COMMENTAIREATTRIBUTION) VALUES({this.idEnseignant},{this.idMateriel},'{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}','{this.Commentaire}');";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Delete from EST_ATTRIBUE where IDMATERIEL= {this.idMateriel} and IDPERSONNEL= {this.idEnseignant} and DATEATTRIBUTION='{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}';";
            accesBD.SetData(requete);
        }

        public ObservableCollection<Attribution> FindAll()
        {
            ObservableCollection<Attribution> lesAttributs = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDPERSONNEL, IDMATERIEL, DATEATTRIBUTION, COMMENTAIREATTRIBUTION from EST_ATTRIBUE ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Attribution a = new Attribution(int.Parse(row["IDMATERIEL"].ToString()), int.Parse(row["IDPERSONNEL"].ToString()),DateTime.Parse(row["DATEATTRIBUTION"].ToString()), (String)row["COMMENTAIREATTRIBUTION"]);
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
            DataAccess accesBD = new DataAccess();
            String requete = $"UPDATE EST_ATTRIBUE SET DATEATTRIBUTION = '{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}', COMMENTAIREATTRIBUTION = '{this.Commentaire}' where IDMATERIEL= {this.idMateriel} and IDPERSONNEL= {this.idEnseignant} and DATEATTRIBUTION='{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}';";
            accesBD.SetData(requete);
        }
    }
}
