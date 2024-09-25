using System;
using System.Linq;

namespace Programming_Excercises_CSharp;
class LinqWhereExcercises
{
    static List<int> FindEvenNumbers(int[] inputNumbers)
    {
        return inputNumbers.ToList<int>().Where(number => number % 2 == 0).ToList();
    }

    //static void Main()
    //{     
        //int [] inputNumbers = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        /*FindEvenNumbers(inputNumbers).ForEach(evenNum =>
        {
            Console.WriteLine($"even number {evenNum}");
        });*/      

    //}
}
