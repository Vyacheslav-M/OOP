using Microsoft.VisualStudio.TestTools.UnitTesting;
using oop_lr1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        Dictionary<string, string> userFields = new Dictionary<string, string>()
        {
            {"key1", "value1"},
            {"key2", "value2"},
            {"key3", "value3"},
            {"key4", "value4"},
            {"key5", "value5"},
        };

        [TestMethod]
        public void TestCreateFirm()
        {
            Firm firm = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);

            Assert.IsNotNull(firm);
            Assert.IsTrue(FirmFactory.Firms.Count > 0);
            Assert.AreEqual("country", firm.Country);
            Assert.AreEqual("email", firm.Email);
            Assert.AreEqual("name", firm.Name);
            Assert.AreEqual("shname", firm.ShName);
            Assert.AreEqual("postInd", firm.PostInx);
            Assert.AreEqual("region", firm.Region);
            Assert.AreEqual("street", firm.Street);
            Assert.AreEqual("town", firm.Town);
            Assert.AreEqual("web", firm.Web);
            Assert.AreEqual(userFields, firm.UserFields);
        }

        [TestMethod]
        public void TestGetList()
        {
            FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "Нижний Новгород", "web", userFields);
            FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "Бор", "web", userFields);
            FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "Нижний Новгород", "web", userFields);

            var firmsNN = FirmFactory.Firms.Where(x => x.Town == "Нижний Новгород").ToList();

            Assert.IsNotNull(firmsNN);
            Assert.IsTrue(firmsNN.All(x => x.Town == "Нижний Новгород"));
            Assert.IsTrue(firmsNN.Count == 2);
        }

        [TestMethod]
        public void TestAddContact()
        {
            ContType contType = new ContType("email", "Письмо послали");
            Contact cont = new Contact("descr", "dataInfo", contType);

            Firm firm1 = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);
            Firm firm2 = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);
            Firm firm3 = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);

            List<Firm> firmsForContact = new List<Firm>();
            firmsForContact.Add(firm1);
            firmsForContact.Add(firm2);

            foreach (var firm in firmsForContact)
            {
                firm.AddCont(cont);
            }

            foreach (var firm in firmsForContact)
            {
                Assert.IsTrue(firm.ExistContact(cont));
            }
            Assert.IsFalse(firm3.ExistContact(cont));
        }

        [TestMethod]
        public void TestAddContactSubFirm()
        {
            ContType contType = new ContType("email", "Коммерческое предложение");
            Contact cont = new Contact("descr", "dataInfo", contType);
            SbFirmType SupplyDepartment = new SbFirmType(false, "Отдел снабжения");

            Firm firm1 = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);
            Firm firm2 = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);
            Firm firm3 = FirmFactory.Factory.Create("country", "email", "name", "shname", "postInd", "region", "street", "town", "web", userFields);

            SubFirm subFirm = new SubFirm("bossName", "email", "name", "ofcbossName", "phone", SupplyDepartment);
            firm1.AdSbFirm(subFirm);
            firm3.AdSbFirm(subFirm);

            List<Firm> AllFirms = FirmFactory.Firms;
            foreach (var firm in AllFirms)
            {
                firm.AddContSbFirm(cont, SupplyDepartment);
            }

            Assert.IsTrue(firm1.ExistContact(cont));
            Assert.IsFalse(firm2.ExistContact(cont));
            Assert.IsTrue(firm3.ExistContact(cont));

            firm2.AddContSbFirm(cont, SupplyDepartment, true);
            Assert.IsTrue(firm2.SbFirmsCount == 1);
            Assert.IsTrue(firm2.ExistContact(cont));
        }
    }
}
