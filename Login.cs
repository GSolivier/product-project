using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Login
    {
        
        Usuario user = new Usuario();
        public bool Logado { get; set; }

        public Login()
        {
            
        }

        public void Programa()
        {   
            
 
        }
        public void Logar()
        {
            Console.WriteLine($"Digite seu email: ");
            string userEmail = Console.ReadLine();

            user.VerificarCadastro(userEmail);

            Console.WriteLine($"Digite sua senha: ");
            string userSenha = Console.ReadLine();


            
        }


        public string Deslogar(Usuario _usuario)
        {
            return"";
        }


    }
}

