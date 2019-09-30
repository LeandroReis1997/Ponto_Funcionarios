using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PointRecord.Models.Employees
{
    public class EmployeesRestClient
    {
        //Rodar api pelo IIS
        private string BASE_URL = "https://localhost:44367/api/employees/";

        //Rodar pelo Console
        //private string BASE_URL = "https://localhost:5001/api/employees/";

        public Task<HttpResponseMessage> GetAll()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync("getall");
        }

        public Task<HttpResponseMessage> Find(long id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"find/{id}");
        }

        public Task<HttpResponseMessage> FindName(string name)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync($"findname/{name}");
        }


        public Task<HttpResponseMessage> Create(Employeees employees)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PostAsJsonAsync("create", employees);
        }

        public Task<HttpResponseMessage> Update(long id, Employeees employees)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            return client.PutAsJsonAsync("update/" + id, employees);
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
