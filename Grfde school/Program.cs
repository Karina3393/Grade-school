namespace Grfde_school
{
    internal class Program
    {
        class School
        {
           
            private Dictionary<int, List<string>> roster = new Dictionary<int, List<string>>();

            
            public void AddStudent(string studentName, int grade)
            {
               
                if (roster.Values.Any(students => students.Contains(studentName)))
                {
                    Console.WriteLine($"Учень {studentName} вже зареєстрований у школі.");
                    return;
                }

                if (!roster.ContainsKey(grade))
                {
                    roster[grade] = new List<string>();
                }

                roster[grade].Add(studentName);
                Console.WriteLine($"Додано {studentName} до {grade} класу.");
            }

           
            public List<string> GetStudentsInGrade(int grade)
            {
                if (roster.ContainsKey(grade))
                {
                    return roster[grade].OrderBy(name => name).ToList();
                }
                else
                {
                    return new List<string>();
                }
            }

            
            public List<string> GetAllStudentsSorted()
            {
                return roster.OrderBy(kvp => kvp.Key)
                             .SelectMany(kvp => kvp.Value.OrderBy(name => name)) 
                             .ToList();
            }
        }

       
            static void Main(string[] args)
            {
                School school = new School();

                school.AddStudent("Anna", 1);
                school.AddStudent("Barb", 1);
                school.AddStudent("Charlie", 1);
                school.AddStudent("Alex", 2);
                school.AddStudent("Peter", 2);
                school.AddStudent("Zoe", 2);
                school.AddStudent("Jim", 5);

                school.AddStudent("Jim", 5); 

              
                Console.WriteLine("Учні у 2 класі: " + string.Join(", ", school.GetStudentsInGrade(2)));

               
                Console.WriteLine("Усі учні: " + string.Join(", ", school.GetAllStudentsSorted()));
            }
        }
    }
