using RPECalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPECalc.Core.Services
{
    public class RPECalculationService : IRPECalculationService
    {
        RpePercentageTable table;

        public RPECalculationService()
        {
            table = new RpePercentageTable();
        }

        public double OneRepMax(double weight, int reps, double rpe)
        {
            return Math.Round(weight / table.GetPercentage(reps, rpe), 2);
        }

        public List<LoadInfo> CalculateLoadForRep(double orm, int repLoad)
        {
            List<LoadInfo> loads = new List<LoadInfo>();

            for(double rpe = 10; rpe >= 6.5; rpe -= .5)
            {
                double percentOfORM = table.GetPercentage(repLoad, rpe);
                loads.Add(
                    new LoadInfo
                    {
                        OneRMPercent = percentOfORM * 100,
                        Rpe = rpe,
                        Weight = Math.Round(orm * percentOfORM,2)
                    });
            }
            return loads;

        }

        public double[,] CalculateRPEChart(double lastWeight, int lastReps, double lastRpe)
        {
            double[,] rpeChart = new double[9, 12];
            double oneRM = OneRepMax(lastWeight, lastReps, lastRpe);

            for (double rpe = 10; rpe >= 6.5; rpe -= .5)
            {
                for (int reps = 1; reps <= 12; reps++)
                {
                    rpeChart[table.GetRPEToIndex(rpe), table.GetRepToIndex(reps)] = oneRM * table.GetPercentage(reps, rpe);
                }
            }
            return rpeChart;
        }
    }
}
