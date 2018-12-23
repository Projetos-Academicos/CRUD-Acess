using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boys
{
    public class Cliente : Pessoa
    {
        public string Carro;
        public string Vendedor;

        
        public Cliente()
        {

        }
        public Cliente(string nome,string cpf, string carro, string vendedor) : this ()
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Carro = carro;
            this.Vendedor = vendedor;
        }
    }
}
