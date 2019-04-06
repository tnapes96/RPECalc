using RPECalc.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPECalc.Core.Services
{
    public interface IRPECalculationService
    {
        double OneRepMax(double weight, int reps, double rpe);

        List<LoadInfo> CalculateLoadForRep(double orm, int repLoad);
    }
}
