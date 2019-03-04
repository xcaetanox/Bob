using System;
using System.ComponentModel;
using System.Collections.Generic;
using Bobson.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace Bobson.UI.Web
{
    public class ClienteViewModel
    {


        public ClienteDTO cliente { get; set; }

        public List<ClienteDTO> clientes { get; set; }

        public List<SegmentoDTO> sgmentos { get; set; }

        public Int32 idSgmento { get; set; }

       




    }
}

