using SampleReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleReact.Services
{
    public interface IFactory
    {
        ISlotTimes Confirm(List<Slot> SelectedSlots);
        List<Slot> GetBooking();
        ISlotTimes Return(List<Slot> SelectedSlots);
    }

    public class Factory : IFactory
    {
        private IBooked Booked;
        private IBooking Booking;
        public Factory(IBooking booking, IBooked booked)
        {
            Booked = booked;
            Booking = booking;
        }

        public List<Slot> GetBooking()
        {
            return Booking.GetAll();
        }


        public ISlotTimes Confirm(List<Slot> SelectedSlots)
        {
            Booking.Update(SelectedSlots, BookingStatus.booked);
            return Booked.Add(SelectedSlots);

        }

        public ISlotTimes Return(List<Slot> SelectedSlots)
        {
            Booking.Update(SelectedSlots, BookingStatus.available);
            return Booked.Reomve(SelectedSlots);

        }





    }







}
