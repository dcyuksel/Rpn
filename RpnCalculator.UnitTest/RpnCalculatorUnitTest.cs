namespace RpnCalculator.UnitTest
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Stack;
    using Unity;

    [TestClass]
    public class RpnCalculatorUnitTest
    {
        [TestMethod]
        public void Expression1()
        {
            var rpnCalculator = GetRpnCalculator();
            var expression = "20 5 /";
            rpnCalculator.Calculate(expression).Should().Be(4);
        }

        [TestMethod]
        public void Expression2()
        {
            var rpnCalculator = GetRpnCalculator();
            var expression = "4 2 + 3 -";
            rpnCalculator.Calculate(expression).Should().Be(3);
        }

        [TestMethod]
        public void Expression3()
        {
            var rpnCalculator = GetRpnCalculator();
            var expression = "3 5 8 * 7 + *";
            rpnCalculator.Calculate(expression).Should().Be(141);
        }

        private static IRpnCalculator GetRpnCalculator()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.AddExtension(new StackUnityContainerExtension());
            unityContainer.AddExtension(new RpnCalculatorUnityContainerExtension());
            return unityContainer.Resolve<IRpnCalculator>();
        }
    }
}
