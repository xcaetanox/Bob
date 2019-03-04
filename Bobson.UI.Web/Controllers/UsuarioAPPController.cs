
using Bobson.Core.DAO;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web;
using Bobson.Core.DTO;
using System.Web.Http.Results;

namespace Bobson.UI.Web.Controllers
{
    public class UsuarioAPPController : ApiController
    {
       
     
        [HttpPost]
        public string Post([FromBody]UsuariosDTO usuariosDTO)
        {
            UsuariosDAO dao = new UsuariosDAO();
            usuariosDTO.latitude_casa = usuariosDTO.latitude_casa.Replace(",", ".");
            usuariosDTO.longitude_casa= usuariosDTO.longitude_casa.Replace(",", ".");

            dao.setPosicaoCasa(usuariosDTO);
            return "ok";
        }





    }
}
