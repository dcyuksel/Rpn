namespace Stack
{
    using Unity.Extension;
    using Unity;

    public class StackUnityContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType(typeof(IStack<>), typeof(Stack<>));
        }
    }
}
