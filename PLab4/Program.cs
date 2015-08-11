using System;
using System.Collections.Generic;
using PLab4.Composite;
using PLab4.Units;

namespace PLab4
{
    static class Program
    {
        static void Main(string[] args)
        {
            var firstClass = new FirstClass(10);
            var busClass = new BusinessClass(20);
            var economClass = new EconomClass(150);

            firstClass.Fill();
            busClass.Fill();
            economClass.Fill();

            var pilots = new List<Pilot> { new Pilot(), new Pilot() };
            var stuards = new List<Stuard>
            {
                new Stuard(),
                new Stuard(),
                new Stuard(),
                new Stuard(),
                new Stuard(),
                new Stuard()
            };

            var plane = new Plane.Plane(pilots, stuards);
            plane.AddUnit(firstClass);
            plane.AddUnit(busClass);
            plane.AddUnit(economClass);

            plane.GetBaggageStatus();

            Console.ReadLine();
        }


    }

}
