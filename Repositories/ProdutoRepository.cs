using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositoriesl;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }
    public Produto CreateProduto(Produto produto)
    {
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }
        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return produto;
    }

    public Produto DeleteProduto(int id)
    {
        var produto = _context.Produtos.Find(id);
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return produto;
    }

    public Produto GetProduto(int id)
    {
        return _context.Produtos.FirstOrDefault(c => c.ProdutoId == id);       
    }

    public IEnumerable<Produto> GetProdutos()
    {
        var produtos = _context.Produtos.ToList();

        return produtos;
    }

    public Produto UpdateProduto( Produto produtoUpdate)
    {
        if (produtoUpdate is null)
        {
            throw new ArgumentNullException(nameof(produtoUpdate));
        }
        _context.Entry(produtoUpdate).State = EntityState.Modified;
        _context.SaveChanges();

        return produtoUpdate;
    }
}
