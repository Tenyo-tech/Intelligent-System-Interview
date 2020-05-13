using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задание_2
{
    public class CarFactory
    {
        private List<Car> cars;
        public CarFactory()
        {
            this.cars = new List<Car>();
        }

        public void Run()
        {
            int amountOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfCars; i++)
            {
                string[] carParameters = Console.ReadLine()
                    .Split("> <", StringSplitOptions.RemoveEmptyEntries);
                Car car = CreateCar(carParameters);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(fragile);
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                PrintInfo(flamable);
            }

        }

        private void PrintInfo(List<string> cars)
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        public Car CreateCar(string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                char[] myChars = { '<', '>' };
                parameter.Trim(myChars);
            }
            
            string model = parameters[0].TrimStart('<');

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            Engine engine = new Engine(engineSpeed,enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Cargo cargo = new Cargo(cargoWeight,cargoType);

            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            Tire firstTire = new Tire(firstTireAge, firstTirePressure);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            Tire secondTire = new Tire(secondTireAge, secondTirePressure);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            Tire thirdTire = new Tire(thirdTireAge, thirdTirePressure);

            double fourthTirePressure = double.Parse(parameters[11]);
            int fourthTireAge = int.Parse(parameters[12].TrimEnd('>'));
            Tire fourthTire = new Tire(fourthTireAge, fourthTirePressure);

            Tire[] tires = { firstTire, secondTire, thirdTire, fourthTire };

            Car car = new Car(model,engine,cargo,tires);

            return car;
        }
    }
}
