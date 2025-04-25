namespace BancoDigital.Classes
{

    

    public class Conta
    {
        public double Saldo{get; private set;}
        protected string NumeroDoBanco{get; set;}
        protected string NumeroDaAgencia{get; set;}
        protected string NumeroDaConta{get; set;}
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public static int  QtdConta = 0;

        List <string> Extrato = new List<string>();


        public Conta(string nome, string cpf, string senha, double saldo)
        {
            Saldo = saldo;
            Nome = nome;
            Cpf = cpf;
            Senha = senha;
            QtdConta ++;
        }

        public void MostrarResumo()
        {
            Console.WriteLine($"Conta criada para: {Nome} | CPF: {Cpf} | Senha: {Senha}");
        }
        

        public void RealizaDeposito(double QtdDeposito)
        {

            
            Saldo += QtdDeposito;

            PopulaExtrato("Deposito", QtdDeposito);
        
        }

        public void RealizaSaque(double QtdSaque)
        {
            
            Saldo -= QtdSaque;

            PopulaExtrato("Saque", QtdSaque);
        }

        public void ConsultaSaldo()
        {

            Utilidades.EscreverCentralizado("Saldo da conta: " + Saldo);

        }

        public void PopulaExtrato(string tipoDeTransacao, double valorTransacao)
        {
           if(tipoDeTransacao == "Deposito")
           {
                Extrato.Add("Depósito ---> Valor: " + valorTransacao);
           }
           else
           {
                Extrato.Add(@"Saque ---> Valor: -" + valorTransacao);
           } 
        
        }

        public void ConsultaExtrato()
        {
            foreach (String ex in Extrato )
            {
                Utilidades.EscreverCentralizado(ex);
            }
            
        
        }

        



    }

    


}