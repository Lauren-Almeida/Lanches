using Lanches.Models;

namespace Lanches.Repository
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}