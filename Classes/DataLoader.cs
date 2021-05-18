using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
   public class DataLoader {
        public List<DataItem> LoadData() {
            var lst = new List<DataItem>();
            using (var reader= new StreamReader(@"..\..\Data\sp.csv")) {
                var factory = new DataItemFactory();
                while(!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var dt = values[0];
                    var vl = values[1];
                    if(dt == "Date") {
                        continue;
                    }
                    var item = factory.CreateDataItem(dt, vl);
                }

            }

            return lst;
        }
    }
}
