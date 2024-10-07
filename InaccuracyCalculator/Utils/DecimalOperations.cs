using System;

namespace InaccuracyCalculator
{
    public static class DecimalOperations
    {
        public static decimal Pow(decimal x, int y)
        {
            decimal result = 1;
            for (int i = 0; i < y; i++)
                result *= x;
            return result;
        }

        public static decimal SizovaRound(decimal x, out int o_precision, int y_precision = -1)
        {
            o_precision = -1;
            if (x == 0)
                return x;

            int precision = 0;
            decimal val = x - decimal.Truncate(x);
            while (Math.Abs(decimal.Truncate(val)) <= 1)
            {
                val -= decimal.Truncate(val);
                if (val == 0.0m)
                {
                    x = decimal.Round(x, precision);
                    break;
                }
                val *= 10;
                precision++;
            }
            o_precision = precision;
            if (y_precision == -1)
                return decimal.Round(x, precision);

            if (precision < y_precision)
            {
                if (Math.Abs(decimal.Truncate(x * (decimal)Math.Pow(10, y_precision))) % 10 != 0)
                    return decimal.Round(x, y_precision);
            }
            else
            {
                o_precision = y_precision;
                x = decimal.Round(x, y_precision);
            }
            for (int i = 0; i < y_precision - precision; i++)
            {
                o_precision += 1;
                x *= 1.0m;
            }
            return x;
        }

        public static string StringFormat(decimal x)
        {
            if (x.ToString().EndsWith("1"))
                return x.ToString() + "0";
            else if (x.ToString().EndsWith("0") && !x.ToString().EndsWith("10"))
                return x.ToString().TrimEnd('0');
            return x.ToString();
        }
    }
}
