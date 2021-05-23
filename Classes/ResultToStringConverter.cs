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
            list.Add(item.PriceDrawdown);
            list.Add(item.MaxPriceDrawdown);
            list.Add(item.MaxPriceDrawdownDate);
            list.Add(item.InputValue);
            list.Add(item.State);
            list.Add(item.IsStateDown);
            list.Add(item.ReserveAll);
            list.Add(item.ReserveChange);
            list.Add(item.SharesAll);
            list.Add(item.SharesChange);
            list.Add(item.Result);
            list.Add(item.MaxResult);
            list.Add(item.MaxResultDate);
            list.Add(item.ResultDrawdown);
            list.Add(item.MaxResultDrawdown);
            list.Add(item.MaxResultDrawdownDate);
            return string.Join(";", list);
        }
        public string GetStringFromDate(DateTime dt) {
            return dt.ToString("MM/dd/yyyy");
        }
        public List<string> ConvertResultList(List<ResultItem> items) {
            List<string> names = new List<string>();
            List<String> resV = new List<string>();
            resV.Add("Date");
            resV.Add("Price");
            resV.Add("MaxPrice");
            resV.Add("MaxPriceDate");
            resV.Add("PriceDrawdown");
            resV.Add("MaxPriceDrawdown");
            resV.Add("MaxPriceDrawdownDate");
            resV.Add("InputValue");
            resV.Add("State");
            resV.Add("IsStateDown");
            resV.Add("ReserveAll");
            resV.Add("ReserveChange");
            resV.Add("SharesAll");
            resV.Add("SharesChange");
            resV.Add("Result");
            resV.Add("MaxResult");
            resV.Add("MaxResultDate");
            resV.Add("ResultDrawdown");
            resV.Add("MaxResultDrawdown");
            resV.Add("MaxResultDrawdownDate");
            string resItem = string.Join(";", resV);
            names.Add(resItem);
            List<string> itemsStrings = items.Select(x => this.ConvertResult(x)).ToList();
            var allItems = names.Concat(itemsStrings).ToList();
            
            return allItems;
        }
    }
}
