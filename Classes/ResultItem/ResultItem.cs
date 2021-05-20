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

        public static List<String> PropertyNames {
            get {
                List<String> res = new List<string>();
                res.Add("Date");
                res.Add("Price");
                res.Add("MaxPrice");
                res.Add("MaxPriceDate");
                res.Add("MaxResult");
                res.Add("MaxResultDate");
                res.Add("DrawDown");
                res.Add("MaxDrawDown");
                res.Add("MaxDrawDownDate");
                res.Add("InputValue");
                res.Add("State");
                res.Add("IsStateChanged");
                res.Add("SharesCount");
                res.Add("AddedShares");
                res.Add("CashAmount");
                res.Add("DiffFromMaxPricePercent");
                res.Add("Result");
                return res;
            }
        }

        public DateTime Date{ get; set; }
        public double Price{ get; set; }
        public double MaxPrice { get; set; }
        public DateTime MaxPriceDate{ get; set; }
        public double MaxResult{ get; set; }
        public DateTime MaxResultDate{ get; set; }
        public double DrawDown{ get; set; }
        public double MaxDrawDown{ get; set; }
        public DateTime MaxDrawDownDate{ get; set; }
        public double InputValue{ get; set; }
        public ResultState State{ get; set; }
        public bool IsStateChanged{ get; set; }
        public int SharesCount{ get; set; }
        public int AddedShares{ get; set; }
        public double CashAmount{ get; set; }
        public double DiffFromMaxPricePercent{ get; set; }
        public double Result{ get; set; }

    }
}
