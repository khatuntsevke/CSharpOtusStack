using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Stack<int> stack = new Stack<int>();
            
            Console.WriteLine("------- Основное задание -------");
            BaseTest();
            Console.WriteLine("\n------- Дополнительное задание #1 -------");
            AdditionalTask1Test();
            Console.WriteLine("\n------- Дополнительное задание #2 -------");
            AdditionalTask2Test();
            Console.WriteLine("\n------- Дополнительное задание #3 -------");
            AdditionalTask3Test();
        }

        public static void BaseTest()
        {
            Console.WriteLine("Создадим стэк: ");
            var otusStack = new OtusStack<string>("a", "b", "c" );
            otusStack.Print();            
            Console.WriteLine($"Size = {otusStack.Size}, Top = '{otusStack.Top}'");
            var deleted = otusStack.Pop();            
            Console.WriteLine($"Изъял верхний элемент '{deleted}' Size = {otusStack.Size}");            
            otusStack.Add("d");
            Console.WriteLine($"Добавил на верх \"d\" ");
            Console.WriteLine($"Size = {otusStack.Size}, Top = '{otusStack.Top}'");
            otusStack.Pop();
            otusStack.Pop();
            otusStack.Pop();
            Console.WriteLine($"Три раза выполним Pop()");
            // size = 0, Top = null
            Console.WriteLine($"Size = {otusStack.Size}, Top = {(otusStack.Top == null ? "null" : otusStack.Top)}");
            Console.WriteLine($"Попробуем вызвать Pop() у пустого стэка");
            try
            {
                otusStack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static void AdditionalTask1Test()
        {            
            var otusStack1 = new OtusStack<string>("a", "b", "c");
            Console.WriteLine("Создали стэк: ");
            otusStack1.Print();
            var otusStack2 = new OtusStack<string>("1", "2", "3");
            Console.WriteLine("и создали стэк: ");
            otusStack2.Print();
            Console.WriteLine("Сольём второй стэк в первый.");
            otusStack1.Merge(otusStack2);
            Console.WriteLine("Первый стэк после слияния: ");
            otusStack1.Print();            
        }
        
        public static void AdditionalTask2Test()
        {
            var s1 = new OtusStack<string>("a", "b", "c");
            var s2 = new OtusStack<string>("1", "2", "3");
            var s3 = new OtusStack<string>("А", "Б", "В");
            Console.WriteLine("Создадим три стэка: ");
            s1.Print();
            s2.Print();
            s3.Print();
            Console.WriteLine("Выполним функцию OtusStack.Concat(s1,s2,s3)");
            var otusStack = OtusStack<string>.Concat(
                new OtusStack<string>("a", "b", "c"),
                new OtusStack<string>("1", "2", "3"),
                new OtusStack<string>("А", "Б", "В"));
            // в стеке otusStack теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
            Console.WriteLine("Функция создала и вернула следующий стэк: ");
            otusStack.Print();
        }
        
        public static void AdditionalTask3Test()
        {
            Console.WriteLine("------- Основное задание c использованием AlternativeOtusStack -------");
            AlternativeBaseTest();
            Console.WriteLine("\n------- Дополнительное задание #1 c использованием AlternativeOtusStack -------");
            AlternativeAdditionalTask1Test();
            Console.WriteLine("\n------- Дополнительное задание #2 c использованием AlternativeOtusStack -------");
            AlternativeAdditionalTask2Test();            
        }

        public static void AlternativeBaseTest()
        {
            Console.WriteLine("Создадим стэк: ");
            var otusStack = new AlternativeOtusStack<string>("a", "b", "c");
            otusStack.Print();
            Console.WriteLine($"Size = {otusStack.Size}, Top = '{otusStack.Top}'");
            var deleted = otusStack.Pop();
            Console.WriteLine($"Изъял верхний элемент '{deleted}' Size = {otusStack.Size}");
            otusStack.Add("d");
            Console.WriteLine($"Добавил на верх \"d\" ");
            Console.WriteLine($"Size = {otusStack.Size}, Top = '{otusStack.Top}'");
            otusStack.Pop();
            otusStack.Pop();
            otusStack.Pop();
            Console.WriteLine($"Три раза выполним Pop()");
            // size = 0, Top = null
            Console.WriteLine($"Size = {otusStack.Size}, Top = {(otusStack.Top == null ? "null" : otusStack.Top)}");
            Console.WriteLine($"Попробуем вызвать Pop() у пустого стэка");
            try
            {
                otusStack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static void AlternativeAdditionalTask1Test()
        {
            var otusStack1 = new AlternativeOtusStack<string>("a", "b", "c");
            Console.WriteLine("Создали стэк: ");
            otusStack1.Print();
            var otusStack2 = new AlternativeOtusStack<string>("1", "2", "3");
            Console.WriteLine("и создали стэк: ");
            otusStack2.Print();
            Console.WriteLine("Сольём второй стэк в первый.");
            otusStack1.Merge(otusStack2);
            Console.WriteLine("Первом стэк после слияния: ");
            otusStack1.Print();
        }
        
        public static void AlternativeAdditionalTask2Test()
        {
            var s1 = new AlternativeOtusStack<string>("a", "b", "c");
            var s2 = new AlternativeOtusStack<string>("1", "2", "3");
            var s3 = new AlternativeOtusStack<string>("А", "Б", "В");
            Console.WriteLine("Создадим три стэка: ");
            s1.Print();
            s2.Print();
            s3.Print();
            Console.WriteLine("Выполним функцию OtusStack.Concat(s1,s2,s3)");
            var otusStack = AlternativeOtusStack<string>.Concat(
                new AlternativeOtusStack<string>("a", "b", "c"),
                new AlternativeOtusStack<string>("1", "2", "3"),
                new AlternativeOtusStack<string>("А", "Б", "В"));
            // в стеке otusStack теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
            Console.WriteLine("Функция создала и вернула следующий стэк: ");
            otusStack.Print();
        }
    }
}

