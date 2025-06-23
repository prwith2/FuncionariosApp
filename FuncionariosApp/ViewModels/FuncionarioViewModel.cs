using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FuncionariosApp.Services;
using FuncionariosApp.ViewModels;
using FuncionariosApp.Views;
using FuncionariosApp.Models;

namespace FuncionariosApp.ViewModels
{
    public class FuncionarioViewModel : BaseViewModel
    {
        private readonly FuncionarioService _service;
        public ObservableCollection<Funcionario> Funcionarios { get; set; }

        public ICommand CarregarCommand { get; }
        public ICommand AdicionarCommand { get; }
        public ICommand DeletarCommand { get; }

        public Funcionario NovoFuncionario { get; set; } = new();

        public FuncionarioViewModel()
        {
            _service = new FuncionarioService();
            Funcionarios = new ObservableCollection<Funcionario>();

            CarregarCommand = new Command(async () => await CarregarFuncionarios());
            AdicionarCommand = new Command(async () => await AdicionarFuncionario());
            DeletarCommand = new Command<int>(async (id) => await DeletarFuncionario(id));
        }

        private async Task CarregarFuncionarios()
        {
            Funcionarios.Clear();
            var lista = await _service.GetFuncionariosAsync();
            foreach (var f in lista)
                Funcionarios.Add(f);
        }

        private async Task AdicionarFuncionario()
        {
            if (await _service.AddFuncionarioAsync(NovoFuncionario))
            {
                await CarregarFuncionarios();
                NovoFuncionario = new Funcionario();
            }
        }

        private async Task DeletarFuncionario(int id)
        {
            if (await _service.DeleteFuncionarioAsync(id))
            {
                await CarregarFuncionarios();
            }
        }
    }
}
