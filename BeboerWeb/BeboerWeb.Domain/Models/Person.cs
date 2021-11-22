using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Telefonnr { get; set; }
        public Guid BrugerId { get; set; }

        public List<Lejer> Lejere { get; set; }
        public List<Booking> Bookinger { get; set; }

        public Person() { }
        public Person(string fornavn, string efternavn, int telefonnr, Guid brugerId)
        {
            Fornavn= fornavn;
            Efternavn= efternavn;
            Telefonnr = telefonnr;
            BrugerId = brugerId;
        }
    }
}
