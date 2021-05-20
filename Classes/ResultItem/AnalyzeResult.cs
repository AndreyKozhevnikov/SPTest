using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class AnalyzeResult {
        public AnalyzeResult(double _startSum) {
            StartSum = _startSum;
            Results = new List<ResultItem>();
        }
        public double StartSum { get; set; }
        public double FinishSum { get; set; }

        public List<ResultItem> Results { get; set; }
    }
}
