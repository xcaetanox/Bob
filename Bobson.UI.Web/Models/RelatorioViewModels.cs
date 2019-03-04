using Bobson.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Bobson.UI.Web.Models
{
    public class RegistroDeOcorrenciasViewModel
    {
        public List<DDLDTO> Estados { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string EstadoDefault { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public String CodigoCliente { get; set; }

        public IDataReader Ocorrencias { get; set; }

        public IDbConnection Conexao { get; set; }
    }


    public class LogPropostaViewModel
    {
        public List<DDLDTO> Usuarios { get; set; }

        [Required]
        [Display(Name = "Representante")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Data Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataInicio { get; set; }

        [Required]
        [Display(Name = "Data Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataFim { get; set; }


        public IDataReader Propostas { get; set; }

        public IDbConnection Conexao { get; set; }
    }

    public class RemessasExcluidasViewModel
    {
        [Required]
        [Display(Name = "Data Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataInicio { get; set; }

        [Required]
        [Display(Name = "Data Fim")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataFim { get; set; }


        public IDataReader Remessas { get; set; }

        public IDbConnection Conexao { get; set; }
    }
}