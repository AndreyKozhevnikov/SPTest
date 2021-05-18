using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
   public class DataItem {
        public DataItem(DateTime _date, double _value) {
            Date = _date;
            Value = _value;
        }

        public DateTime Date{ get; set; }
        public double Value{ get; set; }
    }
}
