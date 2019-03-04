using System;
using System.Data;
using Bobson.Core.Base;
using Bobson.Core.DTO;
using System.Collections.Generic;

namespace Bobson.Core.DAO
{
    public partial class UsuariosDAO : BaseDAO, IBaseDAO<UsuariosDTO>
    {
        public UsuariosDAO()
            : base(new DbConnectionManager().CreateDbConnection())
        {
        }

        public UsuariosDAO(IDbConnection connection)
            : base(connection)
        {
        }

        public UsuariosDAO(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
        }

        public bool setPosicaoCasa(UsuariosDTO usuario)
        {
            try
            {
                this.CreateTextCommand("update aspnetusers set longitude_casa=@LONGITUTE,latitude_casa=@LATITUDE WHERE Id=@ID  ");
                this.AddInParameter("@ID", usuario.Id, DbType.String);
                this.AddInParameter("@LONGITUTE", usuario.longitude_casa, DbType.String);
                this.AddInParameter("@LATITUDE", usuario.latitude_casa, DbType.String);

                this.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public UsuariosDTO LoginEmailApp(string username="",string idusuario="")
        {

            this.CreateTextCommand("select * from aspnetusers where username=@LOGIN or Id=@ID");
            this.AddInParameter("@LOGIN", username, DbType.String);
            this.AddInParameter("@ID", idusuario, DbType.String);


            IDataReader dr = this.ExecuteDataReader();

            UsuariosDTO usuario = new UsuariosDTO();

            if (dr.Read())
            {
                usuario.Id = dr["Id"].ToString();
                usuario.Nome = dr["Nome"].ToString();
                usuario.Email = dr["Email"].ToString();
                usuario.TelefoneComercial = dr["TelefoneComercial"].ToString();
                usuario.TelefoneCelular = dr["TelefoneCelular"].ToString();
                usuario.Cargo = dr["Profissao"].ToString();


                usuario.longitude_casa = dr["longitude_casa"].ToString();

                usuario.latitude_casa = dr["latitude_casa"].ToString();

            }
            else
            {
                usuario.Id = "ffffff";
                usuario.Nome = "Não existe Usuario com esse login";
            }

            dr.Close();
            return usuario;

        }

        public List<UsuariosDTO> InativarAtivar(string id)
        {
            try
            {
                this.CreateCommand("sp_usuario_inativa"); 


                this.AddInParameter("@in_usuario_id", id, DbType.String);

                this.ExecuteNonQuery();

                return ListarUsuarios();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UsuariosDTO> Ativar(string id)
        {
            try
            {
                this.CreateCommand("sp_usuario_ativa");


                this.AddInParameter("@in_usuario_id", id, DbType.String);

                this.ExecuteNonQuery();

                return ListarUsuarios();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UsuariosDTO> resetSenha(string id)
        {
            try
            {
                this.CreateCommand("sp_usuario_reset_senha");


                this.AddInParameter("@in_usuario_id", id, DbType.String);
                this.AddInParameter("@password", "AF9ClHcZYJoGwsi1LMp2KJ+eJjPSq4poBP7d0CB75ubnqU5ss74wWdxqlq8i+DNPig==", DbType.String);

                this.ExecuteNonQuery();

                return ListarUsuarios();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UsuariosDTO> ListarUsuarios(string where="1=1")
        {
            //this.CreateCommand("sp_aros_banheiros");
            //this.AddInParameter("@in_uf", uf, DbType.String);
            //this.AddInParameter("@in_codigo_cliente", codigoCliente, DbType.Int32);
            var sql = "SELECT aspnetusers.*,aspnetroles.Name as Role FROM " +
                " bobson01.aspnetusers inner join aspnetuserroles " +
                " on(aspnetusers.id = aspnetuserroles.UserId) " +
                "inner join aspnetroles on(aspnetuserroles.RoleId = aspnetroles.Id) where " + where;

            this.CreateTextCommand(sql);
           IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<UsuariosDTO> lst = new List<UsuariosDTO>();
                while (dr.Read())
                    lst.Add(new UsuariosDTO
                    {
                        Id = dr["Id"].ToString(),
                        Nome = dr["Nome"].ToString(),
                        Email = dr["email"].ToString(),
                        Status = dr["status"].ToString(),
                        Role = dr["Role"].ToString()


                    });

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }
        }

        public void Salvar(UsuariosDTO entrada)
        {
            throw new NotImplementedException();
        }

        public void Deletar(UsuariosDTO entrada)
        {
            throw new NotImplementedException();
        }

        public List<UsuariosDTO> Listar(UsuariosDTO entrada)
        {
            throw new NotImplementedException();
        }

        public int Contar(UsuariosDTO entrada)
        {
            throw new NotImplementedException();
        }
    }
}

