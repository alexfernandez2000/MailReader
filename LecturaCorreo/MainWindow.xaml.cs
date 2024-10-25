using Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LecturaCorreo
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
        private void ListarCorreos(object sender, RoutedEventArgs e)
        {
            // Código que se ejecuta cuando se hace clic en el botón
            Outlook gm= new Outlook();
            gm.LeerCorreos();
        }

    }
}