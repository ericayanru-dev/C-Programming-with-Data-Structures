using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
  [TestMethod]
  // Scenario: 
  // Expected Result: 
  // Defect(s) Found: 
  public void TestPriorityQueue_1()
  {
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("Low", 1);
    priorityQueue.Enqueue("High", 10);
    priorityQueue.Enqueue("Medium", 5);

    var result = priorityQueue.Dequeue();

    Assert.AreEqual("High", result);
    Assert.AreEqual("[Low (Pri:1), Medium (Pri:5)]", priorityQueue.ToString());
  }

  [TestMethod]
  // Scenario: 
  // Expected Result: 
  // Defect(s) Found: 
  public void TestPriorityQueue_2()
  {
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("First", 10);
    priorityQueue.Enqueue("Second", 10);
    priorityQueue.Enqueue("Low", 1);

    var result = priorityQueue.Dequeue();

    Assert.AreEqual("First", result);
  }

  // Add more test cases as needed below.
  [TestMethod]
  public void TestPriorityQueue_3()
  {
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("Low", 1);
    priorityQueue.Enqueue("Medium", 5);
    priorityQueue.Enqueue("Highest", 20);

    var result = priorityQueue.Dequeue();

    Assert.AreEqual("Highest", result);
  }

  [TestMethod]
  // Scenario: Attempt to dequeue from an empty queue.
  // Expected Result: InvalidOperationException with the message
  // "The queue is empty."
  // Defect(s) Found: No defect found.
  public void TestPriorityQueue_4()
  {
    var priorityQueue = new PriorityQueue();

    var exception = Assert.ThrowsException<InvalidOperationException>(
        () => priorityQueue.Dequeue()
    );

    Assert.AreEqual("The queue is empty.", exception.Message);
  }

  [TestMethod]
  // Scenario: Add several items and repeatedly dequeue them.
  // Expected Result: Items are removed in descending priority order.
  // Items with equal priority are removed in FIFO order.
  // Defect(s) Found: The current Dequeue method does not remove the
  // selected item from the queue.
  public void TestPriorityQueue_5()
  {
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("A", 5);
    priorityQueue.Enqueue("B", 10);
    priorityQueue.Enqueue("C", 10);
    priorityQueue.Enqueue("D", 1);

    Assert.AreEqual("B", priorityQueue.Dequeue());
    Assert.AreEqual("C", priorityQueue.Dequeue());
    Assert.AreEqual("A", priorityQueue.Dequeue());
    Assert.AreEqual("D", priorityQueue.Dequeue());

    Assert.AreEqual(0, priorityQueue.ToString().Length - 2);
  }
}