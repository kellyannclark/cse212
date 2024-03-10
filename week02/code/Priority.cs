public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Enqueue items with different priorities and dequeue one
         Console.WriteLine("Test 1");
         priorityQueue.Enqueue("Item 1", 3);
         priorityQueue.Enqueue("Item 2", 5);
         priorityQueue.Enqueue("Item 3", 1);
         Console.WriteLine("After enqueuing: " + priorityQueue);
         var dequeuedItem1 = priorityQueue.Dequeue();
         Console.WriteLine("Dequeued item: " + dequeuedItem1);
         Console.WriteLine("Queue after dequeue: " + priorityQueue);
        
        // Expected Result: Item 2 is removed first due to highest priority of 5
    
        // Defect(s) Found: The dequeue method does not correctly remove the item with the highest priority from the queue. 

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Enqueue items with the same priority and dequeue all
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("Item 1", 2);
        priorityQueue.Enqueue("Item 2", 2);
        priorityQueue.Enqueue("Item 3", 2);
        Console.WriteLine("After enqueuing: " + priorityQueue);
        var dequeuedItem2 = priorityQueue.Dequeue();
        var dequeuedItem3 = priorityQueue.Dequeue();
        var dequeuedItem4 = priorityQueue.Dequeue();
        Console.WriteLine("Dequeued items: " + dequeuedItem2 + ", " + dequeuedItem3 + ", " + dequeuedItem4);
        Console.WriteLine("Queue after dequeue: " + priorityQueue);

        // Expected Result: Items A, B, and C are dequeued in the order they were enqueued, as they have the same priority.
        // Defect(s) Found: Incorrect dequeue order for items with same priority
  

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}