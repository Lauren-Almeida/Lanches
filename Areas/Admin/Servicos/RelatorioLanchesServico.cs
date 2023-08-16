using Lanches.Context;
using Lanches.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanches.Areas.Admin.Servicos
{
    public class RelatorioLanchesServico
    {
        private readonly AppDbContext _context;

        public RelatorioLanchesServico(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lanche>> GetLanchesReport()
        {
            var lanches = await _context.Lanches.ToListAsync();

            if (lanches is null)
                return default(IEnumerable<Lanche>);

            return lanches;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.Categorias.ToListAsync();

            if (categorias is null)
                return default(IEnumerable<Categoria>);

            return categorias;
        }
    }
}