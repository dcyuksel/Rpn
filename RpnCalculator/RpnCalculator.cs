namespace RpnCalculator
{
    using System;
    using Stack;

    public class RpnCalculator : IRpnCalculator
    {
        private readonly IStack<int> stack;
        private readonly ICalculator calculator;

        public RpnCalculator(IStack<int> stack, ICalculator calculator)
        {
            this.stack = stack;
            this.calculator = calculator;
        }

        public int Calculate(string expression)
        {
            CheckExpressionIsValid(expression);
            var inputs = expression.Split(' ');

            foreach (var input in inputs)
            {
                if (!input.IsStringAnOperator())
                {
                    var inputAsInt = Convert.ToInt32(input);
                    this.stack.Push(inputAsInt);
                }
                else
                {
                    var number2 = this.stack.Pop();
                    var number1 = this.stack.Pop();
                    var result = this.calculator.Calculate(input, number1, number2);
                    this.stack.Push(result);
                }
            }

            if (this.stack.GetCount() != 1) throw new InvalidExpressionException();
            return this.stack.Pop();
        }

        private static void CheckExpressionIsValid(string expression)
        {
            if (expression.IsValid() == false) throw new InvalidExpressionException();
        }
    }
}
