using System.Collections;
using BancoDigital.Classes;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BancoDigital.Classes
{
    public class Layout
    {

        static List<Conta>  contas = new List<Conta>();
        static double saldo = 0;
        static int opcao;
        public static void TelaPrincipal()
        {
            Console.Clear();
            Utilidades.SettaCores();
            Console.Clear();
            opcao = 0;



            Utilidades.EscreverCentralizado("Escolha uma das opções abaixo:");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("1 - Criar Conta");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("2 - Entrar com CPF e Senha");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");

            

            do
            {

                opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    TelaCriaConta();
                    break;
                case 2:
                    TelaLoginConta();
                    break;
                default:
                    Utilidades.EscreverCentralizadoEmVermelho("Opção Inválida!");
                    break;

            }
            
            }while(opcao != 1||opcao != 2);


                
            
            
            Console.ReadKey();

        }

        public static void TelaLoginConta()
        {
            Console.Clear();

            string cpf;
            string senha;

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
                
                
            }while(!Utilidades.ValidarCpfLogin(cpf, contas));


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


            Conta ContaAtual = contas[0];
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
            string cpf;
            string senha;
            
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

            Conta primeiraConta = contas[0];


            

            Console.Clear();

            Utilidades.SettaCores();
            Console.Clear();

            Utilidades.EscreverCentralizado($"Bem Vindo, {primeiraConta.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
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

            

            opcao= int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    TelaContaDeposito();
                    break;
                case 2:
                    TelaContaSaque();
                    break;
                case 3:
                    TelaContaSaldo();
                    break;
                case 4:
                    TelaContaExtrato();
                    break;
                case 5:
                    TelaContaSaindo();
                    break;
                default:
                    Utilidades.EscreverCentralizadoEmVermelho("Opção Inválida! Tente Novamente:");
                    break;

            }






        }


        public static void TelaContaDeposito()
        {
            Console.Clear();

            Conta primeiraConta = contas[0];
            Utilidades.EscreverCentralizado($"Bem Vindo, {primeiraConta.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Utilidades.EscreverCentralizado("Digite o valor do deposito: ");
            double qtddeposito = double.Parse(Console.ReadLine());
            primeiraConta.RealizaDeposito(qtddeposito);

            primeiraConta.ConsultaSaldo();
            Console.ReadKey();

            TelaConta();

        }




        public static void TelaContaSaque()
        {
            Console.Clear();

            Conta primeiraConta = contas[0];
            Utilidades.EscreverCentralizado($"Bem Vindo, {primeiraConta.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            Utilidades.EscreverCentralizado("Digite o valor do saque: ");
            double QtdSaque = double.Parse(Console.ReadLine());
            primeiraConta.RealizaSaque(QtdSaque);

            primeiraConta.ConsultaSaldo();
            Console.ReadKey();

            TelaConta();

        }

        public static void TelaContaSaldo()
        {
            Console.Clear();

            Conta primeiraConta = contas[0];
            Utilidades.EscreverCentralizado($"Bem Vindo, {primeiraConta.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            Console.WriteLine();
            primeiraConta.ConsultaSaldo();
            Console.ReadKey();

            TelaConta();

        }

        public static void TelaContaExtrato()
        {
            Console.Clear();

            Conta primeiraConta = contas[0];
            Utilidades.EscreverCentralizado($"Bem Vindo, {primeiraConta.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
            
            Console.WriteLine();
            Console.WriteLine();
            primeiraConta.ConsultaExtrato();

            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("Saldo atual: " + primeiraConta.Saldo);
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

            Conta primeiraConta = contas[0];
            Utilidades.EscreverCentralizado($"Bem Vindo, {primeiraConta.Nome} | Banco: 000 | Agencia: 00000 | Conta: {Conta.QtdConta} ");
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

    }
}