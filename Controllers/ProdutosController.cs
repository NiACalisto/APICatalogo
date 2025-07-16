using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.CompilerServices;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repositoryProduto;
        private readonly IRepository<Produto> _repository;

        public ProdutosController(IProdutoRepository repositoryProduto, IRepository<Produto> repository)
        {
            _repositoryProduto = repositoryProduto;
            _repository = repository;
        }

        [HttpGet("produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPorCategoria(int id)
        {
            var produtosPorCategoria = _repositoryProduto.GetProdutosPorCategoria(id).ToList();
            if (produtosPorCategoria is null)
            {
                return NotFound();
            }

            return Ok(produtosPorCategoria);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id:int:min(1)}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            return _repository.Get(c => c.ProdutoId == id);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {   
            var newProduto = _repository.Create(produto);

            return new CreatedAtRouteResult("ObterProduto", new { id = newProduto.ProdutoId }, newProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _repository.Update(produto);
            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _repository.Get(c => c.ProdutoId == id);

            if (produto == null)
            {
                return NotFound();
            }
            _repository.Delete(produto);
            return Ok(produto);
        }
    }
}
