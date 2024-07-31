using System;
using System.Windows.Forms;

namespace BankingAppForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicialize o SistemaBancario
            SistemaBancario sistema = new SistemaBancario();

            // Crie a instância do LoginForm com o sistema
            LoginForm loginForm = new LoginForm(sistema);
            Application.Run(loginForm);
        }
    }
}
