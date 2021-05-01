using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas= new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario= ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario= ObterOpcaoUsuario();
            }

            Console.Write("Programa Encerrado.\nObrigado por usar nosso serviço");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int numContaOrg= int.Parse(Console.ReadLine());            
            
            Console.Write("Digite o número da conta destino: ");
            int numContaDest= int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia= double.Parse(Console.ReadLine());

            listContas[numContaOrg].Transferir(valorTransferencia, listContas[numContaDest]);
            return;
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta para depósito: ");
            int numConta= int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito= double.Parse(Console.ReadLine());

            listContas[numConta].Depositar(valorDeposito);
            return;
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta  a ser sacada: ");
            int numConta= int.Parse(Console.ReadLine());

            Console.Write("Digite o valoer a ser sacado: ");
            double valorSaque= double.Parse(Console.ReadLine());

            listContas[numConta].Sacar(valorSaque);
            return;
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i=0; i<listContas.Count; i++){
                Console.WriteLine("#{0} - {1}", i, listContas[i]);
                Console.WriteLine();
            }
        }

        private static void InserirConta()
        {
            Console.Write("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta= int.Parse(Console.ReadLine());
            //Verificar aque se a entrada foi válida

            Console.Write("Digite o nome do cliente: ");
            string entradaNome= Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo= double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            float entradaCredito= float.Parse(Console.ReadLine());

            Conta novaConta= new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo, 
                                                    credito: entradaCredito, 
                                                    nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Informe a ação desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario= Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
