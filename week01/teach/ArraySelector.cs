public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    public static int[] ListSelector(int[] array1, int[] array2, int[] selector)
    {
        List<int> result = new();
        int array1Index = 0;
        int array2Index = 0;

        foreach (int value in selector)
        {
            if (value == 1)
            {
                result.Add(array1[array1Index]);
                array1Index++;
            }
            else if (value == 2)
            {
                result.Add(array2[array2Index]);
                array2Index++;
            }
        }

        return result.ToArray();
    }
}