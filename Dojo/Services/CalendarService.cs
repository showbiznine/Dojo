using Dojo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;

namespace Dojo.Services
{
    public class CalendarService
    {
        private static Appointment BuildAppointment(DJListing listing, DateTime startTime, TimeSpan duration, bool allDay, TimeSpan reminder)
        {
            var appointment = new Appointment();
            appointment.StartTime = startTime;
            if (duration != null)
                appointment.Duration = duration;
            appointment.AllDay = allDay;
            appointment.Subject = listing.name;
            //Check the location to make sure it gets parsed correctly
            appointment.Location = listing.address.line1;
            appointment.Details = listing.subtitle;
            appointment.Reminder = reminder;
            //Test this with listing.website, etc.
            appointment.Uri = new Uri(listing.pretty_url);

            return appointment;
        }

        public static async Task<String> AddToCalendar(DJListing listing, DateTime startTime, TimeSpan duration, bool allDay, TimeSpan reminder)
        {
            var appointment = BuildAppointment(listing, startTime, duration, allDay, reminder);
            var appointmentId = await AppointmentManager.ShowEditNewAppointmentAsync(appointment);
            return appointmentId;
        }
    }
}
