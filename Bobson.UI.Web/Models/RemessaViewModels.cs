using Bobson.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bobson.UI.Web
{
    public class RemessaViewModel
    {
        [Display(Name = "Seu Local")]
        public int Local { get; set; }
        
        [Display(Name = "Ultimos")]
        public int Dia { get; set; }

        public List<DDLDTO> Filiais { get; set; }

        public List<DDLDTO> Transportes { get; set; }

        public List<DDLDTO> Dias { get; set; }

        public List<RemessaDTO> Enviados { get; set; }

        public List<RemessaDTO> Recebidos { get; set; }


        public int Origem { get; set; }

        [Display(Name = "De Onde")]
        public String DescricaoOrigem { get; set; }

        [Required]
        [Display(Name = "Para Onde")]
        public int Destino { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Quem Envia")]
        public String ResponsavelEnvio { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Quem Recebe")]
        public String ResponsavelRecebimento { get; set; }

        [Required]
        [Display(Name = "Forma de Envio")]
        public int FormaEnvio { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Conhecimento")]
        public String NumeroControle { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição do Objeto")]
        public String DescricaoObjeto { get; set; }

        [StringLength(500)]
        [Display(Name = "Observações")]
        public String Observacoes { get; set; }

        public string NovoRegistro { get; set; }

        public RemessaViewModel()
        {

        }
    }
}