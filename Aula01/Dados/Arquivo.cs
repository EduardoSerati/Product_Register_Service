using Aula01.Models;
using System.Text.Json;

namespace Aula01.Dados
{
    public class Arquivo
    {
        public void SalvarArquivo(ProductModelView dados)
        {
            List<ProductModelView> array;
            using (StreamReader r = new(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                array = JsonSerializer.Deserialize<List<ProductModelView>>(meusDados);
                array.Add(dados);

                
            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(array));
        }

        public List<ProductModelView> ProductList()
        {
            List<ProductModelView> retorno;
            using (StreamReader r = new(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ProductModelView>>(meusDados);
                return retorno;

            }
        }

        public void ExcluirArquivo(int id)
        {
            List<ProductModelView> retorno;
            using (StreamReader r = new(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ProductModelView>>(meusDados);
                ProductModelView item = retorno.Find(a => a.Id == id);
                if(item != null)
                {
                    retorno.Remove(item);
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(retorno));
        }

        public void EditarArquivo(ProductModelView dados)
        {
            List<ProductModelView> retorno;
            using (StreamReader r = new(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ProductModelView>>(meusDados);
                int item = retorno.FindIndex(a => a.Id == dados.Id);
                if (item != null)
                {
                    retorno[item] = dados;
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(retorno));
        }

        public ProductModelView LocalizarArquivo(int Id)
        {
            List<ProductModelView> retorno;
            using (StreamReader r = new(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ProductModelView>>(meusDados);
                ProductModelView item = retorno.Find(a => a.Id == Id);
                if (item != null)
                {
                    return item;
                }
                else
                {
                    return new ProductModelView();
                }

            }
           
        }

    }
        
      
}
