using System.Text.RegularExpressions;

namespace BancoDigital.Classes
{
    public class Utilidades
    {
        


        public static void EscreverCentralizado(string mensagem)
        {



            int largura = Console.WindowWidth;
            int posicao = (largura - mensagem.Length) / 2;
            Console.SetCursorPosition(posicao > 0 ? posicao : 0, Console.CursorTop);
            Console.WriteLine(mensagem);

            
        }

        public static void SettaCores()
        {   
            

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Yellow;

            
        }

        public static void EscreverCentralizadoEmVermelho(string mensagem)
        {   
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkCyan;


            
            int largura = Console.WindowWidth;
            int posicao = (largura - mensagem.Length) / 2;
            Console.SetCursorPosition(posicao > 0 ? posicao : 0, Console.CursorTop);
            Console.WriteLine(mensagem);

            SettaCores();
            
        }

        public static void EscreverCentralizadoEmVerde(string mensagem)
        {   
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkCyan;


            
            int largura = Console.WindowWidth;
            int posicao = (largura - mensagem.Length) / 2;
            Console.SetCursorPosition(posicao > 0 ? posicao : 0, Console.CursorTop);
            Console.WriteLine(mensagem);

            SettaCores();

            
        }

        public static bool ValidarNome(string nome)
        {
    
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            if (nome.Length < 2)
                return false;

            
            return Regex.IsMatch(nome, @"^[A-Za-zÀ-ÿ\s]+$"); // Regex: permite apenas letras (acentuadas ou não) e espaços
        }

        public static bool ValidarCpf(string cpf)
        {
    
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            if (cpf.Length != 11)
                return false;

            
            return Regex.IsMatch(cpf, @"^\d{11}$"); // Regex: permite apenas letras (acentuadas ou não) e espaços
        }



    }
}
    

