using System.Collections;
using BancoDigital.Classes;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;

namespace BancoDigital.Classes
{
    public  class Layout
    {

        static List<Conta>  contas = new List<Conta>();
        static double saldo = 0;
        static string opcao;
        static string senha;
        static string cpf;





        public static void TelaPrincipal()
        {
            Console.Clear();
            Utilidades.SettaCores();
            Console.Clear();
            opcao = "";

            if(!contas.Any())
            {
                Conta ContaAdmin = new Conta("admin", "00000000000", "admin123", 0);
                contas.Add(ContaAdmin);
            }

            

            

            Utilidades.EscreverCentralizado("Escolha uma das opções abaixo:");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("1 - Criar Conta");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("2 - Entrar com CPF e Senha");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");

            

            do
            {

                opcao = (Console.ReadLine());

            switch(opcao)
            {
                case "1":
                    TelaCriaConta();
                    break;
                case "2":
                    TelaLoginConta();
                    break;
                default:
                    Utilidades.EscreverCentralizadoEmVermelho("Opção Inválida! Tente Novamente!");
                    break;

            }
            
            }while(opcao != "1"||opcao != "2");


                
            
            
            Console.ReadKey();

        }

        public static void TelaLoginConta()
        {
            Console.Clear();

            //string cpf;
            //string senha;
            

            do
            {
                Console.WriteLine();
                Utilidades.EscreverCentralizado("Digite seu CPF:");
                cpf = Console.ReadLine();

                if (!Utilidades.ValidarCpfLogin(cpf,contas))
                {

                    Console.Clear();         
                    Utilidades.EscreverCentralizadoEmVermelho("CPF Inválido, Tente Novamente...");
                    
                }
                
                
            }while(!Utilidades.ValidarCpfLogin(cpf,contas));


            Utilidades.EscreverCentralizadoEmVerde("CPF Válido");
            Thread.Sleep(1000);
            Console.Clear();


            do
            {
                Console.WriteLine();
                Utilidades.EscreverCentralizado("Digite sua Senha:");
                senha = Console.ReadLine();

                if (!Utilidades.ValidarSenhaLogin(senha,contas))
                {

                    Console.Clear();         
                    Utilidades.EscreverCentralizadoEmVermelho("Senha Inválida, Tente Novamente...");
                    
                }
                
                
            }while(!Utilidades.ValidarSenhaLogin(senha, contas));


            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Utilidades.EscreverCentralizadoEmVerde("Bem Vindo Novamente, " + ContaAtual.Nome);

            Thread.Sleep(1000);
            TelaConta();
            






        }

        public static void TelaCriaConta()
        {
            string nome;
            //string cpf;
            //string senha;
            
            Console.Clear();
            Utilidades.SettaCores();
            Console.Clear();
            



            do
            {
                Console.WriteLine();
                Utilidades.EscreverCentralizado("Digite seu nome:");
                nome = Console.ReadLine();

                if (!Utilidades.ValidarNome(nome))
                {

                    Console.Clear();         
                    Utilidades.EscreverCentralizadoEmVermelho("Nome Inválido, Tente Novamente...");
                    
                }
                
                
            }while(!Utilidades.ValidarNome(nome));

            

            Utilidades.EscreverCentralizadoEmVerde("Nome Válido");
            Thread.Sleep(1000);
            Console.Clear();


            do
            {
                Utilidades.EscreverCentralizado("Digite seu CPF:");
                cpf = Console.ReadLine();

                if (!Utilidades.ValidarCpf(cpf))
                {
                    Console.Clear();         
                    Utilidades.EscreverCentralizadoEmVermelho("CPF Inválido, Tente Novamente...");

                }
                
                
            }while(!Utilidades.ValidarCpf(cpf));;

            Utilidades.EscreverCentralizadoEmVerde("CPF Válido");               
            Thread.Sleep(1000);
            Console.Clear();



            do
            {
                Utilidades.EscreverCentralizado("Digite sua Senha:");
                senha = Console.ReadLine();

                if (!Utilidades.ValidarSenha(senha))
                {
                    Console.Clear();         
                    Utilidades.EscreverCentralizadoEmVermelho("Senha Inválida, Tente Novamente...");

                }
                
                
            }while(!Utilidades.ValidarSenha(senha));


            Utilidades.EscreverCentralizadoEmVerde("Senha Válida");
            Thread.Sleep(1000);
            Console.Clear();


            Utilidades.EscreverCentralizadoEmVerde("Conta Criada com Sucesso!");

            Conta novaConta = new Conta(nome, cpf, senha, saldo);
            contas.Add(novaConta);
    
            Console.WriteLine();
            novaConta.MostrarResumo();

            Thread.Sleep(1000);
            Console.Clear();

            TelaConta();

        }
 
        public static void TelaConta()
        {

            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];


            

            Console.Clear();

            Utilidades.SettaCores();
            Console.Clear();

