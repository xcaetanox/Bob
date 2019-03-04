using Bobson.Core.DAO;
using Bobson.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace BobRestApp.Controllers
{
    public class ClienteController : ApiController
    {

        // GET api/values
        public JsonResult<List<ClienteDTO>> Get(string idVendendor)
        {
            ClienteDAO dao = new ClienteDAO();

            // string json = JsonConvert.SerializeObjec(dao.LoginEmailApp(username), Formatting.Indented);

            return Json(dao.ListarClientes(idVendendor));
        }

    }
}
