using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TypeFitess.Repositories;

namespace TypeFitess
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext context, IProdutoRepository produtoRepository)
        {
            this.context = context;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDb()
        {

            context.Database.Migrate();
            List<ProdutosInicializer> produtos = GetProdutos();
            produtoRepository.SaveProdutos(produtos);
        }

        private static List<ProdutosInicializer> GetProdutos()
        {
            var json = File.ReadAllText("Produtos.json");
            var produtos = JsonConvert.DeserializeObject<List<ProdutosInicializer>>(json);
            return produtos;
        }
    }
}
