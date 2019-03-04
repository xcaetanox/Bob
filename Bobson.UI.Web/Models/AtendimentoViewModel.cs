using System;
using System.ComponentModel;
using System.Collections.Generic;
using Bobson.Core.DTO;
using System.ComponentModel.DataAnnotations;


namespace Bobson.UI.Web
{
    public class AtendimentoViewModel
    {


        public AtendimentoClienteDTO atendimento { get; set; }

        public List<AtendimentoClienteDTO> atendimentoClienteDTOs { get; set; }

        public List<TipoAtendimentoDTO> tiposAtendimento { get; set; }

        public Int32 idTipoAtendimento { get; set; }

        public string completo { get; set; }

        public string nomeCliente { get; set; }



    }
}

