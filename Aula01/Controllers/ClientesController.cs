using Aula01.Dados;
using Aula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    public class ClientesController : Controller
    {
        public static List<ClientesModelView> db = new List<ClientesModelView>();

        public IActionResult SalvarDados(ClientesModelView dados)
        {
            if (dados.Id > 0)
            {
                Arquivo arquivo = new Arquivo();
                arquivo.EditarArquivo(dados);
                //int index = db.FindIndex(a => a.Id == dados.Id);
                //db[index] = dados;
            }
            else
            {
                Random rand = new Random();
                dados.Id = rand.Next(1, 9999);
                db.Add(dados);
                Arquivo arquivo = new Arquivo();
                arquivo.SalvarArquivo(dados);
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Lista()
        {
            Arquivo arquivo = new Arquivo();
            return View(arquivo.ListaClientes());
        }

        public IActionResult Excluir(int id)
        {
            Arquivo arquivo = new Arquivo();
            arquivo.ExcluirArquivo(id);
            return RedirectToAction("Lista");
        }

        public IActionResult Editar(int id)
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
            Arquivo arquivo = new Arquivo();
         
            return View(arquivo.LocalizarArquivo(id));
        }

        public IActionResult Novo()
        {
            
                return View();
          
        }


    }
}
