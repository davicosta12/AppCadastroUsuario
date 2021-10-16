using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroUsuario.Models
{
    public class User
    {
        private int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public long Telefone { get; private set; }
        public long CPF { get; private set; }
        public bool Excluido { get; private set; } = false;

        public User(int id, string nome, string email, long telefone, long cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
        }

        public void ExcluirUsuario()
        {
            Excluido = true;
        }

        public int GetId()
        {
            return Id;
        }

        public override string ToString()
        {
            string usuarioText = "";
            usuarioText += "Nome: " + Nome + Environment.NewLine;
            usuarioText += "Email: " + Email + Environment.NewLine;
            usuarioText += "Telefone: " + Telefone + Environment.NewLine;
            usuarioText += "CPF: " + CPF + Environment.NewLine;
            usuarioText += (Excluido ? "Excluído: Usuário Deletado!" : "");
            return usuarioText;
        }
    }
}
