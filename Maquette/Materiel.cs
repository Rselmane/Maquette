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

        public Materiel(int idMateriel, string codeBarre, string nom, string referenceConstr, int fK_IdCategorie)
        {
            IdMateriel = idMateriel;
            CodeBarre = codeBarre;
            Nom = nom;
            ReferenceConstr = referenceConstr;
            FK_IdCategorie = fK_IdCategorie;
        }

        public Materiel( string codeBarre, string nom, string referenceConstr, int fK_IdCategorie) : this(0, codeBarre, nom, referenceConstr, fK_IdCategorie) 
        {
            
        }

        public int IdMateriel { get; set; }
        public string CodeBarre { get; set; }
        public string Nom { get; set; }
        public string ReferenceConstr { get; set; }
        public int FK_IdCategorie { get; set; }
        public ObservableCollection<Attribution> LesAttributions { get; set; }
        public Categorie CategorieMat { get; set; }

        public void Create()
        {

            DataAccess accesBD = new DataAccess();
      
            String requete = $"Insert into materiel (IDCATEGORIE,CODEBARREINVENTAIRE,NOMMATERIEL,REFERENCECONSTRUCTEURMATERIEL)  VALUES({ this.FK_IdCategorie},'{this.CodeBarre}','{this.Nom}','{this.ReferenceConstr}');";
             accesBD.SetData(requete);
        }
    

        public void Delete()
        {
            DataAccess accesBD = new DataAccess();
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
            String requete = $"select * from materiel where  " + criteres;
           DataTable datas = accesBD.GetData(requete);

            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["IDMATERIEL"].ToString()), (String)row["CODEBARREINVENTAIRE"], (String)row["NOMMATERIEL"], (String)row["REFERENCECONSTR"], int.Parse(row["IDCATEGORIE"].ToString()));
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
