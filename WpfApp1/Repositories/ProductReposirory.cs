using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using System.Net.Http.Json;

namespace WpfApp1.Repositories
{
    internal class ProductReposirory
    {
        public async Task<ProductEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ProductEntity[]>($"{ServerConstants.Host}/v1/product");
            return response;
        }

        public async Task<ProductEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ProductEntity>($"{ServerConstants.Host}/v1/product/{id}");
            return response;
        }

        public async Task<ProductEntity> PostAsync(ProductEntity productEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/product", productEntity);
            return await response.Content.ReadFromJsonAsync<ProductEntity>();
        }

        public async Task<ProductEntity> PutAsync(ProductEntity productEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/product", productEntity);
            return await response.Content.ReadFromJsonAsync<ProductEntity>();
        }

        public async Task<ProductEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<ProductEntity>($"{ServerConstants.Host}/v1/product/{id}");
            return response;
        }

    }
}
