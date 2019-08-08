using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace CadastroComRegEx.View
{
    /// <summary>
    /// Interaction logic for ucCadastro.xaml
    /// </summary>
    public partial class ucCadastro : UserControl
    {
        public ucCadastro()
        {
            InitializeComponent();
        }
        public void Validar (string telefone, string email)
        {

            var textToTestTel = tbtTelefone.Text;
            var regularExpressionTel = @"[\d{2}\ (\d{2}\)\s\d{4,5}\-\d{4}]$";
           // var regularExpressionTel = @"^\+[1-9]{2}\ ([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$";
            var resultTel = Regex.IsMatch(textToTestTel, regularExpressionTel);
            if (resultTel)
            {
                MessageBox.Show("Sucesso ao registrar seu telefone!");
            }
            else
                MessageBox.Show("Telefone inválido!");

            var textToTestEmail = tbtEmail.Text;
            var regularExpressionEmail = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            var resultEmail = Regex.IsMatch(textToTestEmail, regularExpressionEmail);
            if (resultEmail)
            {
                MessageBox.Show("Sucesso ao registrar seu E-mail!");
            }
            else
                MessageBox.Show("E-mail inválido!");


        }
        private void Button_Click(object sender, EventArgs e)
        {
            Validar(tbtTelefone.Text, tbtEmail.Text);
        }
    }
}
