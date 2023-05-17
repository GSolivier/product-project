using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Usuario
    {

        //Instancia objetos de outras classes
        Ferramentas tool = new Ferramentas();
        Login login = new Login();

        //Instancia atributos da classe Usuario
        private Random Codigo = new Random();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        private DateTime DataCadastro = DateTime.Now;

        //Instancia a lista ''usuarios''
        List<Usuario> usuarios = new List<Usuario>();


        //Criação dos métodos da clasee
        public string Cadastrar()
        {
            Usuario NovoUsuario = new Usuario();


            Console.WriteLine($"MENU DE CADASTRO DE USUÁRIO");

            Console.WriteLine($"Digite seu nome completo:");
            NovoUsuario.Nome = Console.ReadLine();

            Console.WriteLine($"Digite seu email:");
            NovoUsuario.Email = Console.ReadLine();

            Console.WriteLine($"Digite sua senha: ");
            NovoUsuario.Senha = Console.ReadLine();

            tool.BarraCarregamento(500,5,"Cadastrando");

            Console.WriteLine($"Usuário Cadastrado com sucesso!");

            Console.WriteLine($"Data de cadastro: {NovoUsuario.DataCadastro}");
            Console.WriteLine($"Código de cadastro: {NovoUsuario.Codigo.Next(10000,1000000)}");
            usuarios.Add(NovoUsuario);
            return "";
        }

        public void VerificarCadastro(string _userEmail)
        {
            // Usuario usuarioEncontrado = usuarios.Find(x => x.Email == _userEmail);
            // int index = usuarios.IndexOf(usuarioEncontrado);

            // usuarios.

            foreach (var item in usuarios)
            {
                if (item.Email.Contains(_userEmail))
                {
                        login.Logado = true;
                }

                else
                {
                    Console.WriteLine($"Email não cadastrado. Por favor, efetue o cadastro.");
                }
            }
        }

        public string Deletar(Usuario _usuario)
        {
            Console.WriteLine($"Tem certeza que deseja excluir a sua conta? 's' para sim ou 'n' para não.");
            ConsoleKeyInfo escolhaMenu = Console.ReadKey(true);

            switch (escolhaMenu.Key)
            {
                case ConsoleKey.S:
                int index = usuarios.IndexOf(_usuario);
                usuarios.RemoveAt(index);
                tool.BarraCarregamento(500,5,"Apagando seu dados");

                Console.WriteLine($"Dados apagados com sucesso!");
                    break;

                case ConsoleKey.N:
                tool.BarraCarregamento(500,5,"Cancelando Operação");
                break;
                default:
                Console.WriteLine($"Tecla inválida.");
                    break;
            }


                return "";
        }
    }
}