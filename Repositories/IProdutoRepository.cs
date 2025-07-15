using APICatalogo.Models;

namespace APICatalogo.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> GetProdutos();
    Produto GetProduto(int id);
    Produto CreateProduto(Produto produto);
    Produto UpdateProduto(Produto produto);
    Produto DeleteProduto(int id);

}
