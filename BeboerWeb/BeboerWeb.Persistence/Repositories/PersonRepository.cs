using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BeboerWebContext _db;

        public PersonRepository(BeboerWebContext db)
        {
            _db = db;
        }
        
        public void CreatePerson(Person person)
        {
            _db.Add(person);
            _db.SaveChanges();
        }

        public Person GetPerson(Guid id)
        {
            return _db.Person.Include(p=>p.Lejere).FirstOrDefault(e => e.Id == id);
        }

        public Person GetPersonByUser(Guid brugerId)
        {
            return _db.Person.First(e => e.BrugerId == brugerId);
        }

        public List<Person> GetPersoner()
        {
            return _db.Person.ToList();
        }

        public void UpdatePerson(Person person)
        {
            if (!personExists(person))
                throw new ArgumentException("Person with given ID does not exist");

            _db.Person.Update(person);
            _db.SaveChanges();
        }

        //public bool IsActiveLejer(Guid personId)
        //{
        //    var activeLejer = false;

        //    var person = _db.Person.First(p => p.Id == personId);

        //    foreach (var lejer in person.Lejere)
        //    {
        //        if (DateTime.Now > lejer.LejeperiodeStart && DateTime.Now < lejer.LejeperiodeSlut)
        //        {
        //            activeLejer = true;
        //        }
        //    }
        //    return activeLejer;
        //}

        private bool personExists(Person person)
        {
            return _db.Person.Any(e => e.Id == person.Id);
        }

        

    }






    


}





