using SpTest.Classes;
using System;

namespace SpTest.Tests {
    public class SimpleAnalyzerTestsBase {
       public SimpleAnalyzer CreateAnalyzer() {
            var s = new SimpleAnalyzer();
            return s;
        }
        public ResultItem CreateResultItem(double price) {
            var r = new ResultItem(new DateTime(2021, 5, 20), price);
            return r;
        }
        public DataItem CreateDataItem(double price) {
            var d = new DataItem(new DateTime(2021, 5, 20), price);
            return d;
        }
        public ResultItem CreateResultItem() {
            var r = new ResultItem(new DateTime(2021, 5, 20), 10);
            return r;
        }

        public DataItem CreateDataItem() {
            var d = new DataItem(new DateTime(2021, 5, 20), 10);
            return d;
        }
    }
}
