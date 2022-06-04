using System.Windows;
using Fitness.ViewModel;

namespace Fitness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
            VersionTextBlock.Text = typeof(MainWindow).Assembly.GetName().Version?.ToString();
            FitnessCalendar.ItemsSource = ((MainViewModel)DataContext).FitnessDays;
        }
    }
}
