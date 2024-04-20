using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registro.BLL.Contracts;

namespace Registro.Web.Controllers
{
    public class VisitanteController : Controller

  
    {
           private readonly IVisitanteService _visitanteService;
        private readonly IAulaService _aulaService;
        private readonly IEdificioService _edificioService;
        private readonly IUsuarioService _usuarioService;
        public VisitanteController(IVisitanteService visitanteService, IAulaService aulaService, IEdificioService edificioService, IUsuarioService usuarioService)
        {
            _visitanteService = visitanteService;
            _aulaService = aulaService;
            _edificioService = edificioService;
            _usuarioService = usuarioService;
        }
        // GET: VisitanteController1
        public ActionResult Index()
        {

            var visitanteData = _visitanteService.GetAll().Data as List<Registro.BLL.Models.VisitanteModel>;
            var visitanteModels = new List<Models.VisitanteModel>();

            if (visitanteData != null)
            {
                visitanteModels = visitanteData.Select(cd => new Models.VisitanteModel()
                {
                    Apellido = cd.Apellido,
                    Aula = cd.Aula,
                    Carrera = cd.Carrera,
                    Correo = cd.Correo,
                    Edificio = cd.Edificio,
                    HoraEntrada = cd.HoraEntrada,
                    HoraSalida = cd.HoraSalida,
                    ID = cd.ID,
                    MotivoVisita = cd.MotivoVisita,
                    Nombre = cd.Nombre
                }).ToList();
            }

            return View(visitanteModels);
        }

        // GET: VisitanteController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisitanteController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisitanteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VisitanteController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VisitanteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VisitanteController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VisitanteController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
