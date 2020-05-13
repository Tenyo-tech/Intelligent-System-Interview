using System;

namespace Задание_2
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CarFactory carFactory = new CarFactory();
            carFactory.Run();
        }
    }
}
