using Aula01.Dados;
using Aula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductModelView> db = new();

        public IActionResult DataSave(ProductModelView data)
        {
            if (data.Id > 0)
            {
                Archive archive = new();
                archive.EditArchive(data);
            }
            else
            {
                Random rand = new();
                data.Id = rand.Next(1, 100);
                db.Add(data);
                Archive archive = new();
                archive.DataSave(data);
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            Archive archive = new();
            return View(archive.ProductList());
        }

        public IActionResult Delete(int id)
        {
            Archive archive = new();
            archive.ExcluirArquivo(id);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            Archive archive = new();
            return View(archive.FindArchive(id));
        }

        public IActionResult New()
        {
                return View();
        }
    }
}
