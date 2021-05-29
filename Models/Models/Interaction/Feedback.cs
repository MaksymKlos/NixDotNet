using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interaction
{
    public class Feedback:IPersonData
    {
        public int FeedbackId { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; }
    }
}
