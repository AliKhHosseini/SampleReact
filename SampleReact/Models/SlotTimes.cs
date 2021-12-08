using System.Collections.Generic;

namespace SampleReact.Models
{

    public enum BookingStatus
    {
        selected,
        booked,
        unavailable,
        available

    }

    public enum HourSplitAmount
    {
        fifteen = 15,
        Thirty = 30,
        Sixty = 60
    }



    /// <summary>
    /// InitialUnavailables ==> Should define in like appSetting.json
    /// </summary>
    public class SlotTimes : ISlotTimes
    {
        private IEnumerable<string> InitialUnavailables = new[]{
            "11:00 AM", "12:00 PM", "12:30 PM", "3:30 PM"
        };

        public HourSplitAmount HourSplitAmount { get; private set; } = HourSplitAmount.Thirty;
        public int OpeningTime { get; private set; }
        public int ClosingTime { get; private set; }
        public List<Slot> SelectedSlots { get; set; }
        public List<List<Slot>> BookedSlots { get; set; }
        public List<Slot> BookingSlots { get; set; }
        public SlotTimes(int openingTime, int closingTime, HourSplitAmount hourSplitAmount)
        {
            this.OpeningTime = openingTime;
            this.ClosingTime = closingTime;
            this.HourSplitAmount = hourSplitAmount;

            this.BookedSlots = new List<List<Slot>>();
            this.SelectedSlots = new List<Slot>();
            this.BookingSlots = new List<Slot>();

            BookingSlots.Populate(OpeningTime, closingTime, hourSplitAmount, BookingStatus.available, InitialUnavailables);

          
        }


    }
 



}
