using System;
using System.Collections.Generic;


namespace Models.People
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

        public Gender() {}
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name),"Gender name can't be null or empty.");
            }

            Name = name;
        }
        public override string ToString()=> Name;
        
    }
}
