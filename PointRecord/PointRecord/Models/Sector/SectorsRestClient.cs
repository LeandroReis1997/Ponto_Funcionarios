using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PointRecord.Models.Sector
{
    public class SectorsRestClient
    {
        //Rodar api pelo IIS
        //private string BASE_URL = "https://localhost:44357/api/sector/";

        //Rodar pelo Console
        private string BASE_URL = "https://localhost:5001/api/sector/";

        public Task<HttpResponseMessage> GetAll()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync("getall");
        }

        public Task<HttpResponseMessage> GetAllOrderBy()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync("getallorderby");
        }

        public Task<HttpResponseMessage> Find(long id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync("find/" + id);
        }

        public Task<HttpResponseMessage> Create(Sectors sectors)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PostAsJsonAsync("create", sectors);
        }

        public Task<HttpResponseMessage> Update(long id, Sectors sectors)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PutAsJsonAsync("update/" + id, sectors);
        }

        public Task<HttpResponseMessage> Delete(long id)
        {
            var category = new HttpClient();
            category.BaseAddress = new Uri(BASE_URL);
            category.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return category.DeleteAsync("delete/" + id);
        }
    }
}
