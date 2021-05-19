using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class ResultItem {
        public ResultItem(DateTime _date, double _price) {
            Date = _date;
            Price = _price;
        }

        public DateTime Date{ get; set; }
        public double Price{ get; set; }

    }
}
