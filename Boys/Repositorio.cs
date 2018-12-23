using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Boys
{
    public class Repositorio
    {
        private string stringConexao = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\GR00T13\Desktop\Boys.mdb;";
        private OleDbConnection ObterConexao()
        {
            return new OleDbConnection(stringConexao);
        }
        // ----------------------------------------FUNCIONARIO---------------------------------------------
        //ok
        public void NovoFuncionario()
        {
            OleDbConnection con = ObterConexao();
            try
            {
                Funcionario eu = new Funcionario();
                Console.WriteLine("Digite o Nome do Funcionario: ");
                eu.Nome = Console.ReadLine();
                Console.WriteLine("\nDigite o CPF do Funcionario: ");
                long aux = long.Parse(Console.ReadLine());
                eu.Cpf = Convert.ToString(aux);
                Console.WriteLine("\nDigite o Cargo do Funcionario: ");
                eu.Cargo = Console.ReadLine();

                if (eu.Nome == "" || aux <= 0 || eu.Cargo == "")
                {
                    throw new CampoVazioException("\n\nERRO: Preencha Todos os Campos Corretamente!");
                }
                else
                {

                    con.Open();
                    string sql = String.Format("INSERT INTO Funcionario (Nome, CPF, Cargo) VALUES ('{0}',{1},'{2}')", eu.Nome, eu.Cpf, eu.Cargo);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\n            Funcionario Cadastrado Com Sucesso ! \n\n");
                }
            }
            catch(OleDbException ex)
            {
                Console.WriteLine("\n\n" +ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (CampoVazioException ex)
            {
                Console.WriteLine(ex.Message);               
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: CPF ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO CPF MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            finally
            {
                con.Close();
            }           
        }
        //ok
        public void ConsultarFuncionario()
        {                           
                OleDbConnection con = ObterConexao();
                OleDbDataReader dr = null;
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Funcionario";
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    Console.WriteLine("              Consultando o Banco de Dados (Funcionarios)\n\n");

                    while (dr.Read())
                    {
                        Funcionario a = new Funcionario();
                        a.Id = (int)dr["IdFuncionario"];
                        a.Nome = dr["Nome"].ToString();
                        a.Cpf = dr["CPF"].ToString();
                        a.Cargo = dr["Cargo"].ToString();                       
                    
                    Console.WriteLine("ID: {0} | Nome: {1} | CPF: {2} | Cargo: {3}.\n", a.Id, a.Nome, a.Cpf, a.Cargo);
                    }
                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);                    
                }
                finally
                {
                    dr.Close();
                    con.Close();
                }                
            
        }
        //ok
        public void AlterarFuncionario()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
               Console.WriteLine("Digite o CPF do Funcionario a ser Atualizado:\n");
               long auxi = long.Parse(Console.ReadLine());
               string cpfatt = Convert.ToString(auxi);

               con.Open();
               string sqll = String.Format("SELECT * FROM Funcionario WHERE CPF = '{0}'", cpfatt);
               OleDbCommand cmmd = new OleDbCommand(sqll, con);
               dr = cmmd.ExecuteReader();

                if (dr.Read())
                {
                    Console.WriteLine("\n\nFuncionario a ser Alterado: \n");
                    Funcionario a = new Funcionario();
                    a.Id = (int)dr["IdFuncionario"];
                    a.Nome = dr["Nome"].ToString();
                    a.Cpf = dr["CPF"].ToString();
                    a.Cargo = dr["Cargo"].ToString();

                    Console.WriteLine("ID: {0} | Nome: {1} | CPF: {2} | Cargo: {3}.\n", a.Id, a.Nome, a.Cpf, a.Cargo);

                    Funcionario eu = new Funcionario();
                    Console.WriteLine("Digite o Nome do Funcionario: ");
                    eu.Nome = Console.ReadLine();
                    Console.WriteLine("\nDigite o CPF do Funcionario: ");
                    long aux = long.Parse(Console.ReadLine());
                    eu.Cpf = Convert.ToString(aux);
                    Console.WriteLine("\nDigite o Cargo do Funcionario: ");
                    eu.Cargo = Console.ReadLine();

                    if (eu.Nome == "" || aux < 0 || eu.Cargo == "")
                    {
                        throw new CampoVazioException("\n\nERRO: Preencha Todos os Campos Corretamente!");
                    }
                    else
                    {
                        string sql = String.Format("UPDATE Funcionario SET Nome = '{0}', CPF = '{1}', Cargo = '{2}' WHERE CPF = '{3}'", eu.Nome, eu.Cpf, eu.Cargo, cpfatt);
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\n            Funcionario Alterado Com Sucesso ! \n\n");
                    }
                }
                else
                {
                    throw new InformacaoNaoEncontradaException("\n\nERRO: Informação não Encontrada no Banco de Dados!");
                }
            }
            catch (InformacaoNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (CampoVazioException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: CPF ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO CPF MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            finally
            {
                con.Close();
            }
        }
        //ok
        public void DeletarFuncionario()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                Console.WriteLine("Digite o CPF do Funcionario a ser Deletado:\n");
                long auxi = long.Parse(Console.ReadLine());
                string cpfatt = Convert.ToString(auxi);

                con.Open();
                string sqll = String.Format("SELECT * FROM Funcionario WHERE CPF = '{0}'", cpfatt);
                OleDbCommand cmmd = new OleDbCommand(sqll, con);
                dr = cmmd.ExecuteReader();
                if (dr.Read())
                {

                        Console.WriteLine("\n\nFuncionario a ser Deletado: \n");
                    
                        Funcionario a = new Funcionario();
                        a.Id = (int)dr["IdFuncionario"];
                        a.Nome = dr["Nome"].ToString();
                        a.Cpf = dr["CPF"].ToString();
                        a.Cargo = dr["Cargo"].ToString();

                        Console.WriteLine("ID: {0} | Nome: {1} | CPF: {2} | Cargo: {3}.\n", a.Id, a.Nome, a.Cpf, a.Cargo);
                    
                    Console.WriteLine("\nDeseja Realmente Deletar Esse Funcionario? ?(S/N)");
                    ConsoleKeyInfo result = Console.ReadKey();
                    Console.Clear();
                    if ((result.KeyChar == 'S') || (result.KeyChar == 's'))
                    {
                        string sql = String.Format("DELETE FROM Funcionario WHERE CPF ='{0}'", cpfatt);
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\n            Funcionario Deletado Com Sucesso ! \n\n");
                    }
                }
                else
                {
                    throw new InformacaoNaoEncontradaException("\n\nERRO: Informação não Encontrada no Banco de Dados!");
                }
            }
            catch (InformacaoNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: CPF ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO CPF MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Funcionario();
            }
            finally
            {
                con.Close();
            }
        }

        // -------------------------------------------CARRO------------------------------------------------
        //ok
        public void NovoCarro()
        {
            OleDbConnection con = ObterConexao();
            try
            {
                Carro eu = new Carro();
                Console.WriteLine("Digite a Marca do Veiculo: ");
                eu.Marca = Console.ReadLine();
                Console.WriteLine("\nDigite o Modelo do Veiculo: ");
                eu.Modelo = Console.ReadLine();
                Console.WriteLine("\nDigite a Placa do Veiculo: ");
                eu.Placa = Console.ReadLine();
                Console.WriteLine("\nDigite o Ano do Veiculo: ");
                eu.Ano = int.Parse(Console.ReadLine());

                if (eu.Marca == "" || eu.Modelo == "" || eu.Placa == "" || eu.Ano < 0)
                {
                    throw new CampoVazioException("\n\nERRO: Preencha Todos os Campos Corretamente!");
                }
                else
                {
                    con.Open();
                    string sql = String.Format("INSERT INTO Carro (Marca, Modelo, Placa, Ano) VALUES ('{0}','{1}','{2}',{3})", eu.Marca, eu.Modelo, eu.Placa, eu.Ano);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\n            Carro Cadastrado Com Sucesso ! \n\n");
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (CampoVazioException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: ANO ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO ANO MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            finally
            {
                con.Close();
            }
        }
        //ok
        public void ConsultarCarro()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                con.Open();
                string sql = "SELECT * FROM Carro";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                dr = cmd.ExecuteReader();
                Console.WriteLine("              Consultando o Banco de Dados (Carros)\n\n");

                while (dr.Read())
                {
                    Carro a = new Carro();
                    a.Id = (int)dr["IdCarro"];
                    a.Marca = dr["Marca"].ToString();
                    a.Modelo = dr["Modelo"].ToString();
                    a.Placa = dr["Placa"].ToString();
                    a.Ano = (int)dr["Ano"];

                    Console.WriteLine("ID: {0} | Marca: {1} | Modelo: {2} | Placa: {3} | Ano: {4}.\n", a.Id, a.Marca,a.Modelo,a.Placa,a.Ano);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO: " + ex.Message);
                
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
        //ok
        public void AlterarCarro()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                Console.WriteLine("Digite a Placa do Carro a ser Atualizado:\n");
                string cpfatt = Console.ReadLine();

                con.Open();
                string sqll = String.Format("SELECT * FROM Carro WHERE Placa ='{0}'", cpfatt);
                OleDbCommand cmmd = new OleDbCommand(sqll, con);
                dr = cmmd.ExecuteReader();
                
                if (dr.Read())
                {
                    Console.WriteLine("\n\nCarro a ser Alterado: \n");
                    Carro a = new Carro();
                    a.Id = (int)dr["IdCarro"];
                    a.Marca = dr["Marca"].ToString();
                    a.Modelo = dr["Modelo"].ToString();
                    a.Placa = dr["Placa"].ToString();
                    a.Ano = (int)dr["Ano"];

                    Console.WriteLine("ID: {0} | Marca: {1} | Modelo: {2} | Placa: {3} | Ano: {4}.\n", a.Id, a.Marca,a.Modelo,a.Placa,a.Ano);
               

                    Carro eu = new Carro();
                    Console.WriteLine("Digite a Marca do Veiculo: ");
                    eu.Marca = Console.ReadLine();
                    Console.WriteLine("\nDigite o Modelo do Veiculo: ");
                    eu.Modelo = Console.ReadLine();
                    Console.WriteLine("\nDigite a Placa do Veiculo: ");
                    eu.Placa = Console.ReadLine();
                    Console.WriteLine("\nDigite o Ano do Veiculo: ");
                    eu.Ano = int.Parse(Console.ReadLine());

                    if (eu.Marca == "" || eu.Modelo == "" || eu.Placa == "" || eu.Ano < 0)
                    {
                        throw new CampoVazioException("\n\nERRO: Preencha Todos os Campos Corretamente!");
                    }
                    else
                    {
                        string sql = String.Format("UPDATE Carro SET Marca = '{0}', Modelo = '{1}', Placa = '{2}', Ano = {3} WHERE Placa = '{4}'", eu.Marca, eu.Modelo, eu.Placa, eu.Ano, cpfatt);
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\n            Carro Alterado Com Sucesso ! \n\n");
                    
                    }
                }
                else
                {
                    throw new InformacaoNaoEncontradaException("\n\nERRO: Informação não Encontrada no Banco de Dados!");
                }
            }
            catch (InformacaoNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (CampoVazioException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: ANO ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO ANO MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            finally
            {
                con.Close();
            }
        }
        //ok
        public void DeletarCarro()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                Console.WriteLine("Digite a Placa do Carro a ser Deletado:\n");
                string cpfatt = Console.ReadLine();

                con.Open();
                string sqll = String.Format("SELECT * FROM Carro WHERE Placa ='{0}'", cpfatt);
                OleDbCommand cmmd = new OleDbCommand(sqll, con);
                dr = cmmd.ExecuteReader();
                
                if (dr.Read())
                {
                    Console.WriteLine("\n\nCarro a ser Deletado: \n");
                    Carro a = new Carro();
                    a.Id = (int)dr["IdCarro"];
                    a.Marca = dr["Marca"].ToString();
                    a.Modelo = dr["Modelo"].ToString();
                    a.Placa = dr["Placa"].ToString();
                    a.Ano = (int)dr["Ano"];

                    Console.WriteLine("ID: {0} | Marca: {1} | Modelo: {2} | Placa: {3} | Ano: {4}.\n", a.Id, a.Marca, a.Modelo, a.Placa, a.Ano);
                
                    Console.WriteLine("\nDeseja Realmente Deletar Esse Funcionario? ?(S/N)");
                    ConsoleKeyInfo result = Console.ReadKey();
                    Console.Clear();
                    if ((result.KeyChar == 'S') || (result.KeyChar == 's'))
                    {
                        string sql = String.Format("DELETE FROM Carro WHERE Placa ='{0}'", cpfatt);
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\n            Carro Deletado Com Sucesso ! \n\n");
                    }
                }
                else
                {
                    throw new InformacaoNaoEncontradaException("\n\nERRO: Informação não Encontrada no Banco de Dados!");
                }
            }
            catch (InformacaoNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: ANO ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO ANO MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Carro();
            }
            finally
            {
                con.Close();
            }
        }

        // ------------------------------------------Cliente-----------------------------------------------
        //ok
        public void NovoCliente()
        {
            OleDbConnection con = ObterConexao();
            try
            {
                Cliente eu = new Cliente();
                Console.WriteLine("Digite o Nome do Cliente: ");
                eu.Nome = Console.ReadLine();
                Console.WriteLine("\nDigite o CPF do Cliente: ");
                long aux = long.Parse(Console.ReadLine());
                eu.Cpf = Convert.ToString(aux);
                Console.WriteLine("\nDigite o Modelo do Carro do Cliente: ");
                eu.Carro = Console.ReadLine();
                Console.WriteLine("\nDigite o Nome do Vendedor que Atendeu o Cliente: ");
                eu.Vendedor = Console.ReadLine();

                if (eu.Nome == "" || eu.Cpf == "" || eu.Carro == "" || eu.Vendedor == "")
                {
                    throw new CampoVazioException("\n\nERRO: Preencha Todos os Campos!");
                }
                else
                {
                    con.Open();
                    string sql = String.Format("INSERT INTO Cliente (Nome, CPF, Carro, Vendedor) VALUES ('{0}','{1}','{2}','{3}')", eu.Nome, eu.Cpf, eu.Carro, eu.Vendedor);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\n            Cliente Cadastrado Com Sucesso ! \n\n");
                }
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (CampoVazioException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: CPF ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO CPF MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            finally
            {
                con.Close();
            }
        }
        //ok
        public void ConsultarCliente()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                con.Open();
                string sql = "SELECT * FROM Cliente";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                dr = cmd.ExecuteReader();
                Console.WriteLine("              Consultando o Banco de Dados (Clientes)\n\n");

                while (dr.Read())
                {
                    Cliente a = new Cliente();
                    a.Id = (int)dr["IdCliente"];
                    a.Nome = dr["Nome"].ToString();
                    a.Cpf = dr["CPF"].ToString();
                    a.Carro = dr["Carro"].ToString();
                    a.Vendedor = dr["Vendedor"].ToString();

                    Console.WriteLine("ID: {0} | Nome: {1} | CPF: {2} | Carro: {3} | Vendedor: {4}.\n", a.Id, a.Nome, a.Cpf, a.Carro, a.Vendedor);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);                
            }
            finally
            {
                dr.Close();
                con.Close();
            }

        }
        //ok
        public void AlterarCliente()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                Console.WriteLine("Digite o CPF do Cliente a ser Atualizado:\n");
                long auxi = long.Parse(Console.ReadLine());
                string cpfatt = Convert.ToString(auxi);

                con.Open();
                string sqll = String.Format("SELECT * FROM Cliente WHERE CPF = '{0}'", cpfatt);
                OleDbCommand cmmd = new OleDbCommand(sqll, con);
                dr = cmmd.ExecuteReader();
                if (dr.Read())
                {
                    Console.WriteLine("\n\nCliente a ser Alterado: \n");
                    Cliente a = new Cliente();
                    a.Id = (int)dr["IdCliente"];
                    a.Nome = dr["Nome"].ToString();
                    a.Cpf = dr["CPF"].ToString();
                    a.Carro = dr["Carro"].ToString();
                    a.Vendedor = dr["Vendedor"].ToString();

                    Console.WriteLine("ID: {0} | Nome: {1} | CPF: {2} | Carro: {3} | Vendedor: {4}.\n", a.Id, a.Nome, a.Cpf, a.Carro, a.Vendedor);


                    Cliente eu = new Cliente();
                    Console.WriteLine("Digite o Nome do Cliente: ");
                    eu.Nome = Console.ReadLine();
                    Console.WriteLine("\nDigite o CPF do Cliente: ");
                    long aux = long.Parse(Console.ReadLine());
                    eu.Cpf = Convert.ToString(aux);
                    Console.WriteLine("\nDigite o Modelo do Carro do Cliente: ");
                    eu.Carro = Console.ReadLine();
                    Console.WriteLine("\nDigite o Nome do Vendedor que Atendeu o Cliente: ");
                    eu.Vendedor = Console.ReadLine();

                    if (eu.Nome == "" || eu.Cpf == "" || eu.Carro == "" || eu.Vendedor == "")
                    {
                        throw new CampoVazioException("\n\nERRO: Preencha Todos os Campos!");
                    }
                    else
                    {
                        string sql = String.Format("UPDATE Cliente SET Nome = '{0}', CPF = '{1}', Carro = '{2}', Vendedor = '{3}' WHERE CPF = '{4}'", eu.Nome, eu.Cpf, eu.Carro, eu.Vendedor, cpfatt);
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\n            Cliente Alterado Com Sucesso ! \n\n");
                    }
                }
                else
                {
                    throw new InformacaoNaoEncontradaException("\n\nERRO: Informação não Encontrada no Banco de Dados!");
                }
            }
            catch (InformacaoNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (CampoVazioException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (OleDbException ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: CPF ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO CPF MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            finally
            {
                con.Close();
            }
        }
        //ok
        public void DeletarCliente()
        {
            OleDbConnection con = ObterConexao();
            OleDbDataReader dr = null;
            try
            {
                Console.WriteLine("Digite o CPF do Cliente a ser Deletado:\n");
                long auxi = long.Parse(Console.ReadLine());
                string cpfatt = Convert.ToString(auxi);

                con.Open();
                string sqll = String.Format("SELECT * FROM Cliente WHERE CPF = '{0}'", cpfatt);
                OleDbCommand cmmd = new OleDbCommand(sqll, con);
                dr = cmmd.ExecuteReader();
                
                if (dr.Read())
                {
                    Console.WriteLine("\n\nCliente a ser Deletado: \n");
                    Cliente a = new Cliente();
                    a.Id = (int)dr["IdCliente"];
                    a.Nome = dr["Nome"].ToString();
                    a.Cpf = dr["CPF"].ToString();
                    a.Carro = dr["Carro"].ToString();
                    a.Vendedor = dr["Vendedor"].ToString();

                    Console.WriteLine("ID: {0} | Nome: {1} | CPF: {2} | Carro: {3} | Vendedor: {4}.\n", a.Id, a.Nome, a.Cpf, a.Carro, a.Vendedor);
              
                    Console.WriteLine("\nDeseja Realmente Deletar Esse Cliente? ?(S/N)");
                     ConsoleKeyInfo result = Console.ReadKey();
                    Console.Clear();
                    if ((result.KeyChar == 'S') || (result.KeyChar == 's'))
                    {
                        string sql = String.Format("DELETE FROM Cliente WHERE CPF ='{0}'", cpfatt);
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        Console.WriteLine("\n\n            Cliente Deletado Com Sucesso ! \n\n");
                    }
                
                }
                else
                {
                    throw new InformacaoNaoEncontradaException("\n\nERRO: Informação não Encontrada no Banco de Dados!");
                }
            }
            catch (InformacaoNaoEncontradaException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\n ERRO: CPF ACEITA SOMENTE NUMEROS !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n\n ERRO: NUMERO DO CPF MUITO GRANDE !");
                Console.ReadKey();
                Console.Clear();
                Menu novo = new Menu();
                novo.Cliente();
            }
            finally
            {
                con.Close();
            }
        }
    }
}

























/*public void AlterarF()
        {
            OleDbConnection con = ObterConexao();
            try
            {
                Console.WriteLine("Digite o CPF do Funcionario a ser Atualizado:\n");
                long auxi = long.Parse(Console.ReadLine());
                string cpfatt = Convert.ToString(auxi);

                Funcionario eu = new Funcionario();
                Console.WriteLine("Digite o Nome do Funcionario: ");
                eu.Nome = Console.ReadLine();
                Console.WriteLine("\nDigite o CPF do Funcionario: ");
                long aux = long.Parse(Console.ReadLine());
                eu.Cpf = Convert.ToString(aux);
                Console.WriteLine("\nDigite o Cargo do Funcionario: ");
                eu.Cargo = Console.ReadLine();

                con.Open();
                string sql = String.Format("UPDATE Funcionario SET Nome = '{0}', CPF = '{1}', Cargo = '{2}' WHERE CPF = '{3}'", eu.Nome, eu.Cpf, eu.Cargo, cpfatt);
                OleDbCommand cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();

                Console.WriteLine("\n\n            Funcionario Atualizado Com Sucesso ! \n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ... " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }
        }*/
