using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Login
    {
        Usuario user = new Usuario(); // Cria um objeto global da classe 'Usuario', para utilizar os métodos e atributos das classes aqui.
        Ferramentas tool = new Ferramentas(); // Cria um objeto global da classe 'Ferramentas', para utilizar os métodos e atributos das classes aqui.

        Produto product = new Produto();

        public bool Logado { get; set; } // atributo booleano para validar se o usuário está ou não logado.
        public bool loopBreak = true; // atributo privado utilizado somente no loop do menu de login e cadastro.

        public Login()
        {
            
        }

        public void Programa() // Classe que faz rodar todo o programa, contendo as lógicas dos menus.
        {   

            Login: // ponto de partida, para utilização futuras do 'goto'

            do // loop dowhile para o menu de cadastro e login
            {
                Console.WriteLine($"BEM VINDO AO NOSSO PROGRAMA!"); // mostra o menu para o usuário no console.

                    Console.WriteLine(@$"
                                O que deseja fazer?

                                    [1] - Login
                                    [2] - Cadastro

                                [0] - Sair do programa
                    "); 

                    ConsoleKeyInfo escolhaMenu = Console.ReadKey(true); // Lê a tecla que o usuário aperta, e guarda ela na variável 'escolhaMenu'. ReadKey(true) para que a tecla apertada não apareça no console.

                    switch (escolhaMenu.Key) // swtich case para a validação da tecla apertada pelo usuário
                    {

                        case ConsoleKey.D1: // primeiro caso, se o usuário apertar o número 1 no teclado e escolher a opção [1] - login.
                            Logar(); // chama a função logar.
                                break; // quebra o laço de repetição assim que a função logar é executada.

                        case ConsoleKey.D2: // segundo caso, se o usuário apertar o número 2 no teclado e escolher a opção [2] - cadastro.
                            user.Cadastrar(); // Usa o objeto que foi instanciado globalmente, e com ele chama a função cadastrar.
                                break; // quebra o laço de repetição assim que a função Cadastrar é executada.

                        case ConsoleKey.D0: // terceiro caso, se o usuário apertar o número 0 no teclado e escolher a opção [0] - Sair do programa.
                            tool.BarraCarregamento(500, 5, "Encerrando"); // Chama a classe ferramentas, através do objeto 'tool' instanciado globalmente, nesse caso, a funçao barra de carregamento é utilizada. 
                            loopBreak = false; // quebra o loop dowhile, com fim de se encerrar o programa
                                break; // quebra o loop switch

                        default: // quando nenhuma tecla acima é selecionada, entra no caso default
                            Console.WriteLine($"Aperte uma tecla válida!"); // informa o usuário para digitar uma tecla válida.
                                break; // retorna para as opções.
                    }
    
            } while (loopBreak); // condição para que o loop dowhile continue, sempre que o loopBreak manter seu estado natural, que é true.


            while (Logado == true) // Loop while, apenas irá rodar se o atributo 'Logado' da classe Login, estiver como true.
            {
                Console.WriteLine(@$" 
                         MENU PRINCIPAL
        
                    [1] - CADASTRAR PRODUTOS
                    [2] - LISTAR PRODUTOS
                    [3] - REMOVER PRODUTOS
                    [4] - CADASTRAR MARCAS
                    [5] - LISTAR MARCAS
                    [6] - REMOVER MARCAS

                    [7] - INFORMAÇÕES DA CONTA
                    [8] - APAGAR A CONTA

                    [0] - DESLOGAR
                    "); // Mostra o menu para o usuário, assim que estiver logado.
    
                ConsoleKeyInfo escolhaMenu = Console.ReadKey(true); // Lê a tecla que o usuário aperta, e guarda ela na variável 'escolhaMenu', ReadKey(true) para que a tecla apertada não apareça no console.

                    switch (escolhaMenu.Key) // swtich case para a validação da tecla apertada pelo usuário
                    {

                        case ConsoleKey.D1:
                            product.Cadastrar();
                        break;

                        case ConsoleKey.D2:
                            product.Listar();
                        break;

                        case ConsoleKey.D3:
                            Console.WriteLine($"Digite o código do produto que deseja deletar:");
                            int userCodigo = int.Parse(Console.ReadLine());
                            
                            product.Deletar(userCodigo);
                        break;

                        case ConsoleKey.D8: // oitavo caso, se o usuário apertar o número 8 no teclado e escolher a opção [8] - APAGAR A CONTA.
                            Console.WriteLine($"Para confirmar a ação, digite o seu email:"); // Pede ao usuário para digitar seu email, a fim de confirmação da exclusão da conta.
                            string userEmail = Console.ReadLine(); // guarda a informação digitada pelo usuário na variável 'userEmail'.
                            user.Deletar(userEmail); // Chama a função 'Deletar' da classe usuário, passando como parâmetro a váriavel 'userEmail.'

                            if (user.Deletar(userEmail) == true)
                            {
                                goto Login; // se a exclusão for confirmada, vai até o ponto de partida 'LOGIN'
                            }
                            else
                            {

                            }
                        break;

                        case ConsoleKey.D0: // nono caso, se o usuário apertar o número 0 no teclado e escolher a opção [0] - DESLOGAR.
                            Deslogar(); // Chama a função 'Deslogar' da classe Login.
                                goto Login; // vai até o ponto de partida 'Login'.

                            default:
                                break;
                    }
            }
 
        }

        public void Logar() //Função responsável pela logica da funçao de executar o login.
        {
            Console.WriteLine($"Digite seu email: "); // Pede o email para o usuário.
            string userEmail = Console.ReadLine(); // Armazena o email digitado pelo usuário na variável 'userEmail'


            Console.WriteLine($"Digite sua senha: "); // Pede a senha para o usuário.
            string userSenha = Console.ReadLine(); // Armazena a senha digitado pelo usuário na variável 'userSenha'

            user.VerificarCadastro(userEmail, userSenha); // Após o usuário digitar as informações, a função 'VerificarCadastro' da classe Usuario é chamada, passando como parâmetros o email e senha fornecidos pelo usuário. Esse método retorna um booleano.

            if (user.VerificarCadastro(userEmail, userSenha) == true) // Condição de if simples, que verifica se o método retorna um valor booleano true.
            {
                    Logado = true; // Muda o estado do atributo 'Logado' para true, para que seja possivel entrar no loop em que se necessita esse estado.
                    loopBreak = false; // Muda o estado do atributo 'loopBreak' para false, para quebrar o loop do login e cadastro.

                user.UserLogado(userEmail); // Função da classe Usuário, que verifica e estabelece qual usuário está logado.
            }


        }

        public void Deslogar() // Método que realizar o logoff do usuário.
        {
            tool.BarraCarregamento(500,5,"Deslogando"); // função da classe 'Ferramentas', que realiza uma barra de carregamento. 
            Logado = false; // Inverte os valores dos atributos.
            loopBreak = true; // Inverte os valores dos atributos.
        }
    }
}

