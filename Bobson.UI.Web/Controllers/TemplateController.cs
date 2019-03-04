using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bobson.UI.Web.Models;
using Bobson.Core.DAO;
using System.Text.RegularExpressions;
using Rotativa;
using System.Threading.Tasks;
using Bobson.Core.DTO;
using Microsoft.AspNet.Identity;

namespace Bobson.UI.Web.Controllers
{

    [Authorize(Roles = Core.Base.Config.Roles.GerenteMaisComercial)]
    public class TemplateController : Controller
    {
        private ClienteDAO daoClientes = new ClienteDAO();

        private string Cabecalho
        {
            get
            {
                return Server.MapPath("~/Views/Template/Cabecalho.html");
            }
        }

        private string Rodape
        {
            get
            {
                return Server.MapPath("~/Views/Template/Rodape.html");
            }
        }
        
                
        private Task CreateLogAsync(GenericViewModel model)
        {
            var dao = new ArosDAO();
            var dto = new HistoricoPropostaDTO();
            model.User = new UsuariosDAO().LoginEmailApp("", User.Identity.GetUserId().ToString());
            dto.EmailAssunto = model.TituloEmail;
            dto.EmailCliente = model.EmailCliente;
            dto.EmailCopia = model.EmailCopia;
            dto.EmailCorpo = model.CorpoEmail;
            dto.ViewName = model.ViewName;
            dto.ViewModel = model.ToString();
            dto.UsuarioId = User.Identity.GetUserId();
            dto.Proposta = model.CamposTexto_30;

            AtendimentoDAO atendimentoDAO = new AtendimentoDAO();

            AtendimentoClienteDTO atendimentoClienteDTO = new AtendimentoClienteDTO();

            atendimentoClienteDTO.UsuarioId = User.Identity.GetUserId();
            atendimentoClienteDTO.tipo = "3";
            atendimentoClienteDTO.dataContato = DateTime.Now;
            atendimentoClienteDTO.dataVisita = DateTime.Now;
            atendimentoClienteDTO.obs = "Orcamento enviado por email :" + model.EmailCliente;
            atendimentoClienteDTO.idCliente = model.idCliente;
            atendimentoClienteDTO.idTipoAtendimento = 3;
            atendimentoClienteDTO.idVendedor = User.Identity.GetUserId();
            atendimentoDAO.Salvar(atendimentoClienteDTO);



            dao.SalvarHistoricoProposta(dto);

            return Task.FromResult(true);
        }

        public async Task EnviaEmail(GenericViewModel model, ViewAsPdf pdfView)
        {
            var emailcliente = new System.Net.Mail.MailAddress(daoClientes.buscarCliente(model.idCliente.ToString()).email);
            model.User = new UsuariosDAO().LoginEmailApp("", User.Identity.GetUserId().ToString());
            model.EmailCliente = emailcliente.ToString();

            await CreateLogAsync(model);

          

            var copia = String.IsNullOrWhiteSpace(model.EmailCopia) ? null : new System.Net.Mail.MailAddress(model.EmailCopia);
            var pdf = pdfView.BuildPdf(ControllerContext);


            string de = new UsuariosDAO().LoginEmailApp("",User.Identity.GetUserId()).Email;

            var assinatura = " <div style=\"height:150; width:529px; padding:0px; background:url(http://bobson.kinghost.net/Images/AssinaturaNova.png) no-repeat white\">  " +
         "     <div> <p align=\"Right\" style=\"padding: 30\"><br><font size=\"3\" color=\"black\">"+model.User.Nome+"</font> " +
          " <br> <font size=\"1\" color=\"black\"> "+model.User.Cargo+" </font> <br>" +
          " <font size=\"1\" color=\"black\">Telefones + 55 "+model.User.TelefoneCelular+" <br> "+model.User.TelefoneComercial+"</font>" +
          " <br> <br>" +
          " <br> </p> </div> </div> <br>";

            model.CorpoEmail += assinatura;

            await ServicosLocais.EnviaEmailProposta(emailcliente, copia, model.TituloEmail, model.CorpoEmail, "PropostaBobsonLatinAmerica.pdf", pdf,de);

        }

