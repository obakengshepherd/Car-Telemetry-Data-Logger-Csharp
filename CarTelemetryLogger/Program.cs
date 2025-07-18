using System;

namespace CarTelemetryLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Speed (km/h): ");
            string speedInput = Console.ReadLine();
            Console.Write("Enter RPM: ");
            string rpmInput = Console.ReadLine();
            Console.Write("Enter Temperature (°C): ");
            string tempInput = Console.ReadLine();

            Console.WriteLine($"You entered: Speed={speedInput}, RPM={rpmInput}, Temp={tempInput}");
        }
    }
}