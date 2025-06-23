using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Models
{
    public class Funcionario
    {
        public int Id_funcionario { get; set; } 
        public string Nome_funcionario { get; set; } = string.Empty;
        public string Senha_funcionario { get; set; } = string.Empty;
    }
}
