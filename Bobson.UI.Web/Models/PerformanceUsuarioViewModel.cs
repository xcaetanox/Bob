using System;
using System.ComponentModel;
using System.Collections.Generic;
using Bobson.Core.DTO;
using System.ComponentModel.DataAnnotations;


namespace Bobson.UI.Web
{
    public class PerformanceUsuarioViewModel
    {


        public string IdUsuario;
        public bool gerenteAdm = false;
        public bool isPdf = false;

        public List<UsuariosDTO> usuarios = new List<UsuariosDTO>();

        

        public List<UsuariosDTO> usuariosGrid = new List<UsuariosDTO>();
        public UsuariosDTO usuarioSelecionado = new UsuariosDTO();


        public List<ClienteDTO> clientes = new List<ClienteDTO>();
        public List<AtendimentoClienteDTO> atendimentos = new List<AtendimentoClienteDTO>();

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime dtInicio =  DateTime.Today.Date;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime dtFim = DateTime.Today.Date;



        public List<RelPerformanceDTO> performanceDia = new List<RelPerformanceDTO>();
        public List<RelPerformanceTotaisDTO> listaDatas = new List<RelPerformanceTotaisDTO>();
        public List<RelPerformanceDTO> performanceTratadaGrid = new List<RelPerformanceDTO>();


        public int totalClienteNegociando = 0;
        public int? totalMaquinaNegociando = 0;

        public int? totalAD = 0;
        public int? totalOS = 0;
        public int? totalTAPETE = 0;
        public int? totalOrcamentos = 0;
        public int? totalAro = 0;





    }
}

