using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosztorysKierowcy
{
    public class Person : IComparable
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

        public string FullName => Name + " " + Surname;

    public int CompareTo(object obj)
    {
        Person compare = obj as Person;
        return String.Compare(this.Surname, compare.Surname);
    }
}
}
