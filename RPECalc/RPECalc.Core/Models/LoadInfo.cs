using MvvmCross;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPECalc.Core.Models
{
    public class LoadInfo
    {
        public int Reps { get; set; }
        public double Rpe { get; set; }
        public double Weight { get; set; }
        public double OneRMPercent { get; set; }
    }
}
