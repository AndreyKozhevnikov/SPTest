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
            item.DrawDown = 4.4;
            item.MaxDrawDown = 5.5;
            item.MaxDrawDownDate = new DateTime(2021, 5, 22);
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
            var expect = "05/19/2021;456.1;1.2;05/20/2021;2.2;3.3;05/21/2021;4.4;5.5;05/22/2021;44;S20;1;3;4;6.6;7.7" + Environment.NewLine +
                "04/03/2022;456.1;1.2;05/20/2021;2.2;3.3;05/21/2021;4.4;5.5;05/22/2021;44;S20;1;3;4;6.6;7.7";
            Assert.AreEqual(expect, res);
        }
    }
}
