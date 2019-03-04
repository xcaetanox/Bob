using Bobson.Core.DAO;
using Bobson.Core.DTO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Controllers
{
    public class DashController : Controller
    {
        private ClienteDAO  dao = new ClienteDAO();
        private ClienteViewModel model = new ClienteViewModel();

       // lista todos os clientes do vendedor logado
        
        public ActionResult Index()
        {
           
            string idUser = User.Identity.GetUserId();
            

            model.clientes = dao.AtualizaStatus(dao.ListarClientes(idUser));

            model.sgmentos = new SegmentoDAO().ListarSgmentos();


            return View("Index", model);
        }


        public ActionResult DetalheCliente(string id)
        {
            ClienteDTO cliente = new ClienteDAO().buscarCliente(id);

            ClienteViewModel modeDetail = new ClienteViewModel();

            modeDetail.cliente = cliente;
            modeDetail.idSgmento = cliente.idSegmento;
            modeDetail.sgmentos = new SegmentoDAO().ListarSgmentos();

            return View("DetalheCliente", modeDetail);
        }


        public ActionResult AtendimentoCliente(int id,string nome)
        {
            Session["idCliente"] = id;

            Session["nomeCliente"] = nome;

            return RedirectToAction("Index", "Atendimento");
        }


        public ActionResult editarcliente(string id)
        {
            ClienteDTO cliente = new ClienteDAO().buscarCliente(id);

            ClienteViewModel modedetail = new ClienteViewModel();

            modedetail.cliente = cliente;
            modedetail.sgmentos = new SegmentoDAO().ListarSgmentos();

            return View("editarcliente", modedetail);
        }


        [HttpPost]
        public ActionResult SalvaCliente(ClienteDTO cliente)
        {
            
            string idUser = User.Identity.GetUserId();

            cliente.idVendedor = idUser; 
           //aa
            if (cliente.Id == 0){
                 model.clientes = dao.SalvarCliente(cliente);
            }   
            else
            {
                model.clientes = dao.AtualizarCliente(cliente);
            }

          
            model.clientes = dao.ListarClientes(idUser);


            model.sgmentos = new SegmentoDAO().ListarSgmentos();


            return View("Index", model);
        }


        //public ActionResult AtendimentoCliente(string id)
        //{

        //    ClienteDTO cliente = new ClienteDAO().buscarCliente(id);

        //    ClienteViewModel modeDetail = new ClienteViewModel();

        //    modeDetail.cliente = cliente;
        //    modeDetail.idSgmento = cliente.idSegmento;
        //    modeDetail.atendimentos = new AtendimentoDAO().buscaHistoricoAtendimento(cliente.Id);


                         
        //    return View("AtendimentoCliente", modeDetail);

        //}
      

    }
}