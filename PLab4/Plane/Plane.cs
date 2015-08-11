using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using PLab4.Composite;
using PLab4.Units;

namespace PLab4.Plane
{
    public class Plane : CompositeUnit
    {
        private FirstClass _firstClass;
        private BusinessClass _businessClass;
        private EconomClass _economClass;
        
        private readonly List<Pilot> _pilots;
        private readonly List<Stuard> _stuards;

        private const int MaxWeight = 1000;
        private const int PilotsRequired = 2;
        private const int StuardsRequired = 6;

        public Plane(List<Pilot> pilots, List<Stuard> stuards) : base(10 + 20 + 150)
        {
            _pilots = pilots;
            _stuards = stuards;
        }

        public void GetBaggageStatus()
        {
            foreach (var unit in GetUnits())
            {
                if (unit is FirstClass)
                    _firstClass = unit as FirstClass;
                if (unit is BusinessClass)
                    _businessClass = unit as BusinessClass;
                if (unit is EconomClass)
                    _economClass = unit as EconomClass;
            }

            if (_pilots == null || _pilots.Count != PilotsRequired || _stuards == null ||
                _stuards.Count != StuardsRequired)
            {
                Console.WriteLine("Недостаточно персонала");
                return;
            }

            if (_firstClass.GetUnits().Count == 0 || _businessClass.GetUnits().Count == 0 ||
                _economClass.GetUnits().Count == 0)
            {
                Console.WriteLine("Самолет без пассажиров");
                return;
            }
            
            Console.WriteLine("Карта загрузки самолета.");

            int economBaggage     = _economClass.GetUnits().Sum(passenger => passenger.GetBaggage());
            int businessBaggage   = _businessClass.GetUnits().Sum(businessman => businessman.GetBaggage());
            int firstClassBaggage = _firstClass.GetUnits().Sum(firstClassMan => firstClassMan.GetBaggage());

            int summary = economBaggage + businessBaggage + firstClassBaggage;

            Console.WriteLine("Багаж первого класса : {0}", firstClassBaggage);
            Console.WriteLine("Багаж бизнес класса : {0}", businessBaggage);
            Console.WriteLine("Багаж эконом класса : {0}", economBaggage);
            Console.WriteLine("Суммарный вес багажа : {0}", summary);

            if(summary > MaxWeight) Console.WriteLine("Самолет перегружен");
            if (summary - economBaggage > MaxWeight)
            {
                Console.WriteLine("Самолет перегружен без учета багажа эконом класса");
            }
            else
            {
                int passIndex = 0;

                while (summary > MaxWeight)
                {                    
                    summary -= _economClass.GetUnits()[passIndex].GetBaggage();
                    passIndex++;
                }

                Console.WriteLine("У {0} пассажиров эконом класса снят багаж. Текущий вес багажа {1}. Самолет готов к отправке", passIndex, summary);
            }
        }
    }
}
