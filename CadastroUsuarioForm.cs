using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BankingAppForms
{
    public partial class CadastroUsuarioForm : Form
    {
        private SistemaBancario sistema;

        public CadastroUsuarioForm(SistemaBancario sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string tipo = cboTipoUsuario.SelectedItem?.ToString();

            // Validação básica
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) || tipo == null)
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AdicionarUsuario(nome, cpf, email, senha, tipo);
                MessageBox.Show("Usuário cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarUsuario(string nome, string cpf, string email, string senha, string tipo)
        {
            string connectionString = "server=localhost;database=BankingApp;user=root;password="; // Atualize conforme necessário

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO usuarios (Nome, CPF, Email, Senha, Tipo) VALUES (@Nome, @CPF, @Email, @Senha, @Tipo)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@CPF", cpf);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.Parameters.AddWithValue("@Tipo", tipo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
