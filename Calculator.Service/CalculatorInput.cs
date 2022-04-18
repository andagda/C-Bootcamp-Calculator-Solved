using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Service
{


    public class CalculatorInput
    {
        public Inputdata[] InputDataArray;
    }

    public class Inputdata
    {
        public decimal[] Numbers { get; set; }
        public string Operation { get; set; }
    }

}
