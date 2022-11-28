namespace ConsoleApp
{
    public static class OtusStackExtensions
    {
        public static void Merge<T>(this PerfectStack<T> stack, PerfectStack<T> anotherStack)
        {
            var anotherStackClone = (PerfectStack<T>)anotherStack.ShallowCopy();
            while(anotherStackClone.Size != 0)
            {                
                stack.Add(anotherStackClone.Pop());
            }            
        }
    }
}
