using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class Worker {
        public void Work() {
            var fileWorker = new FileWorker();
            var dataItemFactory = new DataItemFactory();
            var load = new DataLoader(fileWorker,dataItemFactory, @"..\..\Data\sp99.csv");
            List<DataItem> lst = load.LoadData();
            var analyzer = new SimpleAnalyzer();
            var lst2 = analyzer.Analyze(lst, 50000, 50000);
            var exporter = new ResultExporter(fileWorker);
            var testResults = lst.Select(x => new ResultItem(x.Date, x.Price)).ToList() ;
            exporter.Export(lst2.Results, "first99.csv");

        }

    }
}
