using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class ResultToStringConverter {
        public string ConvertResult(ResultItem item) {
            MyStringList list = new MyStringList();
            list.Add(item.Date);
            list.Add(item.Price);
            list.Add(item.MaxPrice);
            list.Add(item.MaxPriceDate);
            list.Add(item.Result);
            list.Add(item.MaxResult);
            list.Add(item.MaxResultDate);
            list.Add(item.DrawDown);
            list.Add(item.MaxDrawDown);
            list.Add(item.MaxDrawDownDate);
            list.Add(item.InputValue);
            list.Add(item.State);
            list.Add(item.IsStateChanged);
            list.Add(item.SharesCount);
            list.Add(item.AddedShares);
            list.Add(item.CashAmount);
            list.Add(item.DiffFromMaxPricePercent);
            return string.Join(";", list);
        }
        public string GetStringFromDate(DateTime dt) {
            return dt.ToString("MM/dd/yyyy");
        }
        public string ConvertResultList(List<ResultItem> items) {
            string result = string.Join(Environment.NewLine, items.Select(x => this.ConvertResult(x)));
            return result;
        }
    }
}