        [ValidateInput(false)]
        public ActionResult StartView(string id, GenericViewModel model)
        {
            
            model = new GenericViewModel();
            model.ViewName = id.Replace("_edt", "_pnt");
            model.listaClientes = daoClientes.ListarClientes(User.Identity.GetUserId());
            model.User = new UsuariosDAO().LoginEmailApp("", User.Identity.GetUserId().ToString());
            return View(id, model);
        }

        [ValidateInput(false)]
        public ActionResult StartViewRelatorio(string id, string modelParam)
        {
            

            var model = new GenericViewModel();
            model.User = new UsuariosDAO().LoginEmailApp("", User.Identity.GetUserId().ToString());
            model.listaClientes = daoClientes.ListarClientes(User.Identity.GetUserId());
            model = GenericViewModel.GetInstance(modelParam);
            model.ViewName = id.Replace("_edt", "_pnt");
            return View(id, model);
        }




        [ValidateInput(false)]
        public async Task<ActionResult> PrintView(GenericViewModel model)
        {
          //  model.listaClientes = daoClientes.ListarClientes(User.Identity.GetUserId());
            var view = new ViewAsPdf(model.ViewName, model);
            model.User = new UsuariosDAO().LoginEmailApp("", User.Identity.GetUserId().ToString());
            await EnviaEmail(model, view);

            return view;
        }

        public ActionResult EnviarForm(GenericViewModel model)
        {
            model.User = new UsuariosDAO().LoginEmailApp("", User.Identity.GetUserId().ToString());
            model.listaClientes = daoClientes.ListarClientes(User.Identity.GetUserId());
            return View("Enviar", model);
        }

        public ActionResult TinyMCE()
        {
            return View();
        }

