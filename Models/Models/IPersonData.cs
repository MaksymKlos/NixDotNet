﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    internal interface IPersonData
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get;}
    }
}
