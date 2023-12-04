using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class SbFirmType
    {
        bool _isMain;
        string _name;
        public SbFirmType(bool isMain, string name)
        {
            _isMain = isMain;
            _name = name;
        }
        public bool IsMain
        {
            get { return _isMain; }
            set { _isMain = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
