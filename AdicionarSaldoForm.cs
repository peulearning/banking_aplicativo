using System;
using System.Windows.Forms;

namespace BankingAppForms
{
    public partial class AdicionarSaldoForm : Form
    {
        private SistemaBancario sistema;
        private Usuario usuarioLogado;

        public AdicionarSaldoForm(SistemaBancario sistema, Usuario usuarioLogado)
        {
            InitializeComponent();
            this.sistema = sistema;
            this.usuarioLogado = usuarioLogado;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtValor.Text, out decimal valor) && valor > 0)
                {
                    sistema.AdicionarSaldo(usuarioLogado, valor);
                    MessageBox.Show("Saldo adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("O valor deve ser um número positivo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
