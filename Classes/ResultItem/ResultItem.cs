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

        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double MaxPrice { get; set; }
        public DateTime MaxPriceDate { get; set; }
        public double PriceDrawdown { get; set; }
        public double MaxPriceDrawdown { get; set; }
        public DateTime MaxPriceDrawdownDate { get; set; }
        public double InputValue { get; set; }
        public ResultState State { get; set; }
        public bool IsStateDown { get; set; }
        public double ReserveAll { get; set; }
        public double ReserveChange { get; set; }
        public int SharesCount { get; set; }
        public int AddedShares { get; set; }
        public double Result { get; set; }
        public double MaxResult { get; set; }
        public DateTime MaxResultDate { get; set; }
        public double ResultDrawdown { get; set; }
        public double MaxResultDrawdown { get; set; }
        public DateTime MaxResultDrawdownDate { get; set; }

    }
}
