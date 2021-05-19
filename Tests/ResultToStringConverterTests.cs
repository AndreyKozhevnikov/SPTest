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
        [Test]
        public void ConvertItem() {
            //arrange
            var conv = CreateConverter();
            var item = new ResultItem(new DateTime(2021, 5, 19), 456.1);
            //act
            var res = conv.ConvertResult(item);
            //assert
            Assert.AreEqual("05/19/2021;456.1", res);
        }
        [Test]
        public void ConvertItemList() {
            //arrange
            var conv = CreateConverter();
            var item = new ResultItem(new DateTime(2021, 5, 19), 456.1);
            var item2 = new ResultItem(new DateTime(2021, 5, 20), 457.1);
            var lst = new List<ResultItem>();
            lst.Add(item);
            lst.Add(item2);
            //act
            var res = conv.ConvertResultList(lst);
            //assert
            var expect = "05/19/2021;456.1" + Environment.NewLine + "05/20/2021;457.1";
            Assert.AreEqual(expect, res);
        }
    }
}
