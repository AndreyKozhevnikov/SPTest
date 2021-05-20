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
            var load = new DataLoader(fileWorker,dataItemFactory, @"..\..\Data\sp.csv");
            List<DataItem> lst = load.LoadData();
            
        }

    }
}
