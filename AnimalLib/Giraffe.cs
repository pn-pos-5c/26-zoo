namespace AnimalLib
{
    [Serializable]
    public class Giraffe : Herbivore
    {
        public override string Species => "Giraffe";
        public override double GreenFoodPerDay => 3;
        public override double MeatFoodPerDay => 0;
        public override double Price => 30;

        public override string ToString()
        {
            return $"{Species}";
        }
    }
}
