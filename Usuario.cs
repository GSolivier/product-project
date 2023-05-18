using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Usuario
    {

        //Instancia objetos de outras classes
        Ferramentas tool = new Ferramentas(); // Cria um objeto global da classe 'Ferramentas', para utilizar os métodos e atributos das classes aqui.
        
        //Instancia atributos da classe Usuario
        private Random Codigo = new Random(); // Cria um atributo privado para a criação de um número randomico.

        // Instancia os atributos da classe Usuario.
        public string Nome { get; set; } 
        public string Email { get; set; }
        public string Senha { get; set; }
        public string UserCadastrado { get; set; }


        private DateTime DataCadastro = DateTime.Now; // Cria um atributo do tipo DateTime, para fornecer a data atual e guardar em uma varivael.

        //Instancia a lista ''usuarios''
        List<Usuario> usuarios = new List<Usuario>();


        //Criação dos métodos da clasee
        public void Cadastrar() // Método que tem como objetivo cadastrar novos usuários em uma lista.
        {
            Usuario NovoUsuario = new Usuario(); // Criação de um objeto exclusivo desse método, para armazenar os atributos que o usuário digitar.


            Console.WriteLine($"MENU DE CADASTRO DE USUÁRIO"); 

            Console.WriteLine($"Digite seu nome completo:"); // Pede o Nome completo para o usuário.
            NovoUsuario.Nome = Console.ReadLine(); // Guarda o nome do usuário no atributo 'Nome' do objeto criado acima.

            Console.WriteLine($"Digite seu email:"); // Pede o email para o usuário.
            NovoUsuario.Email = Console.ReadLine(); // Guarda o email do usuário no atributo 'Email' do objeto criado acima.

            Console.WriteLine($"Digite sua senha: "); // Pede a senha para o usuário.
            NovoUsuario.Senha = Console.ReadLine(); // Guarda a senha do usuário no atributo 'Senha' do objeto criado acima.

            tool.BarraCarregamento(500,5,"Cadastrando"); // Ferramenta da classe 'Ferramentas', que cria uma barra de carregamento simples.

            Console.WriteLine($"Usuário Cadastrado com sucesso!"); // Informa o usuário que o cadastro foi efetuado.

            Console.WriteLine($"Data de cadastro: {NovoUsuario.DataCadastro}"); // Mostra ao usuário a data do cadastro, e armazena no atributo `DataCadastro` do obejto criado acima.
            Console.WriteLine($"Código de cadastro: {NovoUsuario.Codigo.Next(10000,1000000)}"); // Gera um código ao usuário, entre dez mil e um milhão, e armazena no atributo 'Codigo' do objeto criado acima.

            usuarios.Add(NovoUsuario); // Adiciona o objeto com todos os atributos salvos na lista 'usuarios'.
        }

        public bool VerificarCadastro(string _userEmail, string _userSenha) // Método booleano para verificar quando o usuário tentar logar, se aquele cadastro ja existe, passando como parâmetro o email e senha que o usuário digita.
        {
            Usuario usuarioEncontrado = usuarios.Find(x => x.Email == _userEmail); // Cria um objeto da classe usuário, que pega o email que o usuário digita no login, e usando o Find, ele verifica se aquele email existe, guardando no objeto 'usuarioEncontrado'

                if (usuarioEncontrado == null) // Se o 'usuarioEncontrado' não existir, entra nesse caso.
                {
                    Console.WriteLine($"Email ou senha icorretos."); // Retorna para o usuário que o email ou senha estão incorretos.
                    return false; // retorna o valor 'false' para o método.
                }

                if (usuarioEncontrado.Email != null && usuarioEncontrado.Email == _userEmail) // Se o atributo 'Email' do objeto acima for diferente de nulo e o mesmo atributo for igual ao email digitado pelo usuário, entra nesse caso.
                { 
                            if (usuarioEncontrado.Senha != null && usuarioEncontrado.Senha == _userSenha) // Se o atributo 'Senha' for diferente de nulo, e o mesmo atributo for igual a senha digitada pelo usuário, entra nesse caso.
                            {
                                    tool.BarraCarregamento(500, 5, "Logando"); // Barra de carregamento da classe ferramenta.
                                    return true; // retorna o valor true para o método booleano.
                            }

                            else // Se não entrar no caso acima, entra nesse caso.
                            {
                                    Console.WriteLine($"Email ou senha incorretos"); // Informa ao usuário que algo esta errado.
                                    return false; // retorna o valor falso para o método.
                            }  
                }

                else // Se nao entrar no caso acima, entra nesse caso.
                {
                    Console.WriteLine($"Email não cadastrado. Por favor, efetue o cadastro."); // Informa o usuário que o email nao foi cadastrado.
                    return false; // Retorna o valor falso para o método.
                }
            }

        public string UserLogado(string _userEmail) // Método para veficiar o usuário que esta logado
        {
            Usuario usuarioEncontrado = usuarios.Find(x => x.Email == _userEmail); // Cria um objeto da classe usuário, que pega o email que o usuário digita no login, e usando o Find, ele verifica se aquele email existe, guardando no objeto 'usuarioEncontrado'

            Console.WriteLine($"Bem vindo {usuarioEncontrado.Nome}! "); // Informa o nome do usuário que está logado.
            
            return usuarioEncontrado.Nome;
        }


       public bool Deletar(string _userEmail)
        {
            Login login = new Login();

            Usuario usuarioEncontrado = usuarios.Find(x => x.Email == _userEmail);

            if (usuarioEncontrado == null)
            {
                Console.WriteLine($"Email incorreto. Retornando ao menu");
                return false;
            }

            if (usuarioEncontrado.Email != null && usuarioEncontrado.Email == _userEmail)
            {
                Console.WriteLine($"Tem certeza que deseja excluir a sua conta? 's' para sim ou 'n' para não.");
                ConsoleKeyInfo escolhaMenu = Console.ReadKey(true);

                if (escolhaMenu.Key == ConsoleKey.S)
                {   
                    int index = usuarios.IndexOf(usuarioEncontrado);
                    usuarios.RemoveAt(index);
                    tool.BarraCarregamento(500, 5, "Apagando seus dados");

                    Console.WriteLine($"Dados apagados com sucesso!");
                    login.Deslogar();
                    return true;
            
                }

                else if (escolhaMenu.Key == ConsoleKey.N)
                {
                    tool.BarraCarregamento(500, 5, "Cancelando Operação");
                    return false;
                }
                else
                {
                    Console.WriteLine($"Tecla inválida.");
                    return false;
                }

            }
            return false;
            }
        }
    }

