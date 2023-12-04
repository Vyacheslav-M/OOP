using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class Contact
    {
        DateTime _beginDt = DateTime.Now;
        DateTime? _endDt = null;
        string _descr;
        string _dataInfo;
        ContType _tpy;
        public DateTime BeginDt
        {
            get { return _beginDt; }
            set { _beginDt = value; }
        }
        public ContType CntType
        {
            get { return _tpy; }
            set { _tpy = value; }
        }
        public string DataInfo
        {
            get { return _dataInfo; }
            set { _dataInfo = value; }
        }
        public string Descr
        {
            get { return _descr; }
            set { _descr ??= value; }
        }
        public DateTime? EndDt
        {
            get { return _endDt; }
            set { _endDt = value; }
        }
        public Contact Clone()
        {
            return new Contact(_descr, _dataInfo, _tpy);
        }
        public Contact(string descr, string dataInfo, ContType contType, DateTime? beginDate = null, DateTime? endDate = null) 
        {
            BeginDt = beginDate ?? default;
            EndDt = endDate;
            _descr = descr;
            _dataInfo = dataInfo;
            _tpy = contType;
        }

        public static bool operator ==(Contact left, Contact right)
        {
            return
                (left.Descr, left.CntType.Name, left.CntType.Note, left.DataInfo)
                == (right.Descr, right.CntType.Name, right.CntType.Note, right.DataInfo);
        }

        public static bool operator !=(Contact left, Contact right)
        {
            return !(left == right);
        }
    }
}
