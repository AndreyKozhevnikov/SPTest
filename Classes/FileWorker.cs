using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class FileWorker : IFileWorker {
        public string StreamReaderReadToEnd(string path) {
            string result = null;
            using(var reader = new StreamReader(path)) {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
