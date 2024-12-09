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

        public static decimal RealRound(decimal in_decimal, int precision, bool is_integer_part)
        {
            int integer_part = (int)Math.Truncate(in_decimal);
            int digits_count = integer_part == 0 ? 1 : (integer_part > 0 ? 1 : 2) + (int)Math.Log10(Math.Abs((double)integer_part));
            if (is_integer_part)
                return Math.Round(in_decimal / (decimal)Math.Pow(10, digits_count - precision)) * (decimal)Math.Pow(10, digits_count - precision);
            return Math.Round(in_decimal * (decimal)Math.Pow(10, precision)) / (decimal)Math.Pow(10, precision);
        }

        public static decimal SizovaRound(decimal in_decimal, out bool out_integer_part, out int out_precision)
        {
            out_precision = 0;
            out_integer_part = true;
            if (in_decimal == 0)
                return in_decimal;

            int precision = 0;
            if (Math.Truncate(in_decimal) != 0)
            {
                long integer_part = (long)Math.Truncate(in_decimal);
                int digits_count = integer_part == 0 ? 1 : (integer_part > 0 ? 1 : 2) + (int)Math.Log10(Math.Abs((double)integer_part));
                bool digit_found = false;

                for (int i = digits_count - 1; i >= 0; i--)
                {
                    precision = digits_count - i;
                    if (digit_found)
                        break;
                    if ((int)Math.Truncate(integer_part / Math.Pow(10, i)) % 10 == 0)
                        continue;
                    if ((int)Math.Truncate(integer_part / Math.Pow(10, i)) % 10 == 1)
                    {
                        digit_found = true;
                        continue;
                    }
                    break;
                }
                out_precision = precision;
                return Math.Round(in_decimal / (decimal)Math.Pow(10, digits_count - precision)) * (decimal)Math.Pow(10, digits_count - precision);
            }

            out_integer_part = false;
            decimal val = in_decimal - Math.Truncate(in_decimal);
            while ((int)Math.Truncate(Math.Abs(val)) <= 1)
            {
                if (val == 0.0m)
                {
                    in_decimal = decimal.Round(in_decimal, precision);
                    break;
                }
                val *= 10;
                precision++;
            }
            out_precision = precision;
            return Math.Round(in_decimal, precision);
        }

        public static string StringFormat(decimal x)
        {
            if (x.ToString().EndsWith("1"))
                return x.ToString() + "0";
            else if (x.ToString().EndsWith("0") && !x.ToString().EndsWith("10") && x != 0.0m)
                return x.ToString().TrimEnd('0');
            return x.ToString();
        }

        public static int DigitsCount(this int n) => n == 0 ? 1 : (n > 0 ? 1 : 2) + (int)Math.Log10(Math.Abs((double)n));
    }
}
