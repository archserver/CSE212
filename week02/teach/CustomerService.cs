/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Queue size less than 1 should default to 10
        // Expected Result: Queue size = 10

        Console.WriteLine("Test 1");
        var cs = new CustomerService(-5);
        Console.WriteLine($"Queue should be 10: {cs}");

        // Defect(s) Found: No Defect

        Console.WriteLine("=================");

        // Test 2
        // Scenario: AddNewCustomer should add a customer to the queue and if queue is full it should display an error 
        // Expected Result: Customers added once but as size is 2 it should give us an error stating "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 2");
        cs = new CustomerService(2);

        cs.AddNewCustomer();
        Console.WriteLine("Customer Added Once");
        cs.AddNewCustomer();
        Console.WriteLine("Customer Added Twice");
        cs.AddNewCustomer();
        // should error because we are adding more customers past queue size

        // Defect(s) Found: queue count comparison was > should be >=

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
        // Test 3
        // Scenario: ServeCustomer should serve the next customer from the queue and display details, if queue is empty it should display an error
        // Expected Result: Customers removed twice but as size is 2 it should give us an error stating "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 3");
        cs = new CustomerService(2);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine($"customer being served {cs}");
        cs.ServeCustomer();
        Console.WriteLine($"Removed one customer being served {cs}");
        cs.ServeCustomer();
        Console.WriteLine($"Removed two customer being served {cs}");
        cs.ServeCustomer();
        // should error as we are removine more customers then we have

        // Defect(s) Found: 

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        //if(_queue.Count >= _maxSize)
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
       
        if (_queue.Count <= 0)
            Console.WriteLine("No Customers in Queue.");
        else
        {
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
        

        /*_queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);*/
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}