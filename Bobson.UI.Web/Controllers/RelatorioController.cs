using Bobson.Core.Base;
using Bobson.Core.DAO;
using Bobson.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Controllers
{
   
    [Authorize(Roles = Core.Base.Config.Roles.Gerente)]
    public class RelatorioController : Controller
    {
        public ActionResult RegistroDeOcorrencias()
        {
            ModelState.Remove("EstadoDefault");
            ModelState.Remove("CodigoCliente");
            var model = new RegistroDeOcorrenciasViewModel();
            var dao = new ArosDAO();
            model.Estados = dao.ListarUF();
            model.Conexao = dao.Connection;
            return View(model);
        }

        public ActionResult ExecutarRelatorioOcorrencias(RegistroDeOcorrenciasViewModel model)
        {
            ModelState.Remove("EstadoDefault");
            ModelState.Remove("CodigoCliente");

            var dao = new ArosDAO();
            model.Estados = dao.ListarUF();
            model.Ocorrencias = dao.RelatorioOcorrencias(model.EstadoDefault, Convert.ToInt32(model.CodigoCliente));
            model.Conexao = dao.Connection;
            return View("RegistroDeOcorrencias",model);
        }

        public ActionResult LogPropostas()
        {
            var model = new LogPropostaViewModel();
            var dao = new ArosDAO();
            model.Usuarios = dao.ListarUsuarios(Config.Roles.Comercial.Replace(",Admin",""));
            model.Usuarios.AddRange(dao.ListarUsuarios(Config.Roles.Gerente));
            model.DataInicio = DateTime.Today.AddMonths(-1);
            model.DataFim = DateTime.Today;
            model.Conexao = dao.Connection;
            return View(model);
        }

        public ActionResult ExecutarLogPropostas(LogPropostaViewModel model)
        {
            var dao = new ArosDAO();
            model.Usuarios = dao.ListarUsuarios(Config.Roles.Comercial.Replace(",Admin", ""));
            model.Usuarios.AddRange(dao.ListarUsuarios(Config.Roles.Gerente));
            model.Propostas = dao.LogPropostas(model.Usuario, model.DataInicio, model.DataFim);
            model.Conexao = dao.Connection;
            return View("LogPropostas", model);
        }

        [ValidateInput(false)]
        public ActionResult StartView(string id, string modelParam)
        {
            return RedirectToAction("StartViewRelatorio", "Template", new { ID = id, modelParam = modelParam});
            
            
        }

        public ActionResult RemessasExcluidas()
        {
            var model = new RemessasExcluidasViewModel();
            var dao = new ArosDAO();
            model.DataInicio = DateTime.Today.AddMonths(-1);
            model.DataFim = DateTime.Today;
            model.Conexao = dao.Connection;
            return View(model);
        }

        public ActionResult ExecutarRemessasExcluidas(RemessasExcluidasViewModel model)
        {
            var dao = new ArosDAO();
            model.Remessas = dao.RemessasExcluidas(model.DataInicio, model.DataFim);
            model.Conexao = dao.Connection;
            return View("RemessasExcluidas", model);
        }

    }
}