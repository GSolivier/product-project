using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Login
    {
        
        Usuario user = new Usuario();
        Ferramentas tool = new Ferramentas();
        public bool Logado { get; set; }

        public bool loopBreak = true;
        public Login()
        {
            
        }

        public void Programa()
        {   
        Login:
        do
        {
            
                Console.WriteLine($"BEM VINDO AO NOSSO PROGRAMA!");

                    Console.WriteLine(@$"
                                O que deseja fazer?

                                    [1] - Login
                                    [2] - Cadastro

                                [0] - Sair do programa
                    ");

                    ConsoleKeyInfo escolhaMenu = Console.ReadKey(true);

                    switch (escolhaMenu.Key)
                    {
                        case ConsoleKey.D1:
                        Logar();
                            break;

                        case ConsoleKey.D2:
                                user.Cadastrar();
                                break;
                        default:
                            break;
                    }
    
} while (loopBreak);

while (Logado == true)
{
    
    
    Console.WriteLine(@$"
            MENU PRINCIPAL
        
        [1] - CADASTRAR PRODUTOS
        [2] - LISTAR PRODUTOS
        [3] - REMOVER PRODUTOS
        [4] - CADASTRAR MARCAS
        [5] - LISTAR MARCAS
        [6] - REMOVER MARCAS
        [7] - APAGAR A CONTA

        [0] - DESLOGAR
    ");
    
    ConsoleKeyInfo escolhaMenu = Console.ReadKey(true);

                    switch (escolhaMenu.Key)
                    {
                        case ConsoleKey.D0:
                        Deslogar();

                        goto Login;

                        case ConsoleKey.D7:
                        Console.WriteLine($"Para confirmar a ação, digite o seu email:");
                        string userEmail = Console.ReadLine();

                        user.Deletar(userEmail);
                        goto Login;
                        default:
                            break;
                    }


}
 
        }



        public void Logar()
        {
            Console.WriteLine($"Digite seu email: ");
            string userEmail = Console.ReadLine();


            Console.WriteLine($"Digite sua senha: ");
            string userSenha = Console.ReadLine();

            user.VerificarCadastro(userEmail, userSenha);

            if (user.VerificarCadastro(userEmail, userSenha) == true)
            {
                    Logado = true;
                    loopBreak = false;

                user.UserLogado(userEmail);
            }


        }
        public void Deslogar()
        {
            tool.BarraCarregamento(500,5,"Deslogando");
            Logado = false;
            loopBreak = true;
        }


    }
}

