using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boys
{
    public class Funcionario : Pessoa
    {
        public string Cargo;


        public Funcionario()
        {

        }
        public Funcionario(int id,string nome, string cpf, string cargo) : this()
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cargo = cargo;
        }


    }
}
