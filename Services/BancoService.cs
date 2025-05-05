using BancoDigital.Models;

namespace BancoDigital.Services
{
    public class BancoService
    {
        private List<Conta> contas = new List<Conta>();
        private Conta? contaLogada;

        public BancoService()
        {
            // Cria uma conta admin por padrão
            contas.Add(new Conta("Admin", "00000000000", "admin123"));
        }

        public bool CriarConta(string nome, string cpf, string senha)
        {
            if (contas.Any(c => c.Cpf == cpf))
                return false;

            contas.Add(new Conta(nome, cpf, senha));
            return true;
        }

        public bool Login(string cpf, string senha)
        {
            contaLogada = contas.FirstOrDefault(c => c.Cpf == cpf && c.Senha == senha);
            return contaLogada != null;
        }

        public void Logout()
        {
            contaLogada = null;
        }

        public bool Depositar(double valor)
        {
            if (contaLogada == null)
                return false;

            contaLogada.Depositar(valor);
            return true;
        }

        public bool Sacar(double valor)
        {
            if (contaLogada == null)
                return false;

            return contaLogada.Sacar(valor);
        }

        public double? ObterSaldo()
        {
            return contaLogada?.Saldo;
        }

        public IEnumerable<string>? ObterExtrato()
        {
            return contaLogada?.ObterExtrato();
        }

        public Conta? ContaAtual()
        {
            return contaLogada;
        }
    }
}
