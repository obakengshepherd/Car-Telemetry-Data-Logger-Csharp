using System;
using System.IO;

namespace CarTelemetryLogger
{
    class Program
    {
        // Main entry point for the telemetry logger
        static void Main(string[] args)
        {
            // Arrays to store sensor data (max 100 entries)
            double[] speeds = new double[100];
            double[] rpms = new double[100];
            double[] temps = new double[100];
            int count = 0;
            Random rand = new Random();

            // Prompt for input mode
            Console.WriteLine("--- Car Telemetry Logger ---");
            Console.Write("Choose input mode (m for manual, S for simulate): ");
            string mode = Console.ReadLine().ToLower();

            if (mode == "s")
            {
                // Simulate 5 sensor data entries
                while (count < 5 && count < speeds.Length)
                {
                    speeds[count] = rand.NextDouble() * 200 + 50; // 50-250 km/h
                    rpms[count] = rand.Next(1000, 8000); // 1000-8000 RPM
                    temps[count] = rand.NextDouble() * 50 + 50; // 50-100°C
                    count++;
                }
                Console.WriteLine("Simulated 5 telemetry entries.");
            }
            else
            {
                // Manual input loop for sensor data
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
                            Console.WriteLine("Error: Maximum data entries reached!");
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
                        Console.WriteLine("Error: Inputs must be non-negative numbers (temp >= -50).");
                    }
                }
            }

            DisplayData(speeds, rpms, temps, count);
            SaveToFile(speeds, rpms, temps, count);

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        // Displays recorded sensor data to console
        static void DisplayData(double[] speeds, double[] rpms, double[] temps, int count)
        {
            Console.WriteLine("\n--- Recorded Telemetry Data ---");
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

        // Saves sensor data to telemetry.txt in CSV format
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