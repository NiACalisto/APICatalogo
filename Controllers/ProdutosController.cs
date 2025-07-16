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
        private readonly IUnitOfWork _unitOfWork;

        public ProdutosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("produtos/{id}")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPorCategoria(int id)
        {
            var produtosPorCategoria = _unitOfWork.ProdutoRepository.GetProdutosPorCategoria(id).ToList();
            if (produtosPorCategoria is null)
            {
                return NotFound();
            }
            
            return Ok(produtosPorCategoria);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _unitOfWork.ProdutoRepository.GetAll().ToList();
        }

        [HttpGet("{id:int:min(1)}", Name="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            return _unitOfWork.ProdutoRepository.Get(c => c.ProdutoId == id);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {   
            var newProduto = _unitOfWork.ProdutoRepository.Create(produto);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = newProduto.ProdutoId }, newProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _unitOfWork.ProdutoRepository.Update(produto);
            _unitOfWork.Commit();
            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.Get(c => c.ProdutoId == id);

            if (produto == null)
            {
                return NotFound();
            }
            _unitOfWork.ProdutoRepository.Delete(produto);
            _unitOfWork.Commit();
            return Ok(produto);
        }
    }
}
