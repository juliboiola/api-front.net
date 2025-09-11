using Microsoft.AspNetCore.Mvc;
using crudapi.Data;
using crudapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDBContext;
        //inyeccion de dependencias 
        public EmpleadoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;

        }
        [HttpGet] // (no hace falta ponerlo, se sobreentiende)
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDBContext.Empleados.ToListAsync();
            return View(lista);
        }

        [HttpGet] 
        public IActionResult NuevoEmpleado()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NuevoEmpleado(Empleado empleado)
        {
            await _appDBContext.Empleados.AddAsync(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDBContext.Empleados.Update(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            _appDBContext.Empleados.Remove(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

    }
}
