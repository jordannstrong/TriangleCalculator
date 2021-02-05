using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace TriangleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
            InitializeComponent();
            DataContext = new TriangleViewModel();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex(@"^[.?\d]+$");
            e.Handled = !reg.IsMatch(e.Text);
        }

    }
}
