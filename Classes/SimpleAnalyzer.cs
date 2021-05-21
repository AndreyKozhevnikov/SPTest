using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class SimpleAnalyzer {

        public AnalyzeResult Analyze(List<DataItem> inputItems, double startSum, double monthInput) {
            AnalyzeResult result = new AnalyzeResult(startSum);
            ResultItem currentItem = new ResultItem(DateTime.Now, 0);
            foreach(var inputLine in inputItems) {
                var newResultItem = ProcessLine(inputLine, currentItem, monthInput);
                result.Results.Add(newResultItem);
                currentItem = newResultItem;
            }
            return result;
        }
        public ResultItem ProcessLine(DataItem inputLine, ResultItem currentItem, double inputSum) {
            var result = new ResultItem(inputLine.Date, inputLine.Price);
            if(inputLine.Price > currentItem.MaxPrice) {
                result.MaxPrice = inputLine.Price;
                result.MaxPriceDate = inputLine.Date;
            }
            if(inputLine.Price < currentItem.MaxPrice) {
                double diff = currentItem.MaxPrice - inputLine.Price;
                result.PriceDrawdown = (diff / currentItem.MaxPrice) * 100;
                if(result.PriceDrawdown > currentItem.MaxPriceDrawdown) {
                    result.MaxPriceDrawdown = result.PriceDrawdown;
                    result.MaxPriceDrawdownDate = inputLine.Date;
                }
                if(result.PriceDrawdown >= 10 && result.PriceDrawdown < 20) {
                    result.State = ResultState.S10;
                } else if(result.PriceDrawdown >= 20 && result.PriceDrawdown < 30) {
                    result.State = ResultState.S20;
                } else if(result.PriceDrawdown >= 30) {
                    result.State = ResultState.S30;
                }
            }
            if(result.State != currentItem.State) {
                result.IsStateChanged = true;
            }
            result.InputValue = inputSum;
            return result;
        }
    }
}
