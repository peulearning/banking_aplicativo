using System;

namespace BankingAppForms
{
    public class UsuarioComum : Usuario
    {
        public UsuarioComum(string nomeCompleto, string cpf, string email, string senha) : base(nomeCompleto, cpf, email, senha) { }

        public void EnviarTransferencia(Usuario destinatario, decimal valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                destinatario.Saldo += valor;
            }
            else
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }
        }
    }
}
