using Bobson.Core.DAO;
using Bobson.Core.DTO;
using Bobson.UI.Web.Models;
using Microsoft.AspNet.Identity;
using MySql.AspNet.Identity;
using MySql.AspNet.Identity.Repositories;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace Bobson.UI.Web.Controllers
{
    public class RelAtendimentoController : Controller
    {

        public  PerformanceUsuarioViewModel model = new PerformanceUsuarioViewModel();
        private ApplicationUserManager _userManager;
        public static DateTime dataInicial;
        public static DateTime dataFinal;
        // GET: RelAtendimento
        public async Task<ActionResult> Index()
        {


            model.gerenteAdm = false;
            model.usuarios = null;
            string idUsuario = "";

           UsuariosDAO userDao = new UsuariosDAO();
            model.usuarios = userDao.ListarUsuarios(" aspnetroles.Name = \"Comercial\"");

           idUsuario = User.Identity.GetUserId();


            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user.Result.Roles.Contains("Gerente") || user.Result.Roles.Contains("Admin"))
            {
                model.gerenteAdm = true;
            }

           


            return View(model);
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        public ActionResult FiltraPerfomance(DateTime dtInicio, DateTime dtFim, string idUsuario)
        {
            //limpa o model
            model = new PerformanceUsuarioViewModel();
            model.clientes = new List<ClienteDTO>();
            model.atendimentos = new List<AtendimentoClienteDTO>();
          
            dataInicial = dtInicio;
            dataFinal = dtFim;


            if (idUsuario==null)
            {
                idUsuario = User.Identity.GetUserId();
            }

            UsuariosDAO userdao = new UsuariosDAO();

            model.usuariosGrid.Add(userdao.LoginEmailApp("", idUsuario));
            model.usuarioSelecionado = model.usuariosGrid.Last<UsuariosDTO>();


            Session["idCliente"] = model.usuarioSelecionado.Id;

            ClienteDAO clienteDAO = new ClienteDAO();
            foreach (var clie in clienteDAO.ListarClientes(idUsuario,false))
            {
                model.clientes.Add(clie);

                if (clie.situacaoClienteVendendor =="NEGOCIANDO" || clie.situacaoClienteVendendor  == "TESTE")
                {
                    model.totalClienteNegociando++;
                    model.totalAD += clie.Ad;
                    model.totalOS += clie.Os;
                    model.totalTAPETE += clie.tapete;
                    model.totalAro += clie.aro;
                }

            }
            model.totalMaquinaNegociando = model.totalAD + model.totalOS + model.totalTAPETE+model.totalAro;


            AtendimentoDAO atendimentoDAO = new AtendimentoDAO();

            TipoAtendimentoDAO tipoAtendimentoDAO = new TipoAtendimentoDAO();

           

            foreach (var cliente in model.clientes)
            {
                foreach (var atendi in  atendimentoDAO.listaAtendimentoPorCliente(cliente.Id,dtInicio,dtFim))
                {
                    atendi.descricaoTipo = tipoAtendimentoDAO.BuscarTipo(atendi.idTipoAtendimento).descricao;

                    if (atendi.idTipoAtendimento==3)
                    {
                        model.totalOrcamentos++;
                    }


                    atendi.logintude_casa = model.usuarioSelecionado.longitude_casa.ToString();
                    atendi.latitude_casa = model.usuarioSelecionado.latitude_casa.ToString();


                    model.atendimentos.Add(atendi);
                }    

            }


            model.performanceDia = atendimentoDAO.getPerformanceDia(dtInicio, dtFim, idUsuario);

            DateTime dataUsada = DateTime.Today.Date;

            
            foreach (var datas in model.performanceDia)
            {
                

                if (dataUsada.Date != datas.data.Date)
                {
                    RelPerformanceTotaisDTO datasTotais = new RelPerformanceTotaisDTO();
                    dataUsada = datas.data.Date;

                    if (datas.tipo =="Visita")
                    {
                        datasTotais.totalVisita++;
                        
                    }else if (datas.tipo == "Ligação")
                    {
                        datasTotais.totalLiga++;
                    }

                    datasTotais.data = datas.data.Date;
                    model.listaDatas.Add(datasTotais);
                }
                else
                {

                    if (datas.tipo == "Visita")
                    {
                        model.listaDatas.Last<RelPerformanceTotaisDTO>().totalVisita++;

                    }
                    else if (datas.tipo == "Ligação")
                    {
                        model.listaDatas.Last<RelPerformanceTotaisDTO>().totalLiga++;
                    }
                    
                }
            }



           

        


            UsuariosDAO userDao = new UsuariosDAO();
            model.usuarios = null;

            model.usuarios  = userDao.ListarUsuarios();

            var user = UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user.Result.Roles.Contains("Gerente") || user.Result.Roles.Contains("Admin"))
            {
                model.gerenteAdm = true;
            }


            Session["ModelPerfomance"] = model;
            return View("index",model);
        }



        public ActionResult PDFConfigurado()
        {
          

            model = Session["ModelPerfomance"] as PerformanceUsuarioViewModel;


            model.isPdf = true;


            model.dtFim = dataFinal;
            model.dtInicio = dataInicial;

            var pdf = new ViewAsPdf
            {
                ViewName = "Index",
                FileName = model.usuarioSelecionado.Nome+".pdf",
                PageSize = Size.A4,
               
                PageMargins = new Margins { Bottom = 0, Left = 0, Right =0 , Top = 0 },
                Model = model
            };

            model.isPdf = false;
            return pdf;
        }

       


    }
}