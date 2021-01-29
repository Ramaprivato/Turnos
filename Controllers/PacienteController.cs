using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext Context)
        {
          _context = Context;
        

        }
          public async Task<IActionResult> Index()   
          
         {

              return View(await _context.Paciente.ToListAsync());
          }
    

       public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);//recorre entidad paciente y encuentra "idpaciente" que sea igual al parametro ID
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }



          public IActionResult Create()
        {

            return View();
        }


              [HttpPost]
          public async Task <IActionResult> Create ([Bind("IdPaciente,Nombre,Apellido,Direccion,Telefono,Email")]Paciente paciente){
 

          if(ModelState.IsValid){
          
          _context.Add(paciente);
          await _context.SaveChangesAsync();
          return RedirectToAction(nameof(Index));

          }           
 
            return View();
        }

    }

}