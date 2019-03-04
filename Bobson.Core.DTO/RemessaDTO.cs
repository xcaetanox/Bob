using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bobson.Core.DTO
{
    public class RemessaDTO : BaseDTO
    {
        public int Id { get; set; }

        public string NumeroControle { get; set; }

        public string UrlRastreio
        {
            get
            {

                return "http://websro.correios.com.br/sro_bin/txect01$.Inexistente?P_LINGUA=001&P_TIPO=002&P_COD_LIS=" + NumeroControle;

            }
        }

        public string Recebido
        {
            get
            {
                if (DataRecebimento != null)
                    return ((DateTime)DataRecebimento).ToString("dd/MM/yyyy hh:mm") + "(" + ResponsavelRecebimento + ")";
                else
                    return "-//-";

            }
        }

        public string Enviado
        {
            get
            {
                return DataEnvio.ToString("dd/MM/yyyy hh:mm") + "(" + ResponsavelEnvio + ")";

            }
        }

        public int Origem { get; set; }

        public int Destino { get; set; }

        public int FormaEnvio { get; set; }

        public string DescOrigem { get; set; }

        public string DescDestino { get; set; }

        public string DescFormaEnvio { get; set; }

        public string DescricaoObjeto { get; set; }

        public DateTime DataEnvio { get; set; }

        public string ResponsavelEnvio { get; set; }

        public DateTime? DataRecebimento { get; set; }

        public string ResponsavelRecebimento { get; set; }

        public string Observacoes { get; set; }

        public RemessaDTO()
        {
        }

        public RemessaDTO(IDataReader dr)
        {
            this.Id = Convert.ToInt32(dr["id"]);
            this.NumeroControle = dr["numero_controle"].ToString();
            this.Origem = Convert.ToInt32(dr["origem"]);
            this.Destino = Convert.ToInt32(dr["destino"]);
            this.FormaEnvio = Convert.ToInt32(dr["forma_envio"]);

            this.DescOrigem = dr["desc_origem"].ToString();
            this.DescDestino = dr["desc_destino"].ToString();
            this.DescFormaEnvio = dr["desc_forma_envio"].ToString();

            this.DescricaoObjeto = dr["descricao_objeto"].ToString();

            this.Observacoes = dr["observacoes"].ToString();

            this.DataEnvio = Convert.ToDateTime(dr["data_envio"]);
            this.ResponsavelEnvio = dr["responsavel_envio"].ToString();

            if (dr["data_recebimento"] != null && dr["data_recebimento"] != DBNull.Value)
                this.DataRecebimento = Convert.ToDateTime(dr["data_recebimento"]);

            this.ResponsavelRecebimento = dr["responsavel_recebimento"].ToString();

        }
    }
}
