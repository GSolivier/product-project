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
        private DateTime DataCadastro { get; set; }
        private Marca Marca{ get; set; }
        private Usuario CadastradoPor { get; set; }

        private List<Produto> ListaDeProdutos = new List<Produto>();


        public string Cadastrar(Produto _produto)
        {
            return "";
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