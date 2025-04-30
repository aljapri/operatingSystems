using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Models;
using Scheduler.Interfaces;

namespace Scheduler.Strategies
{
    public class RoundRobinScheduler: ISchedulingStrategy
    {
        public void CalculateWaitingTimes(List<Process> processes, int quantum)
        {
            int currentTime = 0;
            Queue<Process> queue = new Queue<Process>();
            var arrived = new HashSet<Process>();

            while (true)
            {
                foreach (var p in processes)
                {
                    if (p.ArrivalTime <= currentTime && !arrived.Contains(p) && p.RemainingTime > 0)
                    {
                        queue.Enqueue(p);
                        arrived.Add(p);
                    }
                }

                if (queue.Count == 0)
                {
                    if (arrived.Count == processes.Count)
                        break;

                    currentTime++;
                    continue;
                }

                var current = queue.Dequeue();
                int executionTime = (current.RemainingTime < quantum) ? current.RemainingTime : quantum;
                currentTime += executionTime;
                current.RemainingTime -= executionTime;

                foreach (var p in queue)
                {
                    if (p.ArrivalTime <= currentTime && p.RemainingTime > 0)
                        p.WaitingTime += executionTime;
                }

                if (current.RemainingTime > 0)
                {
                    queue.Enqueue(current);
                }
            }
        }
    }
}