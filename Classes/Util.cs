namespace BancoDigital.Classes
{
    public class Utilidades
    {


        public static void EscreverCentralizado(string mensagem, ConsoleColor corTexto, ConsoleColor corFundo)
        {
            Console.ForegroundColor = corTexto;
            Console.BackgroundColor = corFundo;


            int largura = Console.WindowWidth;
            int posicao = (largura - mensagem.Length) / 2;
            Console.SetCursorPosition(posicao > 0 ? posicao : 0, Console.CursorTop);
            Console.WriteLine(mensagem);

            
        }



    }
    
}
