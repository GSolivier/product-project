using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Login
    {

        Usuario UsuariosCadastrados = new Usuario();
        public bool Logado { get; set; }

        public Login()
        {
            
        }

        public string Logar(Usuario _usuario, Usuario _senha)
        {
            Console.WriteLine($"Digite seu email: ");
            string userEmail = Console.ReadLine();

            Console.WriteLine($"Digite sua senha: ");
            string userSenha = Console.ReadLine();

            if (UsuariosCadastrados.Email == userEmail && UsuariosCadastrados.Senha == userSenha)
            {
                Console.WriteLine($"MENU");
                
            }

            else{
                Console.WriteLine($"Usuario nao encontrado");
                UsuariosCadastrados.Cadastrar();
            }
            

            return"";
        }

        public string Deslogar(Usuario _usuario)
        {
            return"";
        }


    }
}