using System;
using System.Windows.Forms;

namespace BankingAppForms
{
    public partial class TransferenciaForm : Form
    {
        private SistemaBancario sistema;
        private Usuario usuarioLogado;

        public TransferenciaForm(SistemaBancario sistema, Usuario usuarioLogado)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuarioLogado = usuarioLogado;
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                // Certifique-se de que txtEmailDestino e txtValor são realmente do tipo TextBox
                string emailDestino = txtEmailDestino.Text;
                string valorTexto = txtValor.Text;

                // Valida o e-mail e o valor
                if (string.IsNullOrWhiteSpace(emailDestino))
                {
                    MessageBox.Show("Por favor, insira o e-mail do destinatário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(valorTexto) || !decimal.TryParse(valorTexto, out decimal valor))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chamando o método Transferir no sistema
                sistema.Transferir(usuarioLogado.Email, emailDestino, valor);
                MessageBox.Show("Transferência realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpa os campos após a transferência
                txtEmailDestino.Clear();
                txtValor.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
