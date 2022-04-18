using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service
{
    public class CalculatorManager
    {
        // Add method adds all numbers and saves the result in the CalculatorData class
        public static void Add(CalculatorData calculate)
        {
            calculate.Operator = CalculatorOperator.Add;
            calculate.calculatorResult = 0;
            calculate.calculatorException = null;
            foreach (decimal item in calculate.inputNumbers)
            {
                try
                {
                    calculate.calculatorResult += item;
                }
                catch (Exception ex)
                {
                    calculate.calculatorException = ex.Message;
                }
                 
            }
        }
        public static void Subtract(CalculatorData calculate)
        {
            calculate.Operator = CalculatorOperator.Subtract;
            calculate.calculatorResult = 0;
            calculate.calculatorException = null;
            var ctr = 0;
            foreach (decimal item in calculate.inputNumbers)
            {
                try
                {
                    if (ctr == 0)
                        calculate.calculatorResult = item;
                    else
                        calculate.calculatorResult -= item;
                    ctr++;
                }
                catch (Exception ex)
                {
                    calculate.calculatorException = ex.Message;
                }
            }
        }

        public static void Multiply(CalculatorData calculate)
        {
            calculate.Operator = CalculatorOperator.Multiply;
            calculate.calculatorResult = 0;
            calculate.calculatorException = null;
            var ctr = 0;
            foreach (decimal item in calculate.inputNumbers)
            {
                try
                {
                    if (ctr == 0)
                        calculate.calculatorResult = item * 1;
                    else
                        calculate.calculatorResult *= item;
                    ctr++;
                }
                catch (Exception ex)
                {
                    calculate.calculatorException = ex.Message;
                }
            }
        }
        public static void Divide(CalculatorData calculate)
        {
            calculate.Operator = CalculatorOperator.Divide;
            calculate.calculatorResult = 0;
            calculate.calculatorException = null;
            var ctr = 0;
            foreach (decimal item in calculate.inputNumbers)
            {
                try
                {
                    if (ctr == 0)
                        calculate.calculatorResult = item / 1;
                    else
                        calculate.calculatorResult /= item;
                    ctr++;
                }
                catch (Exception ex)
                {
                    calculate.calculatorException = ex.Message;
                }

            }
        }

        public List<CalculatorData> ProcessData(CalculatorInput calcInput)
        {

            List<CalculatorData> calculatorDatas = new List<CalculatorData>();
            foreach (Inputdata row in calcInput.InputDataArray)
            {
                CalculatorData calculatorData = new CalculatorData();
                calculatorData.inputNumbers = row.Numbers;
                switch (row.Operation)
                {
                    case "+":
                        Add(calculatorData);
                        break;
                    case "-":
                        Subtract(calculatorData);
                        break;
                    case "/":
                        Divide(calculatorData);
                        break;
                    case "*":   
                        Multiply(calculatorData);
                        break;
                    default:
                        calculatorData.calculatorException = $"Invalid Operator: {row.Operation}";
                        break;
                }
                // add calculatorData to the list 
                calculatorDatas.Add(calculatorData);
            }
            return calculatorDatas;
        }
    }
}
