using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppEntity.Data;

namespace WpfAppEntity.View
{
    /// <summary>
    /// Interaction logic for ucLogin.xaml
    /// </summary>
    public partial class ucLogin : UserControl
    {
        public ucLogin()
        {
            InitializeComponent();
        }
        public event EventHandler success;
        public event EventHandler fail;
        public BibliotecaDBContext context = new BibliotecaDBContext();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userName = tbxLogin.Text;
            var userPass = tbxSenha.Password;

            var result = context.Usuario.FirstOrDefault(x => x.Login == userName &&
            x.Senha == userPass);

            if (result?.Id > 0)
                success("Usuário logado com sucesso!", new EventArgs());

            else
                fail($"Falha ao logar com usuário {userName}.", new EventArgs());
        }
    }
}
