using Bobson.Core.DTO;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class AtendimentoClienteDTO : BaseDTO
    {
        [Key]
       
        public Int32 Id { get; set; }

        [DisplayName("Data Contato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dataContato { get; set; }

        
        public string tipo { get; set; }

        [DisplayName("Obs.:")]
        public string obs { get; set; }

        [DisplayName("Data Ocorrência")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dataVisita { get; set; }

        [DisplayName("Hora Inicial")]
        public string horaIni { get; set; }

        [DisplayName("Hora Fim")]
        public string horaFim { get; set; }

        [DisplayName("Código Cliente")]
        public int idCliente { get; set; }


        public string idVendedor { get; set; }

        [DisplayName("tipo")]
        public Int32 idTipoAtendimento { get; set; }
        //coluna para o relatorio de performance
        public string descricaoTipo { get; set; }

        public string status { get; set; }

        public string logintude { get; set; }
        public string latitude { get; set; }

        public string logintude_casa { get; set; }
        public string latitude_casa { get; set; }



        public AtendimentoClienteDTO()
        {

        }
    }

   
}

