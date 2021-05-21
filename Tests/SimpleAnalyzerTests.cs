using NUnit.Framework;
using SpTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Tests {
    [TestFixture]
    public class SimpleAnalyzerTests {
        ResultItem CreateResultItem() {
            var r = new ResultItem(new DateTime(2021, 5, 20),100);
            return r;
        }
        DataItem CreateDataItem() {
            var d = new DataItem(new DateTime(2021, 5, 20), 100);
            return d;
        }
        SimpleAnalyzer CreateAnalyzer() {
            var s = new SimpleAnalyzer();
            return s;
        }
        [Test]
        public void ProcessLine_Date() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            inputLine.Date = new DateTime(2021, 5, 22);

            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 22), res.Date);
        }
        [Test]
        public void ProcessLine_Price() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            inputLine.Price = 55;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(55, res.Price);
        }
        [Test]
        public void ProcessLine_MaxPrice() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 150;
            inputLine.Price = 160;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(160, res.Price);
        }
        [Test]
        public void ProcessLine_MaxPriceDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 150;
            inputLine.Price = 160;
            inputLine.Date = new DateTime(2021, 5, 28);
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 28), res.MaxPriceDate);
        }
    }
}
