using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boys
{
    public class Carro
    {
        public int Id;
        public string Modelo;
        public string Marca;
        public string Placa;
        public int Ano;     

      

        public Carro()
        {

        }
        public Carro(string modelo, string marca, string placa, int ano) : this()
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.Placa = placa;
            this.Ano = ano;
        }


    }
}
