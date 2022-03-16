using System.Reflection;

namespace AnimalLib
{
    public class AnimalFactory
    {
        private static readonly Dictionary<string, Animal> prototypes = new();
        public string[] AnimalNames => prototypes.Keys.OrderBy(x => x).ToArray();
        private static AnimalFactory? instance = null;
        private int animalsCloned = 0;

        private AnimalFactory()
        {

        }

        static AnimalFactory()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.BaseType != null && !x.IsAbstract && !x.IsSubclassOf(typeof(Animal)))
                .ToList()
                .ForEach(x =>
                {
                    var animal = Activator.CreateInstance(x) as Animal;
                    string name = x.Name;
                    Register(name, animal);
                });
        }

        public static AnimalFactory GetInstance()
        {
            return instance ??= new AnimalFactory();
        }

        private static void Register(string name, Animal? animal)
        {
            Console.WriteLine($"New Animal {name}");
            prototypes[name] = animal;
        }

        public IEnumerable<Animal> Create(string name, int amount)
        {
            if (prototypes.ContainsKey(name))
            {
                animalsCloned += amount;
                for (int i = 0; i < amount; i++)
                {
                    yield return prototypes[name].Clone();
                }
            }

            throw new NotImplementedException();
        }
    }
}
