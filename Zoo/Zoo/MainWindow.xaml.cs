using AnimalLib;
using System.Windows;

namespace Zoo
{
    public partial class MainWindow : Window
    {
        private AnimalFactory animalFactory = AnimalFactory.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            foreach (var name in animalFactory.AnimalNames)
            {
                cboAnimals.Items.Add(name);
            }
        }
    }
}
