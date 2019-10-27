using System.Collections.Generic;
using System.Threading.Tasks;
using TypeFitess.Models;

namespace TypeFitess.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<ProdutosInicializer> produtos);
        Task<IList<Produto>> GetProdutos();
    }
}
