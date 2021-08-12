using System;
using System.Collections.Generic;
using System.Linq;
using FitnessSuperiorMvc.DA.Entities.Interaction;
using FitnessSuperiorMvc.DA.Interfaces;

namespace FitnessSuperiorMvc.Services.Programs
{
    public class CalendarService
    {
        private readonly IRepository<Event> _eventRepository;
        public CalendarService() { }
        public CalendarService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public virtual List<Event> GetAll()
        {
            var events = _eventRepository
                .GetAll().ToList();
            return events;
        }

        public virtual Event GetById(int id)
        {
            return _eventRepository.GetById(id);
        }


        public virtual void Update(Event myEvent) => _eventRepository.Update(myEvent);

        public virtual void Remove(int id)
        {
            var myEvent = _eventRepository.GetById(id);
            if (myEvent == null)
            {
                throw new ArgumentNullException(nameof(myEvent), $"Cannot find event with id '{id}'");
            }
            _eventRepository.Remove(id);
        }

        public virtual Event Create(Event MyEvent) => _eventRepository.Create(MyEvent);
    }
}
