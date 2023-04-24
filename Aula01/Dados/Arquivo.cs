using Aula01.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System;
using Newtonsoft.Json.Linq;

namespace Aula01.Dados
{
    public class Arquivo
    {
        public void SalvarArquivo(ClientesModelView dados)
        {
            List<ClientesModelView> array;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                array = JsonSerializer.Deserialize<List<ClientesModelView>>(meusDados);
                array.Add(dados);

                
            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(array));
        }

        public List<ClientesModelView> ListaClientes()
        {
            List<ClientesModelView> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ClientesModelView>>(meusDados);
                return retorno;

            }
        }

        public void ExcluirArquivo(int id)
        {
            List<ClientesModelView> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ClientesModelView>>(meusDados);
                ClientesModelView item = retorno.Find(a => a.Id == id);
                if(item != null)
                {
                    retorno.Remove(item);
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(retorno));
        }

        public void EditarArquivo(ClientesModelView dados)
        {
            List<ClientesModelView> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ClientesModelView>>(meusDados);
                int item = retorno.FindIndex(a => a.Id == dados.Id);
                if (item != null)
                {
                    retorno[item] = dados;
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(retorno));
        }

        public ClientesModelView LocalizarArquivo(int Id)
        {
            List<ClientesModelView> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<ClientesModelView>>(meusDados);
                ClientesModelView item = retorno.Find(a => a.Id == Id);
                if (item != null)
                {
                    return item;
                }
                else
                {
                    return new ClientesModelView();
                }

            }
           
        }

    }
        
      
}
