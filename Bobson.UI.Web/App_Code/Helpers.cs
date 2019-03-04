using Bobson.Core.DAO;
using Bobson.Core.DTO;
using System.Collections.Generic;
using System.Reflection;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Hyperlink(this HtmlHelper helper, string url, string text, string target)
        {
            return MvcHtmlString.Create(String.Format("<a href='{0}' target='{2}'>{1}</a>", url, text, target));
        }

        public static MvcHtmlString GetStatusImage(this HtmlHelper helper, bool status)
        {
            return MvcHtmlString.Create(String.Format("<span class=\"ui-icon {0}\"></span>", (status ? "ui-icon-circle-check" : "ui-icon-circle-close")));
        }

        public static MvcHtmlString GetPrivacyImage(this HtmlHelper helper, string status)
        {
            return MvcHtmlString.Create(String.Format("<span class=\"ui-icon {0}\"></span>", (status.ToUpper().Equals("OPEN") ? "ui-icon-unlocked" : "ui-icon-locked")));
        }

        public static MvcHtmlString CreateMenuPropostas(this HtmlHelper helper)
        {
            String li = "";

            var dao = new ArosDAO();

            var categorias = dao.ListarCategoriasDeDocumento();
            List<DDLDTO> propostas = null;
            categorias.ForEach(categoria =>
            {
                propostas = dao.ListarDocumentos(Convert.ToInt32(categoria.Id));

                if (propostas.Count > 0)
                {
                    li += String.Format("<li class=\"dropdown-header\">{0}</li>", categoria.Desc);
                }

                propostas.ForEach(proposta =>
                {
                    li += String.Format("<li><a href=\"/Template/StartView/View_{0}_edt\">{1}</a></li>", proposta.Id, proposta.Desc);
                });

                if (propostas.Count > 0)
                {
                    li += "<li role=\"separator\" class=\"divider\"></li>";
                }
            });

            return MvcHtmlString.Create(String.Format("<ul class=\"dropdown-menu\">{0}</ul>", li));
        }

         
        
    }

 
}