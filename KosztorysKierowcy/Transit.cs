using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace KosztorysKierowcy
{
    class Transit
    {
        [DisplayName("ID")]
        public string TransitID { get { return Transitid.ToString(); } }
        [DisplayName("Kierowca")]
        public string DriverName { get { return Driver.FullName; } }
        [DisplayName("Pasażerowie")]
        public string PassengersList
        {
            get
            {
                string result = "";
                foreach (Person person in Passengers)
                    result += person.FullName + ", ";
                if(result == "")
                    result = "Brak";
                else
                    result = result.Remove(result.Length - 2, 2);
                return result;
            }
        }
        [DisplayName("Koszt")]
        public string TransitCost { get { return Cost.ToString("F") + " zł"; } }
        [DisplayName("Data")]
        public string Date { get { return Driven.ToString(); } }
        [DisplayName("Auto")]
        public string CarName { get { return Car.Name; } }
        [DisplayName("Trasa i dystans")]
        public string RouteName { get { return Route.Information; } }
        public int Transitid;
        public Person Driver;
        public Car Car;
        public Route Route;
        public DateTime Driven;
        public Person[] Passengers;
        public double Cost;

        public Transit()
        {
            Transitid = 0;
            Cost = 0;
            Driver = null;
            Car = null;
            Route = null;
            Passengers = null;
        }

        public Transit(int transitid, double cost, Person driver, Car car, Route route, DateTime driven)
        {
            Transitid = transitid;
            Cost = cost;
            Driver = driver;
            Car = car;
            Route = route;
            Driven = driven;
        }

        public Transit(int transitid, double cost, Person driver, Car car, Route route, Person person, DateTime driven)
        {
            Transitid = transitid;
            Cost = cost;
            Driver = driver;
            Car = car;
            Route = route;
            this.AddPassenger(person);
            Driven = driven;
        }

        public void AddPassenger(Person person)
        {
            if (null == this.Passengers)
                this.Passengers = new Person[1];
            else
                Array.Resize(ref this.Passengers, this.Passengers.Length+1);
            this.Passengers[this.Passengers.Length-1] = person;
        }
    }
}
