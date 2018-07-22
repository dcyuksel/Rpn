namespace RpnCalculator
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IsExpressionValidExtension
    {
        private static readonly HashSet<char> Operators =  new HashSet<char>{'+', '-', '/', '*'};

        public static bool IsValid(this string expression)
        {
            return expression.All(c => char.IsNumber(c) || c.IsCharAnOperator() || c == ' ');
        }

        public static bool IsStringAnOperator(this string expression)
        {
            if (expression.Length > 1) return false;

            var expressionAsChar = expression.ToCharArray().First();
            return Operators.Contains(expressionAsChar);
        }

        private static bool IsCharAnOperator(this char c)
        {
            return Operators.Contains(c);
        }
    }
}
