using Bobson.Core.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class SituacaoDTO : BaseDTO
    {
        [Key]
        public string Id { get; set; }

        public string descricao { get; set; }

        public SituacaoDTO()
        {

        }
    }
}

