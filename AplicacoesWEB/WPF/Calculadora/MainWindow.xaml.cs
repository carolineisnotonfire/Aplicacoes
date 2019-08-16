using Calculadora.View;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ucLoginForm_loginCorrect(object sender, EventArgs e)
        {
            ucCalcForm.Visibility = Visibility.Visible;
            MessageBox.Show("Lembre-se: Apenas operações entre dois números e sempre limpando a caixa de texto depois de usá-la caso queira " +
                "usar de novo :)");
        }
    }
}
