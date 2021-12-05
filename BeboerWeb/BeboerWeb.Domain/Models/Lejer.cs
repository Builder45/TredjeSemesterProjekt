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
            if (lejeperiodeStart >= lejeperiodeSlut) throw new ArgumentException("Slutsdatoen skal være senere end startsdatoen");

            LejeperiodeStart = lejeperiodeStart;
            LejeperiodeSlut = lejeperiodeSlut;
            Lejemaal = lejemaal;
        }

        public bool IsOverlappingWith(Lejer otherLejer)
        {
            if (LejeperiodeStart >= otherLejer.LejeperiodeSlut)
            {
                return false;
            }
            return LejeperiodeSlut > otherLejer.LejeperiodeStart;
        }
    }
}
