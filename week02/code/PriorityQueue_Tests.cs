using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Test basic priority based on differing levels of priority
    // Expected Result: Higher priority items should be removed first
    // Defect(s) Found: Loop skips last item and item is not removed
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Test mixed priority items
    // Expected Result: Higher priority items should be dequeued first followed by lower priority. 
    // Defect(s) Found: First item is not prioritized.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
    }


    [TestMethod]
    // Scenario: Test if Fifo works with items with the same priority
    // Expected Result: When priority is equal, first added should be dequeued first.
    // Defect(s) Found: High2 was dequeued before High1
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("Medium1", 3);
        priorityQueue.Enqueue("High2", 5);
        priorityQueue.Enqueue("Medium2", 3);

        // High priority items first with FIFO
        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());

        // Medium priority items second with FIFO
        Assert.AreEqual("Medium1", priorityQueue.Dequeue());
        Assert.AreEqual("Medium2", priorityQueue.Dequeue());

        // Low priority items last
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Test exception with dequeueing from an empty queue
    // Expected Result: Error should be thrown if empty queue
    // Defect(s) Found: None found

    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected Exeption Type: {e.GetType()}");
        }
    }

    [TestMethod]
    // Scenario: Test single item in queue.
    // Expected Result: Single item should be dequeued successfully
    // Defect(s) Found: Exception should have been thrown for empty queue

    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Only", 5);
        Assert.AreEqual("Only", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for empty queue.");
        }
        catch (InvalidOperationException)
        {

        }

    }
}