            Utilidades.EscreverCentralizado($"Bem Vindo, {ContaAtual.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Utilidades.EscreverCentralizado("Escolha uma das opções abaixo:");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("1 - Depositar");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("2 - Sacar");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("3 - Saldo");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("4 - Extrato");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("5 - Sair");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
       
            Utilidades.SettaCores();


            
            //opcao= int.Parse(Console.ReadLine());


            do
            {
                opcao= (Console.ReadLine());

                switch(opcao)
                {
                case "1":
                    TelaContaDeposito();
                    break;
                case "2":
                    if(ContaAtual.Saldo <= 0)
                    {
                        Utilidades.EscreverCentralizadoEmVermelho("Saldo insuficiente para saque!!");
                        Thread.Sleep(2000);
                        TelaConta();
                    }
                    TelaContaSaque();
                    break;
                case "3":
                    TelaContaSaldo();
                    break;
                case "4":
                    TelaContaExtrato();
                    break;
                case "5":
                    TelaContaSaindo();
                    break;                  
                default:
                    Utilidades.EscreverCentralizadoEmVermelho("Opção Inválida! Tente Novamente:");
                    break;

                }
            }while((opcao != "1" || opcao != "2" || opcao != "3" || opcao != "4" || opcao != "5"));

             

             

                





        }


        public static void TelaContaDeposito()
        {
            Console.Clear();

            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];
            Utilidades.EscreverCentralizado($"Bem Vindo, {ContaAtual.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Utilidades.EscreverCentralizado("Digite o valor do deposito: ");

            string entrada = Console.ReadLine();
            

            if (!Regex.IsMatch(entrada, @"^\d+([.,]?\d+)?$")) //verifica se a entra é um número 
            {
                Utilidades.EscreverCentralizadoEmVermelho("Valor inválido! Digite apenas números.");
                Console.ReadKey();
                TelaContaDeposito(); 
                return;
            }

            double qtddeposito = double.Parse(entrada.Replace(',', '.')); // troca vírgula por ponto, se houver
            
            if (qtddeposito <= 0)
            {
                Utilidades.EscreverCentralizadoEmVermelho("O valor do depósito deve ser maior que zero.");
                Console.ReadKey();
                TelaContaDeposito();
                return;
            }
            
            ContaAtual.RealizaDeposito(qtddeposito);

            ContaAtual.ConsultaSaldo();
            Console.ReadKey();

            TelaConta();

        }




        public static void TelaContaSaque()
        {
            Console.Clear();

            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];
            Utilidades.EscreverCentralizado($"Bem Vindo, {ContaAtual.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Utilidades.EscreverCentralizado("Digite o valor do saque: ");
            double QtdSaque = double.Parse(Console.ReadLine());

            if(ContaAtual.Saldo < QtdSaque)
            {
                Utilidades.EscreverCentralizadoEmVermelho("Saldo Insuficiente!!!");
                Console.ReadKey();
                TelaContaSaque();
            }

            ContaAtual.RealizaSaque(QtdSaque);

            ContaAtual.ConsultaSaldo();
            Console.ReadKey();

            TelaConta();

        }

        public static void TelaContaSaldo()
        {
            Console.Clear();

            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];
            Utilidades.EscreverCentralizado($"Bem Vindo, {ContaAtual.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            ContaAtual.ConsultaSaldo();
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Console.ReadKey();

            TelaConta();

        }

        public static void TelaContaExtrato()
        {
            Console.Clear();

            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];
            Utilidades.EscreverCentralizado($"Bem Vindo, {ContaAtual.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            
            Console.WriteLine();
            Console.WriteLine();
            ContaAtual.ConsultaExtrato();
            Console.WriteLine();
            Console.WriteLine();

            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("Saldo atual: " + ContaAtual.Saldo);
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            
            Console.WriteLine();
            Console.WriteLine();
            Utilidades.EscreverCentralizado("Pressione qualquer botão para voltar!");
            Console.ReadKey();

            TelaConta();

        }


        public static void TelaContaSaindo()
        {
            Console.Clear();

            Conta ContaAtual = contas[SelecionaContaAtual(cpf, senha)];
            Utilidades.EscreverCentralizado($"Bem Vindo, {ContaAtual.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Console.WriteLine();

            Utilidades.EscreverCentralizado("Saindo da conta.");
            Thread.Sleep(700);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utilidades.EscreverCentralizado("Saindo da conta.");
            Thread.Sleep(700);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utilidades.EscreverCentralizado("Saindo da conta..");
            Thread.Sleep(700);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Utilidades.EscreverCentralizado("Saindo da conta...");
            Thread.Sleep(700);

            

            TelaPrincipal();

        }


        
        public static int SelecionaContaAtual(string cpf, string senha)
        {
            int indice = -1;
            int contador = 0;

            foreach (Conta conta in contas)
            {
                if (conta.Cpf == cpf && conta.Senha == senha)
                {
                    indice = contador;
                    break;
                }
                contador++;
            }

            return indice;
        }
        

    }
}