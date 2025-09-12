using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Checking to see if the person is added to the back of the queue
    // Expected Result: adding three cases in order expect to see the last added at the end of the queue
    // Defect(s) Found: None
    public void TestPriorityQueue_AddingtoQueue()
    {
        var tom = new PriorityItem("Tom", 7);
        var dick = new PriorityItem("Dick", 5);
        var harry = new PriorityItem("Harry", 3);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(tom.Value, tom.Priority);
        priorityQueue.Enqueue(dick.Value, dick.Priority);
        priorityQueue.Enqueue(harry.Value, harry.Priority);

        var actualText = priorityQueue.ToString();
        var expectedText = "[Tom (Pri:7), Dick (Pri:5), Harry (Pri:3)]";

        if (expectedText != actualText)
            Assert.AreEqual(expectedText, actualText);

    }

    [TestMethod]
    // Scenario: Add case with a higher priority not as the first case see if the highest priority case is removed first without a latter case with equal priority bering removed
    // Expected Result: Adding cases without the highest priority being first, to see if it will pull the second person first. and not the last person 
    // Defect(s) Found: in Dequeue the check on priority level had >= should be > as it will update for each iteme in the list even a latter one.
    public void TestPriorityQueue_HighestPriorityFirst()
    {

        var tom = new PriorityItem("Tom", 5);
        var dick = new PriorityItem("Dick", 7);
        var harry = new PriorityItem("Harry", 3);
        var rose = new PriorityItem("Rose", 7);
        var mat = new PriorityItem("Mat", 2);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(tom.Value, tom.Priority);
        priorityQueue.Enqueue(dick.Value, dick.Priority);
        priorityQueue.Enqueue(harry.Value, harry.Priority);
        priorityQueue.Enqueue(rose.Value, rose.Priority);
        priorityQueue.Enqueue(mat.Value, mat.Priority);

        var actualText = priorityQueue.Dequeue();
        var expectedText = "Dick";

        if (expectedText != actualText)
            Assert.AreEqual(expectedText, actualText);

    }

    [TestMethod]
    // Scenario: Add 3 cases dequeue 1 should be 2 in queue
    // Expected Result: Should return 2 cases
    // Defect(s) Found: Dequeue did not remove items from the queue
    public void TestPriorityQueue_Shrink()
    {

        var tom = new PriorityItem("Tom", 5);
        var dick = new PriorityItem("Dick", 7);
        var harry = new PriorityItem("Harry", 3);

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue(tom.Value, tom.Priority);
        priorityQueue.Enqueue(dick.Value, dick.Priority);
        priorityQueue.Enqueue(harry.Value, harry.Priority);

        var value = priorityQueue.Dequeue();
        var actualText = priorityQueue.ToString();
        var expectedText = "[Tom (Pri:5), Harry (Pri:3)]";

        if (expectedText != actualText)
            Assert.AreEqual(expectedText, actualText);

    }

    [TestMethod]
    // Scenario: Call the Dequeue without adding anything to Queue
    // Expected Result: Should throw exception before erroring out 
    // Defect(s) Found: None
    public void TestPriorityQueue_Empty()
    {

        var priorityQueue = new PriorityQueue();

        try
        {
            var actualText = priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
           );
        }
    }
    // Add more test cases as needed below.
}