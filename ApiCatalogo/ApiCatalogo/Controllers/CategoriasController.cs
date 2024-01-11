using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        #region Injeção de Dependência
        private readonly AppDbContext _context;
        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }
        #endregion Injeção de Dependência

        #region Listar Categorias
        [HttpGet]
        [Route("categorias-produtos")]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.Include(p => p.Produtos).AsNoTracking().ToList(); //=> O contexto reconhece a tabela de produtos, e a retorna no método
            if (categorias is null) return NotFound("Erro: não há categorias cadastradas!");
            return categorias;
        }
        #endregion Listar Categorias

        #region Obter Categoria pelo Id
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id); //=> Retorna o primeiro produto com o id, caso não haja, retorna null
            if (categoria is null) return NotFound("Erro: Categoria não encontrada!");
            return categoria;
        }
        #endregion Obter Categoria pelo Id

        #region Cadastrar Categoria
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null) return BadRequest("Dados Inválidos!");
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }
        #endregion Cadastrar Categoria

        #region Atualizar Categoria
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId) return BadRequest("Dados Inválidos!");
            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }
        #endregion Atualizar Categoria

        #region Deletar Categoria
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria is null) return NotFound("Erro: O produto que você está tentando deletar não existe!");
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
        #endregion Deletar Categoria
    }
}
