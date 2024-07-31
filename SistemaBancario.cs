using System;
using MySql.Data.MySqlClient;

namespace BankingAppForms
{
    public class SistemaBancario
    {
        public void CadastrarUsuario(Usuario usuario)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Usuarios (Nome, CPF, Email, Senha, Saldo, Tipo) VALUES (@Nome, @CPF, @Email, @Senha, @Saldo, @Tipo)", connection);
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@CPF", usuario.CPF);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@Saldo", usuario.Saldo);
                command.Parameters.AddWithValue("@Tipo", usuario is Lojista ? "Lojista" : "Comum");

                command.ExecuteNonQuery();
            }
        }

        public Usuario Login(string email, string senha)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha", connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Senha", senha);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var nome = reader["Nome"].ToString();
                        var cpf = reader["CPF"].ToString();
                        var saldo = Convert.ToDecimal(reader["Saldo"]);
                        var tipo = reader["Tipo"].ToString();

                        if (tipo == "Lojista")
                        {
                            return new Lojista(nome, cpf, email, senha) { Saldo = saldo };
                        }
                        else
                        {
                            return new UsuarioComum(nome, cpf, email, senha) { Saldo = saldo };
                        }
                    }
                }
            }
            throw new InvalidOperationException("Credenciais inválidas.");
        }

        public void RealizarTransferencia(UsuarioComum remetente, Usuario destinatario, decimal valor)
        {
            remetente.EnviarTransferencia(destinatario, valor);

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("INSERT INTO Transacoes (RemetenteId, DestinatarioId, Valor, Data) VALUES ((SELECT Id FROM Usuarios WHERE Email = @EmailRemetente), (SELECT Id FROM Usuarios WHERE Email = @EmailDestinatario), @Valor, @Data)", connection);
                command.Parameters.AddWithValue("@EmailRemetente", remetente.Email);
                command.Parameters.AddWithValue("@EmailDestinatario", destinatario.Email);
                command.Parameters.AddWithValue("@Valor", valor);
                command.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                command.ExecuteNonQuery();
            }
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM Usuarios WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var nome = reader["Nome"].ToString();
                        var cpf = reader["CPF"].ToString();
                        var saldo = Convert.ToDecimal(reader["Saldo"]);
                        var tipo = reader["Tipo"].ToString();

                        if (tipo == "Lojista")
                        {
                            return new Lojista(nome, cpf, email, reader["Senha"].ToString()) { Saldo = saldo };
                        }
                        else
                        {
                            return new UsuarioComum(nome, cpf, email, reader["Senha"].ToString()) { Saldo = saldo };
                        }
                    }
                }
            }
            return null;
        }

        public void AdicionarSaldo(Usuario usuario, decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor a ser adicionado deve ser positivo.");
            }

            using (var connection = Database.GetConnection())
            {
                connection.Open();
                var command = new MySqlCommand("UPDATE Usuarios SET Saldo = Saldo + @Valor WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Valor", valor);
                command.Parameters.AddWithValue("@Email", usuario.Email);

                var rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException("Não foi possível atualizar o saldo. Verifique se o usuário existe.");
                }
            }
        }

        public void Transferir(string emailRemetente, string emailDestinatario, decimal valor)
        {
            var remetente = BuscarUsuarioPorEmail(emailRemetente) as UsuarioComum;
            var destinatario = BuscarUsuarioPorEmail(emailDestinatario);

            if (remetente == null || destinatario == null)
            {
                throw new ArgumentException("Remetente ou destinatário inválido.");
            }

            if (remetente.Saldo < valor)
            {
                throw new InvalidOperationException("Saldo insuficiente.");
            }

            // Atualize os saldos dos usuários
            using (var connection = Database.GetConnection())
            {
                connection.Open();

                // Inicia uma transação
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Atualiza o saldo do remetente
                        var commandRemetente = new MySqlCommand("UPDATE Usuarios SET Saldo = Saldo - @Valor WHERE Email = @Email", connection, transaction);
                        commandRemetente.Parameters.AddWithValue("@Valor", valor);
                        commandRemetente.Parameters.AddWithValue("@Email", remetente.Email);
                        commandRemetente.ExecuteNonQuery();

                        // Atualiza o saldo do destinatário
                        var commandDestinatario = new MySqlCommand("UPDATE Usuarios SET Saldo = Saldo + @Valor WHERE Email = @Email", connection, transaction);
                        commandDestinatario.Parameters.AddWithValue("@Valor", valor);
                        commandDestinatario.Parameters.AddWithValue("@Email", destinatario.Email);
                        commandDestinatario.ExecuteNonQuery();

                        // Registra a transação
                        var commandTransacao = new MySqlCommand("INSERT INTO Transacoes (RemetenteId, DestinatarioId, Valor, Data) VALUES ((SELECT Id FROM Usuarios WHERE Email = @EmailRemetente), (SELECT Id FROM Usuarios WHERE Email = @EmailDestinatario), @Valor, @Data)", connection, transaction);
                        commandTransacao.Parameters.AddWithValue("@EmailRemetente", remetente.Email);
                        commandTransacao.Parameters.AddWithValue("@EmailDestinatario", destinatario.Email);
                        commandTransacao.Parameters.AddWithValue("@Valor", valor);
                        commandTransacao.Parameters.AddWithValue("@Data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        commandTransacao.ExecuteNonQuery();

                        // Commit da transação
                        transaction.Commit();
                    }
                    catch
                    {
                        // Rollback em caso de erro
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
 }
