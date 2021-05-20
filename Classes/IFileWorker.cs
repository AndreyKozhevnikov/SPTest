using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public interface IFileWorker {
        string StreamReaderReadToEnd(string path);
        void StreamWriterWriteLines(string path, List<string> lines);    }
}
