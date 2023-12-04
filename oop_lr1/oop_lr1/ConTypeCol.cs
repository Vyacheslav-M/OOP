using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class ConTypeCol : IEnumerable
    {
        List<ContType> _lst = new List<ContType>();
        public int Count
        {
            get { return _lst.Count; }
        }
        public void Add(ContType type)
        {
            _lst.Add(type);
        }
        public void Clear()
        {
            _lst.Clear();
        }
        public ConTypeCol(List<ContType> contTypes) 
        {
            _lst = contTypes;
        }
        public IEnumerator GetEnumerator() => _lst.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
