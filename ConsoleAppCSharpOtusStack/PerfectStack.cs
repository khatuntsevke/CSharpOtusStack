namespace ConsoleApp
{
    public abstract class PerfectStack<T>
    {
        protected abstract T[] _ToArray();

        protected void _Merge(PerfectStack<T> anotherStack)
        {
            var anotherStackBody = anotherStack._ToArray();
            for (int i = (anotherStackBody.Length - 1); i >= 0; i--)
            {
                Add(anotherStackBody[i]);
            }
        }

        public abstract object ShallowCopy();        

        public abstract int Size { get; }
        public abstract T? Top { get; }
        public abstract void Add(T item);
        public abstract T Pop();

        public void Print()
        {
            Console.Write("[");
            var body = _ToArray();
            for(int i = 0; i < (body.Length-1); i++)
            {
                Console.Write($"{body[i]}, ");
            }
            Console.Write($"{body[^1]}]\n");
        }
    }
}
