using System.ComponentModel.DataAnnotations;

namespace CSharpOtusStack
{
    public abstract class PerfectStack<T>
    {
        public int Size { get; }
        public T? Top { get; }

        abstract public void Add(T item);
        abstract public T Pop();
        abstract public T[] ToArray();
        /// <summary>
        /// Распечатать содержимое объекта в порядке от низа до вершины.
        /// </summary>
        public void Print()
        {
            Console.Write("[");
            var body = ToArray();
            for(int i = 0; i < (body.Length-1); i++)
            {
                Console.Write($"{body[i]}, ");
            }
            Console.Write($"{body[^1]}]\n");
        }
    }
}
