using Bobson.Core.Base;
using Bobson.Core.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobson.Core.DAO
{
    public partial class ArosDAO : BaseDAO, IBaseDAO<ArosDTO>
    {
        public List<DDLDTO> ListarUsuarios(string RoleName)
        {
            this.CreateTextCommand("select aspnetuserroles.UserId, aspnetusers.Nome from aspnetuserroles join aspnetroles on aspnetroles.Id = aspnetuserroles.RoleId join aspnetusers on aspnetusers.Id = aspnetuserroles.UserId where aspnetroles.Name = @Role");
            this.AddInParameter("@Role", RoleName, DbType.String);

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString(), dr[1].ToString()));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }


        public List<DDLDTO> ListarCategoriasDeDocumento()
        {
            this.CreateTextCommand("select id, nome from modelo_categoria order by nome");

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString(), dr[1].ToString()));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }

        }

        public List<DDLDTO> ListarDocumentos(int categoria)
        {
            this.CreateTextCommand("select id, nome from modelo_documento where id_categoria = @id_categoria order by nome");
            this.AddInParameter("@id_categoria", categoria, DbType.Int32);

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString(), dr[1].ToString()));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }

        }



        public List<DDLDTO> LocaisMaquina()
        {
            return new List<DDLDTO>()
            {
                new DDLDTO("Alçapão", "Alçapão"),
                new DDLDTO("Armário", "Armário"),
                new DDLDTO("Parede", "Parede"),
                new DDLDTO("Embaixo Pia", "Embaixo Pia"),
                new DDLDTO("Corredor", "Corredor"),
                new DDLDTO("Fundo", "Fundo")


            };
        }

        public List<DDLDTO> Servicos()
        {
            return new List<DDLDTO>()
            {
                new DDLDTO("R", "Troca Motor"),
                new DDLDTO("M", "Troca Maquina"),
                new DDLDTO("F", "Refil Cheio"),

            };
        }

        public List<DDLDTO> ListarTransportes()
        {
            this.CreateCommand("sp_aros_transportes");

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString().Trim(), dr[1].ToString().Trim()));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public List<DDLDTO> ListarFiliais()
        {

            this.CreateCommand("sp_aros_filiais");

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString().Trim(), dr[1].ToString().Trim()));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public List<DDLDTO> ListarUF()
        {
            this.CreateCommand("sp_aros_uf");

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString().Trim(), dr[0].ToString().Trim()));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public int Contar(ArosDTO entrada)
        {
            return 0;
        }

        public void Deletar(ArosDTO entrada)
        {
            throw new NotImplementedException();
        }



    }
}
