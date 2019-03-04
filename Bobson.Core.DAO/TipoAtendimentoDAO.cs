using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class TipoAtendimentoDAO : BaseDAO, IBaseDAO<SegmentoDTO>
    {
        public TipoAtendimentoDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {
        }

        public TipoAtendimentoDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public TipoAtendimentoDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

       

        //public SegmentoDTO GetTipoAtendimento(String id)
        //{
        //    this.CreateTextCommand("select * from Atendimento_tipo where id='" + id+"'");
           
        //    IDataReader dr = this.ExecuteDataReader();
        //    SegmentoDTO sgmento = new SegmentoDTO();
        //    if (dr.Read()) {

        //        sgmento.Id = dr["id"].ToString();
        //        sgmento.descricao = dr["descricao"].ToString();
              

               
        //    }

        //    return sgmento;

        //}


       public TipoAtendimentoDTO BuscarTipo(Int32 id)
        {
            this.CreateTextCommand("SELECT * FROM bobson01.Atendimento_tipo where id=@ID");
            this.AddInParameter("@ID", id, DbType.Int32);

            IDataReader dr = this.ExecuteDataReader();

            TipoAtendimentoDTO tpAtendimento = new TipoAtendimentoDTO();
            try
            {
                if (dr.Read())
            {
                tpAtendimento.Id =  dr["id"].ToString();
                tpAtendimento.descricao = dr["descricao"].ToString();
                tpAtendimento.completo = dr["completo"].ToString();
            }
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
            return tpAtendimento;


        }

        public List<TipoAtendimentoDTO> listarTipoAtendimento()
        {
            this.CreateTextCommand("select * from bobson01.Atendimento_tipo where id not in(2,3)");

            IDataReader dr = this.ExecuteDataReader();



            try
            {
                List<TipoAtendimentoDTO> lst = new List<TipoAtendimentoDTO>();

                while (dr.Read())
                    if (dr["descricao"].ToString() != "Visita")
                    {
                        lst.Add(new TipoAtendimentoDTO
                        {
                            Id = dr["id"].ToString(),
                            descricao = dr["descricao"].ToString(),
                            completo = dr["completo"].ToString()
                        });
                    }
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

