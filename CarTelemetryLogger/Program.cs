using System;

namespace CarTelemetryLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] speeds = new double[100];
            double[] rpms = new double[100];
            double[] temps = new double[100];
            int count = 0;

            while (true)
            {
                Console.Write("Enter Speed (km/h, or 'exit'): ");
                string speedInput = Console.ReadLine();
                if (speedInput.ToLower() == "exit") break;

                if (double.TryParse(speedInput, out double speed) && speed >= 0)
                {
                    if (count >= speeds.Length)
                    {
                        Console.WriteLine("Max data reached!");
                        break;
                    }
                    speeds[count] = speed;
                    count++;
                    Console.WriteLine("Speed recorded.");
                }
                else
                {
                    Console.WriteLine("Invalid speed! Must be a non-negative number.");
                }
            }

            // Temporary output to verify
            Console.WriteLine("\nRecorded Speeds:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Speed {i + 1}: {speeds[i]}");
            }
        }
    }
}