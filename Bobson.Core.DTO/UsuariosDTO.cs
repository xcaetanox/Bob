using Bobson.Core.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class UsuariosDTO : BaseDTO
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string Nascionalidade { get; set; }
        public string Profissao { get; set; }
        public string Sexo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public string TelefoneComercial { get; set; }
        public string Status { get; set; }
        public string Cargo { get; set; }

        public string Role { get; set; }


        public string longitude_casa { get; set; }
        public string latitude_casa { get; set; }

        public UsuariosDTO()
        {

        }
    }

   
}

