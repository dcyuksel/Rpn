namespace RpnCalculator
{
    using Unity.Extension;
    using Unity;

    public class RpnCalculatorUnityContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<IRpnCalculator, RpnCalculator>();
            this.Container.RegisterType<ICalculator, Calculator>();
        }
    }
}
