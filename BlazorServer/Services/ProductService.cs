using BlazorServer.DTO;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorServer.Services
{
    public class ProductService
    {
        private readonly NavigationManager _nav;
        private HttpClient client;
        public ProductService(NavigationManager nav, IHttpClientFactory httpClientFactory)
        {
            this._nav = nav;
            client = httpClientFactory.CreateClient("AppClient");
        }

        public async Task<List<ProductResponse>> GetAll()
        {
            var products = await client.GetAsync("product/getAllProducts");
            if (products.IsSuccessStatusCode)
            {

                var resultJson = products.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<ProductResponse>>(resultJson);
                //await _accessTokenService.SetToken(result.AccessToken);

                return result;
            }
            else
            {
                return new List<ProductResponse>();
            }
        }

        public async Task<bool> InsertProduct(ProductRequest req)
        {
            var products = await client.PostAsJsonAsync("product/insertProduct", req);
            if (products.IsSuccessStatusCode)
            {


                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
