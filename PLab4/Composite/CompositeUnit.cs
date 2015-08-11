using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using PLab4.Units;

namespace PLab4.Composite
{
    public abstract class CompositeUnit : Unit
    {
        private int _maxPassengers;

        public int MaxPassengersCount
        {
            get { return _maxPassengers; }
            private set { _maxPassengers = value; }
        }

        private List<Unit> _units;

        protected CompositeUnit(int maxPassengers)
        {
            MaxPassengersCount = maxPassengers;
            _units = new List<Unit>();
        }

        protected CompositeUnit()
        {
          
        }

        public override CompositeUnit GetComposite()
        {
            return this;
        }

        public override void AddUnit(Unit unit)
        {
            if (_units.Count < _maxPassengers) 
                _units.Add(unit);
            else 
                throw new Exception("Слишком много пассажиров класса");

        }

        public override List<Unit> GetUnits()
        {
            base.GetUnits();
            return _units;
        }

        public override int GetSummaryBaggage()
        {
            return _units.Sum(unit => unit.GetBaggage());
        }

        public void Fill()
        {
            for (var i = 0; i < MaxPassengersCount; i++)
            {
                var passenger = new Passenger(new Random().Next(5, 60));
                AddUnit(passenger);
            }
        }
    }
}
