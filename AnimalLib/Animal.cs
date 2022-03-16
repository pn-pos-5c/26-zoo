using System.Runtime.Serialization.Formatters.Binary;

namespace AnimalLib
{
    [Serializable]
    public abstract class Animal
    {
        public string Species { get; set; }
        public double GreenFoodPerDay { get; set; }
        public double MeatFoodPerDay { get; set; }
        public double Price { get; set; }

        internal Animal Clone()
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = (Animal)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }
    }
}
