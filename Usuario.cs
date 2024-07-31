namespace BankingAppForms
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; set; }

        public Usuario(string nomeCompleto, string cpf, string email, string senha)
        {
            Nome = nomeCompleto;
            CPF = cpf;
            Email = email;
            Senha = senha;
            Saldo = 0;
        }
    }
}
