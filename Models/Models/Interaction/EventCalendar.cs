using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interaction
{
    public class EventCalendar
    {
        #region Properties

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFullDay { get; set; }
        
        #endregion
    }
}
