using cl1_q1.Interfaces;
using cl1_q1.Models;
using cl1_q1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace cl1_q1.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleado _empleado;
        private readonly IDistrito _distrito;
        private readonly ICargo _cargo;

        public EmpleadoController(
            IEmpleado empleado,
            IDistrito distrito,
            ICargo cargo)
        {
            _empleado = empleado;
            _distrito = distrito;
            _cargo = cargo;
        }

        public IActionResult Index()
        {
            List<Empleado> empleados = _empleado.GetEmpleados();

            return View(empleados);
        }

        public IActionResult Crear()
        {
            List<SelectListItem> distritos = new List<SelectListItem>();
            List<SelectListItem> cargos = new List<SelectListItem>();

            foreach (Distrito distrito in _distrito.GetDistritos()) {
                distritos.Add(new SelectListItem()
                {
                    Value = distrito.IdDistrito.ToString(),
                    Text = distrito.NomDistrito
                });
            }

            foreach (Cargo cargo in _cargo.GetCargos())
            {
                cargos.Add(new SelectListItem()
                {
                    Value = cargo.IdCargo.ToString(),
                    Text = cargo.DesCargo
                });
            }

            ViewBag.Distritos = distritos;
            ViewBag.Cargos = cargos;

            return View();
        }

        public IActionResult Actualizar(int id)
        {
            Empleado empleado = _empleado.GetEmpleado(id);

            List<SelectListItem> distritos = new List<SelectListItem>();
            List<SelectListItem> cargos = new List<SelectListItem>();

            foreach (Distrito distrito in _distrito.GetDistritos())
            {
                distritos.Add(new SelectListItem()
                {
                    Value = distrito.IdDistrito.ToString(),
                    Text = distrito.NomDistrito,
                    Selected = distrito.IdDistrito == empleado.IdDistrito ? true : false
                });
            }

            foreach (Cargo cargo in _cargo.GetCargos())
            {
                cargos.Add(new SelectListItem()
                {
                    Value = cargo.IdCargo.ToString(),
                    Text = cargo.DesCargo,
                    Selected = cargo.IdCargo == empleado.IdCargo ? true : false
                });
            }

            ViewBag.Distritos = distritos;
            ViewBag.Cargos = cargos;

            return View(empleado);
        }

        public IActionResult Detalle(int id)
        {
            Empleado empleado = _empleado.GetEmpleado(id);

            return View(empleado);
        }

        public IActionResult Eliminar(int id)
        {
            Empleado empleado = _empleado.GetEmpleado(id);

            return View(empleado);
        }

        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            int result = _empleado.AddEmpleado(empleado);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Actualizar(Empleado empleado)
        {
            int result = _empleado.UpdateEmpleado(empleado);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarPost(int id)
        {
            int result = _empleado.DeleteEmpleado(id);

            return RedirectToAction("Index");
        }
    }
}
