using System.Collections.ObjectModel;

namespace SfDataGridDemo
{
    public class ViewModel
    {
        private ObservableCollection<OrderInfo> _orders;
        public ObservableCollection<OrderInfo> Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public ViewModel()
        {
            _orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            _orders.Add(new OrderInfo(1001, "Thomas", "Germany", "ALFKI", 25000));
            _orders.Add(new OrderInfo(1002, "Christina", "Germany", "ANATR", 36000));
            _orders.Add(new OrderInfo(1003, "Christina", "Germany", "ANTON", 40040));
            _orders.Add(new OrderInfo(1003, "Lebihan", "Germany", "ANTON", 40040));
            _orders.Add(new OrderInfo(1004, "Thomas Hardy", "Germany", "AROUT", 10700));
            _orders.Add(new OrderInfo(1005, "Christina Berglund", "Sweden", "BERGS", 20300));

            _orders.Add(new OrderInfo(1006, "Hanna Moos", "Sweden", "BLAUS", 50700));
            _orders.Add(new OrderInfo(1007, "Frederique Citeaux", "Sweden", "BLONP", 80100));
            _orders.Add(new OrderInfo(1008, "Martin Sommer", "Sweden", "BOLID", 35000));
            _orders.Add(new OrderInfo(1009, "Laurence Lebihan", "France", "BONAP", 20030));
            _orders.Add(new OrderInfo(1010, "Elizabeth Lincoln", "France", "BOTTM", 54000));

            _orders.Add(new OrderInfo(1011, "Christina Berglund", "France", "BERGS", 20300));
            _orders.Add(new OrderInfo(1012, "Hanna Moos", "France", "BLAUS", 50700));
            _orders.Add(new OrderInfo(1013, "Frederique Citeaux", "France", "BLONP", 80100));
            _orders.Add(new OrderInfo(1014, "Martin Sommer", "France", "BOLID", 35000));
            _orders.Add(new OrderInfo(1015, "Laurence Lebihan", "Italy", "BONAP", 20030));

            _orders.Add(new OrderInfo(1016, "Elizabeth Lincoln", "Italy", "BOTTM", 54000));
            _orders.Add(new OrderInfo(1017, "Christina Berglund", "Italy", "BERGS", 20300));
            _orders.Add(new OrderInfo(1018, "Hanna Moos", "Italy", "BLAUS", 50700));
            _orders.Add(new OrderInfo(1019, "Frederique Citeaux", "Italy", "BLONP", 80100));
            _orders.Add(new OrderInfo(1020, "Martin Sommer", "Italy", "BOLID", 35000));
        }
    }
}
            
        
     

