using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    class Car
    {
        public int Id { get; }
        public String Name { get; }
        public int Consumption { get; }
        public Car(int id, string name, int consumption)
        {
            Id = id;
            Name = name;
            Consumption = consumption;
        }
        public String Information { get { return Name + ", " + Consumption + "/100"; } }
    }
}
