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
        public void ProcessLineDate() {
            //arrange
            var analyzer = CreateAnalyzer();
            var currentItem = CreateResultItem();
            var intputLine = CreateDataItem();
            intputLine.Date = new DateTime(2021, 5, 22);

            //act
            var res = analyzer.ProcessLine(intputLine, currentItem, 100);
            //assert
            Assert.AreEqual(new DateTime(2021, 5, 22), res.Date);
        }
    }
}
