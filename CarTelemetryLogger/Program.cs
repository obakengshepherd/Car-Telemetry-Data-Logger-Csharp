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
                Console.WriteLine("\n--- Enter Sensor Data ---");
                Console.Write("Speed (km/h, or 'exit'): ");
                string speedInput = Console.ReadLine();
                if (speedInput.ToLower() == "exit") break;

                Console.Write("RPM: ");
                string rpmInput = Console.ReadLine();
                Console.Write("Temperature (°C): ");
                string tempInput = Console.ReadLine();

                if (double.TryParse(speedInput, out double speed) &&
                    double.TryParse(rpmInput, out double rpm) &&
                    double.TryParse(tempInput, out double temp) &&
                    speed >= 0 && rpm >= 0 && temp >= -50)
                {
                    if (count >= speeds.Length)
                    {
                        Console.WriteLine("Max data reached!");
                        break;
                    }
                    speeds[count] = speed;
                    rpms[count] = rpm;
                    temps[count] = temp;
                    count++;
                    Console.WriteLine("Data recorded successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid input! Must be non-negative numbers (temp >= -50).");
                }
            }

            Console.WriteLine("\nRecorded Data:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Entry {i + 1}: Speed={speeds[i]}, RPM={rpms[i]}, Temp={temps[i]}");
            }
        }
    }
}