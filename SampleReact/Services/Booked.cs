using SampleReact.Models;
using System.Collections.Generic;

namespace SampleReact.Services
{
    public interface IBooked
    {
        ISlotTimes Add(List<Slot> SelectedSlots);
        ISlotTimes Reomve(List<Slot> SelectedSlots);
    }

    public class Booked : IBooked
    {
        private ISlotTimes SlotTimes;
        public Booked(ISlotTimes slotTimes)
        {
            this.SlotTimes = slotTimes;
        }

        public ISlotTimes Reomve(List<Slot> SelectedSlots)
        {
            SlotTimes.BookedSlots.RemoveSlots(SelectedSlots);
            return SlotTimes;
        }
        public ISlotTimes Add(List<Slot> SelectedSlots)
        {

            SlotTimes.BookedSlots.AddSlots(SelectedSlots);
            return SlotTimes;
        }
    }







}
