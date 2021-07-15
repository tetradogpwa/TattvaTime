using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TattvaTime;

namespace TattvaTimeUnitTest
{
    [TestClass]
    public class TestTattva
    {
        
        [TestMethod]
        public void TestGetTattvaFromDateTime1()
        {
            TestTattvaFromDateTime(2021, 7, 15, 10, 2,15, Tattva.Name.Prithivi, Tattva.Name.Akasha);
        }
        [TestMethod]
        public void TestGetTattvaFromDateTime2()
        {
            TestTattvaFromDateTime(2021, 7, 15, 10, 6,55, Tattva.Name.Prithivi, Tattva.Name.Vayu);
        }
        [TestMethod]
        public void TestGetTattvaFromDateTime3()
        {
            TestTattvaFromDateTime(2021, 7, 15, 10, 12,0, Tattva.Name.Prithivi, Tattva.Name.Tejas);
        }
        [TestMethod]
        public void TestGetTattvaFromDateTime4()
        {
            TestTattvaFromDateTime(2021, 7, 15, 10, 22,0, Tattva.Name.Prithivi, Tattva.Name.Prithivi);
        }
        [TestMethod]
        public void TestGetTattvaFromDateTime5()
        {
            TestTattvaFromDateTime(2021, 7, 15, 10, 26,22, Tattva.Name.Akasha, Tattva.Name.Akasha);
        }
        public void TestTattvaFromDateTime(int year,int month,int day,int hour,int minute,int second,Tattva.Name tattvaName,Tattva.Name subTattvaName)
        {
            const double LAT = 41.7833, LON = 3.0333;
            DateTime date = new DateTime(year, month, day, hour, minute, second, 0);
            Tattva tattva = new Tattva(date, LAT, LON);
            Assert.IsTrue(tattva.TattvaName.Equals(tattvaName) && tattva.SubTattvaName.Equals(subTattvaName));
        }
    }
}
