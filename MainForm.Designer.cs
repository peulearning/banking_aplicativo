namespace BankingAppForms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnMostrarSaldo = new System.Windows.Forms.Button();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.btnAdicionarSaldo = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMostrarSaldo
            // 
            this.btnMostrarSaldo.Location = new System.Drawing.Point(12, 12);
            this.btnMostrarSaldo.Name = "btnMostrarSaldo";
            this.btnMostrarSaldo.Size = new System.Drawing.Size(200, 40);
            this.btnMostrarSaldo.TabIndex = 0;
            this.btnMostrarSaldo.Text = "Mostrar Saldo";
            this.btnMostrarSaldo.UseVisualStyleBackColor = true;
            this.btnMostrarSaldo.Click += new System.EventHandler(this.btnMostrarSaldo_Click);
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.Location = new System.Drawing.Point(12, 58);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(200, 40);
            this.btnTransferencia.TabIndex = 1;
            this.btnTransferencia.Text = "Transferir Dinheiro";
            this.btnTransferencia.UseVisualStyleBackColor = true;
            this.btnTransferencia.Click += new System.EventHandler(this.btnTransferencia_Click);
            // 
            // btnAdicionarSaldo
            // 
            this.btnAdicionarSaldo.Location = new System.Drawing.Point(12, 104);
            this.btnAdicionarSaldo.Name = "btnAdicionarSaldo";
            this.btnAdicionarSaldo.Size = new System.Drawing.Size(200, 40);
            this.btnAdicionarSaldo.TabIndex = 2;
            this.btnAdicionarSaldo.Text = "Adicionar Saldo";
            this.btnAdicionarSaldo.UseVisualStyleBackColor = true;
            this.btnAdicionarSaldo.Click += new System.EventHandler(this.btnAdicionarSaldo_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 150);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(224, 201);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAdicionarSaldo);
            this.Controls.Add(this.btnTransferencia);
            this.Controls.Add(this.btnMostrarSaldo);
            this.Name = "MainForm";
            this.Text = "BankingApp";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnMostrarSaldo;
        private System.Windows.Forms.Button btnTransferencia;
        private System.Windows.Forms.Button btnAdicionarSaldo;
        private System.Windows.Forms.Button btnLogout;
    }
}
