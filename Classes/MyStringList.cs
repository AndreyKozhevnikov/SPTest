using System;
using System.Collections.Generic;

namespace SpTest.Classes {
    public class MyStringList : List<String> {
        public void Add(DateTime dt) {
            this.Add(dt.ToString("MM/dd/yyyy"));
        }
        public void Add(double value) {
            this.Add(value.ToString());
        }
        public void Add(ResultState state) {
            this.Add(state.ToString());
        }
        public void Add(bool _bool) {
            this.Add(_bool ? 1 : 0);
        }
    }
}
