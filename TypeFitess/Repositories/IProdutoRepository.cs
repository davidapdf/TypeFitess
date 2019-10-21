using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeFitess.Models;

namespace TypeFitess.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveProdutos(List<ProdutosInicializer> produtos);
        Task<IList<Produto>> GetProdutos();
    }
}
