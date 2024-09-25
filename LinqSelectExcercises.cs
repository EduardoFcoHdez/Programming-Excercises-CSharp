using System;
using System.Linq;

namespace Programming_Excercises_CSharp
{
    class Person
    {

        public string Name { private set; get; }
        public int Age { private set; get; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

    }

    class Patient
    {
        public string ID => Guid.NewGuid().ToString();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private int _age;
        public string Name
        {
            get
            {
                return $"{this.FirstName} {LastName} ";
            }
        }

        public int Age
        {
            //I used the set property for cumputing another property
            set
            {
                if (this._age > 60)
                {
                    this.Retired = true;
                }
                _age = value;

            }
            get { return this._age; }

        }


        public bool Retired { get; set; }

        public Patient(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return String.Format("ID: {0}, Name: {1}, Age: {2}, Retired: {3}", this.ID, this.Name, this.Age, this.Retired);
        }

    }

    class LinqSelectExcercises
	{        

        public static List<int> GetSumPointsOfEachParticipant(List<int> pointsParticipants, int bonusPoints)
        {
            return pointsParticipants.Select(number => number + bonusPoints).ToList();
        }

        /*Get people names under 18*/
        public static List<string> GetKidsName(List<Person> people)
        {
            
            return people.Where(person => person.Age < 18).Select(person => person.Name).ToList();
        }        

        public static IEnumerable<Tuple<char,int>> GetCharactersFrequency(string word)
        {
            var wordChars = word.ToCharArray().ToList();

            
            var charsFrequency = wordChars.Select((char_) =>
            {
                var frequency = 0;
                var index = 0;
                wordChars.ForEach((word) =>
                {
                    if (char_ == wordChars[index])
                    {
                        frequency++;
                    }
                    index++;
                });

                return new Tuple<char, int>(char_,frequency);
               
            });           

            return charsFrequency;
        }



        /*Count different elements in the list of lists and return a numer in a list*/
        /*public static List<Tuple<int, int>> CountDifferentElementsInLists(List<List<int>> elementsList)
        {
            //Flatten a list of lists
            var elements = elementsList.SelectMany(elements => elements);
            //Get only different elements
            var uniqueElements = elements.Distinct();            

            List<Tuple<int, int>> elementsCount = new List<Tuple<int, int>>();

            uniqueElements.ToList().ForEach((element) =>
            {
                var elementCount_ = elements.Aggregate(0, (accumulator, next) => accumulator = (element == next)? accumulator + 1 : accumulator);

                elementsCount.Add(new Tuple<int, int>(element, elementCount_));

            });            

            return elementsCount.ToList();
        }*/


        /*You can use yield here because we can supouse a large numbers of employees and
         you wouldn't need to wait for all the employees to be process while you can start with
        the next process to your selected employees data thus you improve the performance
         */
        public static IEnumerable<Person> GetAllYoungEmployeesFromALargeList(List<Person> employees)
        {

            foreach (var employee in employees)
            {
                if (employee.Age > 21)
                {
                    yield return employee;
                }
            }

        }


    }


    class TestLinqExcercises
    {
        //public static void Main()
        //{
            /*int[] inputNumbers = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            LinqSelectExcercises.GetSumPointsOfEachParticipant(new int[5] { 0, 1, 2, 3, 4 }.ToList<int>(), 2).ForEach(points =>
            {
               Console.WriteLine($"Total of points: {points} per participant");
            });*/

            /*var person = new Person("Luisito", 17);
            List<Person> people = new List<Person>() { new Person("Luisito", 17), new Person("Karen", 34), new Person("Sergio", 34) };
            LinqSelectExcercises.GetKidsName(people).ForEach(kidName => {
                Console.WriteLine(kidName);
            });*/

            /*Patient patient = new Patient(firstName: "Eduardo", lastName: "Hernandez");
            patient.Age = 66;

            Console.WriteLine($"Patient: {patient.ToString()}");*/

            /*LinqSelectExcercises.GetCharactersFrequency("coca").ToList().ForEach((item) =>
            {
                Console.WriteLine($"Coca:{item}");
            });*/

            /*LinqSelectExcercises.CountDifferentElementsInLists(new List<List<int>> { new List<int> { 2, 2, 1, 2, 0 } }).ForEach((item) =>
            {
                Console.WriteLine($"item:{item}");
            });*/

        //}


    }
}

