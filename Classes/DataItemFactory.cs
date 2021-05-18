using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
  public  class DataItemFactory {
        public DataItem CreateDataItem(string _date, string _value) {
            var dts = _date.Split(' ');
            var dtMonth = dts[0];
            var dtYear = dts[1];
            var newSt = string.Format("01-{0}-{1}", dtMonth, dtYear);
            var newDate = DateTime.Parse(newSt);
            double value = Double.Parse(_value);
            return new DataItem(newDate, value);
        }
    }
}
