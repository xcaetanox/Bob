using Bobson.Core.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bobson.Core.DTO
{
    public class StatusCliente : BaseDTO
    {
        [Key]
        public Int32 Id { get; set; }

        public string descricao { get; set; }

        public StatusCliente()
        {

        }
    }
}

