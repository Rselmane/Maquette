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

        public Attribution(int idPersonnel, int idMateriel, DateTime dateAttribution)
        {
            IdPersonnel = idPersonnel;
            IdMateriel = idMateriel;
            DateAttribution = dateAttribution;
        }

        public Attribution(int idPersonnel, int idMateriel, DateTime dateAttribution, string commentaire) : this(idPersonnel, idMateriel, dateAttribution)
        {
            Commentaire = commentaire;
        }

        public DateTime DateAttribution { get; set; }
        public string Commentaire { get; set; }
        public int IdMateriel { get; set; }
        public Materiel MaterielAttribution { get; set; }
        public int IdPersonnel { get; set; }
        public Personnel PersonnelAttribution { get; set; }
        public void Create()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Insert into EST_ATTRIBUE (IDPERSONNEL, IDMATERIEL, DATEATTRIBUTION, COMMENTAIREATTRIBUTION) VALUES({this.IdPersonnel},{this.IdMateriel},'{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}','{this.Commentaire}');";
            accesBD.SetData(requete);
        }

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"Delete from EST_ATTRIBUE where IDMATERIEL= {this.IdMateriel} and IDPERSONNEL= {this.IdPersonnel} and DATEATTRIBUTION='{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}';";
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
                    Attribution a = new Attribution(int.Parse(row["IDPERSONNEL"].ToString()), int.Parse(row["IDMATERIEL"].ToString()), DateTime.Parse(row["DATEATTRIBUTION"].ToString()), (String)row["COMMENTAIREATTRIBUTION"]);
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
            String requete = $"UPDATE EST_ATTRIBUE SET DATEATTRIBUTION = '{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}', COMMENTAIREATTRIBUTION = '{this.Commentaire}' where IDMATERIEL= {this.IdMateriel} and IDPERSONNEL= {this.IdPersonnel} and DATEATTRIBUTION='{this.DateAttribution.Year}-{this.DateAttribution.Month}-{this.DateAttribution.Day}';";
            accesBD.SetData(requete);
        }
    }
}
