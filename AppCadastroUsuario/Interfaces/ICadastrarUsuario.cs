using AppCadastroUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroUsuario.Interfaces
{
    public interface ICadastrarUsuario<T>
    {
        public List<T> ListaUsuarios();
        public T ObtemUsuario(int id);
        public void InseriUsuario(T novoUsuario);
        public void AtualizaUsuario(int id, T novoUsuario);
        public void RemoveUsuario(int id);
    }
}
