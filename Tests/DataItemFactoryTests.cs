using NUnit.Framework;
using SpTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Tests {
    [TestFixture]
  public  class DataItemFactoryTests {
        [Test]
        public void DataItemConstructor_Date() {
            //arrange
            var dtSt = "May 20";
            var vlSt = "3,044.31";
            var factory = new DataItemFactory();
            //act
            var item =factory.CreateDataItem(dtSt, vlSt);
            //assert
            Assert.AreEqual(new DateTime(2020, 5, 1), item.Date);
        }
        [Test]
        public void DataItemConstructor_Date1() {
            //arrange
            var dtSt = "Aug 98";
            var vlSt = "3,044.31";
            var factory = new DataItemFactory();
            //act
            var item = factory.CreateDataItem(dtSt, vlSt);
            //assert
            Assert.AreEqual(new DateTime(1998, 8, 1), item.Date);
        }
        [Test]
        public void DataItemConstructor_Value() {
            //arrange
            var dtSt = "Aug 98";
            var vlSt = "3,044.31";
            var factory = new DataItemFactory();
            //act
            var item = factory.CreateDataItem(dtSt, vlSt);
            //assert
            Assert.AreEqual(3044.31,item.Value);
        }
    }
}
