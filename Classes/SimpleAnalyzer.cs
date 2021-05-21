using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class SimpleAnalyzer {

        public AnalyzeResult Analyze(List<DataItem> inputItems,double startSum, double monthInput) {
            AnalyzeResult result = new AnalyzeResult(startSum);
            ResultItem currentItem = new ResultItem(DateTime.Now,0);
            foreach(var inputLine in inputItems) {
                var newResultItem = ProcessLine(inputLine, currentItem, monthInput);
                result.Results.Add(newResultItem);
                currentItem = newResultItem;
            }
            return result;
        }
        public ResultItem ProcessLine(DataItem inputLine,ResultItem currentItem, double inputSum) {
            var result= new ResultItem(inputLine.Date, inputLine.Price);
            if(inputLine.Price > currentItem.MaxPrice) {
                result.MaxPrice = inputLine.Price;
                result.MaxPriceDate = inputLine.Date;
            }
            return result;
        }
    }
}
