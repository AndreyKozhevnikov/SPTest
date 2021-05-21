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
        public double MaxResult { get; set; }
        public DateTime MaxResultDate { get; set; }
        public double Drawdown { get; set; }
        public double MaxDrawdown { get; set; }
        public DateTime MaxDrawdownDate { get; set; }
        public double InputValue { get; set; }
        public ResultState State { get; set; }
        public bool IsStateChanged { get; set; }
        public int SharesCount { get; set; }
        public int AddedShares { get; set; }
        public double ReserveAmount { get; set; }
        public double SpentReserve { get; set; }
        public double DiffFromMaxPricePercent { get; set; }
        public double Result { get; set; }

    }
}
