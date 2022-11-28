namespace ConsoleApp
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

        public OtusStack(OtusStack<T> sampleToCopy)
        {
            _body = new List<T>(sampleToCopy._body);
        }

        public override void Add(T newItem)
        {
            _body.Add(newItem);
        }
        
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
        
        public override int Size => _body.Count;        
        
        public override T? Top => (Size == 0)? default : _body[^1];
                
        protected override T[] _ToArray() =>  _body.ToArray();

        public override object ShallowCopy()
        {
            return new OtusStack<T>(this) as object;
        }

        public static OtusStack<T> Concat(params OtusStack<T>[] args)
        {
            var resultStack = new OtusStack<T>();
            foreach (var otusStack in args)
            {
                resultStack._Merge(otusStack);
            }
            return resultStack;
        }
    }
}