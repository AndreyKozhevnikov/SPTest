using NUnit.Framework;
using SpTest.Classes;
using System;

namespace SpTest.Tests {
    [TestFixture]
    public class SharesReserveChangedTests {
        SimpleAnalyzer CreateAnalyzer() {
            var s = new SimpleAnalyzer();
            return s;
        }
        ResultItem CreateResultItem(double price) {
            var r = new ResultItem(new DateTime(2021, 5, 20), price);
            return r;
        }
        DataItem CreateDataItem(double price) {
            var d = new DataItem(new DateTime(2021, 5, 20), price);
            return d;
        }
        #region S0
        [Test]
        public void ProcessLine_SharesAdded_S0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(9);
            var inputLine = CreateDataItem(10);
            currentItem.MaxPrice = 9;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 500);
            //assert
            Assert.AreEqual(35, res.AddedShares);
        }
        [Test]
        public void ProcessLine_SharesAdded_S0_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 105;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(35, res.AddedShares);
        }
        [Test]
        public void ProcessLine_ReserveChange_S0_0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(9);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 90;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(1500, res.ReserveChange);
        }
        [Test]
        public void ProcessLine_ReserveChange_S0_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(9);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 105;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(1500, res.ReserveChange);
        }
        #endregion
        #region S10
        [Test]
        public void ProcessLine_SharesAdded_S10_plain() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 115;
            currentItem.State = ResultState.S10;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(40, res.AddedShares);
        }
        [Test]
        public void ProcessLine_ReserveChange_S10_plain() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 115;
            currentItem.State = ResultState.S10;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(1000, res.ReserveChange);
        }
        [Test]
        public void ProcessLine_SharesAdded_S10_changeFromS0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 115;
            currentItem.State = ResultState.S0;
            currentItem.ReserveAll = 3334;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(50, res.AddedShares);
        }
        [Test]
        public void ProcessLine_ReserveChange_S10_changeFromS0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 115;
            currentItem.State = ResultState.S0;
            currentItem.ReserveAll = 3334;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(-1, Math.Floor(res.ReserveChange));
        }
        #endregion
        #region S20
        [Test]
        public void ProcessLine_SharesAdded_S20_plain() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 130;
            currentItem.State = ResultState.S20;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(45, res.AddedShares);
        }
        [Test]
        public void ProcessLine_ReserveChange_S20_plain() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 130;
            currentItem.State = ResultState.S20;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(500, res.ReserveChange);
        }
        #endregion
        #region S30
        [Test]
        public void ProcessLine_SharesAdded_S30_plain() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 150;
            currentItem.State = ResultState.S30;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(50, res.AddedShares);
        }
        [Test]
        public void ProcessLine_ReserveChange_S30_plain() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            currentItem.MaxPrice = 150;
            currentItem.State = ResultState.S30;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(0, res.ReserveChange);
        }
        #endregion
        [Test]
        public void ProcessLine_SharesCount() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(9);
            var inputLine = CreateDataItem(100);
            currentItem.SharesCount = 20;
            currentItem.MaxPrice = 90;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(55, res.SharesCount);
        }

        [Test]
        public void ProcessLine_ReserveAll() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem(9);
            var inputLine = CreateDataItem(100);
            currentItem.ReserveAll = 20;
            currentItem.MaxPrice = 90;
            //act
            var res = analyzer.ProcessLine(inputLine, currentItem, 5000);
            //assert
            Assert.AreEqual(1520, res.ReserveAll);
        }
    }
}
