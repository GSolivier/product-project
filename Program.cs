using product_project;

Login servico = new Login();


   bool loopBreak = true;

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
            servico.Logar();

        break;

    case ConsoleKey.D2:
            user.Cadastrar();
            break;
    default:
        break;
}



    
} while (loopBreak);
        


    





