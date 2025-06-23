using FuncionarioCRUD.ViewModels;
using FuncionarioCRUD.Services;
namespace FuncionariosCRUD.Views;

public partial class MainPage : ContentPage
{
    public MainPage(FuncionarioViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
