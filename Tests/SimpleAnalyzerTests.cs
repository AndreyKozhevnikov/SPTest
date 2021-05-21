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
            var r = new ResultItem(new DateTime(2021, 5, 20),10);
            return r;
        }
        DataItem CreateDataItem() {
            var d = new DataItem(new DateTime(2021, 5, 20), 10);
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
        [Test]
        public void ProcessLine_Drawdown() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 87.253;
            
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(12.747, res.PriceDrawdown);
        }
        [Test]
        public void ProcessLine_Drawdown_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 187.253;

            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(0, res.PriceDrawdown);
        }
        [Test]
        public void ProcessLine_MaxDrawdown() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            currentItem.MaxPriceDrawdown = 4.12;
            inputLine.Price = 87.253;

            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(12.747, res.MaxPriceDrawdown);
        }
        [Test]
        public void ProcessLine_MaxDrawdownDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            currentItem.MaxPriceDrawdown = 4.12;
            inputLine.Price = 87.253;

            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 100);
            //assert
            Assert.AreEqual(new DateTime(2021,5,20), res.MaxPriceDrawdownDate);
        }
        [Test]
        public void ProcessLine_InputValue() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(77, res.InputValue);
        }
        [Test]
        public void ProcessLine_State0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 110;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(ResultState.S0, res.State);
        }
        [Test]
        public void ProcessLine_State0_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 95;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(ResultState.S0, res.State);
        }
        [Test]
        public void ProcessLine_State10() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 89;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(ResultState.S10, res.State);
        }
        [Test]
        public void ProcessLine_State20() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 75;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(ResultState.S20, res.State);
        }
        [Test]
        public void ProcessLine_State30() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            inputLine.Price = 54;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(ResultState.S30, res.State);
        }
        [Test]
        public void ProcessLine_IsStateChanged() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            currentItem.State = ResultState.S30;
            inputLine.Price = 54;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(false, res.IsStateChanged);
        }
        [Test]
        public void ProcessLine_IsStateChanged_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            currentItem.State = ResultState.S20;
            inputLine.Price = 54;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(true, res.IsStateChanged);
        }
        [Test]
        public void ProcessLine_IsStateChanged_2() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var inputLine = CreateDataItem();
            currentItem.MaxPrice = 100;
            currentItem.State = ResultState.S10;
            inputLine.Price = 154;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 77);
            //assert
            Assert.AreEqual(true, res.IsStateChanged);
        }
    }
}
