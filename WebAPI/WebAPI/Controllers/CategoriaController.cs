using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.Include(e => e.Produtos).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(long? id)
        {
            var categoria = await _context.Categorias
                                          .Include(c => c.Produtos)
                                          .FirstOrDefaultAsync(c => c.CategoriasId == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(long? id, Categoria categoria)
        {
            if (id != categoria.CategoriasId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool CategoriaExists(long? id)
        {
            return _context.Categorias.Any(e => e.CategoriasId == id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostCategoria(Categoria categoria)
        {

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.CategoriasId }, categoria);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoria(long? id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
