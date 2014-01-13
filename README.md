VisualLogs (for .NET)
==========

VisualLogs is a tool for Visualizing object states into a log system.

* The logs are written as regular logs and the object states in SVG
* In order to view the objects the log file must be open in a browser that supports svg (such as Chrome).

How to use
* Use the following attributes in your class your want to visualize
* `VisualLogAttribute` can be put on a field or property we want to visualize
* `VisualLogDescriptionAttribute`can be put on a field or property or method and marks the description of the object to be shown

Example


      public class Store
      {
          private List<Customer> _customers = new List<Customer>();
          [VisualLog]
          private List<Order> _orders = new List<Order>();
          private List<Item> _items = new List<Item>();
  
          public void AddCustomer(Customer customer)
          {
              if (!_customers.Contains(customer))
              {
                  _customers.Add(customer);
              }
          }
  
          public void AddItem(Item item)
          {
              if (!_items.Contains(item))
              {
                  _items.Add(item);
              }
          }
  
          public void AddOrder(Order order)
          {
              _orders.Add(order);
              AddCustomer(order.Customer);
              AddItem(order.Item);
          }
      }
  
      public class Customer
      {
          public Customer(string name)
          {
              Name = name;
          }
          [VisualLogDescription]
          public string Name { get; private set; }
      }
  
      public class Order
      {
          public Order(Customer customer, Item item, int quantity)
          {
              Customer = customer;
              Item = item;
              Quantity = quantity;
          }
  
          [VisualLog]
          public Customer Customer { get; private set; }
          [VisualLog]
          public Item Item { get; private set; }
          [VisualLog]
          public int Quantity { get; set; }
  
          [VisualLogDescription]
          public override string ToString()
          {
              return string.Format("Order: {0}  {1}", Quantity, Item.Name);
          }
      }
  
      public abstract class Item
      {
          protected Item(string name)
          {
              Name = name;
          }
          [VisualLogDescription]
          public string Name{get ;set ;}
      }
  
      public class Book : Item
      {
          public Book(string name) : base(name)
          {
              
          }
      }
  
      public class Phone : Item
      {
          public Phone(string name) : base(name)
          {
              
          }
      }
        
      private static void Main(string[] args)
      {
            Logger.Info("Some info log");
            Logger.Info("Creating a store");
            var store = new Store();
            Logger.Debug("Adding orders");
            store.AddOrder(new Order(new Customer("Walter"),new Book("Harry Potter"),2));
            store.AddOrder(new Order(new Customer("Gustavo"),new Book("Romeo and Juliet"),3));
            Logger.VisualizeObject(store);
            Logger.Debug("Adding more orders");
            store.AddOrder(new Order(new Customer("Mike"), new Phone("LG"), 4));
            store.AddOrder(new Order(new Customer("Jesse"),new Phone("Samsung"),5));
            store.AddOrder(new Order(new Customer("Soul"),new Book("Don Quixote"),6));
            Logger.Debug("Finishing adding orders");
            Logger.VisualizeObject(store);
            Logger.Debug("Exiting.....");
      }

Example of integration with [log4net][http://logging.apache.org/log4net/]

      internal static class Logger
      {
        private static readonly ILog _log = LogManager.GetLogger("DemoLog");
      
        public static void Info(string message)
        {
            _log.Info(message);
        }
      
        public static void Warn(string message)
        {
            _log.Warn(message);
        }
      
        public static void Error(string message)
        {
            _log.Error(message);
        }
      
        public static void Debug(string message)
        {
            _log.Debug(message);
        }
      
        public static void VisualizeObject(object o)
        {
            if (_log.Logger.IsEnabledFor(Level.Verbose))
            {
                var visualizer = Visualizer.Svg;
      
                var objVisualization = visualizer.Visualize(o);
                _log.Debug(objVisualization);
            }
        }
      }

Compiling the project:
`msbuild build.proj`

Running the tests:
`msbuild /t:Tests build.proj`
