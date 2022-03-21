namespace AnimalLib
{
    [Serializable]
    public class Penguin : Carnivore
    {
        public override string Species => "Penguin";
        public override double GreenFoodPerDay => 0;
        public override double MeatFoodPerDay => 0.5;
        public override double Price => 999999.99;

        public override string ToString()
        {
            return $"{Species}";
        }
    }
}
