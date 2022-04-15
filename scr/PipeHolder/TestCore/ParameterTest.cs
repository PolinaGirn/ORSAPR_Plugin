using System;
using Core;
using NUnit.Framework;

namespace TestCore
{
    [TestFixture]
    public class ParameterTest
    {
        private readonly Parameter _testParameter = new Parameter
            (ParametersType.ExternalDiameter, 20, 30, 30);

        [TestCase(TestName = "Позитивный тест геттера Name")]
        public void TestNameGet_GoodScenario()
        {
            // Arrange
            var expected = ParametersType.ExternalDiameter;

            // Act
            var actual = _testParameter.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера Min")]
        public void TestMinGet_GoodScenario()
        {
            // Arrange
            var expected = 20;

            // Act
            var actual = _testParameter.Min;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера Max")]
        public void TestMaxGet_GoodScenario()
        {
            // Arrange
            var expected = 30;

            // Act
            var actual = _testParameter.Max;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера Name")]
        public void TestLimitsGet_GoodScenario()
        {
            // Arrange
            var expected = "(20-30 мм)";

            // Act
            var actual = _testParameter.Limits;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера и сеттера Value")]
        public void TestValueGetSet_GoodScenario()
        {
            // Arrange
            var expected = 30;

            // Act
            var parameter = _testParameter.Clone() as Parameter;
            parameter.Value = expected;
            var actual = parameter.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, TestName = "При попытке сохранить значение, которое меньше минимального," +
                                 " должно измениться сообщение об ошибке")]
        [TestCase(40, TestName = "При попытке сохранить значение, которое больше максимального," +
                                 " должно измениться сообщение об ошибке")]
        public void TestValueSet_WrongValue_ChangeErrorDescription(double wrongValue)
        {
            // Arrange
            var expected = $"Значение должно быть от 20 мм до 30 мм";

            // Act
            var parameter = _testParameter.Clone() as Parameter;
            parameter.Value = wrongValue;
            var actual = parameter.ErrorDescription;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера и сеттера IsValidData")]
        public void TestIsValidDataGetSet_GoodScenario()
        {
            // Arrange
            var expected = true;

            // Act
            var actual = _testParameter.IsValidData;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(TestName = "При сравнении одинаковых объектов возращается истина")]
        public void TestEqualsAndClone_GoodScenario_ReturnTrue()
        {
            // Arrange
            var expected = _testParameter;

            // Act
            var actual = _testParameter.Clone() as Parameter;
            var isEqual = actual.Equals(expected);

            // Assert
            Assert.IsTrue(isEqual);
        }

        [TestCase(TestName = "При сравнении различных объектов возращается ложь")]
        public void TestEquals_DifferentValues_ReturnFalse()
        {
            // Arrange
            var expected = _testParameter;

            // Act
            var actual = _testParameter.Clone() as Parameter;
            actual.Value = 25;
            var isEqual = actual.Equals(expected);

            // Assert
            Assert.IsFalse(isEqual);
        }

        [TestCase(TestName = "При сравнении с нулевым объектом возращается ложь")]
        public void TestEquals_NullValue_ReturnFalse()
        {
            // Act
            var actual = _testParameter;
            var isEqual = actual.Equals(null);

            // Assert
            Assert.IsFalse(isEqual);
        }
    }
}