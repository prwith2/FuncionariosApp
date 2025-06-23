using FuncionariosApp.Views;
using FuncionariosApp.ViewModels;

namespace FuncionariosApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
