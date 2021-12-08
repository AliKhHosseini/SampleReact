using SampleReact.Models;
using System.Collections.Generic;

namespace SampleReact.Services
{
    public interface IBooking
    {
        List<Slot> GetAll();
        ISlotTimes Update(List<Slot> SelectedSlots, BookingStatus BookingStatus);
    }

    public class Booking : IBooking
    {
        private ISlotTimes SlotTimes;
        public Booking(ISlotTimes slotTimes)
        {
            this.SlotTimes = slotTimes;
        }

        public ISlotTimes Update(List<Slot> SelectedSlots, BookingStatus BookingStatus)
        {
            SlotTimes.BookingSlots.FindSlots(SelectedSlots).ForEach(b => b.BookingStatus = BookingStatus.ToString());
            return SlotTimes;
        }

        public List<Slot> GetAll() => SlotTimes.BookingSlots;
    }







}
