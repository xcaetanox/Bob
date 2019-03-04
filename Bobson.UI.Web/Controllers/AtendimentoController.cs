using Bobson.Core.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Bobson.Core.DTO;

namespace Bobson.UI.Web.Controllers
{
    public class AtendimentoController : Controller
    {


        public ActionResult Index()
        {



            AtendimentoViewModel model = new AtendimentoViewModel();
            AtendimentoDAO dao = new AtendimentoDAO();


            string idUser = User.Identity.GetUserId();

          

            //pegar aqui o usuario long e lat
  

            string id = Session["idCliente"].ToString();

            model.nomeCliente = Session["nomeCliente"].ToString();

            model.tiposAtendimento = new TipoAtendimentoDAO().listarTipoAtendimento();

            model.atendimentoClienteDTOs = dao.buscaHistoricoAtendimento(id, idUser);

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult salvar(AtendimentoClienteDTO atendimento)
        {
            AtendimentoViewModel model = new AtendimentoViewModel();
            AtendimentoDAO dao = new AtendimentoDAO();

            string idUser = User.Identity.GetUserId();

            atendimento.idVendedor = idUser;
            atendimento.idCliente = Convert.ToInt32(Session["idCliente"].ToString());


            if (atendimento.Id == 0)
            {
                dao.Salvar(atendimento);
            }
            else
            {
                dao.Atualizar(atendimento);

            }


            model.tiposAtendimento = new TipoAtendimentoDAO().listarTipoAtendimento();


            model.atendimentoClienteDTOs = dao.buscaHistoricoAtendimento(Session["idCliente"].ToString(), idUser);


            return RedirectToAction("Index");
        }


        public ActionResult EditarAtendimento(string id)
        {


            AtendimentoViewModel modedetail = new AtendimentoViewModel();

            AtendimentoDAO dao = new AtendimentoDAO();



            modedetail.tiposAtendimento = new TipoAtendimentoDAO().listarTipoAtendimento();

            AtendimentoClienteDTO cliente = new AtendimentoDAO().buscaAtendimento(id);
            modedetail.atendimento = dao.buscaAtendimento(id);


            return View("EditarAtendimento", modedetail);
        }

        public ActionResult AbreMapa(string id)
        {
            AtendimentoViewModel modedetail = new AtendimentoViewModel();

            AtendimentoDAO dao = new AtendimentoDAO();



            modedetail.tiposAtendimento = new TipoAtendimentoDAO().listarTipoAtendimento();

            AtendimentoClienteDTO cliente = new AtendimentoDAO().buscaAtendimento(id);
            modedetail.atendimento = dao.buscaAtendimento(id);




            return View("AbreMapa", modedetail);
        }


        public ActionResult proximoCliente()
        {
            string idUser = User.Identity.GetUserId();

            string id = Session["idCliente"].ToString();

            AtendimentoDAO dao = new AtendimentoDAO();


            ClienteDTO cliente = dao.proximoCliente(id, idUser);

            if (cliente.nome_cliente != null)
            {

                Session["idCliente"] = cliente.Id;
                Session["nomeCliente"] = cliente.nome_cliente;
            }

            return RedirectToAction("Index");
        }


    }
}