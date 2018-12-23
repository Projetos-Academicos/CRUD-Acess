using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boys
{
    class Menu
    { // ok
        
        public void Inicio()
        {
            Console.Clear();
            Console.WriteLine("            ----------------------------------------------------------");
            Console.WriteLine("            -------------------------- MENU --------------------------");
            Console.WriteLine("            ----------------------------------------------------------");
            Console.WriteLine("            ----- 1. FUNCIONARIO ----- 2. CLIENTE ----- 3. CARRO -----");
            Console.WriteLine("            ----------------------------------------------------------");
            Console.WriteLine("\n\n\n");

            try
            {
                int i = int.Parse(Console.ReadLine());
                Console.Clear();

                if (i == 1)
                {
                    Funcionario();
                }
                else if ( i == 2)
                {
                    Cliente();
                }
                else if( i == 3)
                {
                    Carro();                              
                }
                else
                {
                    Console.WriteLine("\n\n Opção não encontrada !");
                    Console.ReadKey();
                    Inicio();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: DIGITE APENAS VALORES NUMERICOS !");
                Console.ReadKey();
                Console.Clear();
                Inicio();
            }
            catch (OverflowException)
            {                
                Console.WriteLine("\n\n ERRO: VARIAVEL NAO SUPORTA ESSA QUANTIDADE DE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Inicio();
            }
        }

        public void Funcionario()
        {
            Console.WriteLine(" 1. Cadastrar Funcionario");
            Console.WriteLine(" 2. Consultar Funcionario");
            Console.WriteLine(" 3. Alterar Funcionario");
            Console.WriteLine(" 4. Deletar Funcionario");
            Console.WriteLine(" 5. Voltar\n\n");

            try
            {
                int ii = int.Parse(Console.ReadLine());
                Console.Clear();

                if (ii == 1)
                {
                    Repositorio f = new Repositorio();
                    f.NovoFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 2)
                {
                    Repositorio f = new Repositorio();
                    f.ConsultarFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 3)
                {
                    Repositorio f = new Repositorio();
                    f.AlterarFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if (ii == 4)
                {
                    Repositorio f = new Repositorio();
                    f.DeletarFuncionario();
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
                else if( ii == 5)
                {
                    Inicio();
                }
                else
                {
                    Console.WriteLine("\n\n Opção não encontrada !");
                    Console.ReadKey();
                    Console.Clear();
                    Funcionario();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: DIGITE APENAS VALORES NUMERICOS !");
                Console.ReadKey();
                Console.Clear();
                Funcionario();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: VARIAVEL NAO SUPORTA ESSA QUANTIDADE DE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Funcionario();
            }
        }

        public void Cliente()
        {
            Console.WriteLine(" 1. Cadastrar Cliente");
            Console.WriteLine(" 2. Consultar Cliente");
            Console.WriteLine(" 3. Alterar Cliente");
            Console.WriteLine(" 4. Deletar Cliente");
            Console.WriteLine(" 5. Voltar\n\n");

            try
            {
                int ii = int.Parse(Console.ReadLine());
                Console.Clear();

                if (ii == 1)
                {
                    Repositorio f = new Repositorio();
                    f.NovoCliente();
                    Console.ReadKey();
                    Console.Clear();
                    Cliente();
                }
                else if (ii == 2)
                {
                    Repositorio f = new Repositorio();
                    f.ConsultarCliente();
                    Console.ReadKey();
                    Console.Clear();
                    Cliente();
                }
                else if (ii == 3)
                {
                    Repositorio f = new Repositorio();
                    f.AlterarCliente();
                    Console.ReadKey();
                    Console.Clear();
                    Cliente();
                }
                else if (ii == 4)
                {
                    Repositorio f = new Repositorio();
                    f.DeletarCliente();
                    Console.ReadKey();
                    Console.Clear();
                    Cliente();
                }
                else if (ii == 5)
                {
                    Inicio();
                }
                else
                {
                    Console.WriteLine("\n\n Opção não encontrada !");
                    Console.ReadKey();
                    Console.Clear();
                    Cliente();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: DIGITE APENAS VALORES NUMERICOS !");
                Console.ReadKey();
                Console.Clear();
                Cliente();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: VARIAVEL NAO SUPORTA ESSA QUANTIDADE DE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Cliente();
            }
        }

        public void Carro()
        {
            Console.WriteLine(" 1. Cadastrar Carro");
            Console.WriteLine(" 2. Consultar Carro");
            Console.WriteLine(" 3. Alterar Carro");
            Console.WriteLine(" 4. Deletar Carro");
            Console.WriteLine(" 5. Voltar\n\n");

            try
            {
                int ii = int.Parse(Console.ReadLine());
                Console.Clear();
              

                if (ii == 1)
                {
                    Repositorio f = new Repositorio();
                    f.NovoCarro();
                    Console.ReadKey();
                    Console.Clear();
                    Carro();
                }
                else if (ii == 2)
                {
                    Repositorio f = new Repositorio();
                    f.ConsultarCarro();
                    Console.ReadKey();
                    Console.Clear();
                    Carro();
                }
                else if (ii == 3)
                {
                    Repositorio f = new Repositorio();
                    f.AlterarCarro();
                    Console.ReadKey();
                    Console.Clear();
                    Carro();
                }
                else if (ii == 4)
                {
                    Repositorio f = new Repositorio();
                    f.DeletarCarro();
                    Console.ReadKey();
                    Console.Clear();
                    Carro();
                }
                else if (ii == 5)
                {
                    Inicio();
                }
                else
                {
                    Console.WriteLine("\n\n Opção não encontrada !");
                    Console.ReadKey();
                    Console.Clear();
                    Carro();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: DIGITE APENAS VALORES NUMERICOS !");
                Console.ReadKey();
                Console.Clear();
                Carro();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: VARIAVEL NAO SUPORTA ESSA QUANTIDADE DE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Carro();
            }
        }
    }
}
