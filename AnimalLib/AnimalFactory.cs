using System.Reflection;

namespace AnimalLib
{
    public class AnimalFactory
    {
        private static readonly Dictionary<string, Animal> prototypes = new();
        public string[] AnimalNames => prototypes.Keys.OrderBy(x => x).ToArray();
        private static AnimalFactory? instance = null;
        public Dictionary<string, int> AnimalCount { get; } = new();

        private AnimalFactory() { }

        static AnimalFactory()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.BaseType != null && !x.IsAbstract && x.IsSubclassOf(typeof(Animal)))
                .ToList()
                .ForEach(x =>
                {
                    var animal = Activator.CreateInstance(x) as Animal;
                    prototypes[x.Name] = animal;
                });
        }

        public static AnimalFactory GetInstance()
        {
            return instance ??= new AnimalFactory();
        }

        public double CalcGreenFood()
        {
            double sum = 0;
            foreach (var animal in AnimalCount)
            {
                sum += prototypes[animal.Key].GreenFoodPerDay * animal.Value;
            }
            return sum;
        }

        public double CalcMeatFood()
        {
            double sum = 0;
            foreach (var animal in AnimalCount)
            {
                sum += prototypes[animal.Key].MeatFoodPerDay * animal.Value;
            }
            return sum;
        }

        public double CalcTotalPrice()
        {
            double total = 0;
            foreach (var animal in AnimalCount)
            {
                total += prototypes[animal.Key].Price * animal.Value;
            }
            return total;
        }

        public IEnumerable<Animal> Create(string name, int amount)
        {
            if (prototypes.TryGetValue(name, out Animal? animal))
            {
                if (!AnimalCount.TryGetValue(name, out int previous)) previous = 0;
                AnimalCount[name] = previous + amount;

                for (int i = 0; i < amount; i++)
                {
                    yield return animal.Clone();
                }
            }
        }
    }
}
