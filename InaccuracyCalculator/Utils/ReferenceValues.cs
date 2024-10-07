using System;
using System.Collections.Generic;
using System.Linq;

namespace InaccuracyCalculator
{
    public static class DictionaryExtension
    {
        public static bool GetBySize(this Dictionary<int, decimal> SelectedDictionary, int SelectionSize, out decimal ResultFactor)
        {
            return SelectedDictionary.TryGetValue(SelectedDictionary.Keys.Aggregate((x, y) => Math.Abs(x - SelectionSize) < Math.Abs(y - SelectionSize) ? x : y), out ResultFactor);
        }
    }
    public static class ReferenceValues
    {
        public static readonly Dictionary<int, decimal> UFactor95 = new Dictionary<int, decimal>()
        {
            [3] = 0.94m,
            [4] = 0.76m,
            [5] = 0.64m,
            [7] = 0.51m,
            [10] = 0.41m,
            [15] = 0.34m,
            [20] = 0.30m,
            [30] = 0.26m,
            [100] = 0.20m
        };
        public static readonly Dictionary<int, decimal> StudentFactor95 = new Dictionary<int, decimal>()
        {
            [2] = 12.7m,
            [3] = 4.3m,
            [4] = 3.2m,
            [5] = 2.8m,
            [6] = 2.6m,
            [7] = 2.5m,
            [8] = 2.4m,
            [9] = 2.3m,
            [10] = 2.3m,
            [100] = 2.0m
        };
        public static readonly Dictionary<int, decimal> BFactor95 = new Dictionary<int, decimal>()
        {
            [3] = 1.30m,
            [4] = 0.72m,
            [5] = 0.51m,
            [6] = 0.40m,
            [7] = 0.33m,
            [8] = 0.29m,
            [9] = 0.25m,
            [10] = 0.23m,
            [11] = 0.21m,
            [12] = 0.19m
        };
        public static readonly Dictionary<string, char> UTFSymbols = new Dictionary<string, char>()
        {
            ["ind_0"] = '\u2080',
            ["ind_1"] = '\u2081',
            ["ind_2"] = '\u2082',
            ["ind_3"] = '\u2083',
            ["ind_4"] = '\u2084',
            ["ind_5"] = '\u2085',
            ["ind_6"] = '\u2086',
            ["ind_7"] = '\u2087',
            ["ind_8"] = '\u2088',
            ["ind_9"] = '\u2089',
            ["comb_over"] = '\u0305',
            ["beta"] = '\u03B2'
        };
    }
}
