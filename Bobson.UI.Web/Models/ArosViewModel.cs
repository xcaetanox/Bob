using System;
using System.ComponentModel;
using System.Collections.Generic;
using Bobson.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace Bobson.UI.Web
{
    public class ArosViewModel
    {
		public string NovoRegistro { get; set; }

		[Display(Name = "Local")]
		public string LocalSelecionado { get; set; }

		[Display(Name = "Ação")]
		public string ServicoSelecionado { get; set; }

		[Display(Name = "Peso do Refil")]
		public string PesoRefil { get; set; }

		public List<DDLDTO> Locais { get; set; }
		public List<DDLDTO> Servicos { get; set; }

        public List<ArosDTO> Banheiros { get; set; }
        public List<ArosDTO> Maquinas { get; set; }

        public List<ArosDTO> Historico { get; set; }

		
		public int EquipamentoId { get; set; }

        [Required(ErrorMessage = "Volte e selecione o Equipamento")]
        public string EquipamentoDescricao { get; set; }

        public string Funcionamento { get; set; }
        public string Aroma         { get; set; }
        public string Solta         { get; set; }
        public string Para          { get; set; }

        public string IdentificacaoLancamento
        {
            get
            {
                return "  " + this.EstadoDefault + "-" + this.CodigoCliente + " [" + this.Local + ":" + this.Tipo + "]";
            }
        }

		public string IdentificacaoLancamentoSmall
		{
			get
			{
                return "  " + "Funcionamento:" + this.Funcionamento + " " + this.Aroma + " Solta Névoa:" + this.Solta + " Para:" + this.Para;
			}

		}

        [Required(ErrorMessage ="Volte e selecione o Banheiro")]
        public string Local { get; set; }
        public string Tipo { get; set; }
   
        public List<String> Paginas { get; set; }

        public List<DDLDTO> Estados { get; set; }

		[Display(Name = "Estado")]
        public string EstadoDefault { get; set; }

		[Display(Name = "Cliente")]
        [Required]
        public String CodigoCliente { get; set; }


        public ArosViewModel()
        {
            this.NovoRegistro = "none";
        }
    }


    public class ArosSyncViewModel
    {
        [Required]
        [Display(Name ="Arquivo Aros")]
        public System.Web.HttpPostedFileBase ArquivoSistemaAcess { get; set; }

        public bool? Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}

