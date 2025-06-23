using FuncionarioCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FuncionarioCRUD.Services
{
    public class FuncionarioService
    {
        private readonly HttpClient _httpClient;

        public FuncionarioService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5126/api/Funcionario")
            };
        }

        public async Task<List<Funcionario>> GetAllAsync() =>
            await _httpClient.GetFromJsonAsync<List<Funcionario>>("api/funcionarios");

        public async Task<Funcionario> GetByIdAsync(int id) =>
            await _httpClient.GetFromJsonAsync<Funcionario>($"api/funcionarios/{id}");

        public async Task<bool> CreateAsync(Funcionario funcionario)
        {
            var response = await _httpClient.PostAsJsonAsync("api/funcionarios", funcionario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(Funcionario funcionario)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/funcionarios/{funcionario.Id}", funcionario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/funcionarios/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
