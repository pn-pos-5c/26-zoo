namespace AnimalLib
{
    [Serializable]
    public class Gorilla : Herbivore
    {
        public override string Species => "Gorilla";
        public override double GreenFoodPerDay => 2;
        public override double MeatFoodPerDay => 0;
        public override double Price => 3000;

        public override string ToString()
        {
            return $"{Species}";
        }
    }
}
