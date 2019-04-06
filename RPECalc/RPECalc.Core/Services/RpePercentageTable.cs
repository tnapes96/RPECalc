using System;
using System.Collections.Generic;
using System.Text;

namespace RPECalc.Core.Services
{
    public class RpePercentageTable
    {
        //rows = rpe
        //cols = reps
        readonly double[,] percentageTable = new double[,] { {  1.00, .9550, .9220, .8920, .8630, .8370, .8110, .7860, .7620, .7390, .7070, .6800},
                                                             { .9780, .9390, .9070, .8780, .8500, .8240, .7990, .7740, .7510, .7230, .6940, .6670},
                                                             { .9550, .9220, .8920, .8630, .8370, .8110, .7860, .7620, .7390, .7070, .6800, .6530},
                                                             { .9390, .9070, .8780, .8500, .8240, .7990, .7740, .7510, .7230, .6940, .6670, .6400},
                                                             { .9220, .8920, .8630, .8370, .8110, .7860, .7620, .7390, .7070, .6800, .6530, .6260},
                                                             { .9070, .8780, .8500, .8240, .7990, .7740, .7510, .7230, .6940, .6670, .6400, .6130},
                                                             { .8920, .8630, .8370, .8110, .7860, .7620, .7390, .7070, .6800, .6530, .6260, .5990},
                                                             { .8780, .8500, .8240, .7990, .7740, .7510, .7230, .6940, .6670, .6400, .6130, .5860} };

        private readonly Dictionary<double, int> rpeToIndex = new Dictionary<double, int>()
        {
            { 10,  0 },
            { 9.5, 1 },
            { 9,   2 },
            { 8.5, 3 },
            { 8,   4 },
            { 7.5, 5 },
            { 7,   6 },
            { 6.5, 7 }
        };

        private readonly Dictionary<int, int> repsToIndex = new Dictionary<int, int>()
        {
            {1,  0 },
            {2,  1 },
            {3,  2 },
            {4,  3 },
            {5,  4 },
            {6,  5 },
            {7,  6 },
            {8,  7 },
            {9,  8 },
            {10, 9 },
            {11, 10 },
            {12, 11 },
        };

        public double GetPercentage(int reps, double rpe)
        {
            rpeToIndex.TryGetValue(rpe, out int rpeIndex);
            repsToIndex.TryGetValue(reps, out int repsIndex);
            return percentageTable[rpeIndex, repsIndex];
        }

        public int GetRPEToIndex(double rpe)
        {
            rpeToIndex.TryGetValue(rpe, out int rpeIndex);
            return rpeIndex;
        }

        public int GetRepToIndex(int reps)
        {
            repsToIndex.TryGetValue(reps, out int repsIndex);
            return repsIndex;
        }

    }
}
