using Lanches.Models;
using Lanches.Repository.Interfaces;
using Lanches.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        // [HttpGet]
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;
            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetTotal()
            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AddItem(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches
                                    .FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarLanche(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }


        [Authorize]
        public IActionResult RemoveItem(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches
                                    .FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoveLanche(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }



        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}