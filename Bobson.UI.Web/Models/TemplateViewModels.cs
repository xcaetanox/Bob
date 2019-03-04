using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bobson.Core.DTO;

namespace Bobson.UI.Web.Models
{


    public class GenericViewModel
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Mail Cliente")]
        [StringLength(256)]
        public string EmailCliente { get; set; }

        [Display(Name = "Cópia (Opcional)")]
        [DataType(DataType.EmailAddress)]
        [StringLength(256)]
        public string EmailCopia { get; set; }

        [Required]
        [System.Web.Mvc.AllowHtml]
        [StringLength(2000)]
        [Display(Name = "Corpo do E-Mail")]
        public string CorpoEmail { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Assunto do E-Mail")]
        public string TituloEmail { get; set; }

        public string ViewName { get; set; }
        public String CamposTexto_00 { get; set; }
        public String CamposTexto_01 { get; set; }
        public String CamposTexto_02 { get; set; }
        public String CamposTexto_03 { get; set; }
        public String CamposTexto_04 { get; set; }
        public String CamposTexto_05 { get; set; }
        public String CamposTexto_06 { get; set; }
        public String CamposTexto_07 { get; set; }
        public String CamposTexto_08 { get; set; }
        public String CamposTexto_09 { get; set; }
        public String CamposTexto_10 { get; set; }
        public String CamposTexto_11 { get; set; }
        public String CamposTexto_12 { get; set; }
        public String CamposTexto_13 { get; set; }
        public String CamposTexto_14 { get; set; }
        public String CamposTexto_15 { get; set; }
        public String CamposTexto_16 { get; set; }
        public String CamposTexto_17 { get; set; }
        public String CamposTexto_18 { get; set; }
        public String CamposTexto_19 { get; set; }

        public String CamposTexto_20 { get; set; }
        public String CamposTexto_21 { get; set; }
        public String CamposTexto_22 { get; set; }
        public String CamposTexto_23 { get; set; }
        public String CamposTexto_24 { get; set; }
        public String CamposTexto_25 { get; set; }
        public String CamposTexto_26 { get; set; }
        public String CamposTexto_27 { get; set; }
        public String CamposTexto_28 { get; set; }
        public String CamposTexto_29 { get; set; }
        public String CamposTexto_30 { get; set; }
        public String CamposTexto_31 { get; set; }
        public String Campo_assinatura { get; set; }

        public UsuariosDTO User = new UsuariosDTO();

        public ClienteDTO clienteSelecionado{ get; set; }
        public List<ClienteDTO> listaClientes = new List<ClienteDTO>();
        [Display(Name = "Cliente")]
        public Int32 idCliente { get; set; }


        public override string ToString()
        {
            return ToLigthString();
            //return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        private string ToLigthString()
        {
            GenericViewModel obj = (GenericViewModel)this.MemberwiseClone();

            obj.TituloEmail = String.Empty;
            obj.CorpoEmail = String.Empty;
            obj.EmailCliente = String.Empty;
            obj.EmailCopia = String.Empty;

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static GenericViewModel GetInstance(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GenericViewModel>(json);
        }

    }


    public class CabecalhoViewModel
    {
        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Cabeçalho")]
        public string Cabecalho { get; set; }

        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Rodapé")]
        public string Rodape { get; set; }

        public string Erro { get; set; }
        public string Sucesso { get; set; }
    }

    public class TemplateViewModel
    {
        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Cabeçalho padrão")]
        public string Cabecalho { get; set; }

        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Rodapé padrão")]
        public string Rodape { get; set; }

        [Display(Name = "Modelos Atuais")]
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Nome do Modelo")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Categoria do Modelo")]
        public int? Categoria { get; set; }

        public List<DDLDTO> Categorias { get; set; }

        public List<DDLDTO> ListaTemplates { get; set; }

        [Required]
        [System.Web.Mvc.AllowHtml]
        [Display(Name = "Modelo HTML")]
        public string Html { get; set; }

    }
}