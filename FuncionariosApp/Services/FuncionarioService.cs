using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using FuncionariosApp.Models;

namespace FuncionariosApp.Services
{
    public class FuncionarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUrl = "https://localhost:5126/api/Funcionario";

        public FuncionarioService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Funcionario>> GetFuncionariosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Funcionario>>(baseUrl);
        }

        public async Task<bool> AddFuncionarioAsync(Funcionario funcionario)
        {
            var response = await _httpClient.PostAsJsonAsync(baseUrl, funcionario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteFuncionarioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
