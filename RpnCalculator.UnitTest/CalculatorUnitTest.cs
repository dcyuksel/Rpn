using System;

namespace RpnCalculator.UnitTest
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Unity;

    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void Multiply()
        {
            var calculator = GetCalculator();
            var result = calculator.Calculate("*", 3, 5);
            result.Should().Be(15);
        }

        [TestMethod]
        public void Add()
        {
            var calculator = GetCalculator();
            var result = calculator.Calculate("+", 7, 5);
            result.Should().Be(12);
        }

        [TestMethod]
        public void Divide()
        {
            var calculator = GetCalculator();
            var result = calculator.Calculate("/", 15, 5);
            result.Should().Be(3);
        }

        [TestMethod]
        public void NotSupported()
        {
            var calculator = GetCalculator();
            Action action = () => calculator.Calculate("%", 7, 5);
            action.Should().Throw<UnsupportedOperatorException>();
        }

        [TestMethod]
        public void Minus()
        {
            var calculator = GetCalculator();
            var result = calculator.Calculate("-", 7, 5);
            result.Should().Be(2);
        }



        private static ICalculator GetCalculator()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.AddExtension(new RpnCalculatorUnityContainerExtension());
            return unityContainer.Resolve<ICalculator>();
        }
    }
}
