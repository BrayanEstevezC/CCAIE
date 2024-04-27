using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CCAIE.Models.Services
{
    public class Estudiante
    {
        private string _host = "smtp.gmail.com";
        private int _puerto = 587;
        private string _nombre = "Nuevo Alumno";
        private string _remitente = "candidatoscapacitacionaerea@gmail.com";
        private string _clave = "ymgannghkxdgtvgd";

        public bool enviarEstudiante(string asunto, string contenido)
        {
            if (string.IsNullOrEmpty(asunto) || string.IsNullOrEmpty(contenido))
            {
                return false;
            }

            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_nombre, _remitente));
                email.To.Add(MailboxAddress.Parse("escuelaaereajep@gmail.com"));
                email.Subject = asunto;

                var builder = new BodyBuilder();
                builder.HtmlBody = contenido;

                email.Body = builder.ToMessageBody();

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(_host, _puerto, SecureSocketOptions.StartTls);
                    smtp.Authenticate(_remitente, _clave);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CorreoDTO plantillaEstudiante(IWebHostEnvironment hostingEnvironment, HttpContext httpContext)
        {
            string folder = "Plantillas";
            string path = Path.Combine(hostingEnvironment.WebRootPath, folder, "Estudiante.html");

            using (var reader = new StreamReader(path))
            {
                string htmlBody = reader.ReadToEnd();
                CorreoDTO correoDTO = new CorreoDTO()
                {
                    contenido = htmlBody
                };
                return correoDTO;
            }
        }
    }
}
