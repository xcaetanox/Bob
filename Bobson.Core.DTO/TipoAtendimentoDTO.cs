using Bobson.Core.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class TipoAtendimentoDTO : BaseDTO
    {
        [Key]
        public string Id { get; set; }

        public string descricao { get; set; }

        public string completo { get; set; }

        public TipoAtendimentoDTO()
        {

        }
    }

   
}

