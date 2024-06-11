using WebAPI.Model;

namespace AmbienteAPI.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        /*produtos*/
        public async Task<List<Produto>> GetAllProdutosAsync()
        {
            var response = await _httpClient.GetAsync("/api/Produtos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Produto>>();
        }

        public async Task<Produto> GetProdutoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Produtos/{id}");    
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Produto>();
        }

        public async Task<HttpResponseMessage> PostProdutoAsync(Produto produto)
        {
            return await _httpClient.PostAsJsonAsync("api/Produtos", produto);
        }

        public async Task<HttpResponseMessage> PutProdutoAsync(int id, Produto produto)
        {
            return await _httpClient.PutAsJsonAsync($"/api/Produtos/{id}", produto);
        }

        public async Task<HttpResponseMessage> DeleteProdutoAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/Produtos?id={id}");
        }

   
        /*Categorias*/


        public async Task<List<Categoria>> GetAllCategoriasAsync()
        {
            var response = await _httpClient.GetAsync("/api/Categoria");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Categoria>>();
        }

        public async Task<Categoria> GetCategoriaAsync(long? id)
        {
            var response = await _httpClient.GetAsync($"/api/Categoria/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Categoria>();
        }

        public async Task<HttpResponseMessage> PostCategoriaAsync(Categoria categoria)
        {
            return await _httpClient.PostAsJsonAsync("/api/Categoria", categoria);
        }

        /* public async Task<HttpResponseMessage> PutCategoriaAsync(long? id, Categoria categoria)
         {
             var response = await _httpClient.PutAsJsonAsync($"api/Categorias/{id}", categoria);
             response.EnsureSuccessStatusCode();
             return response;
         }*/

        public async Task<HttpResponseMessage> PutCategoriaAsync(long? id, Categoria categoria)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Categorias/{id}", categoria);
            response.EnsureSuccessStatusCode();
            return response;
        }


        public async Task<HttpResponseMessage> DeleteCategoriaAsync(long? id)
        {
            var response = await _httpClient.DeleteAsync($"api/Categorias/{id}");
            response.EnsureSuccessStatusCode();
            return response;
        }




    }
}
