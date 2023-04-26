using Aula01.Models;
using System.Text.Json;

namespace Aula01.Dados
{
    public class Archive
    {
        public void DataSave(ProductModelView data)
        {
            List<ProductModelView> array;
            using (StreamReader sr = new(@"data.json"))
            {
                string registerData = sr.ReadToEnd();
                array = JsonSerializer.Deserialize<List<ProductModelView>>(registerData);
                array.Add(data);

                
            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(array));
        }

        public List<ProductModelView> ProductList()
        {
            List<ProductModelView> back;
            using (StreamReader sr = new(@"data.json"))
            {
                string registerData = sr.ReadToEnd();
                back = JsonSerializer.Deserialize<List<ProductModelView>>(registerData);
                return back;

            }
        }

        public void ExcluirArquivo(int id)
        {
            List<ProductModelView> back;
            using (StreamReader sr = new(@"data.json"))
            {
                string registerData = sr.ReadToEnd();
                back = JsonSerializer.Deserialize<List<ProductModelView>>(registerData);
                ProductModelView item = back.Find(a => a.Id == id);
                if(item != null)
                {
                    back.Remove(item);
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(back));
        }

        public void EditArchive(ProductModelView data)
        {
            List<ProductModelView> back;
            using (StreamReader sr = new(@"data.json"))
            {
                string registerData = sr.ReadToEnd();
                back = JsonSerializer.Deserialize<List<ProductModelView>>(registerData);
                int item = back.FindIndex(a => a.Id == data.Id);
                if (item != null)
                {
                    back[item] = data;
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(back));
        }

        public ProductModelView FindArchive(int Id)
        {
            List<ProductModelView> back;
            using (StreamReader sr = new(@"data.json"))
            {
                string registerData = sr.ReadToEnd();
                back = JsonSerializer.Deserialize<List<ProductModelView>>(registerData);
                ProductModelView item = back.Find(a => a.Id == Id);
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
