using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_Priorities()
    {
        //We add various Values ​​with different priorities
        var bob = new PriorityItem ("Bob", 2);
        var tim = new PriorityItem ("Tim", 5);
        var sue = new PriorityItem ("Sue", 3);
        var ed = new PriorityItem ("Ed", 2);

        var players = new PriorityQueue();
        players.Enqueue (bob.Value, bob.Priority);
        players.Enqueue (tim.Value, tim.Priority);
        players.Enqueue (sue.Value, sue.Priority);
        players.Enqueue (ed.Value, ed.Priority);

        // We removed and verified that the removal was done in the correct order.
        Assert.AreEqual("Tim", players.Dequeue());
        Assert.AreEqual("Sue", players.Dequeue());
        Assert.AreEqual("Bob", players.Dequeue());
        Assert.AreEqual("Ed", players.Dequeue());
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2_Empty()
    {
        var players = new PriorityQueue();

        try
        {
            players.Dequeue();
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

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_3_Dequeue() {

        //We add various Values ​​with different priorities
        var queue = new PriorityQueue();
            queue.Enqueue("A", 1);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 3);
         
        // We verify that the elements are being removed
        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
    }
}