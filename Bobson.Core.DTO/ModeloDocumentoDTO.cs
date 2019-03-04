using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobson.Core.DTO
{
    public class ModeloDocumentoDTO : BaseDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Html { get; set; }
        public int? Categoria { get; set; }

        public ModeloDocumentoDTO(IDataReader dr)
        {
            if (dr != null)
            {
                this.Id = Convert.ToInt32(dr["id"]);
                this.Nome = Convert.ToString(dr["nome"]);
                this.Categoria= Convert.ToInt32(dr["id_categoria"]);
                this.Html = Convert.ToString(dr["html"]);
            }
          
        }
    }
}
