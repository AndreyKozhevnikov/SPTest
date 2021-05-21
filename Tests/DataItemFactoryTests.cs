using NUnit.Framework;
using SpTest.Classes;
using SpTest.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Tests {
    [TestFixture]
  public  class DataItemFactoryTests {

        DataItemFactory CreateFactory() {
            return new DataItemFactory();
        }
        [Test]
        public void DataItemConstructor_Date() {
            //arrange
            var dtSt = "\"May 20\"";
            var vlSt = "\"4,173.85\"";
            var factory = new DataItemFactory();
            //act
            var item =factory.CreateDataItem(dtSt, vlSt);
            //assert
            Assert.AreEqual(new DateTime(2020, 5, 1), item.Date);
        }
        [Test]
        public void DataItemConstructor_Date1() {
            //arrange
            var dtSt = "\"Aug 98\"";
            var vlSt = "\"3,044.31\"";
            var factory = new DataItemFactory();
            //act
            var item = factory.CreateDataItem(dtSt, vlSt);
            //assert
            Assert.AreEqual(new DateTime(1998, 8, 1), item.Date);
        }
        [Test]
        public void DataItemConstructor_Value() {
            //arrange
            var dtSt = "\"Aug 98\"";
            var vlSt = "\"3,044.31\"";
            var factory = new DataItemFactory();
            //act
            var item = factory.CreateDataItem(dtSt, vlSt);
            //assert
            Assert.AreEqual(3044.31,item.Price);
        }
        [Test]
        public void CreateFromString_1() {
            //arrange
            var line= "\"Date\",\"Price\",\"Open\",\"High\",\"Low\",\"Vol.\",\"Change %\"";
            var factory = CreateFactory();
            //act
            var res = factory.CreateDataItemFromString(line);
            //assert
            Assert.AreEqual(null, res);
        }
        [Test]
        public void CreateFromString_2() {
            //arrange
            var line = "\"May 21\",\"4,173.85\",\"4,203.93\",\"4,238.60\",\"4,057.70\",\"-\",\"-0.18%\"";
            var factory = CreateFactory();
            //act
            DataItem res = factory.CreateDataItemFromString(line);
            //assert
            Assert.AreEqual(new DateTime(2021,5,1), res.Date);
            Assert.AreEqual(4173,85, res.Price);
        }
        [Test]
        public void CreateDataItemFromStrings() {
            //arrange
            var lines = Resources.TextFile1;

            var factory = CreateFactory();
            //act
            List<DataItem> res = factory.CreateListDataItemsFromString(lines);
            //assert
            Assert.AreEqual(2, res.Count);
            Assert.Greater(res[1].Date, res[0].Date);
        }
    }
}
