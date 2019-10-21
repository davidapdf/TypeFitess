using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TypeFitess.Models;

namespace TypeFitess.Repositories
{
    public interface IItemPedidoRepository
    {
        Task<ItemPedido> GetItemPedido(int itemPedidoID);
        Task RemoveItemPedido(int itemPedidoID);
    }
}
