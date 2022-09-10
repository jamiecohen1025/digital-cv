using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Class
    {
        public string CName { get; set; }
        public string ClassName;
        public int classID;
        static int ClassIDcount = 0;
        public int ClassCapacity;
        public List<string> studentsInClass = new List<string>();
        public string CompletedClassGrade;
        public static int ccount = 0;




        public Class()
        {
            classID = ClassIDcount + 1;
            ClassCapacity = 20;
            Semester.Allclasses.Add(this);
            ccount++;
        }
        public Class(string className, int Capacity=10)
        {
            ClassName = className;
            classID = ClassIDcount + 1;
            ClassCapacity = Capacity;
            Semester.Allclasses.Add(this);
            ccount++;
        }

        public int adjustCapacity(int x)
        {
            
            ClassCapacity = x;
            return ClassCapacity;
        }

        public void ClassDetails()
        {
            Console.WriteLine("Name: {0}", ClassName);
            Console.WriteLine("Class capacity is {0} students", ClassCapacity);
            Console.WriteLine("Students in this class include:");
            for (int i = 0; i < studentsInClass.Count; i++)
            {
                Console.WriteLine("\t{0}", studentsInClass[i]);
            }

        }





    }



}
