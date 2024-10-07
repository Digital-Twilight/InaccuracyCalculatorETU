using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InaccuracyCalculator
{
    public class Calculation
    {
        public List<decimal> SelectionValues;
        public decimal PeakToPeak;
        public decimal SuitableUFactor;
        public int OutliersCount = 0;
        public List<decimal> SelectionAfterCheck;
        public decimal SelectionAverage;
        public decimal RootMeanSquare;
        public decimal SuitableStudentFactor;
        public decimal ImprecisionStudent;
        public decimal SuitableBFactor;
        public decimal ImprecisionB;
        public decimal ImprecisionFull;
        public decimal ImprecisionRelative;
        public decimal RoundedImprecision;
        public decimal RoundedAverage;
        public string PhysicalSymbol;
        public string PhysicalUnit;
        public decimal Accuracy;

        public Calculation(List<decimal> InputValues, string InputSymbol, string InputUnit, decimal InputAccuracy)
        {
            SelectionValues = InputValues;
            PhysicalSymbol = InputSymbol;
            PhysicalUnit = InputUnit;
            Accuracy = InputAccuracy;
        }

        public void Calculate()
        {
            if (SelectionValues.Count() <= 0)
                throw new ArgumentException(paramName: nameof(SelectionValues), message: "Выборка не может быть пустой");
            SelectionValues.Sort();
            PeakToPeak = SelectionValues.Max() - SelectionValues.Min();
            if (!ReferenceValues.UFactor95.GetBySize(SelectionValues.Count, out SuitableUFactor))
                throw new ArgumentException(paramName: nameof(SuitableUFactor), message: "Не удалось найти подходящий коэффициент U");
            SelectionAfterCheck = new List<decimal>();
            for (int i = 0; i < SelectionValues.Count - 1; i++)
            {
                decimal CurrentPair = Math.Abs(SelectionValues[i + 1] - SelectionValues[i]);
                bool OutlierPresent = CurrentPair > SuitableUFactor * PeakToPeak;
                if (OutlierPresent)
                {
                    OutliersCount++;
                    if (i == 0 || i == SelectionValues.Count - 2)
                        SelectionValues.RemoveAt(i + 1);
                }
                SelectionAfterCheck.Add(SuitableUFactor * PeakToPeak);
            }
            SelectionAverage = SelectionValues.Average();
            decimal TempSum = 0;
            for (int i = 0; i < SelectionValues.Count; i++)
                TempSum += DecimalOperations.Pow(SelectionValues[i] - SelectionAverage, 2);
            RootMeanSquare = decimal.Round((decimal)Math.Sqrt((double)(TempSum / (SelectionValues.Count * (SelectionValues.Count - 1)))), 6);
            if (!ReferenceValues.StudentFactor95.GetBySize(SelectionValues.Count, out SuitableStudentFactor))
                throw new ArgumentException(paramName: nameof(SuitableStudentFactor), message: "Не удалось найти подходящий коэффициент Стьюдента");
            ImprecisionStudent = decimal.Round(RootMeanSquare * SuitableStudentFactor, 6);
            if (!ReferenceValues.BFactor95.GetBySize(SelectionValues.Count, out SuitableBFactor))
                throw new ArgumentException(paramName: nameof(SuitableBFactor), message: $"Не удалось найти подходящий коэффициент {ReferenceValues.UTFSymbols["beta"]}");
            ImprecisionB = decimal.Round(PeakToPeak * SuitableBFactor, 6);
            ImprecisionFull = decimal.Round((decimal)Math.Sqrt((double)(DecimalOperations.Pow(ImprecisionStudent, 2) + DecimalOperations.Pow(Accuracy, 2))), 6);
            ImprecisionRelative = Math.Abs(decimal.Round(ImprecisionFull / SelectionAverage * 100, 2));
            RoundedImprecision = DecimalOperations.SizovaRound(ImprecisionFull, out int ImprecisionPrecision);
            RoundedAverage = DecimalOperations.SizovaRound(SelectionAverage, out int AveragePrecision, y_precision: ImprecisionPrecision);
            if (AveragePrecision > ImprecisionPrecision)
                RoundedImprecision = DecimalOperations.SizovaRound(ImprecisionFull, out int _, y_precision: AveragePrecision);
        }
    }
}
