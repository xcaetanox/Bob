using System;

namespace Bobson.Core.DTO
{
    public class LogDTO : BaseDTO
    {
        public Decimal Id { get; set; }

        public DateTime Data { get; set; }

        public String Mensagem { get; set; }

        public LogDTO(Decimal id, DateTime data, String mensagem)
        {
            this.Id = id;
            this.Data = data;
            this.Mensagem = mensagem;
        }
    }
}

