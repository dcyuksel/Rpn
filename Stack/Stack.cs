namespace Stack
{
    using System.Linq;
    using System.Collections.Generic;

    public class Stack<T> : IStack<T>
    {
        private readonly List<T> container = new List<T>();

        public void Push(T item)
        {
            this.container.Add(item); // O(1)
        }

        public T Pop()
        {
            var length = this.container.Count; // O(1)
            if (length <= 0) throw new EmptyStackException();
            var item = this.container.ElementAt(length - 1); // O(1)
            this.container.RemoveAt(length - 1); // O(1), Alwayse deletes last element, no shifting needed.
            return item;
        }

        public int GetCount()
        {
            return this.container.Count; // O(1)
        }
    }
}
