using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.DA.Entities.People
{
    public class Manager:IPerson, IKey
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
    }
}
