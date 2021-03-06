﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    public class Car
    {
        public int Id { get; }
        public String Name { get; }
        public int Consumption { get; }
        public int OwnerID { get; }
        public Car(int id, string name, int consumption, int ownerid)
        {
            Id = id;
            Name = name;
            Consumption = consumption;
            OwnerID = ownerid;
        }
        public String Information => Name + ", " + Consumption + "/100";
    }
}
