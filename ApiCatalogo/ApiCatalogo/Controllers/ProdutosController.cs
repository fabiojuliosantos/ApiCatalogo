using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        #region Injeção de Dependência
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        #endregion Injeção de Dependência

        #region Listar Produtos
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList(); //=> O contexto reconhece a tabela de produtos, e a retorna no método
            if (produtos is null) return NotFound("Erro: não há produtos cadastrados!");
            return produtos;
        }
        #endregion Listar Produtos

        #region Obter produto pelo Id
        [HttpGet("{id:int}", Name="ObterProduto")]
        public ActionResult<Produto>Get(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id); //=> Retorna o primeiro produto com o id, caso não haja, retorna null
            if (produto is null) return NotFound("Erro: Produto não encontrado!");
            return produto;
        }
        #endregion Obter produto pelo Id

        #region Cadastrar Produto
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null) return BadRequest("Dados Inválidos!");
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }
        #endregion Cadastrar Produto

        #region Atualizar Produto
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId) return BadRequest("Dados Inválidos!");
            _context.Produtos.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }
        #endregion Atualizar Produto

        #region Deletar Produto
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null) return NotFound("Erro: O produto que você está tentando deletar não existe!");
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
        #endregion Deletar Produto
    }
}
