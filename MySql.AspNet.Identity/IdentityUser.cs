using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace MySql.AspNet.Identity
{
    public class IdentityUser : IUser
    {
        public virtual string Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual DateTime? LockoutEndDate { get; set; }
        public virtual bool TwoFactorAuthEnabled { get; set; }
        public virtual List<string> Roles { get; set; }
        public virtual List<IdentityUserClaim> Claims { get; set; }
        public virtual List<UserLoginInfo> Logins { get; set; }


        //Customização

        public string Nome { get; set; }
        public string TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public System.DateTime DataNascimento { get; set; }
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
        public Int32? IdUsuario { get; set; }

        public IdentityUser()
        {
            this.Claims = new List<IdentityUserClaim>();
            this.Roles = new List<string>();
            this.Logins = new List<UserLoginInfo>();
            this.Id = Guid.NewGuid().ToString();
            LockoutEnabled = true;
        }

        public IdentityUser(string userName)
            : this()
        {
            this.UserName = userName;
        }
    }

    public sealed class IdentityUserLogin
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Provider { get; set; }
        public string ProviderKey { get; set; }
    }

    public class IdentityUserClaim
    {
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
    }
}
