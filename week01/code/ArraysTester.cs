public static class ArraysTester {
    /// <summary>
    /// Entry point for the tests
    /// </summary>
    public static void Run() {
        // Sample Test Cases (may not be comprehensive)
        Console.WriteLine("\n=========== PROBLEM 1 TESTS ===========");
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{7, 14, 21, 28, 35}
        multiples = MultiplesOf(1.5, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{1.5, 3.0, 4.5, 6.0, 7.5, 9.0, 10.5, 12.0, 13.5, 15.0}
        multiples = MultiplesOf(-2, 10);
        Console.WriteLine($"<double>{{{string.Join(',', multiples)}}}"); // <double>{-2, -4, -6, -8, -10, -12, -14, -16, -18, -20}

        Console.WriteLine("\n=========== PROBLEM 2 TESTS ===========");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 1);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{9, 1, 2, 3, 4, 5, 6, 7, 8}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 5);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
        numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 9);
        Console.WriteLine($"<List>{{{string.Join(',', numbers)}}}"); // <List>{1, 2, 3, 4, 5, 6, 7, 8, 9}
    }
    /// <summary>
    /// This function will produce a list of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    private static double[] MultiplesOf(double number, int length) //add double[] before the name of the function to tell it that it requires a return
    {
        //Intialize the array of doubles w/ a size of "length" - Empty array(box)
        double[] multiples = new double[length];

        //Create a for loop that populates the array with multiples of the starting "number" 
        for (int i = 1; i <= length; i++)  //This starts the counter - tcounts to "length"
        {
            //Calculate the multiple for the current position
            //Arrays are 0-indexed but we are starting with multiples from 1, so we use 'i - 1' as the index (to pick the right spot in the index)
            multiples[i - 1] = number * i; //multiply "number" * 1, then "number" * 2 etc. (ie: 7*1, 7*2..to 5 times)
        }

        return multiples; // return the filled array
    }
    
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// <c>&lt;List&gt;{1, 2, 3, 4, 5, 6, 7, 8, 9}</c> and an amount is 3 then the list returned should be 
    /// <c>&lt;List&gt;{7, 8, 9, 1, 2, 3, 4, 5, 6}</c>.  The value of amount will be in the range of <c>1</c> and 
    /// <c>data.Count</c>.
    /// <br /><br />
    /// Because a list is dynamic, this function will modify the existing <c>data</c> list rather than returning a new list.
    /// </summary>
    private static void RotateListRight(List<int> data, int amount)
    {
        // Calculate the 'effective rotation' 
        int effectiveRotation = amount % data.Count; //data.Count is the total number of the list / effectiveRotation is "amount" % total number
        if (effectiveRotation == 0) return; // No rotation needed if answer is 0

        // Calculate the slicing point (total number - )
        int slicingPoint = data.Count - effectiveRotation; 

        // Get the two slices of the list
        List<int> firstSlice = data.GetRange(slicingPoint, effectiveRotation); //gets from slicing point to rotation
        List<int> secondSlice = data.GetRange(0, slicingPoint);  //gets from 0 to slicing point

        // Clear the original list and reassemble in the new order
        data.Clear();
        data.AddRange(firstSlice);
        data.AddRange(secondSlice);

    }
}

//uses GetRange and AddRange to create two lists and then recombine