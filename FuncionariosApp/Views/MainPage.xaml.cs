using FuncionariosApp.Services;
using FuncionariosApp.ViewModels;
namespace FuncionariosApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage(FuncionarioViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
