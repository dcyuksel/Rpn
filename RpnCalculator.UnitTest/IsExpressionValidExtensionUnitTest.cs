namespace RpnCalculator.UnitTest
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IsExpressionValidExtensionUnitTest
    {
        [TestMethod]
        public void IsValid1()
        {
            var expression = "34343";
            expression.IsValid().Should().Be(true);
        }

        [TestMethod]
        public void IsValid2()
        {
            var expression = "34343e";
            expression.IsValid().Should().Be(false);
        }

        [TestMethod]
        public void IsValid3()
        {
            var expression = "1+2+3";
            expression.IsValid().Should().Be(true);
        }

        [TestMethod]
        public void IsValid4()
        {
            var expression = "1+20+3";
            expression.IsValid().Should().Be(true);
        }

        [TestMethod]
        public void IsValid5()
        {
            var expression = "1 +20+3";
            expression.IsValid().Should().Be(true);
        }
    }
}
