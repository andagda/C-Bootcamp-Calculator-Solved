using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service
{
    public class CalculatorData
    {
        public decimal[] inputNumbers { get; set; }
        public CalculatorOperator Operator { get; set; }
        public decimal calculatorResult { get; set; }

        public string calculatorException { get; set; }

    }
}
