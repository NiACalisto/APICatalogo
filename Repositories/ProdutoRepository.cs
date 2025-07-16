using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext appDbContext) : base(appDbContext) { }

    public IEnumerable<Produto> GetProdutosPorCategoria(int categoriaId)
    {
        return GetAll().Where(c => c.CategoriaId == categoriaId);   
    }
}
