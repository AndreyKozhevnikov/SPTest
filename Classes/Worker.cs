using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
   public class Worker {
        public void Work() {
            var load = new DataLoader();
            var lst = load.LoadData();
        }

    }
}
