using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
   public class ResultToStringConverter {
        public string ConvertResult(ResultItem item) {
            return string.Format("{0};{1}", item.Date.ToString("MM/dd/yyyy"), item.Price);
        }
        public string ConvertResultList(List<ResultItem> items) {
            string result = string.Join(Environment.NewLine, items.Select(x => this.ConvertResult(x)));
            return result;
        }
    }
}
