using System;
using System.Windows.Forms;

namespace BankingAppForms
{
    public partial class MainForm : Form
    {
        private SistemaBancario sistema;
        private Usuario usuarioLogado;

        public MainForm(SistemaBancario sistema, Usuario usuarioLogado)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuarioLogado = usuarioLogado;

            // Desabilitar botões conforme o tipo de usuário
            if (usuarioLogado is Lojista)
            {
                btnTransferencia.Enabled = false;
                btnAdicionarSaldo.Enabled = false; // Desabilitar se necessário
            }
        }

        public MainForm()
        {
        }

        private void btnMostrarSaldo_Click(object sender, EventArgs e)
        {
            AtualizarSaldo();
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            var transferenciaForm = new TransferenciaForm(sistema, usuarioLogado);
            transferenciaForm.FormClosed += (s, args) => AtualizarSaldo(); // Atualiza o saldo após o fechamento do formulário
            transferenciaForm.ShowDialog();
        }

        private void btnAdicionarSaldo_Click(object sender, EventArgs e)
        {
            var adicionarSaldoForm = new AdicionarSaldoForm(sistema, usuarioLogado);
            adicionarSaldoForm.FormClosed += (s, args) => AtualizarSaldo(); // Atualiza o saldo após o fechamento do formulário
            adicionarSaldoForm.ShowDialog();
        }

        private void AtualizarSaldo()
        {
            var saldoAtualizado = sistema.BuscarUsuarioPorEmail(usuarioLogado.Email)?.Saldo;
            if (saldoAtualizado.HasValue)
            {
                MessageBox.Show($"Seu saldo atualizado é: {saldoAtualizado.Value:C}", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
