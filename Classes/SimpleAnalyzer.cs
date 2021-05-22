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
            double spentFromInput = 0;

            switch(result.State) {
                case ResultState.S0:
                    spentFromInput = result.InputValue * 0.7;
                    break;
                case ResultState.S10:
                    spentFromInput = result.InputValue * 0.8;
                    break;
                case ResultState.S20:
                    spentFromInput = result.InputValue * 0.9;
                    break;
                case ResultState.S30:
                    spentFromInput = result.InputValue;
                    break;
            }
            double inputRemain = result.InputValue - spentFromInput;
            double sumToSpend = spentFromInput;
            if(result.IsStateChanged) {
                double spentFromReserve = 0;
                switch(result.State) {
                    case ResultState.S10:
                        //   if(currentItem.State == ResultState.S0) {
                        spentFromReserve = currentItem.ReserveAll * 0.3;
                        result.ReserveChange -= spentFromReserve;
                        currentItem.ReserveAll -= spentFromReserve;
                        // }
                        break;
                }
                sumToSpend = spentFromInput + spentFromReserve;
            }
            result.ReserveChange += inputRemain;
            result.ReserveAll += inputRemain;

            int sharesToBuyCount = (int)Math.Floor(sumToSpend / result.Price);
            result.AddedShares = sharesToBuyCount;
            result.SharesCount = currentItem.SharesCount + sharesToBuyCount;

            double spentCash = sharesToBuyCount * result.Price;
            double remainCash = sumToSpend - spentCash;

            result.ReserveChange += remainCash;
            result.ReserveAll = currentItem.ReserveAll + result.ReserveChange;


            return result;
        }
    }
}
