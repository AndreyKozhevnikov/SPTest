using NUnit.Framework;
using SpTest.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Tests {
    [TestFixture]
    class ResultToStringConverterTests {
        ResultToStringConverter CreateConverter() {
            return new ResultToStringConverter();
        }
        ResultItem CreateSimpleItem() {
            var item = new ResultItem(new DateTime(2021, 5, 19), 456.1);
            item.MaxPrice = 1.2;
            item.MaxPriceDate = new DateTime(2021, 5, 20);
            item.PriceDrawdown = 4.4;
            item.MaxPriceDrawdown = 5.5;
            item.MaxPriceDrawdownDate = new DateTime(2021, 5, 22);
            item.InputValue = 44;
            item.State = ResultState.S20;
            item.IsStateChanged = true;
            item.SharesCount = 3;
            item.AddedShares = 4;
            item.ReserveAll = 6.6;
            item.ReserveChange = 8.8;
            item.Result = 2.2;
            item.MaxResult = 3.3;
            item.MaxResultDate = new DateTime(2021, 5, 21);
            item.ResultDrawdown = 9.9;
            item.MaxResultDrawdown = 2.3;
            item.MaxResultDrawdownDate = new DateTime(2021, 6, 6);

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
            Assert.AreEqual("05/19/2021;456.1;1.2;05/20/2021;4.4;5.5;05/22/2021;44;S20;1;6.6;8.8;3;4;2.2;3.3;05/21/2021;9.9;2.3;06/06/2021", res);
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
            resV.Add("PriceDrawdown");
            resV.Add("MaxPriceDrawdown");
            resV.Add("MaxPriceDrawdownDate");
            resV.Add("InputValue");
            resV.Add("State");
            resV.Add("IsStateChanged");
            resV.Add("ReserveAll");
            resV.Add("ReserveChange");
            resV.Add("SharesCount");
            resV.Add("AddedShares");
            resV.Add("Result");
            resV.Add("MaxResult");
            resV.Add("MaxResultDate");
            resV.Add("ResultDrawdown");
            resV.Add("MaxResultDrawdown");
            resV.Add("MaxResultDrawdownDate");
            string resItem = string.Join(";", resV);
            var expect = new List<string>();
            expect.Add(resItem);
            expect.Add("05/19/2021;456.1;1.2;05/20/2021;4.4;5.5;05/22/2021;44;S20;1;6.6;8.8;3;4;2.2;3.3;05/21/2021;9.9;2.3;06/06/2021");
            expect.Add("04/03/2022;456.1;1.2;05/20/2021;4.4;5.5;05/22/2021;44;S20;1;6.6;8.8;3;4;2.2;3.3;05/21/2021;9.9;2.3;06/06/2021");
            Assert.AreEqual(expect, res);
        }
    }
}
