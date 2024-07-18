using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RalfLesson {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter Fullname and birthday: ");
            var person1 = new Person {
                Fullname = Console.ReadLine(),
                Birthday = Convert.ToDateTime(Console.ReadLine()),
            };
            person1.DisplayInformation();

            Console.WriteLine("Enter Fullname and birthday: ");
            var person2 = new Person {
                Fullname = Console.ReadLine(),
                Birthday = Convert.ToDateTime(Console.ReadLine()),
            };
            person2.DisplayInformation();
            Console.ReadLine();
        }

        static void Procedural() {
            Console.Write("Enter your fullname: ");
            var fullname = Console.ReadLine();

            Console.Write("Enter your Birthday: ");
            var bday = Console.ReadLine();

            int Age = (int)DateTime.Now.Subtract(Convert.ToDateTime(bday)).TotalDays / 365;

            Console.Write($"Hi, {fullname} your age is {Age}");

            Console.WriteLine("\n");

            Console.Write("Enter your fullname: ");
            var fullname2 = Console.ReadLine();

            Console.Write("Enter your Birthday: ");
            var bday2 = Console.ReadLine();

            int Age2 = (int)DateTime.Now.Subtract(Convert.ToDateTime(bday2)).TotalDays / 365;

            Console.Write($"Hi, {fullname2} your age is {Age2}");
            Console.ReadLine();
        }

        static void OOP1() {
            Person person1 = new Person();
            Console.Write("Enter your fullname: ");
            person1.Fullname = Console.ReadLine();

            Console.Write("Enter your Birthday: ");
            person1.Birthday = Convert.ToDateTime(Console.ReadLine());
            person1.DisplayInformation();

            Console.WriteLine("\n");

            Person person2 = new Person();
            Console.Write("Enter your fullname: ");
            person2.Fullname = Console.ReadLine();

            Console.Write("Enter your Birthday: ");
            person2.Birthday = Convert.ToDateTime(Console.ReadLine());
            person2.DisplayInformation();
        }
    }

    //-----------------My Class OOP

    class Person {
        public string Fullname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get { return GetAge(Birthday); } }

        public Person() {

        }

        public Person(string Fullname, DateTime Birthday) {
            this.Fullname = Fullname;
            this.Birthday = Birthday;
        }

        public void DisplayInformation() {
            Console.WriteLine($"Fullname: {this.Fullname}");
            Console.WriteLine($"Age: {this.Age}");
        }

        private int GetAge(DateTime _Birthday) {
            int output = 0;
            output = (int)DateTime.Now.Subtract(_Birthday).TotalDays / 365;
            return output;
        }
    }
}
