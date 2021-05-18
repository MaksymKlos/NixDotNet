using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }      
        public double Height { get; set; }
        public string Status { get; set; }
        public virtual List<TrainingProgram> TrainingPrograms { get; set; }
        public virtual List<NutritionProgram> NutritionPrograms { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            }
            
        }

        public User()
        {
            Random random = new Random();
            Name = $"User#{random.Next(1000,9999)}";
        }

        public User(string name)
        {
            Name = name;
        }

        public User(string name, DateTime birthDate, string gender,double weight, double height)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            Height = height;
        }
        public override string ToString() => $"{Status} {Name}, {Age}";
        
    }
}
