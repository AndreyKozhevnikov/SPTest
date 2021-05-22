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
            double amountToSpend = 0;

            switch(result.State) {
                case ResultState.S0:
                    amountToSpend = result.InputValue * 0.7;
                    break;
                case ResultState.S10:
                    amountToSpend = result.InputValue * 0.8;
                    break;
                case ResultState.S20:
                    amountToSpend = result.InputValue * 0.9;
                    break;
                case ResultState.S30:
                    amountToSpend = result.InputValue;
                    break;
            }
            int sharesToBuyCount = (int)Math.Floor(amountToSpend / result.Price);
            result.AddedShares = sharesToBuyCount;
            result.SharesCount = currentItem.SharesCount + sharesToBuyCount;

            double spentCash = sharesToBuyCount * result.Price;
            double remainCash = result.InputValue - spentCash;

            result.ReserveChange = remainCash;
            result.ReserveAll = currentItem.ReserveAll + remainCash;


            return result;
        }
    }
}
