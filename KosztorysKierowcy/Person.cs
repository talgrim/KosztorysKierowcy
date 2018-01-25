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
        public bool Driver { get; }

        public Person(int id, string name, string surname, string driver)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            Driver = "True"==driver?true:false;
        }

        public string FullName { get { return Name + " " + Surname; } }
    }
}
