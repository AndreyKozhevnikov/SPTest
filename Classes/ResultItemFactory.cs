using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
   public class ResultItemFactory {
        public ResultItem CreateResultItem(DateTime dt, double pr) {
            return new ResultItem(dt, pr);
        }
    }
}
