namespace BancoDigital.Classes
{

    

    class Conta
    {
        public double saldo{get; private set;}
        protected string NumeroDoBanco{get; set;}
        protected string NumeroDaAgencia{get; set;}
        protected string NumeroDaConta{get; set;}
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public static int  QtdConta = 0;


        public Conta(string nome, string cpf, string senha)
        {
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
            saldo += QtdDeposito;
        
        }

        public void RealizaSaque(double QtdSaque)
        {
            
            saldo -= QtdSaque;
        
        }

        public void ConsultaSaldo()
        {

            Console.WriteLine("Saldo da conta: " + saldo);
        
        }

        public void Extrato()
        {
            
        
        }



    }

    


}