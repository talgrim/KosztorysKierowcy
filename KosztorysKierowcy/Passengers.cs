using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    class Passengers
    {
        public int TransitId { get; }
        public Person Passenger { get; }

        public Passengers(int transitId, Person passenger)
        {
            TransitId = transitId;
            Passenger = passenger;
        }
    }
}
