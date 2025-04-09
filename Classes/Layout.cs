using System.Collections;
using BancoDigital.Classes;
using System;

namespace BancoDigital.Classes
{
    public class Layout
    {
        public static void TelaPrincipal()
        {
            ConsoleColor corFundo = ConsoleColor.DarkCyan;
            ConsoleColor corTexto = ConsoleColor.Yellow;

            
            Console.BackgroundColor = corFundo;
            Console.ForegroundColor = corTexto;
            Console.Clear();

            Utilidades.EscreverCentralizado("Escolha uma das opções abaixo:",corTexto,corFundo);
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>",corTexto,corFundo);
            Utilidades.EscreverCentralizado("1 - Criar Conta",corTexto,corFundo);
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>",corTexto,corFundo);
            Utilidades.EscreverCentralizado("2 - Entrar com CPF e Senha",corTexto,corFundo);
            Utilidades.EscreverCentralizado("<><><><><><><><><><><><><><><><><><><><><><><><><>",corTexto,corFundo);

           

            int opcao = int.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 1:
                    Console.WriteLine("op 1");
                    break;
                case 2:
                    Console.WriteLine("op 2");
                    break;
                default:
                    Utilidades.EscreverCentralizado("Deu Erro!", ConsoleColor.Red,corFundo);;
                    break;

            }
            


            Console.ReadKey();

        }
    }
}