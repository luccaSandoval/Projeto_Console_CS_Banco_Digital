using BancoDigital.Services;
using BancoDigital.UI;

namespace BancoDigital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BancoService bancoService = new BancoService();
            Layout layout = new Layout(bancoService);
            layout.Iniciar();
        }
    }
}
