using exemploAPI.Data;
using exemploAPI.DTOs;
using exemploAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private readonly AppDbContext _context;

        public FornecedorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorRespostaDTO>>> GetFornecedores()
        {
            var fornecedores = await _context.Fornecedores
                .Include(f => f.Produtos)
                .Select(f => new FornecedorRespostaDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Produtos = f.Produtos.Select(p => new ProdutoResumoDTO
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.Preco
                    }).ToList()
                })
                .ToListAsync();

            return fornecedores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorRespostaDTO>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores
                .Include(f => f.Produtos)
                .Where(f => f.Id == id)
                .Select(f => new FornecedorRespostaDTO
                {
                    Id = f.Id,
                    Nome = f.Nome,
                    Produtos = f.Produtos.Select(p => new ProdutoResumoDTO
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Preco = p.Preco
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }


        // PUT: api/Fornecedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, FornecedorDTO fornecedorDto)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            fornecedor.Nome = fornecedorDto.Nome;

            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Fornecedores
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(FornecedorDTO fornecedorDto)
        {
            var fornecedor = new Fornecedor
            {
                Nome = fornecedorDto.Nome
            };

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores
                .Include(f => f.Produtos)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            if (fornecedor.Produtos.Any())
            {
                return BadRequest("Não é possível excluir um fornecedor com produtos vinculados.");
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
