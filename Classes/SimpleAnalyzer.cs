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
        public ResultItem ProcessLine(DataItem inputLine, ResultItem prevResult, double inputSum) {
            var currResult = new ResultItem(inputLine.Date, inputLine.Price);
            currResult.ReserveAll = prevResult.ReserveAll;
            if(inputLine.Price > prevResult.MaxPrice) {
                currResult.MaxPrice = inputLine.Price;
                currResult.MaxPriceDate = inputLine.Date;
            }
            if(inputLine.Price < prevResult.MaxPrice) {
                double diff = prevResult.MaxPrice - inputLine.Price;
                currResult.PriceDrawdown = (diff / prevResult.MaxPrice) * 100;
                if(currResult.PriceDrawdown > prevResult.MaxPriceDrawdown) {
                    currResult.MaxPriceDrawdown = currResult.PriceDrawdown;
                    currResult.MaxPriceDrawdownDate = inputLine.Date;
                }
                if(currResult.PriceDrawdown >= 10 && currResult.PriceDrawdown < 20) {
                    currResult.State = ResultState.S10;
                } else if(currResult.PriceDrawdown >= 20 && currResult.PriceDrawdown < 30) {
                    currResult.State = ResultState.S20;
                } else if(currResult.PriceDrawdown >= 30) {
                    currResult.State = ResultState.S30;
                }
            }
            if(currResult.State > prevResult.State) {
                currResult.IsStateDown = true;
            }
            currResult.InputValue = inputSum;
            double spentFromInput = 0;

            switch(currResult.State) {
                case ResultState.S0:
                    spentFromInput = currResult.InputValue * 0.7;
                    break;
                case ResultState.S10:
                    spentFromInput = currResult.InputValue * 0.8;
                    break;
                case ResultState.S20:
                    spentFromInput = currResult.InputValue * 0.9;
                    break;
                case ResultState.S30:
                    spentFromInput = currResult.InputValue;
                    break;
            }
            double inputRemain = currResult.InputValue - spentFromInput;
            double sumToSpend = spentFromInput;
            if(currResult.IsStateDown) {
                double spentFromReserve = 0;
                double percentToSpent = 0;
                switch(currResult.State) {
                    case ResultState.S10:
                        percentToSpent= 0.3;
                        break;
                    case ResultState.S20:
                        if(prevResult.State == ResultState.S10) {
                            percentToSpent = 0.5;
                        } else {
                            percentToSpent = 0.7;
                        }
                        break;
                    case ResultState.S30:
                        percentToSpent = 1;
                        break;
                }
                spentFromReserve = currResult.ReserveAll * percentToSpent;
                currResult.ReserveChange -= spentFromReserve;
                currResult.ReserveAll -= spentFromReserve;
                sumToSpend = spentFromInput + spentFromReserve;
            }
            currResult.ReserveChange += inputRemain;
            currResult.ReserveAll += inputRemain;

            int sharesToBuyCount = (int)Math.Floor(sumToSpend / currResult.Price);
            currResult.AddedShares = sharesToBuyCount;
            currResult.SharesCount = prevResult.SharesCount + sharesToBuyCount;

            double spentCash = sharesToBuyCount * currResult.Price;
            double remainCash = sumToSpend - spentCash;

            currResult.ReserveChange += remainCash;
            currResult.ReserveAll += remainCash;


            return currResult;
        }
    }
}
