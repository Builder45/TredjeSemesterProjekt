using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Lejer
    {
        public Guid Id { get; set; }
        public da
        public Lejemaal Lejemaal { get; set; }
        public List<Person> Personer { get; set; }
    }
}
