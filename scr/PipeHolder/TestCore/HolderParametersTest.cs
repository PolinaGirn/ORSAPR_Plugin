using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core;
using NUnit.Framework;

namespace TestCore
{
    [TestFixture]
    public class HolderParametersTest
    {
        private List<Parameter> _testParameters =>
            new List<Parameter>
            {
                new Parameter(ParametersType.Height, 15, 40, 25),
                new Parameter(ParametersType.ExternalDiameter, 20, 30, 30),
                new Parameter(ParametersType.PipeDiameter, 10, 27.5, 15),
                new Parameter(ParametersType.HolderDiameter, 60, 90, 60),
                new Parameter(ParametersType.HoleDiameter, 4, 7.5, 6)
            };

        [TestCase(TestName = "Позитивный тест геттера ParametersList")]
        public void TestParametersListGet_GoodScenario()
        {
            // Arrange
            var expected = _testParameters;

            // Act
            var holderParameters = new HolderParameters();
            var actual = holderParameters.ParametersList;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Если все параметры содержат корректные данные," +
                             " IsValidData возвращает true")]
        public void TestIsValidDataGet_ValidData()
        {
            // Arrange
            var expected = true;

            // Act
            var actual = _testParameters.All(parameter => parameter.IsValidData);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Если один из параметров содержит некорректные данные," +
                             " IsValidData возвращает false")]
        public void TestIsValidDataGet_InvalidData()
        {
            // Arrange
            var expected = false;

            // Act
            var parametersList = new HolderParameters();
            try
            {
                parametersList[ParametersType.ExternalDiameter].Value = 80;
            }
            catch (ArgumentException)
            {
            }
            var actual = parametersList.IsValidData;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При получении значения с помощью индексатора возвращается соответствующий параметр")]
        public void TestIndexerGet_ReturnValue()
        {
            // Arrange
            var expected = new Parameter(ParametersType.ExternalDiameter, 20, 30, 30);

            // Act
            var parametersList = new HolderParameters();
            var actual = parametersList[ParametersType.ExternalDiameter];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При установке значения с помощью индексатора, параметр записывается в коллекцию")]
        public void TestIndexerSet_GoodScenario()
        {
            // Arrange
            var expected = new Parameter(ParametersType.ExternalDiameter, 20, 30, 30);

            // Act
            var parametersList = new HolderParameters()
            {
                [ParametersType.ExternalDiameter] = expected
            };
            var actual = parametersList[ParametersType.ExternalDiameter];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "Когда вызывается метод SetDefault, значения коллекции должны установиться по умолчанию")]
        public void TestSetDefault_GoodScenario()
        {
            // Arrange
            var expected = _testParameters;

            // Act
            var holderParameters = new HolderParameters();
            holderParameters.ParametersList.Add(
                new Parameter(ParametersType.ExternalDiameter, 20, 30, 30));
            holderParameters.SetDefault();
            var actual = holderParameters.ParametersList;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
        
        private const string TestOnDependentParameterChanged_ChangeLimits_TestName =
            "При изменении значения параметра {0} на {4}, должны измениться" +
            " ограничения для параметра {1} на Min = {2} и Max = {3}";

        [TestCase(ParametersType.HolderDiameter,
            ParametersType.HoleDiameter, 4, 12.5, 80,
            TestName = TestOnDependentParameterChanged_ChangeLimits_TestName)]
        [TestCase(ParametersType.HolderDiameter,
            ParametersType.ExternalDiameter, 20, 40, 80,
            TestName = TestOnDependentParameterChanged_ChangeLimits_TestName)]
        [TestCase(ParametersType.ExternalDiameter,
            ParametersType.HoleDiameter, 4, 8.75, 25,
            TestName = TestOnDependentParameterChanged_ChangeLimits_TestName)]
        [TestCase(ParametersType.ExternalDiameter,
            ParametersType.PipeDiameter, 10, 22.5, 25,
            TestName = TestOnDependentParameterChanged_ChangeLimits_TestName)]
        public void TestCheckDependencyValue_ChangeLimits(ParametersType testParameter,
            ParametersType name, double expectedMin, double expectedMax, double value)
        {
            // Act
            var parametersList = new HolderParameters
            {
                [testParameter] =
                {
                    Value = value
                }
            };

            parametersList.CheckDependencyValue();
            var changedParameter = parametersList[name];
            var actualMin = changedParameter.Min;
            var actualMax = changedParameter.Max;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedMin, actualMin);
                Assert.AreEqual(expectedMax, actualMax);
            });
        }
    }
}