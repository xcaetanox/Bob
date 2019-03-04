using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class ClienteDAO : BaseDAO, IBaseDAO<ClienteDTO>
    {
        public ClienteDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {
        }

        public ClienteDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public ClienteDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

       


        public ClienteDTO buscarCliente(string id)
        {
            this.CreateCommand("sp_usuario_busca_cliente");
            this.AddInParameter("@id_cliente", id, DbType.Int32);
            IDataReader dr = this.ExecuteDataReader();
            ClienteDTO cliente = new ClienteDTO();
            if (dr.Read()) {
                
                cliente.Id = dr.GetInt32(dr.GetOrdinal("codigo_cliente"));
                cliente.nome_cliente = dr["nome_cliente"].ToString();
                cliente.contato = dr["contato"].ToString();
                cliente.email = dr["email"].ToString();
                cliente.idSegmento = dr.GetInt32(dr.GetOrdinal("id_segmento")); 
                cliente.idSituacao = dr.GetInt32(dr.GetOrdinal("id_situacao")); 
                cliente.idVendedor = dr["id_vendedor"].ToString();
                cliente.telefone = dr["telefone"].ToString();
               cliente.situacaoClienteVendendor = dr["situacao_cliente"].ToString();
                cliente.Ad= dr.GetInt32(dr.GetOrdinal("AD"));
                cliente.Os= dr.GetInt32(dr.GetOrdinal("OS"));
                cliente.tapete = dr.GetInt32(dr.GetOrdinal("TAPETE"));
                cliente.aro = dr.GetInt32(dr.GetOrdinal("ARO"));
                cliente.secador = dr.GetInt32(dr.GetOrdinal("SECADOR"));
                cliente.fioDental = dr.GetInt32(dr.GetOrdinal("FIO_DENTAL"));


            }
            dr.Close();
            return cliente;

        }

        public List<ClienteDTO> ListarClientes(string idVendedor,bool bloqueado = true)
        {



            var sqlPartial = " and  ((situacao_cliente != 'NÃO APROVADO' and situacao_cliente != 'LIGAR NO FUTURO' ) " +
                " or " +
                "  (dataLigar <= current_timestamp() and situacao_cliente = 'LIGAR NO FUTURO')) order by nome_cliente  ";

            if (!bloqueado)
            {
                sqlPartial = " order by nome_cliente  "; 
            }

            this.CreateTextCommand("SELECT * FROM aros_cliente WHERE aros_cliente.id_vendedor = @idvendedor " + sqlPartial);
            this.AddInParameter("@idvendedor", idVendedor, DbType.String);
            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<ClienteDTO> lst = new List<ClienteDTO>();

                while (dr.Read())

                    lst.Add(new ClienteDTO {
                        Id = dr.GetInt32(dr.GetOrdinal("codigo_cliente")),
                        nome_cliente = dr["nome_cliente"].ToString(),
                        contato = dr["contato"].ToString(),
                        email = dr["email"].ToString(),
                        telefone = dr["telefone"].ToString(),
                        idSegmento = dr.GetInt32(dr.GetOrdinal("id_segmento")),
                        idSituacao = dr.GetInt32(dr.GetOrdinal("id_situacao")),
                        idVendedor = dr["id_vendedor"].ToString(),
                        situacaoClienteVendendor = dr["situacao_cliente"].ToString(),
                        Ad = dr.GetInt32(dr.GetOrdinal("AD")),
                        Os = dr.GetInt32(dr.GetOrdinal("OS")),
                        tapete = dr.GetInt32(dr.GetOrdinal("TAPETE")),
                        aro = dr.GetInt32(dr.GetOrdinal("ARO")),
                        secador = dr.GetInt32(dr.GetOrdinal("SECADOR")),
                        fioDental = dr.GetInt32(dr.GetOrdinal("FIO_DENTAL"))

                    });

               

              


                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }



        public List<ClienteDTO> AtualizaStatus(List<ClienteDTO> clientes)
        {
            try
            {
                foreach (var cliente in clientes)
                {
                    this.CreateCommand("sp_status_atendimento_cliente");
                    this.AddInParameter("@idVend", cliente.idVendedor, DbType.String);
                    this.AddInParameter("@idCli", cliente.Id, DbType.String);
                    IDataReader dr = this.ExecuteDataReader();
                    while (dr.Read())
                    {
                        cliente.status +=  dr["status"] + " |   ";
                    }
                    dr.Close();

                }



                return clientes;
            }
            finally
            {
               
                this.CloseConnection();
            }
        }


        public List<ClienteDTO> SalvarCliente(ClienteDTO cliente)
        {
            try
            {
                var sql = "INSERT INTO `bobson01`.`aros_cliente`  (`nome_cliente`," +
                      "  `contato`,  " +
                      "`telefone`, " +
                      " `email`,  " +
                      " `situacao_cliente`, " +
                      "`id_segmento`, " +
                      " `id_vendedor`, " +
                     
                      " `id_situacao`," +
                      " `AD`," +
                      " `OS`," +
                      " `TAPETE`," +
                      " `ARO`," +
                      " `SECADOR`," +
                      " `FIO_DENTAL`," +
                      " data_alteracao," +
                      " dataLigar"+


                      ")" +
                      " values('" + cliente.nome_cliente + "','" + cliente.contato + "','" + cliente.telefone + "','" + cliente.email + "','" + cliente.situacaoClienteVendendor+ "','" + cliente.idSegmento + "','" + cliente.idVendedor + "','" + cliente.idSituacao +
                      "','" + cliente.Ad +
                      "','" + cliente.Os +
                      "','" + cliente.tapete +
                      "','" + cliente.aro+
                      "','" + cliente.secador +
                      "','" + cliente.fioDental +
                      "',current_timestamp()" + 
                      ",'"+cliente.ligarNoFuturoData.ToString("yyyy-MM-dd H:mm:ss") + "')";

                this.ExecuteQuery(sql);

                
            }
            finally
            {
               
                this.CloseConnection();
            }
            return AtualizaStatus(ListarClientes(cliente.idVendedor));

        }


        public List<ClienteDTO> AtualizarCliente(ClienteDTO cliente)
        {
            try
            {
                var sql = "update bobson01.aros_cliente " +
                    "set " +

                    "nome_cliente='" + cliente.nome_cliente + "'," +
                    "contato ='" + cliente.contato + "'," +
                    "telefone ='" + cliente.telefone + "'," +
                    "email='" + cliente.email + "'," +
                    "situacao_cliente='" + cliente.situacaoClienteVendendor + "'," +
                    "id_segmento = '" + cliente.idSegmento + "'," +
                    "id_situacao = '" + cliente.idSituacao + "'," +
                     "AD = '" + cliente.Ad + "'," +
                     "OS = '" + cliente.Os + "'," +
                    "TAPETE = '" + cliente.tapete + "'," +
                    "SECADOR = '" + cliente.secador + "'," +
                    "ARO = '" + cliente.aro + "'," +
                    "FIO_DENTAL = '" + cliente.fioDental + "'," +
                   " data_alteracao = current_timestamp(),"+
                   " dataLigar ='" + cliente.ligarNoFuturoData.ToString("yyyy-MM-dd H:mm:ss") +
                    "' where codigo_cliente=" +cliente.Id;



                this.ExecuteQuery(sql);


            }
            finally
            {

                this.CloseConnection();
            }
            return AtualizaStatus(ListarClientes(cliente.idVendedor));

        }

        


        public void Salvar(ClienteDTO entrada)
        {
            throw new NotImplementedException();
        }


        public void Deletar(ClienteDTO entrada)
        {
            throw new NotImplementedException();
        }

        public List<ClienteDTO> Listar(ClienteDTO entrada)
        {
            throw new NotImplementedException();
        }

        public int Contar(ClienteDTO entrada)
        {
            throw new NotImplementedException();
        }
    }
}

