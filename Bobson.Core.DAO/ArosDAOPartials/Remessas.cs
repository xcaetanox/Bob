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
        public string ObterEmail(int idFilial)
        {
            this.CreateTextCommand("SELECT email FROM bobson01.aros_filiais where id = @id");

            this.AddInParameter("@id", idFilial, DbType.Int32);

            return Convert.ToString(this.ExecuteScalar());
        }

        public List<RemessaDTO> ListarRemessas(int local, DateTime di, DateTime df)
        {
            this.CreateCommand("sp_aros_listar_remessas");
            this.AddInParameter("@in_local", local, DbType.Int32);
            this.AddInParameter("@in_data_inicio", di, DbType.Date);
            this.AddInParameter("@in_data_fim", df, DbType.Date);

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<RemessaDTO> lst = new List<RemessaDTO>();
                while (dr.Read())
                {
                    lst.Add(new RemessaDTO(dr));
                }

                return lst;
            }
            finally
            {
                dr.Close();
                this.CloseConnection();
            }

        }

        public void EditarRemessa(int id, string identificacaoObjeto)
        {
            this.CreateProcedureCommand("sp_aros_editar_remessa");

            this.AddInParameter("@in_id", id, DbType.Int32);
            this.AddInParameter("@in_numero_controle", identificacaoObjeto, DbType.String);

            this.ExecuteNonQuery();
        }


        public void ReceberRemessa(int id, string responsavel)
        {
            this.CreateCommand("sp_aros_receber_remessa");

            this.AddInParameter("@in_id", id, DbType.Int32);
            this.AddInParameter("@in_responsavel", responsavel, DbType.String);

            this.ExecuteNonQuery();
        }


        public int SalvarRemessa(RemessaDTO entrada)
        {
            try
            {
                this.CreateCommand("sp_aros_nova_remessa");

                this.AddInParameter("@in_numero_controle", entrada.NumeroControle, DbType.String);
                this.AddInParameter("@in_origem", entrada.Origem, DbType.Int32);
                this.AddInParameter("@in_destino", entrada.Destino, DbType.Int32);
                this.AddInParameter("@in_forma_envio", entrada.FormaEnvio, DbType.Int32);
                this.AddInParameter("@in_descricao_objeto", entrada.DescricaoObjeto, DbType.String);
                this.AddInParameter("@in_responsavel_envio", entrada.ResponsavelEnvio, DbType.String);
                this.AddInParameter("@in_responsavel_recebimento", entrada.ResponsavelRecebimento, DbType.String);
                this.AddInParameter("@in_observacoes", entrada.Observacoes, DbType.String);
                this.AddInParameter("@in_usuario_id", entrada.UsuarioId, DbType.String);
                
                this.AddOutParameter("@out_id", DbType.Int32);

                this.ExecuteNonQuery();

                return Convert.ToInt32(this.ReturnValue("@out_id"));
            }
            catch (Exception ecx)
            {
                return 0;
            }
        }

        public void ApagarRemessa(int id, string usuarioId)
        {
            try
            {
                this.CreateCommand("sp_aros_delete_remessa");

                this.AddInParameter("@in_id", id, DbType.Int32);
                this.AddInParameter("@in_usuario_id", usuarioId, DbType.String);

                this.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


    }
}
