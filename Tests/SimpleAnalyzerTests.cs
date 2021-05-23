using NUnit.Framework;
using SpTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Tests {
    [TestFixture]
    public class SimpleAnalyzerTests : SimpleAnalyzerTestsBase {
        [Test]
        public void ProcessLine_Date() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            inputLine.Date = new DateTime(2021, 5, 22);

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 22), res.Date);
        }
        [Test]
        public void ProcessLine_Price() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            inputLine.Price = 55;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(55, res.Price);
        }
        [Test]
        public void ProcessLine_MaxPrice() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 150;
            inputLine.Price = 160;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(160, res.Price);
        }
        [Test]
        public void ProcessLine_MaxPriceDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 150;
            inputLine.Price = 160;
            inputLine.Date = new DateTime(2021, 5, 28);
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 28), res.MaxPriceDate);
        }
        [Test]
        public void ProcessLine_Drawdown() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 87.253;

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(12.747, res.PriceDrawdown);
        }
        [Test]
        public void ProcessLine_Drawdown_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 187.253;

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(0, res.PriceDrawdown);
        }
        [Test]
        public void ProcessLine_MaxDrawdown() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            prevResult.MaxPriceDrawdown = 4.12;
            inputLine.Price = 87.253;

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(12.747, res.MaxPriceDrawdown);
        }
        [Test]
        public void ProcessLine_MaxDrawdownDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            prevResult.MaxPriceDrawdown = 4.12;
            inputLine.Price = 87.253;

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 100);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 20), res.MaxPriceDrawdownDate);
        }
        [Test]
        public void ProcessLine_InputValue() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(77, res.InputValue);
        }
        [Test]
        public void ProcessLine_State0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 110;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(ResultState.S0, res.State);
        }
        [Test]
        public void ProcessLine_State0_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 95;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(ResultState.S0, res.State);
        }
        [Test]
        public void ProcessLine_State10() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 89;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(ResultState.S10, res.State);
        }
        [Test]
        public void ProcessLine_State20() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 75;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(ResultState.S20, res.State);
        }
        [Test]
        public void ProcessLine_State30() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            inputLine.Price = 54;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(ResultState.S30, res.State);
        }
        [Test]
        public void ProcessLine_IsStateChanged() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            prevResult.State = ResultState.S30;
            inputLine.Price = 54;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(false, res.IsStateDown);
        }
        [Test]
        public void ProcessLine_IsStateChanged_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            prevResult.State = ResultState.S20;
            inputLine.Price = 54;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(true, res.IsStateDown);
        }
        [Test]
        public void ProcessLine_IsStateChanged_2fromS10toS0() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem();
            var inputLine = CreateDataItem();
            prevResult.MaxPrice = 100;
            prevResult.State = ResultState.S10;
            inputLine.Price = 154;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 77);
            //assert
            Assert.AreEqual(false, res.IsStateDown);
        }
        [Test]
        public void ProcessLine_SharesChange() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(7, res.SharesChange);
        }
        [Test]
        public void ProcessLine_SharesAll() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 20;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(27, res.SharesAll);
        }
        [Test]
        public void ProcessLine_Result() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(11800, res.Result); //(sharesall+sharesinput)/price + reserveall+reserveinput
        }
        [Test]
        public void ProcessLine_MaxResult() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 5000;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(11800, res.MaxResult); 
        }
        [Test]
        public void ProcessLine_MaxResult_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 500000;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(500000, res.MaxResult); 
        }
        [Test]
        public void ProcessLine_MaxResultDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            inputLine.Date = new DateTime(2021, 5, 23);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 5000;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(new DateTime(2021,5,23), res.MaxResultDate); 
        }
        [Test]
        public void ProcessLine_MaxResultDate_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            inputLine.Date = new DateTime(2021, 5, 23);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 500000;
            prevResult.MaxResultDate = new DateTime(2021, 2, 4);
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(new DateTime(2021, 2, 4), res.MaxResultDate); 
        }
        [Test]
        public void ProcessLine_ResultDD() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 50000;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(38200, res.ResultDrawdown); 
        }
        [Test]
        public void ProcessLine_MaxResultDD() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 50000;
            prevResult.MaxResultDrawdown = 20000;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(38200, res.MaxResultDrawdown); 
        }
        [Test]
        public void ProcessLine_MaxResultDD_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 50000;
            prevResult.MaxResultDrawdown = 200000;
            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(200000, res.MaxResultDrawdown); 
        }
        [Test]
        public void ProcessLine_MaxResultDDDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);
            
            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 50000;
            prevResult.MaxResultDrawdown = 20000;
            prevResult.MaxResultDrawdownDate = new DateTime(2021, 4, 4);
            inputLine.Date = new DateTime(2021, 5, 22);

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 22), res.MaxResultDrawdownDate); 
        }
        [Test]
        public void ProcessLine_MaxResultDDDate_1() {
            //arrange
            var analyzer = CreateAnalyzer();
            var prevResult = CreateResultItem(100);
            var inputLine = CreateDataItem(100);

            prevResult.SharesAll = 100;
            prevResult.ReserveAll = 800;
            prevResult.MaxResult = 50000;
            prevResult.MaxResultDrawdown = 200000;
            prevResult.MaxResultDrawdownDate = new DateTime(2021, 4, 4);
            inputLine.Date = new DateTime(2021, 5, 22);

            //act
            var res = analyzer.ProcessLine(inputLine, prevResult, 1000);
            //assert
            Assert.AreEqual(new DateTime(2021, 4, 4), res.MaxResultDrawdownDate);
        }
    }
}
