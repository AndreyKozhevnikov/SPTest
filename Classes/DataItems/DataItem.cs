using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    [DebuggerDisplay("Date: {Date}")]
    public class DataItem {
        public DataItem(DateTime _date, double _value) {
            Date = _date;
            Price = _value;
        }

        public DateTime Date{ get; set; }
        public double Price{ get; set; }
    }
}
