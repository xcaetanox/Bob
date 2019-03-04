using Bobson.Core.DTO;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class ConfigUsuarioEmailDTO : BaseDTO
    {
        [Key]
        public string id { get; set; }
        public string id_usuario { get; set; }
        [DisplayName("Login E-email")]
        public string nome_usuario { get; set; }
        [DisplayName("Senha E-mail")]
        public string senha_usuario { get; set; }
        

        public ConfigUsuarioEmailDTO()
        {

        }
    }

   
}

