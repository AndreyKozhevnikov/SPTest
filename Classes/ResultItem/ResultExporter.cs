using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class ResultExporter {
        IFileWorker fileWorker;
        public ResultExporter(IFileWorker _fileWorker) {
            fileWorker = _fileWorker;
        }
        public void Export(List<ResultItem> list, string path) {
            var converter = new ResultToStringConverter();
            var res = converter.ConvertResultList(list);
            fileWorker.StreamWriterWriteLines(path, res);
        }
    }
}
