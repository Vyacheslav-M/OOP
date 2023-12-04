using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oop_lr1
{
    public class Firm
    {
        string _country;
        DateTime _dateIn;
        string _email;
        string _name;
        string _shname;
        string _postInx;
        string _region;
        string _street;
        string _town;
        string _web;
        public List<SubFirm> SbFirms;
        public Dictionary<string, string> UserFields;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public DateTime DateIn
        {
            get { return _dateIn; }
            set { _dateIn = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string ShName
        {
            get { return _shname; }
            set { _shname = value; }
        }
        public string PostInx
        {
            get { return _postInx; }
            set { _postInx = value; }
        }
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        public int SbFirmsCount
        {
            get { return SbFirms.Count; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }
        public string Web
        {
            get { return _web; }
            set { _web = value; }
        }
        public Firm(string country, string email, string name, string shname, string postInd, string region, 
                    string street, string town, string web, Dictionary<string, string>? fields = null)
        {
            _country = country;
            _dateIn = DateTime.Now;
            _email = email;
            _name = name;
            _shname = shname;
            _postInx = postInd;
            _region = region;
            _street = street;
            _town = town;
            SbFirms = new List<SubFirm>();
            _web = web;
            if (UserFields == null) UserFields = new Dictionary<string, string>(fields);
            UserFields = fields;
        }
        public void AddCont(Contact cont) 
        {
            SubFirm mainSubFirm = SbFirms.SingleOrDefault(x => x.SbFirmTpy.IsMain);
            if (mainSubFirm != null)
            {
                mainSubFirm.AddCont(cont);
            }
        }
        public void AddContSbFirm(Contact cont, SbFirmType sbFirmType, bool oneDvivsion = false) 
        {
            SubFirm subFirm = SbFirms.FirstOrDefault(x => x.SbFirmTpy == sbFirmType);
            if (subFirm != null)
            {
                subFirm.AddCont(cont);
                return;
            }
            if(SbFirms.Count == 1 && oneDvivsion)
            {
                SubFirm mainSubFirm = SbFirms.SingleOrDefault(x => x.SbFirmTpy.IsMain);
                AddCont(cont);
            }
        }
        public void AddField(string key, string field)
        {
            UserFields.Add(key, field);
        }
        public void AdSbFirm(SubFirm subFirm)
        {
            SbFirms.Add(subFirm);
        }
        public bool ExistContact(Contact cont) 
        {
            return SbFirms.Exists(sb => sb.ExistContact(cont));
        }
        public string GetField(string key)
        {
            return UserFields[key];
        }
        public SubFirm GetMain() 
        {
            return SbFirms.First(x => x.SbFirmTpy.IsMain);
        }
        public void RenameField(string oldName, string newName)
        {
            var temp = UserFields[oldName];
            UserFields.Remove(oldName);
            UserFields.Add(newName, temp);

        }
        public void SetField(string key, string field)
        {
            UserFields[key] = field;
        }
    }
}
