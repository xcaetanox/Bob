using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class AtendimentoDAO : BaseDAO, IBaseDAO<AtendimentoClienteDTO>
    {
        public AtendimentoDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {
        }

        public AtendimentoDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public AtendimentoDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }


        public ClienteDTO proximoCliente(string clienteid, string idVendedor)
        {
            this.CreateCommand("proximo_cliente");
            this.AddInParameter("@IdVend", idVendedor, DbType.String);
            this.AddInParameter("@idCli", clienteid, DbType.Int32);


            IDataReader dr = this.ExecuteDataReader();

            ClienteDTO cliente = new ClienteDTO();

            if (dr.Read())
            {

                cliente.Id = dr.GetInt32(dr.GetOrdinal("codigo_cliente"));
                cliente.nome_cliente = dr["nome_cliente"].ToString();
            }
            dr.Close();
            return cliente;
        }
       public AtendimentoClienteDTO buscaAtendimento(string id)
        {
            this.CreateCommand("sp_buscaantendimento");
            this.AddInParameter("@idParam", id, DbType.Int32);
            
            IDataReader dr = this.ExecuteDataReader();

            AtendimentoClienteDTO atendimentoClienteDTO = new AtendimentoClienteDTO();
            if (dr.Read())
            {

                atendimentoClienteDTO.Id = dr.GetInt32(dr.GetOrdinal("id"));
                atendimentoClienteDTO.idCliente = dr.GetInt32(dr.GetOrdinal("idCliente"));
                atendimentoClienteDTO.horaIni = dr["horaIni"].ToString();
                atendimentoClienteDTO.horaFim = dr["horaFim"].ToString();
                atendimentoClienteDTO.obs = dr["obs"].ToString();
                atendimentoClienteDTO.idVendedor = dr["idVendedor"].ToString();
                atendimentoClienteDTO.idTipoAtendimento = dr.GetInt32(dr.GetOrdinal("id_tipo_atendimento"));
                atendimentoClienteDTO.dataContato = dr.GetDateTime(dr.GetOrdinal("dataContato"));
                atendimentoClienteDTO.dataVisita = dr.GetDateTime(dr.GetOrdinal("dataVisita"));

                atendimentoClienteDTO.logintude = dr["logintude"].ToString();
                atendimentoClienteDTO.latitude = dr["latitude"].ToString();


            }
            else
            {
                atendimentoClienteDTO.dataVisita = DateTime.Today;
            }
            dr.Close();

            return atendimentoClienteDTO;

        }


        public List<AtendimentoClienteDTO> buscaHistoricoAtendimento(string clienteid, string idVendedor)
        {


            UsuariosDTO usuariosDTO = new UsuariosDAO().LoginEmailApp("", idVendedor);

            this.CreateCommand("sp_atendimento");
            this.AddInParameter("@IdVend", idVendedor, DbType.String);
            this.AddInParameter("@idCli", clienteid, DbType.Int32);
            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<AtendimentoClienteDTO> lst = new List<AtendimentoClienteDTO>();
                while (dr.Read()) {

                    lst.Add(new AtendimentoClienteDTO {
                        Id = dr.GetInt32(dr.GetOrdinal("id")),
                        dataContato = (DateTime)dr["datacontato"],
                        idTipoAtendimento = dr.GetInt32(dr.GetOrdinal("id_tipo_atendimento")),
                        obs = dr["obs"].ToString(),
                        dataVisita = (DateTime)dr["datavisita"],
                        horaIni = dr["horaini"].ToString(),
                        tipo = dr["descricao"].ToString(),
                        horaFim = dr["horafim"].ToString(),
                        idVendedor = dr["idvendedor"].ToString(),
                        logintude = dr["logintude"].ToString(),
                        latitude = dr["latitude"].ToString(),
                        logintude_casa = usuariosDTO.longitude_casa.ToString(),
                        latitude_casa =  usuariosDTO.latitude_casa.ToString()
                        


                });
                }


                dr.Close();

                return lst;
            }

        
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public List<AtendimentoClienteDTO> listaAtendimentoPorCliente(int idCliente,DateTime? dtInicio,DateTime? dtFim)
        {
            string sql = "select * from Atendimento where idCliente = @IDCLIENTE";

            

            if (dtInicio !=null && dtFim != null)
            {

                sql += " and dataContato between @DT_INI AND @DT_FIM";

                this.CreateTextCommand(sql);
                this.AddInParameter("@IDCLIENTE", idCliente, DbType.Int32);

                this.AddInParameter("@DT_INI", dtInicio, DbType.DateTime);
                this.AddInParameter("@DT_FIM", dtFim, DbType.DateTime);
            }
            else
            {
                this.CreateTextCommand(sql);
                this.AddInParameter("@IDCLIENTE", idCliente, DbType.Int32);
            }

            

            IDataReader dr = this.ExecuteDataReader();
            List<AtendimentoClienteDTO> atendimentos = new List<AtendimentoClienteDTO>();

          try
            {
                List<AtendimentoClienteDTO> lst = new List<AtendimentoClienteDTO>();
                while (dr.Read()) {

                    lst.Add(new AtendimentoClienteDTO {
                        Id = dr.GetInt32(dr.GetOrdinal("id")),
                        dataContato = (DateTime)dr["datacontato"],
                        idTipoAtendimento = dr.GetInt32(dr.GetOrdinal("id_tipo_atendimento")),
                        obs = dr["obs"].ToString(),
                        dataVisita = (DateTime)dr["datavisita"],
                        horaIni = dr["horaini"].ToString(),
                        idCliente = dr.GetInt32(dr.GetOrdinal("idCliente")),
                        horaFim = dr["horafim"].ToString(),
                        idVendedor = dr["idvendedor"].ToString(),
                        logintude = dr["logintude"].ToString(),
                        latitude = dr["latitude"].ToString()
                      


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

        public void Atualizar(AtendimentoClienteDTO entrada)
        {

            DateTime dataContato = entrada.dataContato;
              
            DateTime dataVisita = entrada.dataVisita;
            try
            {
                var sql = "UPDATE `bobson01`.`Atendimento` SET " + 
                " dataContato ='"+ dataContato.ToString("yyyy-MM-dd H:mm:ss") + "',"+
                " tipo ='"+entrada.tipo+"'," +
                " obs = '"+entrada.obs+"'," +
                " dataVisita = '"+dataVisita.ToString("yyyy-MM-dd H:mm:ss") + "'," +
                " horaIni = '"+entrada.horaIni+"'," +
                " HoraFim = '" + entrada.horaFim + "'," +
                " id_tipo_atendimento = " + entrada.idTipoAtendimento +
                " WHERE id =" +entrada.Id;
            this.ExecuteQuery(sql);


        }
            finally
            {

                this.CloseConnection();
    }

}





        public void Salvar(AtendimentoClienteDTO entrada)
        {
            try
            {

                DateTime dataContato = entrada.dataContato;


                if (entrada.latitude == null)
                {
                    entrada.latitude = "0";
                }

                if (entrada.logintude==null)
                {
                    entrada.logintude = "0";
                }


                DateTime dataVisita = entrada.dataVisita;
                   



                var sql = " INSERT INTO `bobson01`.`Atendimento`" +
                          "  (dataContato,tipo,obs,dataVisita,horaIni,HoraFim,idCliente,idVendedor,id_tipo_atendimento,latitude,logintude)" +
                          "  VALUES(current_timestamp(),'" + entrada.tipo + "','" + entrada.obs + "','" + dataVisita.ToString("yyyy-MM-dd H:mm:ss") + "','" 
                           + entrada.horaIni + "','"
                            + entrada.horaFim + "','" + entrada.idCliente + "','" + entrada.idVendedor + "','" + entrada.idTipoAtendimento+ 
                            "','"+entrada.latitude.ToString().Replace(",",".")+ "','" + entrada.logintude.ToString().Replace(",",".") + "')";


                this.ExecuteQuery(sql);


            }
            finally
            {

                this.CloseConnection();
            }
            
        }


        public List<RelPerformanceDTO> getPerformanceDia(DateTime dtIni,DateTime dtfim, string idUsuario)
        {

            this.CreateTextCommand("select cli.nome_cliente as nome ,atend.dataContato as data ,atend_tipo.descricao as tipo, atend.obs" +
                " from aspnetusers user inner join Atendimento atend on (user.Id = atend.idVendedor)" +
                " inner join Atendimento_tipo atend_tipo on(atend.id_tipo_atendimento = atend_tipo.id) " +
                " inner join aros_cliente cli on(atend.idCliente = cli.codigo_cliente)" +
                " where dataContato between @DATAINI AND @DATAFIM AND user.Id = @ID_USER order by datacontato");
            this.AddInParameter("@DATAINI", dtIni, DbType.DateTime);
            this.AddInParameter("@DATAFIM", dtfim, DbType.DateTime);
            this.AddInParameter("@ID_USER", idUsuario, DbType.String);

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                
                List<RelPerformanceDTO> lst = new List<RelPerformanceDTO>();
                while (dr.Read())
                {

                    lst.Add(new RelPerformanceDTO
                    {
                       
                        
                        nome= dr["nome"].ToString(),
                        data = (DateTime)dr["data"],
                        tipo = dr["tipo"].ToString(),
                        obs = dr["obs"].ToString()


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

        public void Deletar(AtendimentoClienteDTO entrada)
        {
            throw new NotImplementedException();
        }

        public List<AtendimentoClienteDTO> Listar(AtendimentoClienteDTO entrada)
        {
            throw new NotImplementedException();
        }

        public int Contar(AtendimentoClienteDTO entrada)
        {
            throw new NotImplementedException();
        }
    }
}

