using System;
using System.Web.Mvc;
using System.Collections.Generic;
using Bobson.Core.DTO;
using Bobson.Core.DAO;
using Microsoft.AspNet.Identity;

namespace Bobson.UI.Web.Controllers
{
    [Authorize(Roles = Core.Base.Config.Roles.GerenteMaisTecnico)]
    public class ArosController : Controller
    {
        public ActionResult Index()
		{
			ArosViewModel model = new ArosViewModel();
			model.Estados = new ArosDAO().ListarUF();
			model.EstadoDefault = "SP";

			return View("Index", model);
		}

		public ActionResult VoltarParaIndex(ArosViewModel model)
        {
			model.Estados = new ArosDAO().ListarUF();
			return View("Index", model);
		}


		[HttpPost]
        public ActionResult Banheiro(ArosViewModel model)
        {
            ModelState.Remove("Local");
            ModelState.Remove("Tipo");

            model.Local = "";
            model.Tipo = "";
            model.Banheiros = new ArosDAO().ListarBanheiros(model.EstadoDefault, int.Parse(model.CodigoCliente));

            return View("Banheiro", model);
        }


        [HttpPost]
        public ActionResult Maquina(ArosViewModel model)
        {
            ModelState.Remove("EquipamentoId");
            ModelState.Remove("EquipamentoDescricao");
            ModelState.Remove("Funcionamento");
            ModelState.Remove("Aroma");
            ModelState.Remove("Solta");
            ModelState.Remove("Para");

            model.EquipamentoId = 0;
            model.EquipamentoDescricao = "";
            model.Funcionamento = "";
            model.Aroma = "";
            model.Solta = "";
            model.Para = "";

            model.Maquinas = new ArosDAO().ListarMaquinas(model.EstadoDefault, int.Parse(model.CodigoCliente), model.Local, model.Tipo);
            return View("Maquina", model);
        }


        [HttpPost]
        public ActionResult Historico(ArosViewModel model)
        {
            ModelState.Remove("EquipamentoId");
            ModelState.Remove("EquipamentoDescricao");
            ModelState.Remove("Funcionamento");
            ModelState.Remove("Aroma");
            ModelState.Remove("Solta");
            ModelState.Remove("Para");
            ModelState.Remove("Local");
            ModelState.Remove("Tipo");

            model.Historico = new ArosDAO().Listar(new ArosDTO { CodigoEquipamento = model.EquipamentoId }); 
            return View("Historico", model);
        }

		[HttpPost]
		public ActionResult Registro(ArosViewModel model)
		{
            model.Locais = new ArosDAO().LocaisMaquina();
            model.Servicos = new ArosDAO().Servicos();


            ModelState.Remove("EquipamentoId");
            ModelState.Remove("EquipamentoDescricao");
            ModelState.Remove("Funcionamento");
            ModelState.Remove("Aroma");
            ModelState.Remove("Solta");
            ModelState.Remove("Para");
            ModelState.Remove("Local");
            ModelState.Remove("Tipo");

            return View("Registro", model);
		}

		[HttpPost]
		public ActionResult EfetuarRegistro(ArosViewModel model)
		{
			ArosDAO dao = new ArosDAO();
			dao.Salvar(new ArosDTO
			{
                Estado = model.EstadoDefault,
                CodigoCliente = Convert.ToInt32(model.CodigoCliente),
                CodigoEquipamento = model.EquipamentoId,
                Acontecimento = model.ServicoSelecionado,
                PesoRefil = model.PesoRefil,
                Observacoes = model.LocalSelecionado,
                UsuarioId = User.Identity.GetUserId()
            });


            ModelState.Remove("EquipamentoId");
            ModelState.Remove("EquipamentoDescricao");
            ModelState.Remove("Funcionamento");
            ModelState.Remove("Aroma");
            ModelState.Remove("Solta");
            ModelState.Remove("Para");
            ModelState.Remove("Local");
            ModelState.Remove("Tipo");

            return VoltarParaIndex(new ArosViewModel
            { 
                NovoRegistro = "block",
                EstadoDefault = "SP",
                CodigoCliente = "",

		    });
		}


        

        public JsonResult ListarBanheiros(int? clienteId, string estado)
        {
            string body = "";

            ArosDAO dao = new ArosDAO();

            List<ArosDTO> lst = dao.ListarBanheiros(estado, (int)clienteId);

            foreach (ArosDTO item in lst)
            {
                body = body + item.ToBanheiroTr();
            }

            return Json(new { id = ArosDTO.IdBanheiroTable, html = ArosDTO.ToBanheiroTable(body) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarMaquinas(int? clienteId, string estado, string local)
        {
            string body = "";
            ArosDAO dao = new ArosDAO();

            List<ArosDTO> lst = dao.ListarMaquinas(estado, (int)clienteId, local.Split('|')[0].Trim(), local.Split('|')[1].Trim());

            foreach (ArosDTO item in lst)
            {
                body = body + item.ToMaquinaTr();
            }

            return Json(new { id = ArosDTO.IdMaquinaTable, html = ArosDTO.ToMaquinaTable(body) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHistorico(string estado, int? clienteId, int? equipamentoId)
        {
            string body = "";

            List<ArosDTO> lst = new ArosDAO().Listar(new ArosDTO { CodigoEquipamento = (int)equipamentoId });

            foreach (ArosDTO item in lst)
            {
                body += item.ToHistoricoTr();
            }

            return Json(new { id = ArosDTO.IdHistoricoTable, html = ArosDTO.ToHistoricoTable(body) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Registrar(int? cliente, string estado, int equipamento, string acontecimento, string peso, string obs)
        {

            ArosDAO dao = new ArosDAO();
            dao.Salvar(new ArosDTO
            {
                Estado = estado,
                CodigoCliente = (int)cliente,
                CodigoEquipamento = (int)equipamento,
                Acontecimento = acontecimento,
                PesoRefil = peso,
                Observacoes = obs,
                UsuarioId = User.Identity.GetUserId()
            });

            return Json(new { retorno = "Registro Efetuado" }, JsonRequestBehavior.AllowGet);
        }

    }
}

