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

        /// <summary>
        /// Stocke 4 infomations :
        /// 2 entier : ID du personnel , Id du materiel
        /// 1 string : Commentaire
        /// 1 dateTime : La Date de l'attribtion
        /// </summary>
        public Attribution(int idPersonnel, int idMateriel, DateTime dateAttribution, string commentaire)
        {
            DateAttribution = dateAttribution;
            Commentaire = commentaire;
            IdMateriel = idMateriel;
            IdPersonnel = idPersonnel;
        }

        private DateTime dateAttribution;
        private string commentaire;
        private int idMateriel;
        private Materiel materielAttribution;
        private int idPersonnel;
        private Personnel personnelAttribution;
        /// <summary>
        /// Obtient ou définit la DateAttribution –
        /// Elle doit être une date valide
        /// </summary>

        public DateTime DateAttribution
        {
            get
            {
                return this.dateAttribution;
            }

            set
            {
                this.dateAttribution = value;
            }
        }
        /// <summary>
        /// Obtient ou définit le commentaire –
        /// Elle doit pas être vide
        /// </summary>
        public string Commentaire
        {
            get
            {
                return this.commentaire;
            }

            set
            {
                this.commentaire = value;
            }
        }
        /// <summary>
        /// Obtient ou définit l'id du materiel –
        /// </summary>
        public int IdMateriel
        {
            get
            {
                return this.idMateriel;
            }

            set
            {
                this.idMateriel = value;
            }
        }
        /// <summary>
        /// Obtient  la liste des Materiel pour les Attributions –
        /// </summary>
        public Materiel MaterielAttribution
        {
            get
            {
                return this.materielAttribution;
            }

            set
            {
                this.materielAttribution = value;
            }
        }
        /// <summary>
        /// Obtient  l'id du Personnel
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
        /// Obtient  les Attributions des Personnels
        /// </summary>
        public Personnel PersonnelAttribution
        {
            get
            {
                return this.personnelAttribution;
            }

            set
            {
                this.personnelAttribution = value;
            }
        }

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
            ObservableCollection<Attribution> lesAttributs = new ObservableCollection<Attribution>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDPERSONNEL, IDMATERIEL, DATEATTRIBUTION, COMMENTAIREATTRIBUTION from EST_ATTRIBUE where " + criteres + " ;";
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
