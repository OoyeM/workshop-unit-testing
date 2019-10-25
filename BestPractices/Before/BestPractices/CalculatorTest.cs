using System;
using Xunit;
using FluentAssertions;

namespace BestPractices
{
    public class CalculatorTest
    {
        private Calculator _calculator;

        public CalculatorTest()
        {
            _calculator = new Calculator();
        }



        [Theory]
        [InlineData(10, 5, 15)]
        public void TestAdd(int value1, int value2, int expected)
        {
            var actualResult = _calculator.Add(value1, value2);

            actualResult.Should().Be(expected);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public void TestAddBorderValues(int value1, int value2)
        {
            Action action = () => _calculator.Add(value1, value2);


            action.Should().Throw<OverflowException>();
        }

        [Theory]
        [InlineData(10,5,5)]
        public void TestSubtract(int value1, int value2, int expected)
        {
            var actualResult = _calculator.Add(value1, value2);

            actualResult.Should().Be(expected);
        }

        [Theory]
        [InlineData(int.MinValue, 1)]
        [InlineData(int.MaxValue, -1)]
        public void TestSubtractBorderValues(int value1, int value2)
        {
            Action action = () => _calculator.Subtract(value1, value2);
            action.Should().Throw<OverflowException>();
        }
    }
}
