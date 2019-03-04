using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bobson.Core.DTO;
using Bobson.Core.DAO;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bobson.UI.Web.Controllers
{
    [Authorize(Roles = Core.Base.Config.Roles.GerenteMaisEscritorio)]
    public class RemessaController : Controller
    {
        public ActionResult Index()
        {
            ArosDAO dao = new ArosDAO();

            RemessaViewModel model = new RemessaViewModel();
            model.ResponsavelEnvio = "";
            model.NovoRegistro = "none";
            model.Filiais = dao.ListarFiliais();
            model.Transportes = dao.ListarTransportes();
            model.Dias = PreencherDias();

            model.ResponsavelEnvio = Nome45UsuarioLogado();

            HttpCookie cookie = HttpContext.Request.Cookies["Filtro"];

            if (cookie == null)
            {
                cookie = new HttpCookie("Filtro", "-14|" + model.Filiais[0].Id);
                cookie.Expires = DateTime.Now.AddDays(365);
                cookie.HttpOnly = true;
                HttpContext.Response.SetCookie(cookie);

                model.Local = Convert.ToInt32(model.Filiais[0].Id);
                model.Dia = -14;
            }
            else
            {
                model.Local = Convert.ToInt32(cookie.Value.Split('|')[1]);
                model.Dia = Convert.ToInt32(cookie.Value.Split('|')[0]);
            }

            model.Origem = model.Local;
            DDLDTO obj = model.Filiais.Where(i => i.Id.Trim().Equals(model.Local.ToString().Trim())).FirstOrDefault();
            model.DescricaoOrigem = obj == null ? "" : obj.Desc;

            List<RemessaDTO> lst = dao.ListarRemessas(model.Local, DateTime.Today.AddDays(model.Dia), DateTime.Today);

            model.Recebidos = FiltrarRecebidos(lst, model.Local);
            model.Enviados = FiltrarEnviados(lst, model.Local);

            return View(model);
        }

        private string Nome45UsuarioLogado()
        {
            var userId = User.Identity.GetUserId();
            var user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);

            string resp = user.Nome;

            if (resp.Length > 45)
                resp = resp.Substring(0, 44);

            return resp;
        }

        [HttpPost]
        public ActionResult Index(RemessaViewModel model)
        {
            ArosDAO dao = new ArosDAO();

            ModelState.Remove("Observacoes");
            ModelState.Remove("DescricaoObjeto");
            ModelState.Remove("ResponsavelEnvio");
            ModelState.Remove("ResponsavelRecebimento");
            ModelState.Remove("NumeroControle");
            ModelState.Remove("FormaEnvio");
            ModelState.Remove("Destino");

            model.Transportes = dao.ListarTransportes();
            model.Filiais = dao.ListarFiliais();
            model.Dias = PreencherDias();
            model.NovoRegistro = "none";

            List<RemessaDTO> lst = dao.ListarRemessas(model.Local, DateTime.Today.AddDays(model.Dia), DateTime.Today);

            model.Recebidos = FiltrarRecebidos(lst, model.Local);
            model.Enviados = FiltrarEnviados(lst, model.Local);

            model.Origem = model.Local;
            DDLDTO obj = model.Filiais.Where(i => i.Id.Trim().Equals(model.Local.ToString().Trim())).FirstOrDefault();
            model.DescricaoOrigem = obj == null ? "" : obj.Desc;

            HttpCookie cookie = new HttpCookie("Filtro", model.Dia + "|" + model.Local);
            cookie.Expires = DateTime.Now.AddDays(365);
            cookie.HttpOnly = true;
            HttpContext.Response.SetCookie(cookie);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Criar(RemessaViewModel model)
        {
            ArosDAO dao = new ArosDAO();

            int id = dao.SalvarRemessa(new RemessaDTO
            {
                NumeroControle = model.NumeroControle,
                Origem = model.Origem,
                ResponsavelEnvio = model.ResponsavelEnvio,
                Destino = model.Destino,
                ResponsavelRecebimento = model.ResponsavelRecebimento,
                FormaEnvio = model.FormaEnvio,
                DescricaoObjeto = model.DescricaoObjeto,
                Observacoes = model.Observacoes,
                UsuarioId = User.Identity.GetUserId()
            });

            model.Transportes = dao.ListarTransportes();
            model.Filiais = dao.ListarFiliais();
            model.Dias = PreencherDias();

            ModelState.Remove("Observacoes");
            ModelState.Remove("DescricaoObjeto");
            ModelState.Remove("ResponsavelEnvio");
            ModelState.Remove("ResponsavelRecebimento");
            ModelState.Remove("NumeroControle");
            ModelState.Remove("FormaEnvio");
            ModelState.Remove("Destino");

            HttpCookie cookie = HttpContext.Request.Cookies["Filtro"];

            if (cookie != null)
            {
                model.Local = Convert.ToInt32(cookie.Value.Split('|')[1]);
                model.Dia = Convert.ToInt32(cookie.Value.Split('|')[0]);
            }

            List<RemessaDTO> lst = dao.ListarRemessas(model.Local, DateTime.Today.AddDays(model.Dia), DateTime.Today);

            model.Recebidos = FiltrarRecebidos(lst, model.Local);
            model.Enviados = FiltrarEnviados(lst, model.Local);

            model.Origem = model.Local;
            DDLDTO obj = model.Filiais.Where(i => i.Id.Trim().Equals(model.Local.ToString().Trim())).FirstOrDefault();
            model.DescricaoOrigem = obj == null ? "" : obj.Desc;

            model.NumeroControle = String.Empty;
            model.ResponsavelEnvio = Nome45UsuarioLogado();
            model.DescricaoObjeto = String.Empty;
            model.Observacoes = String.Empty;

            model.NovoRegistro = "block";

            var callbackUrl = Url.Action("Index", "Remessa", routeValues: null, protocol: Request.Url.Scheme);

            await ServicosLocais.EnviarEmailAsync(
                new System.Net.Mail.MailAddress(dao.ObterEmail(model.Destino), model.Filiais.Where(f=> f.Id.Equals(model.Destino.ToString())).Select(f=>f.Desc).ToString() ), 
                null, 
                "Nova Remessa vindo de: " + model.DescricaoOrigem, "Clique " + String.Format("<a href=\"{0}\">{1}</a>", callbackUrl, "aqui")  + " para mais informações.", true);

            return View("Index", model);
        }

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Editar(string id, string objeto)
		{
			new ArosDAO().EditarRemessa(Convert.ToInt32(id), objeto);

            //Returning data - we can hadle this data in form afterSubmit event
            return Json(new { success = true });
		}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Excluir(string id)
        {
            new ArosDAO().ApagarRemessa(Convert.ToInt32(id), User.Identity.GetUserId());

            return Json(new { success = true });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Receber(string id, string responsavel)
        {
            if (!String.IsNullOrWhiteSpace(responsavel))
            {
                responsavel = responsavel.Trim();
                if (responsavel.Length > 45)
                    responsavel = responsavel.Substring(0, 44);
            }

            new ArosDAO().ReceberRemessa(Convert.ToInt32(id), responsavel);

            return Json(new { success = true , rowId = "#rid_" + id.Trim() });
        }

        private List<DDLDTO> PreencherDias()
        {
            return new List<DDLDTO>
            {
                new DDLDTO("-7", "7 Dias"),
                new DDLDTO("-14", "14 Dias"),
                new DDLDTO("-28", "28 Dias"),
                new DDLDTO("-60", "2 Meses"),
                new DDLDTO("-90", "3 Meses"),
                new DDLDTO("-180", "6 Meses"),
                new DDLDTO("-360", "1 Ano")
            };
        }

        private List<RemessaDTO> FiltrarRecebidos(List<RemessaDTO> lst, int local)
        {
            return lst.Where(i => i.Destino.Equals(local)).OrderBy(o => o.DataEnvio).ToList();
        }

        private List<RemessaDTO> FiltrarEnviados(List<RemessaDTO> lst, int local)
        {
            return lst.Where(i => i.Origem.Equals(local)).OrderBy(o => o.DataEnvio).ToList();
        }

    }
}
