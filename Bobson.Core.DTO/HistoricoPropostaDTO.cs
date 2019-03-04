using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobson.Core.DTO
{
    public class HistoricoPropostaDTO : BaseDTO
    {
        public DateTime Data { get; set; }
        public String EmailAssunto { get; set; }
        public String EmailCorpo { get; set; }
        public String EmailCliente { get; set; }
        public String EmailCopia { get; set; }
        public String ViewName { get; set; }
        public String ViewModel { get; set; }
        public Int32 ModeloId { get; set; }
        public string ModeloDescricao { get; set; }
        public string Proposta { get; set; }

        public Int32 ViewNameToId
        {
            get
            {
                return Int32.Parse(this.ViewName.ToUpper().Replace("VIEW_","").Replace("_PNT",""));
            }
        }

        public HistoricoPropostaDTO() { }
        public HistoricoPropostaDTO(IDataReader dr)
        {
            this.Data = Convert.ToDateTime(dr["data"]);
            this.UsuarioId = Convert.ToString(dr["usuario"]);
            this.EmailAssunto = Convert.ToString(dr["email_assunto"]);
            this.EmailCorpo = Convert.ToString(dr["email_corpo"]);
            this.EmailCliente = Convert.ToString(dr["email_cliente"]);
            this.EmailCopia = Convert.ToString(dr["email_copia"]);
            this.ViewName = Convert.ToString(dr["view_name"]);
            this.ViewModel = Convert.ToString(dr["view_model"]);
            this.ModeloId = Convert.ToInt32(dr["id_modelo"]);
            this.Proposta = Convert.ToString(dr["proposta"]);
        }
    }
}
