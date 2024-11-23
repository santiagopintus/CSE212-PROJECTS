using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Queue the following items: ("first",1),("second",1),("third",1), ("mostPriority",6),("leastPriority",0),("secondPriority",5). Remove Unqueue 3 items
    // Expected Result: Should have 3 items and the queue should be: ("second",1),("third",1),("leastPriority",0)
    // Defect(s) Found: Enqueue was using Insert instead of Add method.
    // Defect(s) Found: Dequeue was using  i < _queue.Count; instead of i < _queue.Count - 1;
    // Defect(s) Found: Dequeue wasn't updating the highest priority variable.
    public void TestPriorityQueue_1()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 1);
        priorityQueue.Enqueue("third", 1);
        priorityQueue.Enqueue("mostPriority", 6);    // Highest priority
        priorityQueue.Enqueue("leastPriority", 0);   // Lowest priority
        priorityQueue.Enqueue("secondPriority", 5);  // Second highest priority

        // Act & Assert: Dequeue based on priority
        Assert.AreEqual("mostPriority", priorityQueue.Dequeue());  // Priority 6
        Assert.AreEqual("secondPriority", priorityQueue.Dequeue()); // Priority 5
        Assert.AreEqual("first", priorityQueue.Dequeue());         // Priority 1 (first added of 1s)

        // Assert the remaining count in the queue
        Assert.AreEqual(3, priorityQueue.Count); // Should have 3 items left

        // Continue to check remaining items
        Assert.AreEqual("second", priorityQueue.Dequeue()); // Next in line with priority 1
        Assert.AreEqual("third", priorityQueue.Dequeue());  // Next in line with priority 1
        Assert.AreEqual("leastPriority", priorityQueue.Dequeue()); // Lowest priority 0
        Assert.AreEqual(0, priorityQueue.Count); // Queue should be empty now
    }

    [TestMethod]
    // Scenario: The queue is empty. 
    // Expected Result: Dequeue should throw an exception.
    // Defect(s) Found: Enqueue was using Insert instead of Add method.
    // Defect(s) Found: Dequeue was using  i < _queue.Count; instead of i < _queue.Count - 1;
    // Defect(s) Found: Dequeue wasn't updating the highest priority variable.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with identical priorities: ("item1", 3), ("item2", 3), ("item3", 3)
    // Expected Result: Items should be dequeued in the order they were added: "item1", "item2", "item3"
    // Defect(s) Found: Enqueue was using Insert instead of Add method.
    // Defect(s) Found: Dequeue was using  i < _queue.Count; instead of i < _queue.Count - 1;
    // Defect(s) Found: Dequeue wasn't updating the highest priority variable.
    public void TestPriorityQueue_3_IdenticalPriorities()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("item1", 3);
        priorityQueue.Enqueue("item2", 3);
        priorityQueue.Enqueue("item3", 3);

        // Act & Assert: Check that items with the same priority follow FIFO order
        Assert.AreEqual("item1", priorityQueue.Dequeue());
        Assert.AreEqual("item2", priorityQueue.Dequeue());
        Assert.AreEqual("item3", priorityQueue.Dequeue());
        Assert.AreEqual(0, priorityQueue.Count); // Queue should be empty now
    }

    [TestMethod]
    // Scenario: Queue the following items: ("low",1),("high",5),("medium",3),("lowest",0). Remove 2 items.
    // Expected Result: After removing two items with the highest priorities, 2 items should remain, ordered by their priorities: ("medium",3), ("lowest",0)
    // Defect(s) Found: Enqueue was using Insert instead of Add method.
    // Defect(s) Found: Dequeue was using  i < _queue.Count; instead of i < _queue.Count - 1;
    // Defect(s) Found: Dequeue wasn't updating the highest priority variable.
    public void TestPriorityQueue_4_MixedPriorities()
    {
        // Arrange
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);      // Highest priority
        priorityQueue.Enqueue("medium", 3);
        priorityQueue.Enqueue("lowest", 0);    // Lowest priority

        // Act & Assert: Dequeue items with the highest priorities
        Assert.AreEqual("high", priorityQueue.Dequeue());    // Priority 5
        Assert.AreEqual("medium", priorityQueue.Dequeue());  // Priority 3

        // Assert the remaining count and order in the queue
        Assert.AreEqual(2, priorityQueue.Count); // Should have 2 items left
        Assert.AreEqual("low", priorityQueue.Dequeue());     // Next with priority 1
        Assert.AreEqual("lowest", priorityQueue.Dequeue());  // Lowest priority 0
        Assert.AreEqual(0, priorityQueue.Count); // Queue should be empty now
    }
}
