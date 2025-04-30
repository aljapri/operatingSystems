using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scheduler.Models;

namespace Scheduler.Interfaces
{
    public interface ISchedulingStrategy
    {
        void CalculateWaitingTimes(List<Process> processes, int quantum);
    }
}