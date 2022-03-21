namespace AnimalLib
{
    [Serializable]
    public class Gibbon : Carnivore
    {
        public override string Species => "Gibbon";
        public override double GreenFoodPerDay => 1;
        public override double MeatFoodPerDay => 2;
        public override double Price => 800;

        public override string ToString()
        {
            return $"{Species}";
        }
    }
}
