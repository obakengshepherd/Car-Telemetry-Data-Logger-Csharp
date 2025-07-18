using System;

namespace CarTelemetryLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Speed (km/h): ");
            string speedInput = Console.ReadLine();
            if (double.TryParse(speedInput, out double speed) && speed >= 0)
            {
                Console.WriteLine($"Valid speed: {speed}");
            }
            else
            {
                Console.WriteLine("Invalid speed! Must be a non-negative number.");
            }

            Console.Write("Enter RPM: ");
            string rpmInput = Console.ReadLine();
            if (double.TryParse(rpmInput, out double rpm) && rpm >= 0)
            {
                Console.WriteLine($"Valid RPM: {rpm}");
            }
            else
            {
                Console.WriteLine("Invalid RPM! Must be a non-negative number.");
            }

            Console.Write("Enter Temperature (°C): ");
            string tempInput = Console.ReadLine();
            if (double.TryParse(tempInput, out double temp) && temp >= -50)
            {
                Console.WriteLine($"Valid temperature: {temp}");
            }
            else
            {
                Console.WriteLine("Invalid temperature! Must be >= -50.");
            }
        }
    }
}