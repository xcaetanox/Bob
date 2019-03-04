using BobRestApp;
using Bobson.Core.DAO;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web;
using Bobson.Core.DTO;
using System.Web.Http.Results;

namespace WebServicesAPP.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public JsonResult<UsuariosDTO> Get(string username)
        {
            UsuariosDAO dao = new UsuariosDAO();

           // string json = JsonConvert.SerializeObjec(dao.LoginEmailApp(username), Formatting.Indented);

            return Json(dao.LoginEmailApp(username));
        }



        // GET api/values
        [HttpPost]
        public string Post([FromBody]AtendimentoClienteDTO atendimento)
        {
            AtendimentoDAO dao = new AtendimentoDAO();
            dao.Salvar(atendimento);
            return "ok";
        }




        // GET api/values/5
        public IEnumerable<string> Get(int idAtendimento)
        {
            AtendimentoDAO dao = new AtendimentoDAO();
            string json = JsonConvert.SerializeObject(dao.buscaAtendimento(idAtendimento.ToString()), Formatting.Indented);
            return new string[] { json };
        }

      

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }



        //private void loginAsync()
        //{
        //    var result = SignInManager.PasswordSignInAsync("", "", false, shouldLockout: false);
        //}


        //private ApplicationSignInManager _signInManager;

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}
    }
}
