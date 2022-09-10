using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Semester
    {
        public string SName { get; set; }
        public int Scount = 1;
        static int StartYear = 2020;
        public int SemesterYear;
        public bool SemesterSession;
        static int countsession = 0;
        static int countyear = 0;
        public static List<Class> Allclasses = new List<Class>();
        public static List<Semester> Slist = new List<Semester>();



        public Semester()
        {
            countsession++;
            countyear++;
            if (countsession % 2 == 0)
            {
                SemesterSession = true;
            }
            else
            {
                SemesterSession = false;
            }
            if (countyear % 2 == 0)
            {
                StartYear++;
                SemesterYear = StartYear;
            }
            else
            {
                SemesterYear = StartYear;
            }
        }



        public void CompleteSemester(List<Student> x)
        {

            for (int k = 0; k < x.Count; k++)
            {
                for (int j = 0; j < 3; j++)
                {

                        x[k].CompleteClass(x[k].ClassesTaking[j]);

                }
            }
            for (int k = 0; k < x.Count; k++)
            {
                x[k].ClassesTaking.Clear();
                //for (int m = 0; m < 3; m++)
                //{
                    //x[k].ClassesTaking.RemoveAt(0);
                    
                //}
            }
            for (int k = 0; k<Allclasses.Count; k++)
            {
                for (int i = 0; i<Allclasses[k].ClassCapacity; i++)
                {
                    Allclasses[k].studentsInClass.Clear();
                }
            }

            Console.WriteLine("Congrats! The semester is over! Below is the list of students and the classes they still need:");
            for (int i = 0; i <x.Count;i++)
            {
                x[i].DisplayStudent();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }


            Scount++;
            Slist.Add(new Semester {SName = "S" + Scount});

        }



        public void ListAvailableClasses()
        {
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, Allclasses[i].ClassName);
                }//in case of adjustments, only 9 classes can be listed at max
            }
            catch
            {
                for (int i = 0; i<Allclasses.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i + 1, Allclasses[i].ClassName);
                }
            }
        }

        public void SemesterDetails()
        {
            string i;
            if (countsession % 2 == 0)
            {
                i = "spring";
            }
            else
            {
                i = "fall";
            }

            Console.WriteLine("The current semester is {0} {1}", i, SemesterYear);

        }

        public static void addNewClass()
        {

            int Capacity;
            bool error = true;
            Console.WriteLine("What is the name of the new class?");
            string className = Console.ReadLine();
            Console.WriteLine("What is the capacity of the new class?");
            while (error)
            {
                if (Int32.TryParse(Console.ReadLine(), out Capacity))
                {

                    Semester.Allclasses.Add(new Class { CName = "c" + Class.ccount });
                    Console.WriteLine(Class.ccount);
                    Allclasses[Class.ccount-1].ClassName = className;
                    Allclasses[Class.ccount-1].ClassCapacity = Capacity;
                    error = false;
                    Console.WriteLine("Class {0} has been created", className);
                    Allclasses.RemoveAt(Class.ccount);                    

                }
                else
                {
                    Console.WriteLine("Please enter a valid integer");
                    error = true;
                }
            }
        }

        public static void listallclasses()
        {
            for (int i = 0; i < Allclasses.Count; i++)
                Console.WriteLine("{0}. {1}", i+1, Allclasses[i].ClassName);
        }

        public void removeclass()
        {
            bool error1 = true;
            int y;
            listallclasses();
            while (error1)
            {
                try
                {
                    Console.WriteLine("What class do you want to remove? Type the number associated with this class");

                    if (int.TryParse(Console.ReadLine(), out y))
                    {
                        y--;

                        Console.WriteLine("Success. {0} has been removed", Allclasses[y].ClassName);
                        Allclasses.RemoveAt(y);


                        error1 = false;
                    }
                    else
                    {
                        Console.WriteLine("Please input a valid number integer within the range");
                        error1 = true;
                    }
                }

                catch
                {
                    Console.WriteLine("Please enter a valid integer");
                    error1 = true;
                }
            }

        }

    }//class
}