        public ActionResult Index()
        {
            var dao = new ArosDAO();
            
            var model = new TemplateViewModel();
            model.ListaTemplates = dao.ListarDocumentos();
            model.ListaTemplates.Insert(0, new Core.DTO.DDLDTO(null, null, "Criar Novo Tamplate"));
            model.Categorias = dao.ListarCategoriasDeDocumento();
            model.Cabecalho = LoadHtml(this.Cabecalho);
            model.Rodape = LoadHtml(this.Rodape);
            return View("Index", model);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Atualizar(TemplateViewModel model)
        {
            var dao = new ArosDAO();
            model.ListaTemplates = dao.ListarDocumentos();
            model.Categorias = dao.ListarCategoriasDeDocumento();
            model.Cabecalho = LoadHtml(this.Cabecalho);
            model.Rodape = LoadHtml(this.Rodape);


            if (model.Id != null)
            {
                var obj = new ArosDAO().ObterDocumento((int)model.Id);
                model.Html = obj.Html; // Microsoft.Security.Application.Sanitizer.GetSafeHtml(new ArosDAO().ObterDocumento((int)model.Id));
                model.Categoria = obj.Categoria;
                var tg = model.ListaTemplates.Where(i => i.Id.Equals(model.Id.ToString())).FirstOrDefault();
                model.Nome = tg.Desc;
            }
            else
            {
                model.Nome = String.Empty;
                model.Html = String.Empty;
            }


            model.ListaTemplates.Insert(0, new Core.DTO.DDLDTO(null, null, "Criar Novo Tamplate"));
            ModelState.Remove("Categoria");
            ModelState.Remove("Nome");
            ModelState.Remove("Html");
            return View("Index", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(TemplateViewModel model)
        {
            var dao = new ArosDAO();
            model.ListaTemplates = dao.ListarDocumentos();
            model.Categorias = dao.ListarCategoriasDeDocumento();
            model.Cabecalho = LoadHtml(this.Cabecalho);
            model.Rodape = LoadHtml(this.Rodape);

            if (ModelState.IsValid)
            {

                if (model.Id == null)
                    ModelState.Remove("Id");

                var id = new ArosDAO().SalvarDocumento(
                new Core.DTO.ModeloDocumentoDTO(null)
                {

                    Id = model.Id,
                    Categoria = model.Categoria,
                    Nome = model.Nome,
                    Html = model.Html
                });

                //Só Seta o ID na Model, se ele não existir ainda (Novo Resgistro)
                if (id > 0 && model.Id == null)
                    model.Id = id;

                CreateViews(model);

                //Atualiza a lista
                model.ListaTemplates = new ArosDAO().ListarDocumentos();

            }

            ModelState.Remove("Categoria");
            ModelState.Remove("Nome");
            ModelState.Remove("Html");

            //model.Html = Microsoft.Security.Application.Sanitizer.GetSafeHtml(model.Html);
            model.ListaTemplates.Insert(0, new Core.DTO.DDLDTO(null, null, "Criar Novo Tamplate"));
            return View("Index", model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(TemplateViewModel model)
        {
            var dao = new ArosDAO();
            model.ListaTemplates = dao.ListarDocumentos();
            model.Categorias = dao.ListarCategoriasDeDocumento();
            model.Cabecalho = LoadHtml(this.Cabecalho);
            model.Rodape = LoadHtml(this.Rodape);

            if (ModelState.IsValid)
            {

                if (model.Id == null)
                    ModelState.Remove("Id");

                var id = new ArosDAO().DeletarDocumento(
                new Core.DTO.ModeloDocumentoDTO(null)
                {
                    Id = model.Id,
                });

                DeleteViews(model);

                //Atualiza a lista
                model.ListaTemplates = new ArosDAO().ListarDocumentos();

            }

            ModelState.Remove("Categoria");
            ModelState.Remove("Nome");
            ModelState.Remove("Html");

            //model.Html = Microsoft.Security.Application.Sanitizer.GetSafeHtml(model.Html);
            model.ListaTemplates.Insert(0, new Core.DTO.DDLDTO(null, null, "Criar Novo Tamplate"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CabecalhoRodape()
        {
            return View(new CabecalhoViewModel
            {
                Erro = "none",
                Sucesso = "none",
                Cabecalho = LoadHtml(this.Cabecalho),
                Rodape = LoadHtml(this.Rodape)
        });
        }


        [HttpPost]
        public ActionResult CabecalhoRodape(CabecalhoViewModel model)
        {
            this.SaveHtml(this.Cabecalho, model.Cabecalho);
            this.SaveHtml(this.Rodape, model.Rodape);
            model.Sucesso = "block";
            model.Erro = "none";
            return View(model);
        }
      
        private void CreateViews(TemplateViewModel model)
        {
            var htmlEdt = model.Html.Replace("@", "@@");
            var htmlPnt = model.Html.Replace("@", "@@");
            var path = Server.MapPath("~/Views/Template/");
            var fileRazorEdt = path + "View_" + model.Id.ToString() + "_edt.cshtml";
            var fileRazorPnt = path + "View_" + model.Id.ToString() + "_pnt.cshtml";

            var campo_data = "[(#CAMPO_DATA#)]";
            var campo_livre = "[(#CAMPO_LIVRE#)]";

            var campo_assinatura = "[(#CAMPO_ASSINATURA#)]";
           


            var razor_data = " @DateTime.Today.ToLongDateString() ";
            var razor_edt = " <div class=\"input-group input-group-sm col-lg-2\"> <span class=\"input-group-addon\">?</span> @Html.EditorFor(model => model.CamposTexto_^~^, new { htmlAttributes = new { style=\"width: 120px\", @class = \"form-control btn-info\", @placeholder=\"Campo Livre\" } }) </div> ";
            //var razor_lbl = " @Html.Label(Model.CamposTexto_^~^) ";
            var razor_lbl = " @Model.CamposTexto_^~^ ";
            var razor_img = " <div style=\"height:150; width:529px; padding:0px; background:url(http://bobson.kinghost.net/Images/AssinaturaNova.png) no-repeat white\">  " +
         "     <div> <p align=\"Right\" style=\"padding: 30\"><br><font size=\"3\" color=\"black\">@Model.User.Nome</font> " +
          " <br> <font size=\"1\" color=\"black\"> @Model.User.Cargo </font> <br>" +
          " <font size=\"1\" color=\"black\">Telefones + 55 @Model.User.TelefoneCelular <br> @Model.User.TelefoneComercial</font>" +
          " <br> <br>" +
          " <br> </p> </div> </div> <br>";




            int idx = -1;
            int i = -1;
            var regexLivre = new Regex(Regex.Escape(campo_livre));
            while ((idx = htmlEdt.IndexOf(campo_livre)) >= 0)
            {
                i = i + 1;
                htmlEdt = regexLivre.Replace(htmlEdt, razor_edt.Replace("^~^", (i).ToString().PadLeft(2, '0')), 1);
                htmlPnt = regexLivre.Replace(htmlPnt, razor_lbl.Replace("^~^", (i).ToString().PadLeft(2, '0')), 1);
            }



            System.IO.File.WriteAllText(fileRazorEdt,
                "@model Bobson.UI.Web.Models.GenericViewModel " + Environment.NewLine +
                "@using (Html.BeginForm(\"PrintView\", \"Template\")) { @Html.HiddenFor(m => m.ViewName) <hr/> " + Environment.NewLine +
                model.Cabecalho.Replace(campo_data, razor_data) + Environment.NewLine +
                htmlEdt.Replace(campo_data, razor_data).ToString().Replace(campo_assinatura, razor_img) + Environment.NewLine +
                
              
                model.Rodape.Replace(campo_data, razor_data) + Environment.NewLine + " <br/> " + Environment.NewLine +
                "@Html.Action(\"EnviarForm\", \"Template\", Model) " +
                "<hr /><div class=\"text-center\"><input type=\"submit\" class=\"btn btn-primary\" value=\"Enviar\" /></div> } " + Environment.NewLine +
                "@section Scripts { @Scripts.Render(\"~/bundles/tinymce\")  @Html.Action(\"TinyMCE\", \"Template\")  }");

           System.IO.File.WriteAllText(fileRazorPnt, "@{ Layout = null; }" + Environment.NewLine +
                "@model Bobson.UI.Web.Models.GenericViewModel" + Environment.NewLine + model.Cabecalho.Replace(campo_data, razor_data) + Environment.NewLine + htmlPnt.Replace(campo_data, razor_data).ToString().Replace(campo_assinatura, razor_img) + Environment.NewLine + Environment.NewLine + model.Rodape.Replace(campo_data, razor_data));
        }

        private void DeleteViews(TemplateViewModel model)
        {
            var htmlEdt = model.Html.Replace("@", "@@");
            var htmlPnt = model.Html.Replace("@", "@@");
            var path = Server.MapPath("~/Views/Template/");
            var fileRazorEdt = path + "View_" + model.Id.ToString() + "_edt.cshtml";
            var fileRazorPnt = path + "View_" + model.Id.ToString() + "_pnt.cshtml";

            if (System.IO.File.Exists(fileRazorEdt))
                System.IO.File.Delete(fileRazorEdt);

            if (System.IO.File.Exists(fileRazorPnt))
                System.IO.File.Delete(fileRazorPnt);

        }

        private string LoadHtml(string caminho)
        {
            if (System.IO.File.Exists(caminho))
            {
                return System.IO.File.ReadAllText(caminho);
            }
            else
            {
                return "Crie um novo: Arquivo não encontrado: <b>" + caminho + "</b>";
            }
        }

        private void SaveHtml(string caminho, string html)
        {
            System.IO.File.WriteAllText(caminho, html);
        }


    }
}
