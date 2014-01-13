VisualLogs (for .NET)
==========

VisualLogs is a tool for Visualizing object states into a log system.

* The logs are written as regular logs and the object states in SVG
* In order to view the objects the log file must be open in a browser that supports svg (such as Chrome).


Example



    class Program
      {
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
      }
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
  }
