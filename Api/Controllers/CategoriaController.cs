using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly TravitextilContext _context;
        public CategoriaController(TravitextilContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll() {
            var categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
         
        public IActionResult GetById([FromRoute] int id){
            var categoria = _context.Categorias.Find(id);

            if (categoria == null){
                return NotFound();
            }
            return Ok(categoria);
        }
        
        
    }
}