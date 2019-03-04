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
        public void SalvarHistoricoProposta(HistoricoPropostaDTO entrada)
        {
            this.CreateTextCommand("insert into proposta_historico (data,usuario,email_assunto,email_corpo,email_cliente,email_copia,view_name,view_model,id_modelo,proposta) values (@data,@usuario,@email_assunto,@email_corpo,@email_cliente,@email_copia,@view_name,@view_model,@id_modelo,@proposta);");

            this.AddInParameter("@data", DateTime.Now, DbType.DateTime);
            this.AddInParameter("@usuario", entrada.UsuarioId, DbType.String);
            this.AddInParameter("@email_assunto", entrada.EmailAssunto, DbType.String);
            this.AddInParameter("@email_corpo", entrada.EmailCorpo, DbType.String);
            this.AddInParameter("@email_cliente", entrada.EmailCliente, DbType.String);
            this.AddInParameter("@email_copia", entrada.EmailCopia, DbType.String);
            this.AddInParameter("@view_name", entrada.ViewName, DbType.String);
            this.AddInParameter("@view_model", entrada.ViewModel, DbType.String);
            this.AddInParameter("@id_modelo", entrada.ViewNameToId, DbType.Int32);
            this.AddInParameter("@Proposta", entrada.Proposta, DbType.String);

            this.ExecuteNonQuery();
        }


        public int SalvarDocumento(ModeloDocumentoDTO entrada)
        {
            this.CreateTextCommand("insert into modelo_documento (id, nome, html, id_categoria) values (@in_id, @in_nome, @in_html, @id_categoria) ON DUPLICATE KEY UPDATE nome=@in_nome, html=@in_html, id_categoria=@id_categoria; select LAST_INSERT_ID();");

            this.AddInParameter("@in_id", (object)entrada.Id ?? DBNull.Value, DbType.Int32);
            this.AddInParameter("@in_nome", entrada.Nome, DbType.String);
            this.AddInParameter("@in_html", entrada.Html, DbType.String);
            this.AddInParameter("@id_categoria", (object)entrada.Categoria ?? DBNull.Value, DbType.Int32);

            return Convert.ToInt32(this.ExecuteScalar());
        }

        public int DeletarDocumento(ModeloDocumentoDTO entrada)
        {
            this.CreateTextCommand("delete from modelo_documento where id = @in_id");

            this.AddInParameter("@in_id", (object)entrada.Id ?? DBNull.Value, DbType.Int32);

            this.ExecuteNonQuery();

            return 0;
        }

        public ModeloDocumentoDTO ObterDocumento(int id)
        {
            this.CreateTextCommand("select id, nome, html, id_categoria from modelo_documento where id = @id");
            this.AddInParameter("@id", id, DbType.Int32);

            IDataReader dr = this.ExecuteDataReader();

            if (dr.Read())
                return new ModeloDocumentoDTO(dr);
            else
                return null;
        }

        public List<DDLDTO> ListarDocumentos()
        {

            this.CreateTextCommand("select modelo_documento.id, modelo_documento.nome,  concat('[', modelo_categoria.nome, '] ', modelo_documento.nome) as categoria from modelo_documento join modelo_categoria on modelo_categoria.id = modelo_documento.id_categoria order by modelo_categoria.id, modelo_documento.nome");

            IDataReader dr = this.ExecuteDataReader();

            try
            {
                List<DDLDTO> lst = new List<DDLDTO>();
                while (dr.Read())
                {
                    lst.Add(new DDLDTO(dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));
                }

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
