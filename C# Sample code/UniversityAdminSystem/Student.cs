using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Project
{
    class Student
    {
        public string Name { get; set; }
        public int StudentID;
        public string StudentName;
        static int nextStudentID;
        public List<Class> ClassesTaking;
        public List<Class> ClassesCompleted;
        public List<Class> ClassesNeeded;
        public double GPA;
        static List<double> CompletedGPAs;
        public static List<Student> Graduates = new List<Student>();

        public List<Semester> SemestersCompleted;


        public Student()
        {
            nextStudentID++;
            StudentID = nextStudentID;
            GPA = 4.00;
            ClassesTaking = new List<Class>();
            ClassesCompleted = new List<Class>();
            CompletedGPAs = new List<double>();
            CompletedGPAs.Add(4.00);
            ClassesNeeded = new List<Class>();
            SemestersCompleted = new List<Semester>();
        }//studentconstructor

        public Student(string name)
        {
            StudentName = name;
            nextStudentID++;
            StudentID = nextStudentID;
            ClassesTaking = new List<Class>();
            ClassesCompleted = new List<Class>();
            ClassesNeeded = new List<Class>();
            GPA = 4.00;
            CompletedGPAs = new List<double>();
            CompletedGPAs.Add(4.00);
            SemestersCompleted = new List<Semester>();
        }//student constructor

        public void DisplayStudent()
        {
            Console.WriteLine("Displaying the details of student {0}", StudentName);
            Console.WriteLine("\t Student {0}", StudentID);
            Console.WriteLine("\t Student {0} has a GPA of {1}", StudentName, GPA);
            Console.WriteLine("\t {0} is taking the following classes:", StudentName);
            for (int i = 0; i < ClassesTaking.Count; i++)
            {
                Console.WriteLine("\t\t{0}", ClassesTaking[i].ClassName);
            }
            Console.WriteLine("\t {0} has taken the following classes:",StudentName);
            for (int i = 0; i < ClassesCompleted.Count; i++)
            {
                Console.WriteLine("\t\t {0}", ClassesCompleted[i].ClassName);
            }
            Console.WriteLine("\t{0} needs to take the following classes:",StudentName);
            for (int i = 0; i < ClassesNeeded.Count; i++)
            {
                Console.WriteLine("\t\t{0}", ClassesNeeded[i].ClassName);
            }
        }//displaystudent method

        public void CompleteClass(Class x)
        {
            Random rand = new Random();
            double grade = rand.Next(0, 6);

            if (grade <= 0.5)
            {
                x.CompletedClassGrade = "A";

                ClassesCompleted.Add(x);
                ClassesNeeded.Remove(x);
                CompletedGPAs.Add(4.00);
                GPA = CompletedGPAs.Average();
                Console.WriteLine("{0} completed {1} with a {2}", this.StudentName, x.ClassName, x.CompletedClassGrade);
            }
            else
            {
                if (grade < 2)
                {
                    x.CompletedClassGrade = "B";
                    //ClassesTaking.Remove(x);
                    ClassesCompleted.Add(x);
                    ClassesNeeded.Remove(x);
                    CompletedGPAs.Add(3.00);
                    GPA = CalculateGPA(CompletedGPAs);
                    Console.WriteLine("{0} completed {1} with a {2}", this.StudentName, x.ClassName, x.CompletedClassGrade);
                }
                else
                {
                    if (grade < 4)
                    {
                        x.CompletedClassGrade = "C";
                        //ClassesTaking.Remove(x);
                        ClassesCompleted.Add(x);
                        ClassesNeeded.Remove(x);
                        CompletedGPAs.Add(2.00);
                        GPA = CalculateGPA(CompletedGPAs);
                        Console.WriteLine("{0} completed {1} with a {2}", this.StudentName, x.ClassName, x.CompletedClassGrade);
                    }
                    else
                    {
                        if (grade < 5.25)
                        {
                            x.CompletedClassGrade = "D";
                            //ClassesTaking.Remove(x);
                            ClassesCompleted.Add(x);
                            ClassesNeeded.Remove(x);
                            CompletedGPAs.Add(1.00);
                            GPA = CalculateGPA(CompletedGPAs);
                            Console.WriteLine("{0} completed {1} with a {2}", this.StudentName, x.ClassName, x.CompletedClassGrade);
                        }
                        else
                        {
                            x.CompletedClassGrade = "F";
                            CompletedGPAs.Add(0);
                            GPA = CalculateGPA(CompletedGPAs);
                            Console.WriteLine("{0} completed {1} with a {2}", this.StudentName, x.ClassName, x.CompletedClassGrade);
                        }//F else

                    }//D else
                }//C else
            }//B else/ end of grades If statement a          
        }//completeclass method   

        public void addclass(Semester y)
        {

            int z = 0;
            y.SemesterDetails();
            y.ListAvailableClasses();
            for (int j = 0; j < 3; j++)
            {
                bool error = true;
                bool capacityfull = true;

                while (error)
                {

                    Console.WriteLine("What is {0}'s Class {1}? Type 1-9 where 1 is the top of the list and 9 is the bottom of the list.", StudentName, j + 1);
                    while (capacityfull)
                    {
                        if (Int32.TryParse(Console.ReadLine(), out z))
                        {
                            error = false;
                            switch (z)
                            {
                                case 1:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[0]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[0].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[0].ClassCapacity == Semester.Allclasses[0].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[0].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[0]);
                                                Semester.Allclasses[0].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[1]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[1].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[1].ClassCapacity == Semester.Allclasses[1].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[1].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[1]);
                                                Semester.Allclasses[1].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[2]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[2].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[2].ClassCapacity == Semester.Allclasses[2].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[2].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[2]);
                                                Semester.Allclasses[2].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 4:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[3]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[3].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[3].ClassCapacity == Semester.Allclasses[3].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[3].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[3]);
                                                Semester.Allclasses[3].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 5:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[4]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[4].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[4].ClassCapacity == Semester.Allclasses[4].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[4].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[4]);
                                                Semester.Allclasses[4].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 6:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[5]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[5].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[5].ClassCapacity == Semester.Allclasses[5].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[5].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[5]);
                                                Semester.Allclasses[5].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 7:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[6]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[6].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[6].ClassCapacity == Semester.Allclasses[6].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[6].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[6]);
                                                Semester.Allclasses[6].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 8:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[7]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[7].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[7].ClassCapacity == Semester.Allclasses[7].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[7].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[7]);
                                                Semester.Allclasses[7].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                case 9:
                                    {
                                        if (ClassesTaking.Contains(Semester.Allclasses[8]))
                                        {
                                            Console.WriteLine("You are already enrolled in {0}. Pick a different class", Semester.Allclasses[8].ClassName);
                                            capacityfull = true;
                                        }
                                        else
                                        {
                                            if (Semester.Allclasses[8].ClassCapacity == Semester.Allclasses[8].studentsInClass.Count)
                                            {
                                                Console.WriteLine("Error. {0} is full. Please select another class.", Semester.Allclasses[8].ClassName);
                                                capacityfull = true;
                                            }
                                            else
                                            {
                                                ClassesTaking.Add(Semester.Allclasses[8]);
                                                Semester.Allclasses[8].studentsInClass.Add(StudentName);
                                                capacityfull = false;
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("Enter a valid integer between 1 and {0} :)", Semester.Allclasses.Count - 1);
                                        error = true;
                                    }
                                    break;
                            }//switchcase

                        }//if

                        else
                        {
                            Console.WriteLine("Enter a valid integer between 1 and 5");
                            error = true;
                        }//else
                    }

                }//error
            }//for
            if (y.SemesterSession == false)
            {
                Console.WriteLine("Student {0} is taking the following classes in fall {1}", StudentName, y.SemesterYear);
                for (int i = 0; i < ClassesTaking.Count; i++)
                    Console.WriteLine("\t {0}", ClassesTaking[i].ClassName);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Student {0} is taking the following classes in spring {1}", StudentName, y.SemesterYear);
                for (int i = 0; i < ClassesTaking.Count; i++)
                    Console.WriteLine("\t {0}", ClassesTaking[i].ClassName);
                Console.WriteLine();
            }//else
        }//addclass method

        public static void DisplayGraduates()
        {
            Console.WriteLine("Student's who graduated include:");
            for (int i = 0; i<Graduates.Count; i++)
            {
                Console.WriteLine("\t{0} with a GPA of {1}",Graduates[i].StudentName,Graduates[i].GPA);
            }
        }

        public double CalculateGPA(List<double> x)
        {
            double y = x.Average();
            return y;

        }
    }//Classs
}






