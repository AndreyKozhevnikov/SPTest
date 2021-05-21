using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    [TestFixture]
    class ResultToStringConverterTests {
        ResultToStringConverter CreateConverter() {
            return new ResultToStringConverter();
        }
        ResultItem CreateSimpleItem() {
            var item = new ResultItem(new DateTime(2021, 5, 19), 456.1);
            item.MaxPrice = 1.2;
            item.MaxPriceDate = new DateTime(2021, 5, 20);
            item.Result = 2.2;
            item.MaxResult = 3.3;
            item.MaxResultDate = new DateTime(2021, 5, 21);
            item.Drawdown = 4.4;
            item.MaxDrawdown = 5.5;
            item.MaxDrawdownDate = new DateTime(2021, 5, 22);
            item.InputValue = 44;
            item.State = ResultState.S20;
            item.IsStateChanged = true;
            item.SharesCount = 3;
            item.AddedShares = 4;
            item.CashAmount = 6.6;
            item.DiffFromMaxPricePercent = 7.7;
            return item;
        }
        [Test]
        public void ConvertItem() {
            //arrange
            var conv = CreateConverter();
            var item = CreateSimpleItem();

            //act
            var res = conv.ConvertResult(item);
            //assert
            Assert.AreEqual("05/19/2021;456.1;1.2;05/20/2021;2.2;3.3;05/21/2021;4.4;5.5;05/22/2021;44;S20;1;3;4;6.6;7.7", res);
        }
        [Test]
        public void ConvertItemList() {
            //arrange
            var conv = CreateConverter();
            var item = CreateSimpleItem();
            var item2 = CreateSimpleItem();
            item2.Date = new DateTime(2022, 4, 3);
            var lst = new List<ResultItem>();
            lst.Add(item);
            lst.Add(item2);
            //act
            var res = conv.ConvertResultList(lst);
            //assert
            List<String> resV = new List<string>();
            resV.Add("Date");
            resV.Add("Price");
            resV.Add("MaxPrice");
            resV.Add("MaxPriceDate");
            resV.Add("Result");
            resV.Add("MaxResult");
            resV.Add("MaxResultDate");
            resV.Add("Drawdown");
            resV.Add("MaxDrawdown");
            resV.Add("MaxDrawdownDate");
            resV.Add("InputValue");
            resV.Add("State");
            resV.Add("IsStateChanged");
            resV.Add("SharesCount");
            resV.Add("AddedShares");
            resV.Add("CashAmount");
            resV.Add("DiffFromMaxPricePercent");
            
            string resItem = string.Join(";", resV);
            var expect = new List<string>();
            expect.Add(resItem);
            expect.Add("05/19/2021;456.1;1.2;05/20/2021;2.2;3.3;05/21/2021;4.4;5.5;05/22/2021;44;S20;1;3;4;6.6;7.7");
            expect.Add("04/03/2022;456.1;1.2;05/20/2021;2.2;3.3;05/21/2021;4.4;5.5;05/22/2021;44;S20;1;3;4;6.6;7.7");
            Assert.AreEqual(expect, res);
        }
    }
}
