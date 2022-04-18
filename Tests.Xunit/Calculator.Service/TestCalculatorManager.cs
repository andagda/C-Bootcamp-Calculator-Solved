using Xunit;
using Calculator.Service;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tests.Xunit
{
    public class TestCalculatorManager
    {

        public static IEnumerable<object[]> CalculatorTestDataAdd =>
        new List<object[]>
        {
            new object[] {
                new CalculatorData()
                {
                    inputNumbers = new decimal[1] { 1000 },
                    Operator = CalculatorOperator.Add
                },
                1000
            },
            new object[] {
                new CalculatorData()
                {
                    inputNumbers = new decimal[2] { 1, 2.5M },
                    Operator = CalculatorOperator.Add
                },
                3.5
            },
            new object[] {
                new CalculatorData()
                {
                    inputNumbers = new decimal[3] { -1, -2, 5 },
                    Operator = CalculatorOperator.Add
                },
                2
            }

        };

        [Theory]
        [MemberData(nameof(CalculatorTestDataAdd))]
        public void Add_ShouldHaveCorrectSum_AddingPositiveOrNegativeNumbers(CalculatorData inputCalculatorData, decimal expectedResult)
        {

            CalculatorManager.Add(inputCalculatorData);
            Assert.Equal(expectedResult, inputCalculatorData.calculatorResult);
            Assert.Equal(CalculatorOperator.Add, inputCalculatorData.Operator);

        }

        public static IEnumerable<object[]> CalculatorTestDataSubtract =>
        new List<object[]>
        {
            new object[] {
                new CalculatorData()
                {
                    inputNumbers = new decimal[1] { 1000 },
                    Operator = CalculatorOperator.Subtract
                },
                1000
            },
            new object[] {
                new CalculatorData()
                {
                    inputNumbers = new decimal[2] { 1, 2 },
                    Operator = CalculatorOperator.Subtract
                },
                -1
            },
            new object[] {
                new CalculatorData()
                {
                    inputNumbers = new decimal[3] { -1, -2, 5 },
                    Operator = CalculatorOperator.Subtract
                },
                -4
            }

        };

        [Theory]
        [MemberData(nameof(CalculatorTestDataSubtract))]
        public void Subtract_ShouldHaveCorrectDifference_SubtractingPositiveOrNegativeNumbers(CalculatorData inputCalculatorData, decimal expectedResult)
        {

            CalculatorManager.Subtract(inputCalculatorData);
            Assert.Equal(expectedResult, inputCalculatorData.calculatorResult);
            Assert.Equal(CalculatorOperator.Subtract, inputCalculatorData.Operator);
        }

        public static IEnumerable<object[]> CalculatorTestDataMultiply =>
            new List<object[]>
            {
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[1] { 1000 },
                        Operator = CalculatorOperator.Multiply
                    },
                    1000
                },
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[2] { 1, -2 },
                        Operator = CalculatorOperator.Multiply,
                    },
                    -2
                },
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[3] { -1, -2, 5 },
                        Operator = CalculatorOperator.Multiply,
                    },
                    10
                },
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[4] { -1, -2, 5, 0 },
                        Operator = CalculatorOperator.Multiply,
                    },
                    0
                }

            };

        [Theory]
        [MemberData(nameof(CalculatorTestDataMultiply))]
        public void Multiply_ShouldHaveCorrectProduct_MultiplyingPositiveOrNegativeNumbers(CalculatorData inputCalculatorData, decimal expectedResult)
        {

            CalculatorManager.Multiply(inputCalculatorData);
            Assert.Equal(expectedResult, inputCalculatorData.calculatorResult);
            Assert.Equal(CalculatorOperator.Multiply, inputCalculatorData.Operator);

        }

        public static IEnumerable<object[]> CalculatorTestDataDivide =>
            new List<object[]>
            {
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[1] { 1000 },
                        Operator = CalculatorOperator.Divide
                    },
                    1000
                },
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[2] { 4, -2 },
                        Operator = CalculatorOperator.Divide,
                    },
                    -2
                },
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[2] { -1, -2 },
                        Operator = CalculatorOperator.Divide,
                    },
                    0.5
                },
                new object[] {
                    new CalculatorData()
                    {
                        inputNumbers = new decimal[1] { -10000 },
                        Operator = CalculatorOperator.Divide,
                    },
                    -10000
                }

            };

        [Theory]
        [MemberData(nameof(CalculatorTestDataDivide))]
        public void Divide_ShouldHaveCorrectDividend_DividingPositiveOrNegativeNumbers(CalculatorData inputCalculatorData, decimal expectedResult)
        {

            CalculatorManager.Divide(inputCalculatorData);
            Assert.Equal(expectedResult, inputCalculatorData.calculatorResult);
            Assert.Equal(CalculatorOperator.Divide, inputCalculatorData.Operator);
        }

        [Fact]
        public void Add_ShouldHaveCorrectSum_AddingLargeValues()
        {
            CalculatorData maxCalculatorData = new CalculatorData()
            {
                inputNumbers = new decimal[2] { 999999999999999999999999M, 999999999999999999999999M },
                Operator = CalculatorOperator.Add,
            };

            CalculatorManager.Add(maxCalculatorData);
            Assert.Equal(1999999999999999999999998M, maxCalculatorData.calculatorResult);

        }

        [Fact]
        public void Multiply_ShouldHaveException_MultiplyingLargeValues()
        {
            CalculatorData exceptionCalculatorData = new CalculatorData()
            {
                inputNumbers = new decimal[2] { 999999999999999999999999M, 999999999999999999999999M },
                Operator = CalculatorOperator.Multiply,
            };

            CalculatorManager.Multiply(exceptionCalculatorData);
            Assert.Equal("Value was either too large or too small for a Decimal.", exceptionCalculatorData.calculatorException);

        }

        [Fact]
        public void Multiply_ShouldHaveException_MultiplyingLargeNegativeValues()
        {
            CalculatorData exceptionCalculatorData = new CalculatorData()
            {
                inputNumbers = new decimal[2] { -9999999999999999999999999M, 10100 },
                Operator = CalculatorOperator.Multiply,
            };

            CalculatorManager.Multiply(exceptionCalculatorData);
            Assert.Equal("Value was either too large or too small for a Decimal.", exceptionCalculatorData.calculatorException);

        }

        [Fact]
        public void Divide_ShouldHaveException_DividingByZero()
        {
            CalculatorData exceptionCalculatorData = new CalculatorData()
            {
                inputNumbers = new decimal[2] { 1000, 0 },
                Operator = CalculatorOperator.Divide,
            };

            CalculatorManager.Divide(exceptionCalculatorData);
            Assert.Contains("divide by zero", exceptionCalculatorData.calculatorException);

        }


        [Fact]
        public void ProcessData_ShouldHaveInvalidOperator_WhenInvalidMathOperatorIsPassed()
        {
            // Arrange
            string jsonInput = @"{
                'InputDataArray':[
                    {
                    'Numbers':[1,2.2,3,4,5],
                    'Operation': '_'
                    }
                ]
            }";

            CalculatorInput calculatorInput = new CalculatorInput();
            calculatorInput=JsonConvert.DeserializeObject<CalculatorInput>(jsonInput);
            CalculatorManager calculatorManager = new CalculatorManager();
            List<CalculatorData> calculatorDataList = new List<CalculatorData>();

            //Act
            calculatorDataList=calculatorManager.ProcessData(calculatorInput);
            
            // Assert
            foreach (var item in calculatorDataList)
            {
                Assert.Contains("Invalid Operator",item.calculatorException);
            }
            
        }

    }
}