namespace RpnCalculatorMainProject
{
    using System;
    using RpnCalculator;
    using Stack;
    using Unity;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var rpnCalculator = GetRpnCalculator();
                Console.WriteLine(Resourceresx.ResourceManager.GetString("WelcomeText"));
                var expression = Console.ReadLine();

                try
                {
                    var result = rpnCalculator.Calculate(expression);
                    Console.WriteLine(Resourceresx.ResourceManager.GetString("ResultText") + result);
                }
                catch (EmptyStackException e)
                {
                    Console.WriteLine(Resourceresx.ResourceManager.GetString("EmptyStackException"));
                }
                catch (InvalidExpressionException e)
                {
                    Console.WriteLine(Resourceresx.ResourceManager.GetString("InvalidExpressionException"));
                }
                catch (UnsupportedOperatorException e)
                {
                    Console.WriteLine(Resourceresx.ResourceManager.GetString("UnsupportedOperatorException"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(Resourceresx.ResourceManager.GetString("UnknownError"));
                }
            }
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
