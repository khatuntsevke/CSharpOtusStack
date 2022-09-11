using System.Security.Cryptography;

namespace CSharpOtusStack
{
    public class AlternativeOtusStack<T> : PerfectStack<T>
    {
        class StackItem<T>
        {
            public T? item;
            public StackItem<T>? previousStackItem;            
            public StackItem()
            {
                item = default;
                previousStackItem = null;
            }
            public StackItem(T? initItem, StackItem<T>? initPrevious)
            {
                item = initItem;
                previousStackItem = initPrevious;
            }
        }

        private StackItem<T> _bodyTail;
        private int _size;
        
        /// <summary>
        /// Количество объектов, которые хранит OtusStack
        /// </summary>
        public int Size
        {
            get
            {
                return _size;
            }
        }
        /// <summary>
        /// Текущий верхний объект OtusStack
        /// </summary>
        public T? Top
        {
            get
            {               
                return _bodyTail.item;
            }
        }
        public AlternativeOtusStack()
        {
            _bodyTail = new StackItem<T>();
            _size = 0;
        }
        public AlternativeOtusStack(params T[] args)
        {
            _bodyTail = new StackItem<T>();
            _size = 0;
            foreach (var arg in args)
            {
                _bodyTail = new StackItem<T>(arg, _bodyTail);                
                _size += 1;
            }
        }
        /// <summary>
        /// Добавить объект на верх OtusStack.
        /// </summary>
        /// <param name="newItem"></param>
        public override void Add(T newItem)
        {
            _bodyTail = new StackItem<T>(newItem, _bodyTail);
            _size += 1;
        }
        /// <summary>
        /// Изымает объект с верха OtusStack.
        /// </summary>
        /// <returns>Объект, который был на верху.</returns>
        /// <exception cref="InvalidOperationException">Возникает при вызове у объекта нулевого размера</exception>
        public override T Pop()
        {
            T tmpItem;

            if (Size == 0)
            {
                throw new InvalidOperationException("Ошибка! Вызов метода OtusStack.Pop у пустого объекта OtusStack.");
            }
            else
            {
                tmpItem = _bodyTail.item;
                _bodyTail = _bodyTail.previousStackItem;
                _size -= 1;
                return tmpItem;
            }
        }       
        /// <summary>
        /// Копирование элементов в новый Array.
        /// </summary>
        /// <returns>Ссылка на на созданный Array.</returns>
        public override T[] ToArray()
        {
            T[] result = new T[Size];

            var currentStackItem = _bodyTail;
            for (int i = result.Length-1; i >= 0; i--)
            {
                result[i] = currentStackItem.item;
                currentStackItem = currentStackItem.previousStackItem;
            }            
            return result;
        }
        /// <summary>
        /// Выполнить слияние произвольного количества объектов OtusStack.
        /// </summary>
        /// <param name="args">Неограниченное количество объектов OtusStack.</param>
        /// <returns>Новый объект OtusStack с элементами каждого стека в порядке параметров, но сами элементы записаны в обратном порядке.</returns>
        public static AlternativeOtusStack<T> Concat(params AlternativeOtusStack<T>[] args)
        {
            var resultStack = new AlternativeOtusStack<T>();
            foreach (var otusStack in args)
            {
                resultStack.Merge(otusStack);
            }
            return resultStack;
        }
    }
}
