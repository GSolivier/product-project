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
        

        //Instancia atributos da classe Usuario
        private Random Codigo = new Random();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        Usuario usuarioEncontrado;

        public string UserCadastrado { get; set; }
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

        public bool VerificarCadastro(string _userEmail, string _userSenha)
        {
            Login login = new Login();
            Usuario usuarioEncontrado = usuarios.Find(x => x.Email == _userEmail);

                if (usuarioEncontrado == null)
                {
                    Console.WriteLine($"Email não cadastrado.");
                    Console.WriteLine($"");
                    return false;
                }

                if (usuarioEncontrado.Email != null && usuarioEncontrado.Email == _userEmail)
                {
                       
                            if (usuarioEncontrado.Senha != null && usuarioEncontrado.Senha == _userSenha)
                            {


                                    tool.BarraCarregamento(500, 5, "Logando");
                                    Console.WriteLine($"");
                                    return true;
                            }

                            else
                            {
                                tool.BarraCarregamento(500, 5, "SENHA INCORRETA. VOLTANDO PARA O MENU.");
                                login.Logado = false;
                                return false;
                                
                            }
                       
                }

                else
                {
                    Console.WriteLine($"Email não cadastrado. Por favor, efetue o cadastro.");
                    
                return false;
                }
            }

        public void UserLogado(string _userEmail)
        {
            Usuario usuarioEncontrado = usuarios.Find(x => x.Email == _userEmail);

            Console.WriteLine($"Bem vindo {usuarioEncontrado.Nome}! ");
            
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