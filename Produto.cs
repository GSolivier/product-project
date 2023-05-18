using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Produto
    {
        private int Codigo { get; set; }
        private string NomeProduto {get;set;}
        private float Preco { get; set; }
        private DateTime DataCadastro = DateTime.Now;
        private Marca Marca = new Marca();
        private Usuario CadastradoPor { get; set; }

        private List<Produto> ListaDeProdutos = new List<Produto>();


        public void Cadastrar()
        {
            Produto NovoProduto = new Produto();
            

            Console.WriteLine($"Digite o código do produto: ");
            NovoProduto.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o nome do produto: ");
            NovoProduto.NomeProduto = Console.ReadLine();

            Console.WriteLine($"Digite a marca do produto: ");
            Marca.NomeMarca = Console.ReadLine();

            Console.WriteLine($"Digite o código da marca: ");
            Marca.Codigo = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Digite o preço do produto: ");
            NovoProduto.Preco = float.Parse(Console.ReadLine());

            

        }

        public List<Produto> Listar()
        {
            return ListaDeProdutos;
        }

        public string Deletar (Produto _produto)
        {
            return"";
        }
    }
}