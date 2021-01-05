using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApi;
using Moq;

namespace CalculatorTests
{
    public class CalculatorApi_UnitTests
    {
        private Mock<IDiagnostics> diagnostics;
        private ISimpleCalculator GetCalculator()
        {
            diagnostics = new Mock<IDiagnostics>();
            var calc = new Calculator(diagnostics.Object);
            return calc;
        }

        [Test]
        public void Add_AnyIntegers_DiagnosticsLogIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Add(2, 3);
            //Assert
            diagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Subtract_AnyIntegers_DiagnosticsLogIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Subtract(2, 3);
            //Assert
            diagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Multiply_AnyIntegers_DiagnosticsLogIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Multiply(2, 3);
            //Assert
            diagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Divide_AnyIntegers_DiagnosticsLogIsInvoked()
        {
            //Arrange
            //Mock<IDiagnostics> diagnostics = new Mock<IDiagnostics>();
            ISimpleCalculator calc = GetCalculator();
            //Act
            var result = calc.Divide(2, 3);
            //Assert
            diagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        //Format for testing name UnitUnderTest_Scenario_ExpectedOutcome
        //Unit under test is just the method name, scenario is what the parameters are
        //expected outcome is what the test should return
        [TestCase(0,0,0)]
        [TestCase(0, 5, 5)]
        [TestCase(5, 4, 9)]
        
        public void Add_PositiveIntegers_ReturnIntegerSum(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Add(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase(-2, -7, -9)]
        [TestCase(-10, -2, -12)]
        [TestCase(-10,-7,-17)]
        public void Add_NegativeIntegers_ReturnIntegerSum(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Add(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase(-2, 7, 5)]
        [TestCase(2, -10, -8)]
        [TestCase(10, -7, 3)]
        public void Add_MixtureIntegers_ReturnIntegerSum(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Add(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }


        [TestCase(0, 0, 0)]
        [TestCase(2,3,-1)]
        [TestCase(5,2,3)]
        public void Subtract_PositiveIntegers_ReturnIntegerSub(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Subtract(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(-1, -3, 2)]
        [TestCase(-5, -1, -4)]
        [TestCase(-5, -5, 0)]
        public void Subtract_NegativeIntegers_ReturnIntegerSub(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Subtract(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(-1, 3, -4)]
        [TestCase(5, -1, 6)]
        [TestCase(5, -5, 10)]
        public void Subtract_MixedIntegers_ReturnIntegerSub(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Subtract(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase(0, 0, 0)]
        [TestCase(1, 3, 3)]
        [TestCase(0, 2, 0)]
        [TestCase(5, 5, 25)]
        public void Multiply_PositiveIntegers_ReturnIntegerMult(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Multiply(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(-1, -3, 3)]
        [TestCase(-0, -2, 0)]
        [TestCase(-5, -5, 25)]
        public void Multiply_NegativeIntegers_ReturnIntegerMult(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Multiply(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(4, -3, -12)]
        [TestCase(0, -2, 0)]
        [TestCase(-5, 5, -25)]
        public void Multiply_MixedIntegers_ReturnIntegerMult(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Multiply(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(-4)]
        public void Divide_ZeroByIntegers_ReturnZero(int input)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Divide(0, input);
            int expectedResult = 0;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(-4)]
        public void Divide_IntegersByZero_ReturnZero(int input)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Divide(input,0);
            int expectedResult = 0;
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(2,3,0)]
        [TestCase(4,1,4)]
        [TestCase(8,3,2)]
        public void Divide_PositiveIntegersByPositiveIntegers_ReturnIntegerDiv(int input1,int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Divide(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(-2, -3, 0)]
        [TestCase(-4, -1, 4)]
        [TestCase(-8, -3, 2)]
        public void Divide_NegativeIntegersByNegativeIntegers_ReturnIntegerDiv(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Divide(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(-2, 3, -0)]
        [TestCase(4, -1, -4)]
        [TestCase(-8, 3, -2)]
        public void Divide_MixedIntegers_ReturnIntegerDiv(int input1, int input2, int expectedResult)
        {
            //Arrange
            ISimpleCalculator calc = GetCalculator();
            //Act
            int result = calc.Divide(input1, input2);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }


    }
}
