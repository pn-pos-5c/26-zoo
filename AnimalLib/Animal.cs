using System.Runtime.Serialization.Formatters.Binary;

namespace AnimalLib
{
    [Serializable]
    public abstract class Animal
    {
        public abstract string Species { get; }
        public abstract double GreenFoodPerDay { get; }
        public abstract double MeatFoodPerDay { get; }
        public abstract double Price { get; }

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

        public override string ToString()
        {
            return Species;
        }
    }
}
