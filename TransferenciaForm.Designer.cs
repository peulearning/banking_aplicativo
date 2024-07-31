namespace BankingAppForms
{
    partial class TransferenciaForm
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
            this.txtEmailDestino = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblEmailDestino = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEmailDestino
            // 
            this.txtEmailDestino.Location = new System.Drawing.Point(12, 29);
            this.txtEmailDestino.Name = "txtEmailDestino";
            this.txtEmailDestino.Size = new System.Drawing.Size(200, 20);
            this.txtEmailDestino.TabIndex = 0;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 68);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(200, 20);
            this.txtValor.TabIndex = 1;
            // 
            // lblEmailDestino
            // 
            this.lblEmailDestino.AutoSize = true;
            this.lblEmailDestino.Location = new System.Drawing.Point(12, 13);
            this.lblEmailDestino.Name = "lblEmailDestino";
            this.lblEmailDestino.Size = new System.Drawing.Size(92, 13);
            this.lblEmailDestino.TabIndex = 2;
            this.lblEmailDestino.Text = "Email do Destino:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 52);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 3;
            this.lblValor.Text = "Valor:";
            // 
            // btnTransferir
            // 
            this.btnTransferir.Location = new System.Drawing.Point(12, 104);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(200, 40);
            this.btnTransferir.TabIndex = 4;
            this.btnTransferir.Text = "Transferir";
            this.btnTransferir.UseVisualStyleBackColor = true;
            this.btnTransferir.Click += new System.EventHandler(this.btnTransferir_Click);
            // 
            // TransferenciaForm
            // 
            this.ClientSize = new System.Drawing.Size(224, 161);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblEmailDestino);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtEmailDestino);
            this.Name = "TransferenciaForm";
            this.Text = "Transferência - BankingApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtEmailDestino;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblEmailDestino;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Button btnTransferir;
    }
}
