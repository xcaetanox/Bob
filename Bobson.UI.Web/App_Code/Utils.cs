using Bobson.Core.Base;
using Bobson.Core.DAO;
using Bobson.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

using System.Web.Mvc;

namespace Bobson.UI.Web
{
    public class FragmenteDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            RegisterViewModel dto = (RegisterViewModel)validationContext.ObjectInstance;

      //      Object instance = validationContext.ObjectInstance;
        //    Type type = instance.GetType();
            
//            Object dia = type.GetProperty("DiaNascimento ").GetValue(instance, null);
  //          Object mes = type.GetProperty("MesNascimento ").GetValue(instance, null);
    //        Object ano = type.GetProperty("AnoNascimento ").GetValue(instance, null);

            try
            {
                //      new DateTime((int)ano, (int)mes, (int)dia);
                    new DateTime(dto.AnoNascimento, (int)dto.MesNascimento, (int)dto.DiaNascimento);
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Informe uma Data de Nascimento Válida");
            }            
        }
    }

    public class ServicosLocais
    {
        public static async Task EnviaEmailProposta(MailAddress para, MailAddress copia, string assunto, string corpo, string filename, byte[] anexo = null, string de="")
        {
            await EnviarEmailAsync(para, copia, assunto, corpo, true, filename, "application/pdf", anexo,de);

        }

        public static async Task EnviarEmailAsync(MailAddress para, MailAddress copia, string assunto, string corpo, bool ishtml, string filename = null, string filetype = null, byte[] anexo = null,string de="")
        {
            SmtpClient smtp;

            if (de=="") {

                 smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("aros.bobson@gmail.com", "@lex2016"),
                    EnableSsl = true
                };
            }
            else
            {
                smtp = new SmtpClient("mail.bobson.com.br", 587)
                {
                    Credentials = new NetworkCredential("programador@bobson.com.br", "U,zY]#(I+ZxG"),
                    EnableSsl = true
                };
                
            }
         
            using (var message = new MailMessage(new MailAddress(Config.EmailFromAdress, Config.EmailFromName), para)
            {
                Subject = assunto,
                IsBodyHtml = ishtml,
                Body = corpo
            })
            {

                if (de!="")
                {
                    if (de.Contains("@bobson.com.br"))
                    {

                        message.From = new MailAddress(de);
                    }
                    else
                    {
                        message.From = new MailAddress("bobson@bobson.com.br");

                    }
                }
                else
                {
                    message.From = new MailAddress("bobson@bobson.com.br");
                }
                

                

                if (copia != null)
                    message.CC.Add(copia);

                if (anexo != null)
                {
                    MemoryStream stream = new MemoryStream(anexo);
                    Attachment att1 = new Attachment(stream, filename, filetype);
                    message.Attachments.Add(att1);
                }

                await smtp.SendMailAsync(message);
            }
        }
    }
}