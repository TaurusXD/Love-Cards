using Love_Cards.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Love_Cards.Controllers
{
    public class CartoesController : Controller
    {
        private const int _tamBloco = 4;
        //Mock de produtos
        List<Produto> _lista = new List<Produto>()
        {
            new Produto(){Nome="Produto 1", imagem = "4028.jpg", Preco = 400},
            new Produto(){Nome="Produto 2", imagem = "4028.jpg", Preco = 410},
            new Produto(){Nome="Produto 3", imagem = "4028.jpg", Preco = 420},
            new Produto(){Nome="Produto 4", imagem = "4028.jpg", Preco = 450},
            new Produto(){Nome="Produto 1", imagem = "4028.jpg", Preco = 400},
            new Produto(){Nome="Produto 2", imagem = "4028.jpg", Preco = 410},
            new Produto(){Nome="Produto 3", imagem = "4028.jpg", Preco = 420},
            new Produto(){Nome="Produto 4", imagem = "4028.jpg", Preco = 450}
        };

        //Carregamento de produtos limitados 
        private List<Produto> ObterBlocoProduto(int bloco)
        {
            var posinicial = _tamBloco * (bloco - 1);
           return _lista.Skip(posinicial).Take(_tamBloco).ToList();
        }
        //Obtenção dos dados da View Cartoes
        private string CarregarBlocoProtuto(List<Produto> lista)
        {
            var ret = string.Empty;
            ViewData.Model = lista;
            var viewProduto = ViewEngines.Engines.FindPartialView(ControllerContext, "BlocoProdutoParcial");
            using (var writer = new StringWriter())
            {
                var viewContext = new ViewContext(ControllerContext, viewProduto.View, ViewData, TempData, writer);
                viewProduto.View.Render(viewContext, writer);
                ret = writer.GetStringBuilder().ToString();
            }
            return ret;
        }
        public ActionResult Index()
        {
            return View(this.ObterBlocoProduto(1));
        }
        public ActionResult ListarProduto(List<Produto> lista)
        {
            return PartialView("BlocoProdutoParcial", lista);
        }
        private bool VerificarUltimoBloco(int bloco)
        {
            var posInicial = _tamBloco * (bloco - 1);
            var ultimoItem = (posInicial + _tamBloco);
            return (ultimoItem >= _lista.Count);

        }
        [HttpPost]
        public ActionResult CarregarBlocoProduto(int bloco)
        {
            var listaProduto = this.ObterBlocoProduto(bloco);
            return Json(new BlocoProduto()
            {
                Html = this.CarregarBlocoProtuto(listaProduto),
                UltimoBloco = this.VerificarUltimoBloco(bloco)
            });
        }
    }
}
