using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class SbFirmTypeCol : IEnumerable
    {
        List<SbFirmType> _lst = new List<SbFirmType>();
        public int Count
        {
            get { return _lst.Count; }
        }
        public void Add(SbFirmType type)
        {
            _lst.Add(type);
        }
        public void Clear()
        {
            _lst.Clear();
        }
        public SbFirmTypeCol(List<SbFirmType> sbFirmTypes)
        {
            _lst = sbFirmTypes;
        }
        public IEnumerator GetEnumerator() => _lst.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
