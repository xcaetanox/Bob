using Bobson.Core.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Controllers
{
    [Authorize(Roles = Config.Roles.Gerente)]
    public class ArosSyncController : Controller
    {
        private string mensagemdeProcessamento;

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ArosSyncViewModel model)
        {
            SalvarArquivo(model.ArquivoSistemaAcess);
            model.Sucesso = ProcessarArquivo();
            model.Mensagem = mensagemdeProcessamento;

            return View(model);
        }

        private bool ProcessarArquivo()
        {
            Bobson.Core.DAO.ArosDAO dao = new Bobson.Core.DAO.ArosDAO();
            StreamReader file = null;
            try
            {
                string path = Server.MapPath("~/Sync/") + "Sync.csv";

                string line;
                List<String> script = new List<string>();
                string[] reg;
                file = new StreamReader(path, System.Text.Encoding.GetEncoding("ISO-8859-1"));

                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    reg = line.Split(';');

                    dao.SalvarEquipamento(new Bobson.Core.DTO.ArosDTO
                    {
                        Estado = reg[0].Replace("\"", ""),  //uf, 
                        CodigoCliente = GetInt(reg[1].Replace("\"", "")),  //codigo_cliente, 
                        CodigoBanheiro = GetInt(reg[2].Replace("\"", "")),
                        Local = reg[3].Replace("\"", ""),  //local,  
                        Tipo = reg[4].Replace("\"", ""),  //tipo,
                        DescricaoEquipamento = reg[6].Replace("\"", ""),  //descricao, 
                        HoraLiga = GetTimeSpan(reg[7].Replace("\"", "")),  //hora_liga, 
                        HoraDesliga = GetTimeSpan(reg[8].Replace("\"", "")),  //hora_desliga, 
                        Aroma = reg[10].Replace("\"", ""),  //aroma, 
                        DataUltimaTroca = GetDate(reg[11].Replace("\"", "")), //ultima_troca, 
                        PesoRefil = GetInt(reg[12].Replace("\"", "")).ToString(), //peso_refil  
                        NevoaSolta = new TimeSpan(0, 0, GetInt(reg[13].Replace("\"", "").Trim())),  //solta_nevoa, 
                        NevoaPara = new TimeSpan(0, 0, GetInt(reg[14].Replace("\"", "").Trim()))  //para_nevoa, 
                    });
                }

                return true;

            }
            catch (Exception exa)
            {
                this.mensagemdeProcessamento = exa.Message;
                return false;
            }
            finally
            {
                if (file != null)
                    file.Close();
                dao.CloseConnection();
                dao = null;
            }

        }

        private void SalvarArquivo(HttpPostedFileBase arquivoSistemaAcess)
        {
            if (arquivoSistemaAcess != null && arquivoSistemaAcess.ContentLength > 0)
            {
                string path = Server.MapPath("~/Sync/");
                string file = "Sync.csv";

                if (System.IO.File.Exists(path + file))
                {
                    System.IO.File.Copy(path + file, path + "Sync-" + DateTime.Now.ToString("dd-MM-yyyy hh.mm.ss") + ".csv");
                    System.IO.File.Delete(path + file);
                }

                arquivoSistemaAcess.SaveAs(path + file);
            }
        }

        private TimeSpan GetTimeSpan(string valor)
        {
            TimeSpan o;

            if (TimeSpan.TryParse(valor, out o))
                return o;
            else
                return TimeSpan.Parse("00:00:00");
        }

        private static int GetInt(string valor)
        {
            int o;
            if (int.TryParse(valor, out o))
                return o;
            else
                return 0;

        }

        private static DateTime GetDate(string dt)
        {
            if (dt.Trim().Equals(string.Empty))
                return new DateTime(2222, 02, 22);
            else
            {

                string[] frag = dt.Split('/');

                return new DateTime(int.Parse(frag[2]), int.Parse(frag[1]), int.Parse(frag[0]));
            }
        }

    }
}