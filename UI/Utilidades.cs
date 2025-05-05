namespace BancoDigital.UI
{
    public static class Utilidades
    {
        public static void EscreverCentralizado(string mensagem)
        {
            int largura = Console.WindowWidth;
            int posicao = (largura - mensagem.Length) / 2;
            Console.SetCursorPosition(posicao > 0 ? posicao : 0, Console.CursorTop);
            Console.WriteLine(mensagem);
        }

        public static void SetarCoresPadrao()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
        }
    }
}
