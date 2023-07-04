using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAutoMapper.Models;

namespace DemoAutoMapper.Repositories
{
    public class PersonRepository
    {
        public static List<Person> persons;
        public PersonRepository()
        {
            persons = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            persons.Add(person);
        }
        
        public List<Person> GetAllPersons()
        {
            return persons;
        }
        public Person GetPersonById(int Id)
        {
            foreach(var person in persons)
            {
                if(person.Id == Id)
                    return person;
            }
            return null;
        }
        public void UpdatePerson(Person person)
        {

        }
        public void RemovePerson(int Id)
        {

        }
    }
}
