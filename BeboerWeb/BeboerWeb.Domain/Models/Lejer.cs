using System.Collections.Generic;

namespace BeboerWeb.Domain.Models
{
    public class Lejer
    {
        public Guid Id { get; set; }

        public DateTime LejeperiodeStart { get; set; }

        public DateTime LejeperiodeSlut { get; set; }

        public Lejemaal Lejemaal { get; set; }
        public List<Person> Personer { get; set; } = new List<Person>();

        // Tom constructor vigtig for EF
        public Lejer() { }

        public Lejer(DateTime lejeperiodeStart, DateTime lejeperiodeSlut, Lejemaal lejemaal)
        {
            LejeperiodeStart = lejeperiodeStart;
            LejeperiodeSlut = lejeperiodeSlut;
            Lejemaal = lejemaal;
        }
    }
}
