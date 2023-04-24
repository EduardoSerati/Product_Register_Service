using Aula01.Dados;
using Aula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductModelView> db = new();

        public IActionResult SalvarDados(ProductModelView dados)
        {
            if (dados.Id > 0)
            {
                Arquivo arquivo = new();
                arquivo.EditarArquivo(dados);
                //int index = db.FindIndex(a => a.Id == dados.Id);
                //db[index] = dados;
            }
            else
            {
                Random rand = new();
                dados.Id = rand.Next(1, 9999);
                db.Add(dados);
                Arquivo arquivo = new();
                arquivo.SalvarArquivo(dados);
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            Arquivo arquivo = new();
            return View(arquivo.ProductList());
        }

        public IActionResult Delete(int id)
        {
            Arquivo arquivo = new();
            arquivo.ExcluirArquivo(id);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            //ClientesModelView cliente = db.Find(obj => obj.Id == id);
            //if (cliente != null)
            //{
            //    return View(cliente);
            //}
            //else
            //{
            //    return RedirectToAction("Lista");
            //}
            Arquivo arquivo = new();
         
            return View(arquivo.LocalizarArquivo(id));
        }

        public IActionResult New()
        {
            
                return View();
          
        }


    }
}
