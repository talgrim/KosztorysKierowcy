using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    public class Person
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public Person []Persons { get; private set; }
        public bool Driver { get; }

        public Person(int id, string name, string surname, bool driver)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            Driver = driver;
        }

        public string FullName { get { return Name + " " + Surname; } }

        public void ListToArray(List<Person> list)
        {
            Persons = new Person[list.Count];
            foreach(Person element in list)
                Persons[element.Id] = element;
        }
    }
}
