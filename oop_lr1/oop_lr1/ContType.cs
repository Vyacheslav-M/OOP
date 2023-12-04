using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class ContType
    {
        string _name;
        string _note;
        public ContType(string name, string note)
        {
            _name = name;
            _note = note;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
    }
}
