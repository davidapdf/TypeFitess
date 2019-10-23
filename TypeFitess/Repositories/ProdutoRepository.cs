using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeFitess.Models;

namespace TypeFitess.Repositories
{
 
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
        public async Task<IList<Produto>> GetProdutos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task SaveProdutos(List<ProdutosInicializer> prod)
        {
            foreach (var produto in prod)
            {
                if (!await dbSet.Where(p => p.Codigo == produto.Codigo).AnyAsync())
                {
                    await dbSet.AddAsync(new Produto(produto.Codigo, produto.Nome, produto.Preco));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class ProdutosInicializer
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

}
