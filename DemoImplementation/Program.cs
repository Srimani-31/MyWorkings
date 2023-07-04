using System;

namespace DemoImplementation
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DemoNullReferenceException();
        }

        static void DemoNullReferenceException()
        {
            
            try
            {
                Person person = null;
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Null reference caught{0}",ex.Message);
            }           
        }
    }
}
