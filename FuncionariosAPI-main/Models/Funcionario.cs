using System.ComponentModel.DataAnnotations;

namespace FuncionariosAPI.Models
{
    public class Funcionario
    {
        [Key]
        public int Id_funcionario { get; set; }

        public string Nome_Funcionario { get; set; } = string.Empty;

        public string Senha_funcionario { get; set; } = string.Empty;
    }
}
