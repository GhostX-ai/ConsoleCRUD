using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ConsoleCRUD.Models;
using System.Linq;

namespace ConsoleCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            Console.WriteLine("Welcome to hell");
            while (true)
            {
                AlwaysOn();
                try
                {
                    Console.WriteLine("1 - for add a student\n2 - for select the student");
                    int chs = int.Parse(Console.ReadLine());
                    if (chs == 1)
                    {
                        AddStudent();
                    }
                    else if (chs == 2)
                    {
                        Console.Write("Copy and Enter Id from upper:");
                        string Id = Console.ReadLine();
                        using (SchoolContext db = new SchoolContext())
                        {
                            st = db.Student.Find(Id);
                            if (st == null)
                            {
                                continue;
                            }
                            Console.Write("1 for delete\n2 for edit\t:");
                            int ch = int.Parse(Console.ReadLine());
                            if (ch == 1)
                            {
                                db.Student.Remove(st);
                                db.SaveChanges();
                            }
                            else if (ch == 2)
                            {
                                Console.Write("Enter new FullName:");
                                st.FullName = Console.ReadLine();
                                Console.Write("Enter new Age:");
                                st.Age = int.Parse(Console.ReadLine());
                                Console.Write("Enter new Grade:");
                                st.Level = int.Parse(Console.ReadLine());
                                db.SaveChanges();
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private static void AlwaysOn()
        {
            using (SchoolContext db = new SchoolContext())
            {
                db.Student.ToList().ForEach(p =>
                {
                    Console.WriteLine($"Id:{p.Id}\nFullName:{p.FullName}\nLevel:{p.Level}\nAge:{p.Age}");
                });
            }
        }

        private static void AddStudent()
        {
            Guid gr = Guid.NewGuid();
            Student st = new Student();
            st.Id = gr.ToString();
            Console.Write("Enter student's FullName:");
            st.FullName = Console.ReadLine();
            Console.Write("Enter his(her) age:");
            st.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter student's grade:");
            st.Level = int.Parse(Console.ReadLine());
            using (SchoolContext db = new SchoolContext())
            {
                db.Student.Add(st);
                db.SaveChanges();
            }
        }
    }
}
