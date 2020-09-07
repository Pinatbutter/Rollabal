/******************************************************************************************************
* Diego Pina                                                                                          *
* Dr McCown                                                                                           *
* Comp 4450-01                                                                                        *
* Sept 2, 2020                                                                                        *
* HW - C# Console Program                                                                             *
* Project Description:   This program organizes a list of students into two other lists: "left" and   *
* "right". It does so according to the first number in their HNumber.                                 *
*******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            students.Add(new Student { FirstName = "Bob", LastName = "Smith", HNumber = "H12345678" });
            students.Add(new Student { FirstName = "Pam", LastName = "White", HNumber = "H22345678" });
            students.Add(new Student { FirstName = "Sue", LastName = "Black", HNumber = "H52345678" });
            students.Add(new Student { FirstName = "Lee", LastName = "Green", HNumber = "H82345678" });

            List<Student> leftStudents;
            List<Student> rightSudents;
            DivideStudents(students, out leftStudents, out rightSudents);

            // Pam and Lee
            Console.WriteLine("Left:");
            foreach (var s in leftStudents)
            {
                Console.WriteLine(s);
            }

            // Bob and Sue
            Console.WriteLine("\nRight:");
            foreach (var s in rightSudents)
            {
                Console.WriteLine(s);
            }
        }
        public static void DivideStudents(List<Student> students, out List<Student> left, out List<Student> right)
        {
            left = new List<Student>();
            right = new List<Student>();
            foreach (var aStudent in students)
            {
                int temp = int.Parse("0" + aStudent.HNumber[1]);
                int isEven = 0;
                int odd = 1;
                int evenOrOdd = temp % 2;
                if (evenOrOdd == isEven)
                {
                    left.Add(aStudent);
                }
                else if (evenOrOdd == odd)
                {
                    right.Add(aStudent);
                }
            }

        }
    }

    class Student
    {
        private string firstName, lastName, hNumber;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                
                if(value == "")
                {
                    throw new ArgumentException(String.Format("First name cant be empty"));
                }
                else
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (value == "")
                {
                    throw new ArgumentException(String.Format("Last name cant be empty"));
                }
                else
                {
                    lastName = value;
                }
            }
        }


        /************************************************************************************************************************
         *  Citations for HNumber:                                                                                              *
         *  https://www.dotnetperls.com/substring                                                                               *
         *  https://stackoverflow.com/questions/7461080/fastest-way-to-check-if-string-contains-only-digits                     *
          **********************************************************************************************************************/
        public string HNumber
        {
            get
            {
                return hNumber;
            }

            set
            {
                int hNumberLenght = 9;
                if (value.Length != hNumberLenght)
                {
                    throw new ArgumentException(String.Format("HNumber has to have a value length of 9"));
                }
                if (value[0] != 'H')
                {
                    throw new ArgumentException(String.Format("HNumber has to start with an 'H'"));
                }
                string onlyDigits = value.Substring(1, 8);
                if (onlyDigits.All(char.IsDigit) != true)
                {
                    throw new ArgumentException(String.Format("Characters following the 'H' in HNumber should be digits"));
                }
                else
                {
                   hNumber = value;
                }
            }
        }

        public override string ToString()
        {
            return FirstName + ", " + LastName + " - " + HNumber;
        }

    }
}
