using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfIntro.Model
{
    public class Repository
    {
        public void AddPerson(string FirstName, string LastName)
        {
            EfDbContext db = new EfDbContext();

            Person person = new()
            {
                FirstName = FirstName,
                LastName = LastName
            };


            db.Persons.Add(person);
            db.SaveChanges();
        }

        public void UpdatePerson(int Id, string firstName, string lastName)
        {
            EfDbContext db = new EfDbContext();
            Person person = db.Persons.Find(Id); 
            
            if(person != null)
            {
                person.FirstName = firstName;
                person.LastName = lastName;
                db.SaveChanges();
            }
        }

        public void PrintPeople()
        {
            EfDbContext db = new EfDbContext();
            var persons = db.Persons.ToList();

            foreach(var person in persons)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

        public void DeletePerson(int Id)
        {
            EfDbContext db = new EfDbContext();
            Person person = db.Persons.Find(Id);
            if(person != null)
            {
                db.Persons.Remove(person);
                db.SaveChanges();
            }
        }
    }
}
