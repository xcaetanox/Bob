using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bobson.UI.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }



    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Esqueci minha senha")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve conter ao menos {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "A senha e confirmação não conferem.")]
        public string ConfirmPassword { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> ListaEstados { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> ListaTipoPessoas { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> ListaSexo { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Roles { get; set; }






        [Required]
        [Display(Name = "Setor")]
        public string Role { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Pessoa")]
        public string TipoPessoa { get; set; }

        [StringLength(14)]
        [Display(Name = "Cpf ou Cnpj")]
        public string CpfCnpj { get; set; }

        [StringLength(20)]
        [Display(Name = "Rg")]
        public string Rg { get; set; }

        [Display(Name = "Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [FragmenteDate]
        public System.DateTime DataNascimento
        {
            get
            {
                try
                { 
                return new System.DateTime(this.AnoNascimento, this.MesNascimento, this.DiaNascimento);
                }
                catch
                {
                    return System.DateTime.Today;
                }
            }

        }

        [Required]
        public int DiaNascimento { get; set; }

        [Required]
        public int MesNascimento { get; set; }

        [Required]
        public int AnoNascimento { get; set; }




        [StringLength(20)]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [StringLength(20)]
        [Display(Name = "Nascionalidade")]
        public string Nascionalidade { get; set; }

        [StringLength(20)]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [StringLength(1)]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [StringLength(20)]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [StringLength(100)]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [StringLength(10)]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [StringLength(20)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [StringLength(50)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [StringLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [StringLength(2)]
        [Display(Name = "Estado")]
        public string Uf { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone Residencial")]
        [DisplayFormat(DataFormatString = "{0:(##)####-####}", ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneResidencial { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular")]
        [DisplayFormat(DataFormatString = "{0:(##)#####-####}", ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneCelular { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone Comercial")]
        [DisplayFormat(DataFormatString = "{0:(##)####-####}", ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneComercial { get; set; }

    }

    public class EditViewModel
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> ListaEstados { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> ListaTipoPessoas { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> ListaSexo { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Roles { get; set; }

       
        [Display(Name = "Setor de Atuação")]
        public string Role { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [StringLength(1)]
        [Display(Name = "Tipo de Pessoa")]
        public string TipoPessoa { get; set; }

        [StringLength(14)]
        [Display(Name = "Cpf ou Cnpj")]
        public string CpfCnpj { get; set; }

        [StringLength(20)]
        [Display(Name = "Rg")]
        public string Rg { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public System.DateTime DataNascimento { get; set; }

        [StringLength(20)]
        [Display(Name = "Estado Civil")]
        public string EstadoCivil { get; set; }

        [StringLength(20)]
        [Display(Name = "Nascionalidade")]
        public string Nascionalidade { get; set; }

        [StringLength(20)]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [StringLength(1)]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [StringLength(20)]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [StringLength(100)]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [StringLength(10)]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [StringLength(20)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [StringLength(50)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [StringLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [StringLength(2)]
        [Display(Name = "Estado")]
        public string Uf { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone Residencial")]
        [DisplayFormat(DataFormatString = "{0:(##)####-####}", ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneResidencial { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular")]
        [DisplayFormat(DataFormatString = "{0:(##)#####-####}", ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneCelular { get; set; }

        [StringLength(20)]
        [Display(Name = "Telefone Comercial")]
        [DisplayFormat(DataFormatString = "{0:(##)####-####}", ApplyFormatInEditMode = true)]
        [DataType(DataType.PhoneNumber)]
        public string TelefoneComercial { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
