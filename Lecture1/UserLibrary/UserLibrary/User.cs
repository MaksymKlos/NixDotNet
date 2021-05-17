using System;

namespace UserLibrary
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string DisplayInfo() => $"Name: {Name}, age: {Age}";

        public override string ToString()=>$"Name: {Name}, age: {Age}";

    }
}
