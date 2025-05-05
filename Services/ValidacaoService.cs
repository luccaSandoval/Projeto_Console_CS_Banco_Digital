namespace BancoDigital.Services
{
    public static class ValidacaoService
    {
        public static bool ValidarNome(string nome) =>
            !string.IsNullOrWhiteSpace(nome) && nome.Length > 2;

        public static bool ValidarCpf(string cpf) =>
            cpf.Length == 11 && cpf.All(char.IsDigit);

        public static bool ValidarSenha(string senha) =>
            senha.Length >= 6 && senha.Any(char.IsLetter) && senha.Any(char.IsDigit);
    }
}
