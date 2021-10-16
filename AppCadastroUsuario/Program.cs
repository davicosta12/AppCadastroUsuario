using AppCadastroUsuario.Models;
using AppCadastroUsuario.Repositories;
using System;

namespace AppCadastroUsuario
{
    class Program
    {
        static CadastrarUsuario cadastraUsuarioRepositorio = new();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarUsuarios();
                        break;
                    case "2":
                        InseriUsuario();
                        break;
                    case "3":
                        AtualizaUsuario();
                        break;
                    case "4":
                        ExcluirUsuario();
                        break;
                    case "5":
                        VisualizarUsuario();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarUsuarios()
        {
            Console.WriteLine("*** Listar usuários ***");

            var lista = cadastraUsuarioRepositorio.ListaUsuarios();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var usuario in lista)
                Console.WriteLine($"#ID {usuario.GetId()}: - Nome: {usuario.Nome} CPF:{usuario.CPF} {(usuario.Excluido ? "*Excluído*" : "")}"); 
        }

        private static void InseriUsuario()
        {
            string nome, email;
            long telefone, cpf;

            Console.WriteLine("*** Inseri um novo usuário ***");

            LeDadosUsuario(out nome, out email, out telefone, out cpf);

            User usuario = new(cadastraUsuarioRepositorio.ProximoUserId(), nome, email, telefone, cpf);

            cadastraUsuarioRepositorio.InseriUsuario(usuario);
        }

        private static void AtualizaUsuario()
        {
            Console.WriteLine("*** Atualiza dados do usuário ***");

            string nome, email;
            long telefone, cpf;

            Console.Write("Digite o id do usuário: ");
            int id = Int32.Parse(Console.ReadLine());

            User usuarioProcurado = cadastraUsuarioRepositorio.ObtemUsuario(id);

            if(usuarioProcurado == null)
            {
                Console.WriteLine();
                Console.WriteLine("Usuário não encontrado!");
            }
            else
            {
                LeDadosUsuario(out nome, out email, out telefone, out cpf);
                User usuarioAlterado = new(id, nome, email, telefone, cpf);
                cadastraUsuarioRepositorio.AtualizaUsuario(id, usuarioAlterado);
            }
        }

        private static void ExcluirUsuario()
        {
            Console.WriteLine("*** Excluir Usuário ***");

            Console.Write("Digite o id do usuário: ");
            int id = Int32.Parse(Console.ReadLine());

            User usuarioProcurado = cadastraUsuarioRepositorio.ObtemUsuario(id);

            if (usuarioProcurado == null)
            {
                Console.WriteLine();
                Console.WriteLine("Usuário não encontrado!");
            }
            else
            {
                cadastraUsuarioRepositorio.RemoveUsuario(id);
            }
        }

        private static void VisualizarUsuario()
        {
            Console.WriteLine("*** Visualizar Usuário ***");

            Console.Write("Digite o id do usuário: ");
            int id = Int32.Parse(Console.ReadLine());

           User usuarioProcurado = cadastraUsuarioRepositorio.ObtemUsuario(id);

           if (usuarioProcurado == null)
           {
                Console.WriteLine();
                Console.WriteLine("Usuário não encontrado!");
           }
           else
           {
                Console.WriteLine(usuarioProcurado);
           }
        }

        private static void LeDadosUsuario(out string nome, out string email, out long telefone, out long cpf)
        {
            Console.Write("Digite o Nome do usuário: ");
            nome = Console.ReadLine();
            Console.Write("Digite o Email do usuário: ");
            email = Console.ReadLine();
            Console.Write("Digite o Telefone do usuário: ");
            telefone = Int64.Parse(Console.ReadLine());
            Console.Write("Digite o CPF do usuário: ");
            cpf = Int64.Parse(Console.ReadLine());
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Aplicativo de Cadastro dos usuários!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar usuários cadastrados");
            Console.WriteLine("2- Inserir novo usuário");
            Console.WriteLine("3- Atualizar usuário");
            Console.WriteLine("4- Excluir usuário");
            Console.WriteLine("5- Visualizar usuário");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
