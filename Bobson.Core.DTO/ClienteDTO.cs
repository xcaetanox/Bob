using Bobson.Core.DTO;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class ClienteDTO : BaseDTO
    {
        [Key]
        [DisplayName("Código Cliente")]
        public Int32 Id { get; set; }

        [DisplayName("Cliente")]
        public string nome_cliente { get; set; }

        [DisplayName("Contato")]
        public string contato { get; set; }

        [DisplayName("Telefone")]
        public string telefone { get; set; }

        [DisplayName("E-mail")]
        public string email { get; set; }

        [DisplayName("Segmento")]
        public Int32 idSegmento { get; set; }

        public string idVendedor { get; set; }

        [DisplayName("Situação")]
        public Int32 idSituacao { get; set; }

        [DisplayName("Atendimentos")]
        public string status { get; set; }

        [DisplayName("Situação Atual")]
        public string situacaoClienteVendendor { get; set; }

        [DisplayName("AD")]
        public Int32? Ad { get; set; }
        [DisplayName("OS")]
        public Int32? Os { get; set; }
        [DisplayName("TAPETE")]
        public Int32? tapete { get; set; }
        [DisplayName("ARO")]
        public Int32? aro { get; set; }
        [DisplayName("SECADOR")]
        public Int32? secador { get; set; }
        [DisplayName("FIO DENTAL")]
        public Int32? fioDental { get; set; }

        [DisplayName("Data Ligar")]
        public DateTime ligarNoFuturoData { get; set;  }


        public ClienteDTO()
        {
            this.ligarNoFuturoData = DateTime.Now;
        }
    }

   
}

