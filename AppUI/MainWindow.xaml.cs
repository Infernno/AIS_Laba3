using System.Windows;
using ConsoleApp.DAL;

namespace AppUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var context = new EmployeeContext("SqlDatabase");
            var repository = new EmployeeRepository(context);

            var viewModel = new WpfViewModel(repository);

            DataContext = viewModel;
        }
    }
}
