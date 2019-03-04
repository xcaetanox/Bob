using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class ArosDAO : BaseDAO, IBaseDAO<ArosDTO>
    {
        public ArosDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {            
        }

        public ArosDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public ArosDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public void Salvar(ArosDTO entrada)
        {
            try
            {
                this.CreateCommand("sp_aros_registro");

                this.AddInParameter("@in_uf", entrada.Estado, DbType.String);
                this.AddInParameter("@in_codigo_cliente", entrada.CodigoCliente, DbType.Int32);
                this.AddInParameter("@in_codigo_equipamento", entrada.CodigoEquipamento, DbType.Int32);
                this.AddInParameter("@in_acontecimento", entrada.Acontecimento, DbType.String);
                this.AddInParameter("@in_peso_refil", entrada.PesoRefil, DbType.String);
                this.AddInParameter("@in_observacoes", entrada.Observacoes, DbType.String);
                this.AddInParameter("@in_usuario_id", entrada.UsuarioId, DbType.String);

                this.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }


        public void SalvarEquipamento(ArosDTO entrada)
        {
            //   try
            //   { 
            if (entrada.CodigoBanheiro <= 0)
                throw new Exception("Código do Banheiro está Vazio ou é Zero! O arquivo deve conter códigos de Banheiro Válidos !");

            this.CreateCommand("sp_aros_cadastro");

            this.AddInParameter("@in_uf", entrada.Estado.Trim(), DbType.String);
            this.AddInParameter("@in_codigo_cliente", entrada.CodigoCliente, DbType.Int32);
            this.AddInParameter("@in_codigo_banheiro", entrada.CodigoBanheiro, DbType.Int32);
            this.AddInParameter("@in_local", entrada.Local.Trim(), DbType.String);
            this.AddInParameter("@in_tipo", entrada.Tipo.Trim(), DbType.String);
            this.AddInParameter("@in_descricao", entrada.DescricaoEquipamento.Trim(), DbType.String);
            this.AddInParameter("@in_hora_liga", entrada.HoraLiga, DbType.Time);
            this.AddInParameter("@in_hora_desliga", entrada.HoraDesliga, DbType.Time);
            this.AddInParameter("@in_aroma", entrada.Aroma.Trim(), DbType.String);
            this.AddInParameter("@in_ultima_troca", entrada.DataUltimaTroca, DbType.DateTime);
            this.AddInParameter("@in_peso_refil", entrada.PesoRefil, DbType.Int32);
            this.AddInParameter("@in_nevoa_solta", entrada.NevoaSolta, DbType.Time);
            this.AddInParameter("@in_nevoa_para", entrada.NevoaPara, DbType.Time);

            this.ExecuteNonQuery();
            //   }
            //    catch(Exception ex)
            //    {
            //       throw (ex);
            //    }
        }

        public List<ArosDTO> ListarBanheiros(string uf, int codigoCliente)
        {
            this.CreateCommand("sp_aros_banheiros");
            this.AddInParameter("@in_uf", uf, DbType.String);
            this.AddInParameter("@in_codigo_cliente", codigoCliente, DbType.Int32);

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<ArosDTO> lst = new List<ArosDTO>();
                while (dr.Read())
                    lst.Add(new ArosDTO
                    {
                        Local = dr["local"].ToString(),
                        Tipo = dr["tipo"].ToString(),
                        HoraLiga = TimeSpan.Parse(dr["hora_liga"].ToString()),
                        HoraDesliga = TimeSpan.Parse(dr["hora_desliga"].ToString()),
                        Aroma = dr["aroma"].ToString(),
                        CodigoEquipamento = Convert.ToInt32(dr["codigo_equipamento"]),
                        DescricaoEquipamento = Convert.ToString(dr["descricao_equipamento"]),
                        CodigoCliente = Convert.ToInt32(dr["codigo_cliente"]),
                        NevoaSolta = TimeSpan.Parse(dr["nevoa_solta"].ToString()),
                        NevoaPara = TimeSpan.Parse(dr["nevoa_para"].ToString())
                    });

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public List<ArosDTO> ListarMaquinas(string uf, int clienteId, string local, string tipo)
        {
            try
            {
                this.CreateCommand("sp_aros_maquinas");
                this.AddInParameter("@in_uf", uf, DbType.String);
                this.AddInParameter("@in_codigo_cliente", clienteId, DbType.Int32);
                this.AddInParameter("@in_local", local, DbType.String);
                this.AddInParameter("@in_tipo", tipo, DbType.String);

                IDataReader dr = this.ExecuteDataReader();

                try
                {
                    List<ArosDTO> lst = new List<ArosDTO>();
                    while (dr.Read())
                        lst.Add(new ArosDTO
                        {
                            Local = dr["local"].ToString(),
                            Tipo = dr["tipo"].ToString(),
                            HoraLiga = TimeSpan.Parse(dr["hora_liga"].ToString()),
                            HoraDesliga = TimeSpan.Parse(dr["hora_desliga"].ToString()),
                            Aroma = dr["aroma"].ToString(),
                            CodigoEquipamento = Convert.ToInt32(dr["codigo_equipamento"]),
                            DescricaoEquipamento = Convert.ToString(dr["descricao_equipamento"]),
                            CodigoCliente = Convert.ToInt32(dr["codigo_cliente"]),
                            NevoaSolta = TimeSpan.Parse(dr["nevoa_solta"].ToString()),
                            NevoaPara = TimeSpan.Parse(dr["nevoa_para"].ToString())
                        });

                    return lst;
                }
                finally
                {
                    dr.Close();
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public List<ArosDTO> Listar(ArosDTO entrada)
        {
            this.CreateCommand("sp_aros_report");
            this.AddInParameter("@in_codigo_equipamento", entrada.CodigoEquipamento, DbType.Int32);

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<ArosDTO> lst = new List<ArosDTO>();
                while (dr.Read())
                    lst.Add(new ArosDTO
                    {
                        CodigoCliente = Convert.ToInt32(dr["codigo_cliente"]),
                        //                            NomeCliente = dr["nome_cliente"].ToString(), 
                        DescricaoEquipamento = dr["descricao_equipamento"].ToString(),
                        Acontecimento = dr["acontecimento"].ToString(),
                        PesoRefil = dr["peso_refil"].ToString(),
                        Observacoes = dr["observacoes"].ToString(),
                        Local = dr["local"].ToString(),
                        Tipo = dr["tipo"].ToString(),
                        DataOcorrencia = Convert.ToDateTime(dr["data_ocorrencia"])
                    });

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

      
    }
}

