using System.Collections.Generic;

namespace SampleReact.Models
{
    public interface ISlotTimes
    {
        List<List<Slot>> BookedSlots { get; set; }
        List<Slot> BookingSlots { get; set; }
        int ClosingTime { get; }
        HourSplitAmount HourSplitAmount { get; }
        int OpeningTime { get; }
        List<Slot> SelectedSlots { get; set; }
    }
}