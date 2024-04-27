using CCAIE.Models;
using CCAIE.Models.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CCAIE.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EstudianteController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarCorreo(EstudianteDTO estudiante)
        {
            var estudianteService = new Estudiante();

            string plantillaPath = Path.Combine(_hostingEnvironment.WebRootPath, "Plantillas", "Estudiante.html");
            string contenidoPlantilla = System.IO.File.ReadAllText(plantillaPath);

            contenidoPlantilla = contenidoPlantilla.Replace("{nombre}", estudiante.Nombre);
            contenidoPlantilla = contenidoPlantilla.Replace("{email}", estudiante.Email);
            contenidoPlantilla = contenidoPlantilla.Replace("{contenido_adicional}", estudiante.ContenidoAdicional);


            if (string.IsNullOrEmpty(estudiante.Asunto))
            {
                estudiante.Asunto = "Nuevo Estudiante";
            }

            bool enviado = estudianteService.enviarEstudiante(estudiante.Asunto, contenidoPlantilla);

            TempData["CorreoEnviado"] = enviado;

            ModelState.Clear();

            return RedirectToAction("Index");
        }

    }
}
