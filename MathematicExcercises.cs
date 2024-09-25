using System;
namespace Programming_Excercises_CSharp
{
	public class MathematicExcercises
	{

        static List<int> getListOfMultiples(int number, int maxMultiples)
        {
            List<int> multiples = new List<int>();

            for (int i = 1; i <= maxMultiples; i++)
            {
                multiples.Add(number * i);
            }

            return multiples;
        }

        /*static void Main()
        {
            var multipleList = getListOfMultiples(number:7, maxMultiples: 5);

            multipleList.ForEach(multiple => Console.WriteLine(multiple));

        }*/

    }
}

