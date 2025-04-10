using System.Collections;
using BancoDigital.Classes;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BancoDigital.Classes
{
    public class Layout
    {

        

        public static void TelaPrincipal()
        {
            Console.Clear();
            Utilidades.SettaCores();
            Console.Clear();
            

            Utilidades.EscreverCentralizado("Escolha uma das opções abaixo:");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("1 - Criar Conta");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");
            Utilidades.EscreverCentralizado("2 - Entrar com CPF e Senha");
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>");

            

            int opcao = 0;


                
            opcao = int.Parse(Console.ReadLine());

            

            switch(opcao)
            {
                case 1:
                    TelaCriaConta();
                    break;
                case 2:
                    Console.WriteLine("op 2");
                    break;
                default:
                    Utilidades.EscreverCentralizadoEmVermelho("Opção Inválida!");
                    break;

            }
            
            Console.ReadKey();

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
                
                
            }while(!Utilidades.ValidarNome(nome));;

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


            TelaConta();

        }

        public static void TelaConta()
        {
            Console.Clear();

            Utilidades.SettaCores();
            Console.Clear();

            Utilidades.EscreverCentralizado("Bem Vindo, Nome | Banco: 000 | Agencia: 00000 | Conta: 000 ");
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

            Console.ReadKey();






        }




    }
}