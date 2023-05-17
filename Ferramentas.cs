using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Ferramentas
    {
        public void BarraCarregamento(int _tempo, int _pontos, string _texto)
        {

            Console.Write(_texto);
            
            for (var i = 0; i < _pontos; i++)
            {
                Console.Write(".");
                Thread.Sleep(_tempo);
            }
            Console.Clear();
        }
    }
}