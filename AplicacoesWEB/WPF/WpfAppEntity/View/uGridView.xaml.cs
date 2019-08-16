using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppEntity.Data;

namespace WpfAppEntity.View
{
    /// <summary>
    /// Interaction logic for uGridView.xaml
    /// </summary>
    public partial class uGridView : UserControl
    {
        public uGridView()
        {
            InitializeComponent();
        }
        public BibliotecaDBContext context = new BibliotecaDBContext(); 
        private void DtGridView_Loaded(object sender, RoutedEventArgs e)
        {
            dtGridView.ItemsSource = context.Usuario.ToList<Usuario>();

        }

        private void DtGridView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void DtGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChangesAsync();

            MessageBox.Show("Itens salvos com sucesso");
        }
    }
}
