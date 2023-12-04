using System;
using System.Collections.Generic;
using System.Text;

namespace oop_lr1
{
    public class FirmFactory
    {
        private static FirmFactory factory;
        private FirmFactory() { }
        public static List<Firm> Firms { get; private set; } = new List<Firm>();
        public static SbFirmType MainSubFirmType { get; } = new SbFirmType(true, "Основной офис");

        public static FirmFactory Factory
        {
            get
            {
                if (factory == null) factory = new FirmFactory();
                return factory;
            }
        }
        public Firm Create(string country, string email, string name, string shname, string postInd, string region, string street, string town, string web, Dictionary<string, string>? fields = null)
        {
            Firm firm = new Firm(country, email, name, shname, postInd, region, street, town, web, fields);
            firm.AdSbFirm(new SubFirm("bossName", "email", "name", "ofcbossName", "phone", MainSubFirmType));
            Firms.Add(firm);
            return firm;
        }
    }
}
