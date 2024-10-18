using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InaccuracyCalculator
{
    public partial class MainForm : Form
    {
        private Calculation lastCalculation;

        public MainForm()
        {
            InitializeComponent();
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void SampleSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SelectionSizeTextBox.Text = SelectionSizeTrackBar.Value.ToString();
        }

        private void SelectionSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            int SelectionSize = int.Parse(SelectionSizeTextBox.Text);
            SelectionGroupBox.Size = new Size(55 * SelectionSize + 6 * (SelectionSize + 1), 45);
            CalculateButton.Location = new Point(SelectionGroupBox.Size.Width + 18, 95);
            if (SelectionGroupBox.Controls.Count < SelectionSize)
                for (int i = SelectionGroupBox.Controls.Count; i < SelectionSize; i++)
                {
                    TextBox textBox = new TextBox() { Name = "Value_" + i.ToString(), Size = new Size(55, 20), Location = new Point(6 * (i + 1) + 55 * i, 19) };
                    textBox.KeyPress += new KeyPressEventHandler(NumericalTextBox_KeyPress);
                    SelectionGroupBox.Controls.Add(textBox);
                }
            else
                for (int i = SelectionGroupBox.Controls.Count; i > SelectionSize; i--)
                    SelectionGroupBox.Controls.RemoveAt(i - 1);
        }

        private void NumericalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '-')
                e.Handled = true;
            if ((e.KeyChar == ',' && (sender as TextBox).Text.Contains(',')) || (e.KeyChar == '-' && (sender as TextBox).Text.Contains('-')))
                e.Handled = true;
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                if (textBox.Text == string.Empty)
                {
                    MessageBox.Show(this, "Необходимо заполнить все ячейки!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            CalculatedDataGridView.Rows.Clear();
            List<decimal> SelectionValues = new List<decimal>();
            try
            {
                foreach (TextBox textBox in SelectionGroupBox.Controls.OfType<TextBox>())
                    SelectionValues.Add(decimal.Parse(textBox.Text));
            }
            catch (OverflowException exc) 
            {
                MessageBox.Show(this, $"Ошибка ввода значений выборки:\n{exc.Message}\n\nПроверьте введённые данные", "Упс! Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lastCalculation = new Calculation(SelectionValues, PhysicalSymbolTextBox.Text, PhysicalUnitTextBox.Text, decimal.Parse(AccuracyTextBox.Text));
            try
            {
                lastCalculation.Calculate();
            }
            catch (ArgumentException exc)
            {
                MessageBox.Show(this, $"Во время вычисления произошла следующая ошибка:\n{exc.Message}", "Упс! Ошибка...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CalculatedDataGridView.Rows.Add("Размах выборки", DecimalOperations.StringFormat(lastCalculation.PeakToPeak));
            CalculatedDataGridView.Rows.Add("Оценка грубой погрешности", "Статистический коэффициент " + lastCalculation.SuitableUFactor);
            for (int i = 0; i < lastCalculation.CheckPair.Count; i++)
                CalculatedDataGridView.Rows.Add(lastCalculation.PhysicalSymbol + ReferenceValues.UTFSymbols["ind_" + (i + 1).ToString()], lastCalculation.CheckPair[i]);
            if (lastCalculation.OutliersCount != 0)
                CalculatedDataGridView.Rows.Add("Вывод", $"В данной выборке присутствует {lastCalculation.OutliersCount} {(lastCalculation.OutliersCount > 1 ? "грубых погрешностей" : "грубая погрешность")}");
            else
                CalculatedDataGridView.Rows.Add("Вывод", $"В данной выборке грубые погрешности отсутствуют");
            if (!lastCalculation.ValidSelection)
            {
                MessageBox.Show(this, $"Выборка не является связной", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CalculatedDataGridView.Rows.Add(lastCalculation.PhysicalSymbol + ReferenceValues.UTFSymbols["comb_over"], DecimalOperations.StringFormat(lastCalculation.SelectionAverage));
            CalculatedDataGridView.Rows.Add("СКО сред.", DecimalOperations.StringFormat(lastCalculation.RootMeanSquare));
            CalculatedDataGridView.Rows.Add("Оценка случайной погрешности по Стьюденту", DecimalOperations.StringFormat(lastCalculation.ImprecisionStudent));
            CalculatedDataGridView.Rows.Add("Оценка случайной погрешности по размаху выборки", DecimalOperations.StringFormat(lastCalculation.ImprecisionB));
            CalculatedDataGridView.Rows.Add("Полная погрешность результатов измерений", DecimalOperations.StringFormat(lastCalculation.ImprecisionFull));
            CalculatedDataGridView.Rows.Add("Относительная погрешность результатов измерений", DecimalOperations.StringFormat(lastCalculation.ImprecisionRelative) + '%');
            CalculatedDataGridView.Rows.Add("Окончательный результат", $"{lastCalculation.RoundedAverage} +- {lastCalculation.RoundedImprecision}");
        }

        private void DOCX_MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Эта функция всё ещё находится в разработке!", "WIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PDF_MenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Эта функция всё ещё находится в разработке!", "WIP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
