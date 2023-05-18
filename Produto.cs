using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Produto
    {
        Ferramentas tool = new Ferramentas();

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
            NovoProduto.Marca.NomeMarca = Console.ReadLine();

            Console.WriteLine($"Digite o código da marca: ");
            NovoProduto.Marca.Codigo = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Digite o preço do produto: ");
            NovoProduto.Preco = float.Parse(Console.ReadLine());

            Console.WriteLine($"Produto Cadastrado com sucesso!");

            Console.WriteLine($"Data de cadastro: {NovoProduto.DataCadastro}");
            Console.WriteLine($"Cadastrado por:");
            
            ListaDeProdutos.Add(NovoProduto);
        }

        public void Listar()
        {
            foreach (var item in ListaDeProdutos)
            {
                Console.WriteLine($"Nome do produto: {item.NomeProduto}");
                Console.WriteLine($"Código do produto: {item.Codigo}");
                Console.WriteLine($"Marca do produto: {item.Marca.NomeMarca}");
                Console.WriteLine($"Código da marca: {item.Marca.Codigo}");
                Console.WriteLine($"Preço do produto: {item.Preco:C}");

                Console.WriteLine($"Data de cadastro: {item.DataCadastro}");
                Console.WriteLine($"Cadastrado por: ");
            }
        }

        public void Deletar (int _CodigoProduto)
        {
            Produto CodigoProdutoDeletar = ListaDeProdutos.Find(x => x.Codigo == _CodigoProduto);

            if (CodigoProdutoDeletar == null)
            {
                Console.WriteLine($"Produto não encontrado");
                
            }
            else{
                if (CodigoProdutoDeletar.Codigo != null && CodigoProdutoDeletar.Codigo == _CodigoProduto)
                {
                    Console.WriteLine($"Produto Encontrado");

                    Console.WriteLine($"Nome do produto: {CodigoProdutoDeletar.NomeProduto}");
                    Console.WriteLine($"Código do produto: {CodigoProdutoDeletar.Codigo}");
                    Console.WriteLine($"Marca do produto: {CodigoProdutoDeletar.Marca.NomeMarca}");
                    Console.WriteLine($"Código da marca: {CodigoProdutoDeletar.Marca.Codigo}");
                    Console.WriteLine($"Preço do produto: {CodigoProdutoDeletar.Preco:C}");

                    Console.WriteLine($"Data de cadastro: {CodigoProdutoDeletar.DataCadastro}");
                    Console.WriteLine($"Cadastrado por: ");
                    

                    Console.WriteLine($"Tem certeza que deseja excluir o produto    ? 's' para sim ou 'n' para não.");
                    ConsoleKeyInfo escolhaMenu = Console.ReadKey(true);

                    switch (escolhaMenu.Key)
                    {
                        case ConsoleKey.S:
                            int index = ListaDeProdutos.IndexOf(CodigoProdutoDeletar);
                            ListaDeProdutos.RemoveAt(index);
                            tool.BarraCarregamento(500, 5, "Apagando seus dados");
                            break;
                        case ConsoleKey.N:
                         tool.BarraCarregamento(500,5,"Cancelando operação.");
                            break;
                        default:
                            break;
                    }
                    


                    
                }

            }
        }
    }
}