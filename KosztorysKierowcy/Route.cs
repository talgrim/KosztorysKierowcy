using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    public class Route
    {
        public int Id { get; }
        public String Name { get; }
        public int Distance { get; }
        public Route(int id, string name, int distance)
        {
            Id = id;
            Name = name;
            Distance = distance;
        }
        public String Information { get { return Name + ", " + Distance + " km"; } }
    }
}
