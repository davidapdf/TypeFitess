using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeFitess.Models;

namespace TypeFitess.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<ItemPedido> GetItemPedido(int itemPedidoId)
        {
            return
                await dbSet
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        public Task RemoveItemPedido(int itemPedidoID)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePedido(int itemPedidoId)
        {
            dbSet.Remove(await GetItemPedido(itemPedidoId));
        }
    }
}
