//Jamie Cohen
//IS 350
//University system ment to replicate the process of going to a university

using System;
using System.Collections.Generic;


class main
{
    static void main(string[] args)
    {
        List<Class> ClassesRequired = new List<Class>();
        Class c1 = new Class("Intro to English", 5);
        ClassesRequired.Add(c1);
        Class c2 = new Class("Calculus", 5);
        ClassesRequired.Add(c2);
        Class c3 = new Class("Electrical Engineering", 7);
        ClassesRequired.Add(c3);
        Class c4 = new Class("Computer Engineering I", 4);
        ClassesRequired.Add(c4);
        Class c5 = new Class("Statistics", 3);
        ClassesRequired.Add(c5);
        Class c6 = new Class("Computer Engineering Lab", 2);
        ClassesRequired.Add(c6);
        Class c7 = new Class("Introduction to Python", 3);
        ClassesRequired.Add(c7);
        Class c8 = new Class("Advanced Data Structures", 5);
        ClassesRequired.Add(c8);
        Class c9 = new Class("Math", 2);
        ClassesRequired.Add(c9);
        Semester S1 = new Semester();
        Semester.Slist.Add(S1);
        List<Student> studentlist = new List<Student>();
        int Tcount;
        int Hcount;
        int Mcount;
        int y;
        int z;
        bool error1 = true;
        bool error2 = true;
        bool error3 = true;
        bool cont = true;
        bool again = true;


        Console.WriteLine("Welcome to the Pandemic University. We are online all the time");
        Console.WriteLine("How many students are are enrolling in PU?");
        while (error1)
        if (Int32.TryParse(Console.ReadLine(), out Tcount))
        {
                error1 = false;
                while (error3)
                {
                    for (int i = 0; i <Tcount; i++)
                    {
                    Console.WriteLine("What is the name of student {0}", i + 1);


                        string checkname = Console.ReadLine();
                        if (String.IsNullOrEmpty(checkname))
                        {
                            error3 = true;
                            Console.WriteLine("Please enter a name.");
                        }
                        else
                        {
                            studentlist.Add(new Student { Name = "T" + (i + 1) });
                            studentlist[i].StudentName = checkname;
                            studentlist[i].ClassesNeeded = new List<Class> {c1, c2, c3, c4, c5, c6, c7, c8, c9} ;
                            error3 = false;
                        }
                    }

                }
        }
        else
        {
                Console.WriteLine("Please input a number integer.");
                error1 = true;
        }


        Console.WriteLine("Welcome to Pandemic University. All students are required to take the following classes:");
        //for (int i = 0; i < ClassesRequired.Count; i++)
        //Console.WriteLine(ClassesRequired[i].ClassName);
        Semester.listallclasses();
        Console.WriteLine();

            Console.WriteLine("Do you want make changes to your university? Yes (1) or no (2)?");
            while(again)
            {
                while (error2)
                {
                if (Int32.TryParse(Console.ReadLine(), out Hcount))
                {
                    if (Hcount == 1)
                    {
                        Console.WriteLine("Please select from the list below for options that can be changed.");
                        Console.WriteLine("\t 1) Add class.");
                        Console.WriteLine("\t 2) Remove class.");
                        Console.WriteLine("\t 3) adjust class capacity");

                        Console.WriteLine("Please select the number associated with the adjustment you want to make.");
                        if (Int32.TryParse(Console.ReadLine(), out Mcount))
                        {
                            switch (Mcount)
                            {
                                case 1:
                                    {
                                        Semester.addNewClass();
                                        Console.WriteLine("Adjust something else? Yes (1) or no (2)");
                                        string p = Console.ReadLine();    
                                        if (p == "1")
                                        {
                                            again = true;
                                        }
                                        else
                                        {
                                            if (p == "2")
                                            {
                                                again = false;
                                                error2 = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input was administered. The system will take this as a desire to not continue adjustment.");
                                                again = false;
                                                error2 = false;
                                            }   
                                        }

                                    }
                                    break;
                                case 2:
                                    {
                                            S1.removeclass();
                                                try
                                                {
                                                Console.WriteLine("Adjust something else? Yes (1) or no (2)");
                                                if (Console.ReadLine() == "1")
                                                    {
                                                    again = true;
                                                    }
                                                    else
                                                    {
                                                    again = false;
                                                    error2 = false;
                                                    }
                                                }
                                            catch
                                                {
                                                Console.WriteLine("Invalid input was administered. The system will take this as a desire to not continue adjustment.");
                                                again = false;
                                                error2 = false;
                                                }

                                    }
                                    break;
                                case 3:
                                    {
                                        Semester.listallclasses();
                                        Console.WriteLine("Which class do you want to adjust? Select the associated number");
                                        if (int.TryParse(Console.ReadLine(), out y))
                                        {
                                            y--;
                                            Semester.Allclasses[y].ClassDetails();
                                            Console.WriteLine("The current Capacity is displayed above.");
                                            Console.WriteLine("What do you want the new capacity to be?");
                                            if (int.TryParse(Console.ReadLine(), out z))
                                            {
                                                Semester.Allclasses[y].adjustCapacity(z);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Please input a valid number integer within the range");
                                                error2 = true;
                                            }
                                            try
                                                {
                                                    Console.WriteLine("Adjust something else? Yes (1) or no (2)");
                                                    if (Console.ReadLine() == "1")
                                                    {
                                                        again = true;

                                                    }
                                                    else
                                                    {
                                                        again = false;
                                                        error2 = false;
                                                    }
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Invalid input was administered. The system will take this as a desire to not continue adjustment.");
                                                    again = false;
                                                    error2 = false;
                                                }

                                        }
                                        break;

                                    }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please select an integer number from the list.");
                            error2 = true;
                        }


                    }
                    else
                    {
                        if (Hcount == 2)
                        {
                            Console.WriteLine("The semester will continue as previously set");
                            error2 = false;
                            again = false;
                        }
                        else
                        {
                            Console.WriteLine("Please type 1 for yes or 2 for no.");
                            error2 = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please type 1 for yes or 2 for no.");
                    error2 = true;
                }
                }
            }
            
        Console.WriteLine();
            
        while (cont)
        {
            for (int k = 0; k < Semester.Slist.Count; k++)
            {

                if (studentlist.Count > 0)
                {
                    for (int i = 0; i < studentlist.Count; i++)
                    {

                        Console.WriteLine("Students must take 3 classes per semester. Student's can take classes again as electives or to improve GPA");
                        studentlist[i].addclass(Semester.Slist[k]);
                        Console.WriteLine();
                    }
                    Console.WriteLine("With classes assigned. Students will now take the semester");
                    S1.CompleteSemester(studentlist);

                    for (int i = 0; i < studentlist.Count; i++)
                    {
                        if (studentlist[i].ClassesNeeded.Count == 0)
                        {
                            Console.WriteLine("Congrats! Student {0} graduated!", studentlist[i].StudentName);
                            Console.WriteLine();
                            Console.WriteLine();
                            Student.Graduates.Add(studentlist[i]);
                            studentlist.RemoveAt(i);

                            i--;
                        }
                        else
                        {
                            cont = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Congratulation! All students have graduated. We hope you enjoyed your time at PU!");
                    Student.DisplayGraduates();
                    cont = false;
                }
                        
                        


            }
        }   
                    
                
    }

}//main





    