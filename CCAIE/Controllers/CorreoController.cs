using CCAIE.Models;
using CCAIE.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCAIE.Controllers
{
    public class CorreoController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CorreoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Enviar(CorreoDTO correo, IFormFile archivoAdjunto)
        {
            var correoService = new Correo();

            string filePath = null;
            if(archivoAdjunto != null && archivoAdjunto.Length > 0) 
            {
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                if(!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                filePath = Path.Combine(uploadsFolder, archivoAdjunto.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await archivoAdjunto.CopyToAsync(stream);
                }
            }

            string plantillaPath = Path.Combine(_hostingEnvironment.WebRootPath, "Plantillas", "Index.html");
            string contenidoPlantilla = System.IO.File.ReadAllText(plantillaPath);

            contenidoPlantilla = contenidoPlantilla.Replace("{nombre}", correo.nombre);
            contenidoPlantilla = contenidoPlantilla.Replace("{telefono}", correo.telefono);
            contenidoPlantilla = contenidoPlantilla.Replace("{email}", correo.email);
            contenidoPlantilla = contenidoPlantilla.Replace("{contenido_adicional}", correo.contenido);

            bool enviado = correoService.enviarCorreo(correo.asunto, contenidoPlantilla, filePath);

            if(!string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = new CorreoDTO
            {
                asunto = "Asunto Predefinido"
            };
            return View(model);
        }
    }
}
