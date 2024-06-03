using ExamenConciertosAWSMVC.Models;
using System.Net.Http.Headers;

namespace ExamenConciertosAWSMVC.Services
{
    public class ServiceApiConciertos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;

        public ServiceApiConciertos(KeysModel keys)
        {
            this.UrlApi = keys.ApiConciertos;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/conciertos";
            List<Evento> data = await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<List<Evento>> GetEventoAsync(int idcategoria)
        {
            string request = "api/conciertos" + idcategoria;
            List<Evento> data = await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            string request = "api/conciertos";
            List<Categoria> data = await this.CallApiAsync<List<Categoria>>(request);
            return data;
        }
    }
}
