using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace product_project
{
    public class Marca
    {
        private int Codigo { get; set; }
        private string NomeMarca {get; set;}
        private DateTime DataCadastro { get; set; }

        List<Marca> marca = new List<Marca>();
        public string Cadastrar(Marca _marca)
        {
            return"";
        }

        public List<Marca> Listar()
        {
            return marca;
        }

        public string Deletar(Marca _marca)
        {
            return "";
        }
    }
}