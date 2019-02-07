using System.Collections.Generic;
using tp3.Models;
using tp3.Services;
using Microsoft.AspNetCore.Mvc;

namespace TP3___Entrepot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly studentService _studentService;

        public EtudiantController(studentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<etudiants>> Get()
        {
            return _studentService.Get();
        }

        [HttpGet("{da}")]
        public ActionResult<etudiants> Get(string da)
        {
            var etudiant = _studentService.Get(da);

            if (etudiant == null)
            {
                return NotFound();
            }

            return etudiant;

        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, etudiants etudiantInput)
        {
            var etudiant = _studentService.Get(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            _studentService.Update(id, etudiantInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var etudiant = _studentService.Get(id);

            if (etudiant == null)
            {
                return NotFound();
            }

            _studentService.Remove(etudiant.Id);
            return NoContent();
        }
    }
}