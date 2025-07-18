using System;
using System.IO;

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
            Random rand = new Random();

            Console.Write("Manual input or simulate? (m/S): ");
            string mode = Console.ReadLine().ToLower();

            if (mode == "s")
            {
                while (count < 5 && count < speeds.Length)
                {
                    speeds[count] = rand.NextDouble() * 200 + 50; // 50-250 km/h
                    rpms[count] = rand.Next(1000, 8000); // 1000-8000 RPM
                    temps[count] = rand.NextDouble() * 50 + 50; // 50-100°C
                    count++;
                }
                Console.WriteLine("Simulated 5 entries.");
            }
            else
            {
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
            }

            DisplayData(speeds, rpms, temps, count);
            SaveToFile(speeds, rpms, temps, count);

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        static void DisplayData(double[] speeds, double[] rpms, double[] temps, int count)
        {
            Console.WriteLine("\nRecorded Data:");
            if (count == 0)
            {
                Console.WriteLine("No data recorded.");
                return;
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Entry {i + 1}: Speed={speeds[i]} km/h, RPM={rpms[i]}, Temp={temps[i]}°C");
            }
        }

        static void SaveToFile(double[] speeds, double[] rpms, double[] temps, int count)
        {
            string filePath = "telemetry.txt";
            string data = "Speed,RPM,Temperature\n";
            for (int i = 0; i < count; i++)
            {
                data += $"{speeds[i]},{rpms[i]},{temps[i]}\n";
            }
            File.WriteAllText(filePath, data);
            Console.WriteLine($"\nData saved to {filePath}");
        }
    }
}