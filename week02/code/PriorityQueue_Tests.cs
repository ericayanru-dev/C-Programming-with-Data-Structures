using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
  [TestMethod]
  // Scenario: Add three items with different priorities: Low (1), High (10), and Medium (5).
  // Dequeue one item and check the remaining queue.
  // Expected Result: "High" is returned because it has the highest priority,
  // and High is removed from the queue.
  // Defect(s) Found: The original Dequeue method returned the highest-priority
  // value but did not remove the item from the queue. 
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
  // Scenario: Add First (10), Second (10), and Low (1), where First and Second
  // have the same highest priority.
  // Expected Result: "First" is returned because it was added before Second,
  // following FIFO order when priorities are equal.
  // Defect(s) Found: The original Dequeue method used >= when comparing
  // priorities, so it selected the later item when two items had equal priority.
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
  // Scenario: Add Low (1), Medium (5), and Highest (20), with Highest being
  // the last item added to the queue.
  // Expected Result: "Highest" is returned because it has the highest priority,
  // even though it is the last item in the queue.
  // Defect(s) Found: The original Dequeue method did not examine the last item
  // because its loop condition used index < _queue.Count - 1.
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
  // Scenario: Add A (5), B (10), C (10), and D (1), then repeatedly dequeue
  // all items from the queue.
  // Expected Result: B is removed first, followed by C because B and C have
  // the same highest priority and B was added first. Then A and finally D
  // are removed. The queue is empty after all four items are dequeued.
  // Defect(s) Found: The original Dequeue method did not remove the selected
  // item from the queue, causing repeated calls to return the same item.
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