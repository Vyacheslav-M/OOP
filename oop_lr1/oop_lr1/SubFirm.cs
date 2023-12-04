using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class SubFirm
    {
        string _bossName;
        string _email;
        string _name;
        string _ofcBossName;
        string _tel;
        SbFirmType _tpy;
        public List<Contact> Conts;
        public string BossName
        {
            get { return _bossName; }
            set { _bossName = value; }
        }
        public int CountCont
        {
            get { return Conts.Count; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public bool IsMain
        {
            get { return _tpy.IsMain; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string OfcBossName
        {
            get { return _ofcBossName; }
            set { _ofcBossName = value; }
        }
        public SbFirmType SbFirmTpy
        {
            get { return _tpy; }
            set { _tpy = value; }
        }
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public SubFirm(string bossName, string email, string name, string ofcbossName, string tel, SbFirmType sbFirmType) 
        {
            _bossName = bossName;
            _email = email;
            _name = name;
            _ofcBossName = ofcbossName;
            _tel = tel;
            Conts = new List<Contact>();
            _tpy = sbFirmType;
        }
        public void AddCont(Contact cont) 
        {
            Conts.Add(cont.Clone()); 
        }
        public bool ExistContact(Contact cont)
        {
            return Conts.Exists(x => x == cont);
        }
        public bool IsYourType(SbFirmType type) 
        {
            return SbFirmTpy.Name == type.Name;
        }
    }
}
