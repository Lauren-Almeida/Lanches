using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Context;
using Lanches.Models;

namespace Lanches.Areas.Admin.Servicos
{
    public class GraficoVendasServico
    {
        private readonly AppDbContext context;

        public GraficoVendasServico(AppDbContext context)
        {
            this.context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in context.PedidoDetalhes
                           join l in context.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome, pd.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LancheGrafico>();

            foreach (var l in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = l.LancheNome;
                lanche.LanchesQuantidade = l.LanchesQuantidade;
                lanche.LanchesValorTotal = l.LanchesValorTotal;
                lista.Add(lanche);
            }

            return lista;
        }
    }
}