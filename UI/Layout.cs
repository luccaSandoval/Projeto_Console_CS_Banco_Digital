using BancoDigital.Services;
using BancoDigital.Models;

namespace BancoDigital.UI
{
    public class Layout
    {
        private readonly BancoService _bancoService;

        public Layout(BancoService bancoService)
        {
            _bancoService = bancoService;
        }

        public void Iniciar()
        {
            while (true)
            {
                Utilidades.SetarCoresPadrao();
                Utilidades.EscreverCentralizado("Bem-vindo ao Banco Digital");
                Utilidades.EscreverCentralizado("1 - Criar Conta");
                Utilidades.EscreverCentralizado("2 - Entrar");
                Utilidades.EscreverCentralizado("3 - Sair");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarConta();
                        break;
                    case "2":
                        Entrar();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void CriarConta()
        {
            Console.Clear();
            Utilidades.EscreverCentralizado("Criar Conta");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF (11 números): ");
            string cpf = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (!ValidacaoService.ValidarNome(nome) || !ValidacaoService.ValidarCpf(cpf) || !ValidacaoService.ValidarSenha(senha))
            {
                Console.WriteLine("Dados inválidos. Tente novamente.");
                Console.ReadKey();
                return;
            }

            if (_bancoService.CriarConta(nome, cpf, senha))
                Console.WriteLine("Conta criada com sucesso!");
            else
                Console.WriteLine("CPF já cadastrado!");

            Console.ReadKey();
        }

        private void Entrar()
        {
            Console.Clear();
            Utilidades.EscreverCentralizado("Login");

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            if (_bancoService.Login(cpf, senha))
                TelaConta();
            else
            {
                Console.WriteLine("CPF ou Senha inválidos.");
                Console.ReadKey();
            }
        }

        private void TelaConta()
        {
            while (true)
            {
                Console.Clear();
                var conta = _bancoService.ContaAtual();
                if (conta == null) return;

                Utilidades.EscreverCentralizado($"Olá, {conta.Nome}");
                Utilidades.EscreverCentralizado("1 - Depositar");
                Utilidades.EscreverCentralizado("2 - Sacar");
                Utilidades.EscreverCentralizado("3 - Saldo");
                Utilidades.EscreverCentralizado("4 - Extrato");
                Utilidades.EscreverCentralizado("5 - Logout");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RealizarDeposito();
                        break;
                    case "2":
                        RealizarSaque();
                        break;
                    case "3":
                        ConsultarSaldo();
                        break;
                    case "4":
                        ConsultarExtrato();
                        break;
                    case "5":
                        _bancoService.Logout();
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void RealizarDeposito()
        {
            Console.Write("Valor para depositar: ");
            if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
            {
                _bancoService.Depositar(valor);
                Console.WriteLine("Depósito realizado!");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            Console.ReadKey();
        }

        private void RealizarSaque()
        {
            Console.Write("Valor para sacar: ");
            if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
            {
                if (_bancoService.Sacar(valor))
                    Console.WriteLine("Saque realizado!");
                else
                    Console.WriteLine("Saldo insuficiente.");
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
            Console.ReadKey();
        }

        private void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo atual: {_bancoService.ObterSaldo():C}");
            Console.ReadKey();
        }

        private void ConsultarExtrato()
        {
            var extrato = _bancoService.ObterExtrato();
            if (extrato != null)
            {
                foreach (var linha in extrato)
                    Console.WriteLine(linha);
            }
            Console.ReadKey();
        }
    }
}
