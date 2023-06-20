using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Maquette
{
    public class Materiel : Crud<Materiel>
    {
        public Materiel()
        {
        }
        /// <summary>
        /// Stocke 5 infomations :
        /// 2 entier : ID du personnel , Id de la Categorie
        /// 3 string : Nom, Reference Constructeur et le code barre
        /// </summary>
        public Materiel(int idMateriel, string codeBarre, string nom, string referenceConstr, int fK_IdCategorie)
        {
            IdMateriel = idMateriel;
            CodeBarre = codeBarre;
            Nom = nom;
            ReferenceConstr = referenceConstr;
            FK_IdCategorie = fK_IdCategorie;
        }

        public Materiel(string codeBarre, string nom, string referenceConstr, int fK_IdCategorie) : this(0, codeBarre, nom, referenceConstr, fK_IdCategorie) {  }

        private int idMateriel;
        private string codeBarre;
        private string nom;
        private string referenceConstr;
        private int fK_IdCategorie;
        private ObservableCollection<Attribution> lesAttributions;
        private Categorie categorieMat;
        /// <summary>
        /// Obtient l'id du materiel
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
        /// Obtient  le code Barre  du Materiel
        /// il doit pas être vide
        /// </summary>
        public string CodeBarre
        {
            get
            {
                return this.codeBarre;
            }

            set
            {
                this.codeBarre = value;
            }
        }
        /// <summary>
        /// Obtient  le nom du Materiel
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
        /// Obtient  la Reference Constructeur du materiel
        /// il doit pas être vide
        /// </summary>
        public string ReferenceConstr
        {
            get
            {
                return this.referenceConstr;
            }

            set
            {
                this.referenceConstr = value;
            }
        }
        /// <summary>
        /// Obtient  l'id de la categori
        /// </summary>
        public int FK_IdCategorie
        {
            get
            {
                return this.fK_IdCategorie;
            }

            set
            {
                this.fK_IdCategorie = value;
            }
        }
        /// <summary>
        /// Obtient  la liste des attriubtions des categories
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
        /// Obtient  la Categorie des materiaux
        /// </summary>
        public Categorie CategorieMat
        {
            get
            {
                return this.categorieMat;
            }

            set
            {
                this.categorieMat = value;
            }
        }
        /// <summary>
        /// Creer un Materiel dans la base de donnéss
        /// </summary>
        public void Create()
        {

            DataAccess accesBD = new DataAccess();
      
            String requete = $"Insert into MATERIEL (IDCATEGORIE, NOMMATERIEL,REFERENCECONSTRUCTEURMATERIEL, CODEBARREINVENTAIRE)  VALUES({ this.FK_IdCategorie},'{this.Nom}','{this.ReferenceConstr}','{this.CodeBarre}');";
            accesBD.SetData(requete);
        }
        /// <summary>
        /// Supprime un materiel de la base de donnés
        /// </summary>

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
            foreach(Attribution attsup in this.LesAttributions)
            {
                attsup.Delete();
            }
            String requete = $"DELETE  FROM  materiel where IDMATERIEL = {this.IdMateriel};";
            accesBD.SetData(requete);

        }
        /// <summary>
        /// recupère la liste complète des matériaux de la base de donnés
        /// </summary>
        /// <returns> une liste avec  les donnés des matériaux</returns>
        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select IDMATERIEL,CODEBARREINVENTAIRE, NOMMATERIEL,REFERENCECONSTRUCTEURMATERIEL,IDCATEGORIE  from MATERIEL ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["IDMATERIEL"].ToString()), (String)row["CODEBARREINVENTAIRE"], (String)row["NOMMATERIEL"], (String)row["REFERENCECONSTRUCTEURMATERIEL"], int.Parse(row["IDCATEGORIE"].ToString()));
                    lesMateriels.Add(m);
                }

            }
            return lesMateriels;
        }
        /// <summary>
        /// recupère la liste  des matériaux de la base de donnés à partir d'un critère
        /// </summary>
        /// <returns> une liste avec avec le ou les materiels corrspondants </returns>
        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            ObservableCollection<Materiel> leMateriel = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = $"select * from materiel where " + criteres + " ;";
            DataTable datas = accesBD.GetData(requete);

            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["IDMATERIEL"].ToString()), (String)row["CODEBARREINVENTAIRE"], (String)row["NOMMATERIEL"], (String)row["REFERENCECONSTRUCTEURMATERIEL"], int.Parse(row["IDCATEGORIE"].ToString()));
                    leMateriel.Add(m);
                }
            }
            return leMateriel;

        }

        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// met à jour dans la base donné un matériel
        /// </summary>
        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"update  materiel SET  IDCATEGORIE  = {this.FK_IdCategorie} , CODEBARREINVENTAIRE = '{this.CodeBarre}',NOMMATERIEL = '{this.Nom}, REFERENCECONSTRUCTEURMATERIEL '{this.ReferenceConstr}' where IDMATERIEL = {this.IdMateriel};";
            accesBD.SetData(requete);

        }
    }
}
