using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class ConfigEmailUsuarioDAO : BaseDAO, IBaseDAO<ConfigUsuarioEmailDTO>
    {
        IDbConnection IBaseDAO<ConfigUsuarioEmailDTO>.Connection => throw new NotImplementedException();

        IDbTransaction IBaseDAO<ConfigUsuarioEmailDTO>.Transaction => throw new NotImplementedException();

        public ConfigEmailUsuarioDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {
        }

        public ConfigEmailUsuarioDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public ConfigEmailUsuarioDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }


        

        public Boolean AtualizarCliente(string RoleId,string UserId)
        {
            try
            {
                
                var sql = "update bobson01.aspnetuserroles1 set  RoleId=@ROLEID where UserId=@USERID";

                this.CreateTextCommand(sql);
                this.AddInParameter("@ROLEID", RoleId, DbType.String);
                this.AddInParameter("@USERID", UserId, DbType.String);
                this.ExecuteQuery(sql);


            }
            finally
            {

                this.CloseConnection();
            }
            return true;

        }

      

        public void Salvar(ConfigUsuarioEmailDTO entrada)
        {
            throw new NotImplementedException();
        }

        public void Deletar(ConfigUsuarioEmailDTO entrada)
        {
            throw new NotImplementedException();
        }

        public List<ConfigUsuarioEmailDTO> Listar(ConfigUsuarioEmailDTO entrada)
        {
            throw new NotImplementedException();
        }

        public int Contar(ConfigUsuarioEmailDTO entrada)
        {
            throw new NotImplementedException();
        }
    }
}

