public static class Divisors {
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run() {
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number)
    {
        // Create an empty list to store divisors
        List<int> results = new();

        // Loop through all numbers from 1 to number - 1
        for (int i = 1; i < number; i++)
        {
            // If i divides number evenly, it is a divisor
            if (number % i == 0)
            {
                // Add i to the list of results
                results.Add(i);
            }
        }

        // Return the list of divisors found
        return results;
    }
}