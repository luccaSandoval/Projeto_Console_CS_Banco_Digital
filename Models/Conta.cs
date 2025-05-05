namespace BancoDigital.Models
{
    public class Conta
    {
        public double Saldo { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Senha { get; private set; }
        public int NumeroConta { get; private set; }
        private List<string> Extrato { get; set; }

        private static int contadorContas = 1;

        public Conta(string nome, string cpf, string senha)
        {
            Nome = nome;
            Cpf = cpf;
            Senha = senha;
            Saldo = 0;
            NumeroConta = contadorContas++;
            Extrato = new List<string>();
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Extrato.Add($"+ Depósito: {valor:C}");
        }

        public bool Sacar(double valor)
        {
            if (valor > Saldo)
                return false;

            Saldo -= valor;
            Extrato.Add($"- Saque: {valor:C}");
            return true;
        }

        public IEnumerable<string> ObterExtrato()
        {
            return Extrato.AsReadOnly();
        }
    }
}
