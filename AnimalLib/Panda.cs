namespace AnimalLib
{
    [Serializable]
    public class Panda : Herbivore
    {
        public override string Species => "Panda";
        public override double GreenFoodPerDay => 10;
        public override double MeatFoodPerDay => 0;
        public override double Price => 1;

        public override string ToString()
        {
            return $"{Species}";
        }
    }
}
