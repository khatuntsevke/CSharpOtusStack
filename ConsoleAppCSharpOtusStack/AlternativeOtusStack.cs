namespace ConsoleApp
{
    public class AlternativeOtusStack<T> : PerfectStack<T>
    {
        class StackItem<ItemType>
        {
            public ItemType item;
            public StackItem<ItemType>? previousStackItem;            
            public StackItem(ItemType initItem, StackItem<ItemType>? initPrevious)
            {
                item = initItem;
                previousStackItem = initPrevious;
            }            
        }

        private StackItem<T>? _bodyTail;
        private int _size;

        public AlternativeOtusStack()
        {
            _size = 0;
            _bodyTail = null;
        }
                
        public override int Size => _size;
        
        public override T? Top =>  (_bodyTail == null) ? default(T) : _bodyTail.item;            
          
        public AlternativeOtusStack(params T[] args)
        {
            _bodyTail = new StackItem<T>(args[0], null);
            _size = 1;
            for(int i = 1; i < args.Length; i++)
            {
                _bodyTail = new StackItem<T>(args[i], _bodyTail);
                _size += 1;
            }
        }               

        public override void Add(T newItem)
        {
            _bodyTail = new StackItem<T>(newItem, _bodyTail);
            _size += 1;
        }
        
        public override T Pop()
        {
            T tmpItem;

            if (_bodyTail == null)
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
        
        protected override T[] _ToArray()
        {
            T[] result = new T[Size];
            if (_bodyTail != null)
            {
                StackItem<T>? currentStackItem = _bodyTail;
                for (int i = result.Length - 1; i >= 0; i--)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    result[i] = currentStackItem.item;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    currentStackItem = currentStackItem.previousStackItem;
                }
            }
            return result;
        }

        public override object ShallowCopy()
        {
            return new AlternativeOtusStack<T>(_ToArray()) as object;
        }

        public static AlternativeOtusStack<T> Concat(params AlternativeOtusStack<T>[] args)
        {
            var resultStack = new AlternativeOtusStack<T>();
            foreach (var otusStack in args)
            {
                resultStack._Merge(otusStack);
            }
            return resultStack;
        }
    }
}
