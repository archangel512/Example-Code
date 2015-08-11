using System.Collections.Generic;
using PLab4.Composite;

namespace PLab4.Units
{
    public abstract class Unit
    {
        public virtual CompositeUnit GetComposite()
        {
            return null;
        }

        public virtual List<Unit> GetUnits()
        {
            return null;
        }

        public virtual void AddUnit(Unit unit)
        {

        }

        public virtual int GetSummaryBaggage()
        {
            return 0;
        }

        public virtual int GetBaggage()
        {
            return 0;
        }
    }
}
