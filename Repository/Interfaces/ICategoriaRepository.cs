using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lanches.Models;

namespace Lanches.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}