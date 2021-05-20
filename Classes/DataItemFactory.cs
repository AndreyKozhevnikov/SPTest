using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
  public  class DataItemFactory {
        public DataItem CreateDataItem(string _date, string _value) {
            var dts = _date.Replace("\"","").Split(' ');
            var dtMonth = dts[0];
            var dtYear = dts[1];
            var newSt = string.Format("01-{0}-{1}", dtMonth, dtYear);
            var newDate = DateTime.Parse(newSt);
            _value = _value.Replace("\"", "");
            double newValue = Double.Parse(_value);
            return new DataItem(newDate, newValue);
        }
        public DataItem CreateDataItemFromString(string line) {
            line = line.Replace("\",\"", "\";\"");
            var values = line.Split(';');
            var dt = values[0];
            var vl = values[1];
            if(dt == "\"Date\"") {
                return null;
            }
            return CreateDataItem(dt, vl);
        }
    }
}
