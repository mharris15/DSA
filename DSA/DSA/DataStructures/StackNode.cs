using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures
{
    public class StackNode<T> where T : IComparable<T>
    {
        private List<T> _items;
        private List<T> _minItems;

        public StackNode() 
        { 
            _items = new List<T>();
            _minItems = new List<T>();
        }

        public void Push(T item)
        {
            _items.Add(item);

            // Push to min stack if it's the new min
            if (_minItems.Count == 0 || item.CompareTo(_minItems[^1]) <= 0)
            {
                _minItems.Add(item);
            }
        }

        public T? Pop()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Stack is empty.");

            var item = _items[^1];
            _items.RemoveAt(_items.Count - 1);

            if (item.CompareTo(_minItems[^1]) == 0)
            {
                _minItems.RemoveAt(_minItems.Count - 1);
            }

            return item;
        }

        public T? FindMin()
        {
            if (_minItems.Count == 0)
                throw new InvalidOperationException("Stack is empty.");

            return _minItems[^1];
        }

    }
}
