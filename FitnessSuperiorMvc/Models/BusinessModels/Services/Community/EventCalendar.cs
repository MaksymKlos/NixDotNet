using System;

namespace FitnessSuperiorMvc.BLL.BusinessModels.Services.Community
{
    public class EventCalendar
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFullDay { get; set; }
        
    }
}
