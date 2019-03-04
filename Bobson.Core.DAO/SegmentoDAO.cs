using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class SegmentoDAO : BaseDAO, IBaseDAO<SegmentoDTO>
    {
        public SegmentoDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {
        }

        public SegmentoDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public SegmentoDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        //public List<SegmentoDTO> InativarAtivar(string id)
        //{
        //    try
        //    {
        //        this.CreateCommand("sp_usuario_inativa"); 


        //        this.AddInParameter("@in_usuario_id", id, DbType.String);

        //        this.ExecuteNonQuery();

        //        return ListarUsuarios();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<SegmentoDTO> Ativar(string id)
        //{
        //    try
        //    {
        //        this.CreateCommand("sp_usuario_ativa");


        //        this.AddInParameter("@in_usuario_id", id, DbType.String);

        //        this.ExecuteNonQuery();

        //        return ListarUsuarios();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public List<SegmentoDTO> resetSenha(string id)
        //{
        //    try
        //    {
        //        this.CreateCommand("sp_usuario_reset_senha");


        //        this.AddInParameter("@in_usuario_id", id, DbType.String);
        //        this.AddInParameter("@password", "AF9ClHcZYJoGwsi1LMp2KJ+eJjPSq4poBP7d0CB75ubnqU5ss74wWdxqlq8i+DNPig==", DbType.String);

        //        this.ExecuteNonQuery();

        //        return ListarUsuarios();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}


        public SegmentoDTO GetSegmento(String id)
        {
            this.CreateCommand("select * from segmento_cliente where id='" + id+"'");
           
            IDataReader dr = this.ExecuteDataReader();
            SegmentoDTO sgmento = new SegmentoDTO();
            if (dr.Read()) {

                sgmento.Id = dr["id"].ToString();
                sgmento.descricao = dr["descricao"].ToString();
              

               
            }
            dr.Close();

            return sgmento;

        }

        public List<SegmentoDTO> ListarSgmentos()
        {
            this.CreateCommand("sp_segmentos");

            IDataReader dr = this.ExecuteDataReader();
           

            try
            {

              
                List<SegmentoDTO> lst = new List<SegmentoDTO>();

                while (dr.Read())

                    lst.Add(new SegmentoDTO {
                        Id = dr["id"].ToString(),
                        descricao = dr["descricao"].ToString()
                        

                });   

                

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public void Salvar(SegmentoDTO entrada)
        {
            throw new NotImplementedException();
        }

        public void Deletar(SegmentoDTO entrada)
        {
            throw new NotImplementedException();
        }

        public List<SegmentoDTO> Listar(SegmentoDTO entrada)
        {
            throw new NotImplementedException();
        }

        public int Contar(SegmentoDTO entrada)
        {
            throw new NotImplementedException();
        }
    }
}

