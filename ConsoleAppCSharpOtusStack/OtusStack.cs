namespace CSharpOtusStack
{
    public class OtusStack<T> : PerfectStack<T>
    {       
        private List<T> _body;        
        public OtusStack()
        {
            _body = new List<T>();
        }
        public OtusStack(params T[] args)
        {
            _body = new List<T>(args);
        }
        /// <summary>
        /// Добавить объект на верх OtusStack.
        /// </summary>
        /// <param name="newItem"></param>
        public override void Add(T newItem)
        {
            _body.Add(newItem);
        }
        /// <summary>
        /// Изымает объект с верха OtusStack.
        /// </summary>
        /// <returns>Объект, который был на верху.</returns>
        /// <exception cref="InvalidOperationException">Возникает при вызове у объекта нулевого размера</exception>
        public override T Pop()
        {
            T tmpElement;

            if (_body.Count == 0)
            {
                throw new InvalidOperationException("Ошибка! Вызов метода OtusStack.Pop у пустого объекта OtusStack.");
            }
            else
            {
                tmpElement = _body[^1];
                _body.RemoveAt(_body.Count - 1);
                return tmpElement;
            }
        }
        /// <summary>
        /// Количество объектов, которые хранит OtusStack
        /// </summary>
        public override int Size
        {
            get
            {
                return _body.Count;
            }
        }
        /// <summary>
        /// Текущий верхний объект OtusStack
        /// </summary>
        public override T? Top
        {
            get
            {
                return (Size == 0)? default(T) : _body[^1];                
            }
        }
        /// <summary>
        /// Копирование элементов в новый Array.
        /// </summary>
        /// <returns>Ссылка на на созданный Array.</returns>
        public override T[] ToArray()
        {            
            return _body.ToArray();
        }

        /// <summary>
        /// Выполнить слияние произвольного количества объектов OtusStack.
        /// </summary>
        /// <param name="args">Неограниченное количество объектов OtusStack.</param>
        /// <returns>Новый объект OtusStack с элементами каждого стека в порядке параметров, но сами элементы записаны в обратном порядке.</returns>
        public static OtusStack<T> Concat(params OtusStack<T>[] args)
        {
            var resultStack = new OtusStack<T>();
            foreach (var otusStack in args)
            {
                resultStack.Merge(otusStack);
            }
            return resultStack;
        }
    }
}
