using System;
using System.Windows.Forms;

namespace BankingAppForms
{
    public partial class LoginForm : Form
    {
        private SistemaBancario sistema;

        public LoginForm(SistemaBancario sistema)
        {
            InitializeComponent();
            this.sistema = sistema;
        }

        public LoginForm()
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtEmail.Text;
                var senha = txtSenha.Text;
                var usuario = sistema.Login(email, senha);

                var mainForm = new MainForm(sistema, usuario);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            var cadastroForm = new CadastroUsuarioForm(sistema);
            cadastroForm.ShowDialog();
        }
    }
}
