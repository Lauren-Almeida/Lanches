using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Context;
using Lanches.Models;

namespace Lanches.Repository
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}