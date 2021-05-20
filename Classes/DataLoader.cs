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
                    var item = factory.CreateDataItemFromString(line);
                    lst.Add(item);
                }
            }
            return lst;
        }
    }
}
