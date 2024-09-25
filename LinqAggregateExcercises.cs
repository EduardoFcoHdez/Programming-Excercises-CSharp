using System;
using System.Linq;

namespace Programming_Excercises_CSharp;


public class Student
{
    public string Name { private set; get; }
    public int Age { set; get; }
    public int[] scores { set; get; }
    public int scoresAverage
    {
        get
        {
            var avg = scores.Aggregate(0, (accumulator, value) =>
            {
                int avg = accumulator += value;
                return avg;
            });
            return avg / scores.Length;
        }
    }

    public Student(String name, int Age, int[] scores)
    {
        this.Name = name;
        this.Age = Age;
        this.scores = scores;
    }
}

public struct StateVotes
{
    public int downVotes;
    public int upVotes;
}


public class LinqAggregateExcercises
{
	public static int SumPositiveNumbers(List<int> numbers)
	{
		return numbers.Aggregate(0, (accum, current) =>			
			accum = (current > 0) ? accum + current : accum
		);
	}

    public static int SumNumbers(List<int> numbers)
    {
        return numbers.Aggregate(0, (accumulator,current) =>
        {
           return accumulator += current;
        });
        
    }    

	public static int CalculateAverage(List<int> numbers)
	{
		int average = numbers.Aggregate(0, (accum, current) =>
			accum += current
			) / numbers.Count;

		return average;
	}

    //Get the vote count
    public static int getVoteCount(List<StateVotes> votes)
    {
        int totalVotes = votes.Aggregate(0, (accumulator, current) =>
        {
            return accumulator += (current.upVotes - current.downVotes);
        });

        return totalVotes;

    }

    /*Count different elements in the list of lists and return a numer in a list*/
    public static List<Tuple<int, int>> CountDifferentElementsInLists(List<List<int>> elementsList)
    {
        //Flatten a list of lists
        var elements = elementsList.SelectMany(elements => elements);
        //Get only different elements
        var uniqueElements = elements.Distinct();

        List<Tuple<int, int>> elementsCount = new List<Tuple<int, int>>();

        uniqueElements.ToList().ForEach((element) =>
        {
            var elementCount_ = elements.Aggregate(0, (accumulator, next) => accumulator = (element == next) ? accumulator + 1 : accumulator);

            elementsCount.Add(new Tuple<int, int>(element, elementCount_));

        });

        return elementsCount.ToList();
    }

    public static void Main()
    {
        /*List<Student> students = new List<Student> { new Student("Eduardo", 40, new int[] {8,10}), new Student("Francisco", 43, new int[] { 8, 7 }) };

        foreach (var student in students)
        {
            Console.WriteLine(student.scoresAverage);
        }*/

        /*List<int> numbers = new List<int> { 2, 4, 6, 8, 10 };

        var sum = SumNumbers(numbers);*/

        //var votes = getVoteCount(new List<StateVotes>() { new StateVotes() { upVotes = 5, downVotes = 6 }, new StateVotes() { upVotes = 7, downVotes = 8 } });

        //Console.WriteLine($"votes: {votes}");

        LinqAggregateExcercises.CountDifferentElementsInLists(new List<List<int>> { new List<int> { 2, 2, 1, 2, 0 } }).ForEach((item) =>
            {
                Console.WriteLine($"item:{item}");
         });
    }


}

