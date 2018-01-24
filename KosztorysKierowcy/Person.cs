using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    class Person
    {
        public int Id { get; }
        public String Name { get; }
        public String Surname { get; }
        public Person []Persons { get; private set; }

        public Person(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public String FullName { get { return Name + " " + Surname; } }

        public void ListToArray(List<Person> list)
        {
            Persons = new Person[list.Count];
            foreach(Person element in list)
                Persons[element.Id] = element;
        }
    }
}
