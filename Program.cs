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
