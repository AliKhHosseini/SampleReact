using SampleReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleReact
{
    public static class Helper
    {

        public static void AddSlots(this List<List<Slot>> BookedSlots, List<Slot> SelectedSlots)
        {
            BookedSlots.Add(new List<Slot>(SelectedSlots));
        }

        public static void RemoveSlots(this List<List<Slot>> BookingSlot, List<Slot> SelectedSlots)
        {
            BookingSlot.RemoveAll(b => SelectedSlots.Select(s => s.SlotId).Any(r => b.Select(g => g.SlotId).Contains(r)));
        }

        public static List<Slot> FindSlots(this List<Slot> Slots, List<Slot> SelectedSlots)
        {
            return Slots.Where(b => SelectedSlots.Select(s => s.SlotId).Contains(b.SlotId)).ToList();
        }


        public static List<Slot> Populate(this List<Slot> Slots, int OpeningTime, int ClosingTime, HourSplitAmount HourSplitAmount, BookingStatus BookingStatus, IEnumerable<string> InitialUnavailables)
        {
            int i = 0;
            while (DateTime.Today.AddHours(OpeningTime).AddMinutes(i * (int)HourSplitAmount).Hour < ClosingTime)
            {
                var start = DateTime.Today.AddHours(OpeningTime).AddMinutes((int)HourSplitAmount * (i++)).ToShortTimeString();
                Slots.Add(new Slot
                {
                    SlotId = i,
                    StartTime = start,
                    EndTime = DateTime.Today.AddHours(OpeningTime).AddMinutes((int)HourSplitAmount * (i)).ToShortTimeString(),
                     BookingStatus = InitialUnavailables.Contains(start) ? BookingStatus.unavailable.ToString() : BookingStatus.available.ToString()
                    
                });
            }

            return Slots;
        }





    }
}
