using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using CCAIE.Models;

namespace CCAIE.Models.Services
{
    public class Correo
    {
        private string _host = "smtp.gmail.com";
        private int _puerto = 587;
        private string _nombre = "Nuevo Docente";
        private string _remitente = "candidatoscapacitacionaerea@gmail.com";
        private string _clave = "ymgannghkxdgtvgd";

        public bool enviarCorreo(string asunto, string contenido, string filePath)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(_nombre, _remitente));
                email.To.Add(MailboxAddress.Parse("escuelaaereajep@gmail.com"));
                email.Subject = asunto;

                var builder = new BodyBuilder();
                builder.HtmlBody = contenido;

                if (!string.IsNullOrEmpty(filePath))
                {
                    builder.Attachments.Add(filePath);
                }
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
            catch
            {
                return false;
            }
        }

        public CorreoDTO crearPlantilla(IWebHostEnvironment hostingEnvironment, HttpContext httpContext)
        {
            string folder = "Plantillas";
            string path = Path.Combine(hostingEnvironment.WebRootPath, folder, "Index.html");
            string scheme = httpContext.Request.Scheme;
            string host = httpContext.Request.Host.ToString();

            using (var reader = new StreamReader(path))
            {
                string htmlBody = reader.ReadToEnd();
                CorreoDTO correoDTO = new CorreoDTO()
                {
                    asunto = "Pruebas",
                    contenido = htmlBody
                };
                return correoDTO;
            }
        }

    }
}
