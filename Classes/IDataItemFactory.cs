using System.Collections.Generic;

namespace SpTest.Classes {
    public interface IDataItemFactory {
        DataItem CreateDataItem(string _date, string _value);
        DataItem CreateDataItemFromString(string line);
        List<DataItem> CreateListDataItemsFromString(string inputString);
    }
}
