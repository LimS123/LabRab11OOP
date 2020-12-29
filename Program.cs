using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace LabRab11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var lengthMonth = from key in month
                              where key.Length == 6
                              orderby key
                              select key;

            var winterOrSummerMonth = from w in month
                                      where w == "June" || w == "July" || w == "August"
                               || w == "January" || w == "December" || w == "February"
                                      orderby w
                                      select w;

            var ascendingMonth = from a in month
                                 orderby a ascending
                                 select a;

            var absMonth = from abs in month
                           where abs.Contains("u") && abs.Length >= 4
                           orderby abs
                           select abs;


            foreach (var i in lengthMonth)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            foreach (var i in winterOrSummerMonth)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            foreach (var i in ascendingMonth)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            foreach (var i in absMonth)
            {
                Console.WriteLine(i);
            }

            List < Student > students = new List<Student>
            {
                new Student {Name = "Roman Zayats", faculty = "FIT", groupp = 2, Age = 18 },
                new Student {Name = "Vlad Simakovich", faculty = "FIT", groupp = 2, Age = 18 },
                new Student {Name = "Dasha Volchek", faculty = "FIT", groupp = 1, Age = 19 },
                new Student {Name = "Maxim Akulevich", faculty = "FIT", groupp = 1, Age = 19 },
                new Student {Name = "Maloy Student", faculty = "PIM", groupp = 5, Age = 17 }
            };

            var findFaculty = from student in students
                              where student.faculty == "PIM"
                              select student;

            Console.WriteLine();
            foreach (Student student in findFaculty)
                Console.WriteLine($"{student.Name} - {student.faculty}");

            Console.WriteLine();

            var findAge = from student in students
                              where student.Age < 18
                              select student;

            foreach(Student student in findFaculty)
                Console.WriteLine($"{student.Name} - {student.Age} - младший студент");
            Console.WriteLine();

            var findGroup = from student in students
                            where student.groupp == 2
                            select student;

            foreach (Student student in findGroup)
                Console.WriteLine($"{student.Name} - {student.groupp} - студент искомой группы");
            Console.WriteLine();

            var findName = from student in students
                            where student.Name == "Roman Zayats"
                            select student;

            foreach (Student student in findName)
                Console.WriteLine($"{student.Name} - {student.groupp} - студент c искомым именем");
            Console.WriteLine();

            List < Team > teams = new List<Team>()
               {
                 new Team { Name = "NaVi", Country ="Укрина" },
                 new Team { Name = "VirtusPro", Country ="Польша" }
            };
            List<Player> players = new List<Player>()
            {
                 new Player {Name="flamie", Team="NaVi"},
                 new Player {Name="S1mple", Team="NaVi"},
                 new Player {Name="YEKINDAR", Team="VirtusPro"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");

            Console.Read();
        }
        public class Team
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }
        public class Player
        {
            public string Name { get; set; }
            public string Team { get; set; }
        }
        class Student
        {
            public string Name { get; set; }
            public string faculty { get; set; }
            public int groupp { get; set; }

            public int Age { get; set; }
        }
    }
}

