using ReceipTax._1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceipTax._1.Helpers
{
    public class ReadAllReceiptsList
    {
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        public ObservableCollection<Receipt> GetAllReceipts()
        {
            return Db_Helper.ReadReceipts();
        }
    }
}
