using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementConsoleApp
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }

    public class Program
    {
        static List<Student> students = new List<Student>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== STUDENT MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            break;

                        case 2:
                            ViewStudents();
                            break;

                        case 3:
                            UpdateStudent();
                            break;

                        case 4:
                            DeleteStudent();
                            break;

                        case 5:
                            Console.WriteLine("Application Closed.");
                            return;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }

        static void AddStudent()
        {
            try
            {
                Student student = new Student();

                Console.Write("Enter Student Id: ");
                student.Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                student.Name = Console.ReadLine() ?? "";

                Console.Write("Enter Student Age: ");
                student.Age = Convert.ToInt32(Console.ReadLine());

                students.Add(student);

                Console.WriteLine("Student Added Successfully.");
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        static void ViewStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found.");
                return;
            }

            Console.WriteLine("\n----- STUDENT LIST -----");

            foreach (Student s in students)
            {
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name} | Age: {s.Age}");
            }
        }

        static void UpdateStudent()
        {
            try
            {
                Console.Write("Enter Student Id to Update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Student? student = students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    Console.WriteLine("Student Not Found.");
                    return;
                }

                Console.Write("Enter New Name: ");
                student.Name = Console.ReadLine() ?? "";

                Console.Write("Enter New Age: ");
                student.Age = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Student Updated Successfully.");
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        static void DeleteStudent()
        {
            try
            {
                Console.Write("Enter Student Id to Delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Student? student = students.FirstOrDefault(s => s.Id == id);

                if (student == null)
                {
                    Console.WriteLine("Student Not Found.");
                    return;
                }

                students.Remove(student);

                Console.WriteLine("Student Deleted Successfully.");
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
            }
        }
    }
}