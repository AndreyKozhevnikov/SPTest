using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTest.Classes {
    public class DataLoader {
        IFileWorker fileWorker;
        IDataItemFactory dataItemFactory;
        string pathToFile;
        public DataLoader(IFileWorker _fileWorker, IDataItemFactory _dataItemFactory,string _pathToFile) {
            fileWorker = _fileWorker;
            dataItemFactory = _dataItemFactory;
            pathToFile = _pathToFile;
        }
    
   
        public List<DataItem> LoadData() {
            var inputString = fileWorker.StreamReaderReadToEnd(pathToFile);
            return dataItemFactory.CreateListDataItemsFromString(inputString);
        }
    }
}
