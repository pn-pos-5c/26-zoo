using AnimalLib;
using System.Linq;
using System.Windows;

namespace Zoo
{
    public partial class MainWindow : Window
    {
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
            foreach (var name in AnimalFactory.GetInstance().AnimalNames)
            {
                cboAnimals.Items.Add(name);
            }
        }

        private void UpdateAnimalList()
        {
            var animals = AnimalFactory.GetInstance().AnimalCount.ToArray();
            var animalNames = new string[animals.Length];

            for (var i = 0; i < animals.Length; i++)
            {
                animalNames[i] = $"{animals[i].Value} x {animals[i].Key}";
            }

            listAnimals.ItemsSource = animalNames;
            listAnimals.Items.Refresh();
        }

        private void UpdateZooDetails()
        {
            lblGreenFoodPerDay.Content = AnimalFactory.GetInstance().CalcGreenFood();
            lblMeatFoodPerDay.Content = AnimalFactory.GetInstance().CalcMeatFood();
            lblTotalPrice.Content = AnimalFactory.GetInstance().CalcTotalPrice();
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtAnimalCount.Text, out int amount) || cboAnimals.SelectionBoxItem is not string name) return;

            AnimalFactory.GetInstance().Create(name, amount).Count();
            UpdateAnimalList();
            UpdateZooDetails();
        }
    }
}
