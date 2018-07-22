namespace Stack.UnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Unity;
    using FluentAssertions;

    [TestClass]
    public class IntStackUnitTest
    {
        [TestMethod]
        public void IfStackIsEmptyThenStackEmptyExceptionShouldBeThrown()
        {
            var stack = GetStack();
            Action action = () => stack.Pop();
            action.Should().Throw<EmptyStackException>();
        }

        [TestMethod]
        public void WhenStackIsEmptyAndNewElementAddedThenStackCountMustBeOne()
        {
            var stack = GetStack();
            stack.Push(1);
            stack.GetCount().Should().Be(1);
        }

        [TestMethod]
        public void WhenStackIsNotEmptyThenPop()
        {
            var item = 1;
            var stack = GetStack();
            stack.Push(item);
            stack.Pop().Should().Be(item);
        }

        private static IStack<int> GetStack()
        {
            IUnityContainer container = new UnityContainer();
            container.AddExtension(new StackUnityContainerExtension());
            return container.Resolve<IStack<int>>();
        }
    }
}
