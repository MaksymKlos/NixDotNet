document.addEventListener('DOMContentLoaded', function () {
    //var events = [];
    //$.ajax({
    //    type: "GET",
    //    url: "/Workout/GetEvents",
    //    success: function (data) {
    //        $.each(data,
    //            function(i, v) {
    //                events.push({
    //                    title: v.Subject,
    //                    description: v.Description,
    //                    start: moment(v.Start),
    //                    end: v.End != null ? moment(v.End) : null,
    //                    color: v.ThemeColor,
    //                    allDay: v.IsFullDay
    //                });
    //            });

    //        GenerateCalender(events);
    //    },
    //    error: function (error) {
    //        alert('failed');
    //    }
    //    });
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        dateClick: function () {
            alert('a day has been clicked!');
        },
        eventContent: 'some text'
    });
    calendar.render();
});