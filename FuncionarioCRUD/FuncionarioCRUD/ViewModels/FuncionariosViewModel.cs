using FuncionarioCRUD.Models;
using FuncionarioCRUD.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuncionarioCRUD.ViewModels
{
    public class FuncionariosViewModel : INotifyPropertyChanged
    {
        private readonly FuncionarioService _service;

        public ObservableCollection<Funcionario> Funcionarios { get; } = new();
        public Funcionario NovoFuncionario { get; set; } = new();

        public ICommand CarregarCommand { get; }
        public ICommand AdicionarCommand { get; }
        public ICommand AtualizarCommand { get; }
        public ICommand DeletarCommand { get; }

        public FuncionariosViewModel()
        {
            _service = new FuncionarioService();

            CarregarCommand = new Command(async () => await LoadFuncionarios());
            AdicionarCommand = new Command(async () => await AddFuncionario());
            AtualizarCommand = new Command<Funcionario>(async (f) => await UpdateFuncionario(f));
            DeletarCommand = new Command<Funcionario>(async (f) => await DeleteFuncionario(f));

            LoadFuncionarios();
        }

        public async Task LoadFuncionarios()
        {
            Funcionarios.Clear();
            var lista = await _service.GetAllAsync();
            foreach (var f in lista)
                Funcionarios.Add(f);
        }

        public async Task AddFuncionario()
        {
            if (!string.IsNullOrWhiteSpace(NovoFuncionario.Nome) && !string.IsNullOrWhiteSpace(NovoFuncionario.Senha))
            {
                await _service.CreateAsync(NovoFuncionario);
                NovoFuncionario = new Funcionario(); // limpa campos
                await LoadFuncionarios();
                OnPropertyChanged(nameof(NovoFuncionario));
            }
        }

        public async Task UpdateFuncionario(Funcionario funcionario)
        {
            await _service.UpdateAsync(funcionario);
            await LoadFuncionarios();
        }

        public async Task DeleteFuncionario(Funcionario funcionario)
        {
            await _service.DeleteAsync(funcionario.Id);
            await LoadFuncionarios();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
