using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Models;
using Scheduler.Interfaces;

namespace Scheduler.Services
{
    public class SchedulerService
    {
        private readonly ISchedulingStrategy _strategy;

        public SchedulerService(ISchedulingStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Run(List<Process> processes, int quantum)
        {
            _strategy.CalculateWaitingTimes(processes, quantum);
            PrintResults(processes);
        }

        private void PrintResults(List<Process> processes)
        {
            int totalWaitingTime = 0;
            Console.WriteLine("\nنتائج العمليات:");
            foreach (var p in processes)
            {
                Console.WriteLine($"العملية {p.Id}: زمن الانتظار = {p.WaitingTime}");
                totalWaitingTime += p.WaitingTime;
            }

            Console.WriteLine($"\nTWT (المجموع الكلي لزمن الانتظار): {totalWaitingTime}");
            Console.WriteLine($"متوسط زمن الانتظار = {(double)totalWaitingTime / processes.Count:F2}");
        }
    }
}