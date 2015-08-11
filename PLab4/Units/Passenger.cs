namespace PLab4.Units
{
    public class Passenger : Unit
    {
        public override int GetSummaryBaggage()
        {
            return 60;
        }

        private readonly int _baggage;

        public Passenger(int baggage)
        {
            _baggage = baggage;
        }

        public override int GetBaggage()
        {
            return _baggage;
        }
    }
}
