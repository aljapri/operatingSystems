using System;
using System.Collections.Generic;
using Scheduler.Models;
using Scheduler.Services;
using Scheduler.Strategies;
using Scheduler.Helpers; // 👈 import InputHelper

namespace Scheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = InputHelper.ReadInt("Enter the number of processes: ", min: 1);
                List<Process> processes = new List<Process>();

                for (int i = 0; i < n; i++)
                {
                    int arrival = InputHelper.ReadInt($"Enter arrival time for process {i + 1}: ", min: 0);
                    int burst = InputHelper.ReadInt($"Enter burst time for process {i + 1}: ", min: 1);

                    processes.Add(new Process(i + 1, arrival, burst));
                }

                int quantum = InputHelper.ReadInt("Enter Quantum: ", min: 1);

                var scheduler = new SchedulerService(new RoundRobinScheduler());
                scheduler.Run(processes, quantum);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
