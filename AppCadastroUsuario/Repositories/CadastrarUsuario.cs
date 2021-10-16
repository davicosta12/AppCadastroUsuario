using AppCadastroUsuario.Interfaces;
using AppCadastroUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastroUsuario.Repositories
{
    public class CadastrarUsuario : ICadastrarUsuario<User>
    {
        readonly List<User> listaUsuariosCadastrados = new();

        public List<User> ListaUsuarios()
        {
            return listaUsuariosCadastrados;
        }

        public User ObtemUsuario(int id)
        {
            User usuarioProcurado = listaUsuariosCadastrados.Find(elem => elem.GetId() == id);

            if(usuarioProcurado == null)
            {
                return null;
            }

            return listaUsuariosCadastrados[id];
        }

        public void InseriUsuario(User usuarioNovo)
        {
            listaUsuariosCadastrados.Add(usuarioNovo);
        }

        public void AtualizaUsuario(int id, User usuarioNovo)
        {
            listaUsuariosCadastrados[id] = usuarioNovo;
        } 

        public void RemoveUsuario(int id)
        {
            listaUsuariosCadastrados[id].ExcluirUsuario();
        }

        public int ProximoUserId()
        {
            return listaUsuariosCadastrados.Count();
        }
    }
}
