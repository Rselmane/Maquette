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

        public void Create()
        {

            DataAccess accesBD = new DataAccess();
      
            String requete = $"Insert into MATERIEL (IDCATEGORIE, NOMMATERIEL,REFERENCECONSTRUCTEURMATERIEL, CODEBARREINVENTAIRE)  VALUES({ this.FK_IdCategorie},'{this.Nom}','{this.ReferenceConstr}','{this.CodeBarre}');";
            accesBD.SetData(requete);
        }
    

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

        public void Update()
        {
            DataAccess accesBD = new DataAccess();
            String requete = $"update  materiel SET  IDCATEGORIE  = {this.FK_IdCategorie} , CODEBARREINVENTAIRE = '{this.CodeBarre}',NOMMATERIEL = '{this.Nom}, REFERENCECONSTRUCTEURMATERIEL '{this.ReferenceConstr}' where IDMATERIEL = {this.IdMateriel};";
            accesBD.SetData(requete);

        }
    }
}
