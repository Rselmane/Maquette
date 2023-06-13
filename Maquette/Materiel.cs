using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquette
{
    public class Materiel:Crud<Materiel>
    {
        public Materiel()
        {
        }

        public Materiel(int idCategorie, string codeBarre, string nom, string referenceConstr, int fK_IdCategorie)
        {
            this.IdCategorie = idCategorie;
            this.CodeBarre = codeBarre;
            this.Nom = nom;
            this.ReferenceConstr = referenceConstr;
            this.FK_IdCategorie = fK_IdCategorie;
        }

        public int IdCategorie { get; set; }
        public string CodeBarre { get; set; }
        public string Nom { get; set; }
        public string ReferenceConstr { get; set; }
        public int FK_IdCategorie { get; set; }

        public void Create()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select  IDCATEGORIE, CODEBARRE, NOM,REFERENCECONSTR  from MATERIEL ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["IDCATEGORIE"].ToString()), (String)row["CODEBARRE"], (String)row["NOM"], (String)row["REFERENCECONSTR"], int.Parse(row["IDCATEGORIE"].ToString()));
                    lesMateriels.Add(m);
                }
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Materiel> FindAll()
        {
            ObservableCollection<Materiel> lesMateriels = new ObservableCollection<Materiel>();
            DataAccess accesBD = new DataAccess();
            String requete = "select  IDCATEGORIE, CODEBARRE, NOM,REFERENCECONSTR  from MATERIEL ;";
            DataTable datas = accesBD.GetData(requete);
            if (datas != null)
            {
                foreach (DataRow row in datas.Rows)
                {
                    Materiel m = new Materiel(int.Parse(row["IDCATEGORIE"].ToString()),(String)row["CODEBARRE"], (String)row["NOM"], (String)row["REFERENCECONSTR"], int.Parse(row["IDCATEGORIE"].ToString()));
                    lesMateriels.Add(m);
                }
            }
            return lesMateriels;
        }

        public ObservableCollection<Materiel> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
        }
    }
}
