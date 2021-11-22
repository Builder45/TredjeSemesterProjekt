using BeboerWeb.Application.Persistence;
using BeboerWeb.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

     
    }






    


}





