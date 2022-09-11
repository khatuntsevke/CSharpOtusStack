namespace CSharpOtusStack
{
    public static class OtusStackExtensions
    {
        public static void Merge<T>(this PerfectStack<T> stack, PerfectStack<T> anotherStack)
        {
            var anotherStackBody = anotherStack.ToArray();
            for(int i = (anotherStackBody.Length-1); i >=0; i--)
            {
                stack.Add(anotherStackBody[i]);
            }
        }
    }
}
