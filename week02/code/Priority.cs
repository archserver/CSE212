using Microsoft.VisualBasic;

public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);
        String Item;
        // Test Cases

        // Test 1
        // Scenario: Adding and removing priority queue with matching priorities 
        // Expected Result: Server, Fire, Network, DNS, Laptop, Empty Queue
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Network",5);
        priorityQueue.Enqueue("Laptop",0);
        priorityQueue.Enqueue("Server",6);
        priorityQueue.Enqueue("DNS",4);
        priorityQueue.Enqueue("Fire",6);

        Console.WriteLine(priorityQueue);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);

        // Defect(s) Found: if (_queue[index].Priority >=    needs to be > not >=
        // was not removing items from queue added _queue.Remove(highPriorityIndex);
        // removed the -1 from the queue count in the for loop

        Console.WriteLine("---------");

        // Test 2
        // Scenario: 
        // Expected Result: Empty Queue, Server, Network, Fire, DNS, Water Leak, Power Outage, Laptop, Empty Queue
        Console.WriteLine("Test 2");

        Console.WriteLine(priorityQueue);
        Item = priorityQueue.Dequeue();

        priorityQueue.Enqueue("Network",5);
        priorityQueue.Enqueue("Laptop",0);
        priorityQueue.Enqueue("Server",6);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        priorityQueue.Enqueue("DNS",4);
        priorityQueue.Enqueue("Fire",6);
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        priorityQueue.Enqueue("Water Leak",6);
        priorityQueue.Enqueue("Power Outage",4);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
         Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);
        Item = priorityQueue.Dequeue();
        Console.WriteLine(Item);

        // Defect(s) Found:  None

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below

    }
}