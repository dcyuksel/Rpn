namespace RpnCalculator
{
    public class Calculator : ICalculator
    {
        public int Calculate(string opr, int number1, int number2)
        {
            if (opr == "+") return number1 + number2;
            if (opr == "-") return number1 - number2;
            if (opr == "/") return number1 / number2;
            if (opr == "*") return number1 * number2;

            throw new UnsupportedOperatorException();
        }
    }
}
