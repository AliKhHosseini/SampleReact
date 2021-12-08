using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleReact.Models;
using SampleReact.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SampleReact.Tests
{
    [TestClass()]
    public class SlotTimesTests
    {
        [TestMethod()]
        public void Test_GenerateCorrectBookingSlots()
        {
            var slotTimes = new SlotTimes(8, 16, HourSplitAmount.fifteen);
            Assert.AreEqual(slotTimes.BookingSlots.Count, 32);
        }


        [TestMethod()]
        public void Test_BookedSlots()
        {
            //Arrange
            var slotTimes = new SlotTimes(9, 17, HourSplitAmount.Thirty);

            var booked = new Booked(slotTimes);
            var booking = new Booking(slotTimes);

            var TimeSlotFactory = new Factory(booking , booked);

            List<Slot> SelectedSlots = new List<Slot>();
            SelectedSlots.Add(new Slot { StartTime = "9:00 AM", EndTime = "09:30 AM", SlotId = 1, BookingStatus = BookingStatus.selected.ToString() });
            SelectedSlots.Add(new Slot { StartTime = "9:30 AM", EndTime = "10:00 AM", SlotId = 2, BookingStatus = BookingStatus.selected.ToString() });

            // Act

            TimeSlotFactory.Confirm(SelectedSlots);


            //Assert
            Assert.AreEqual(slotTimes.BookingSlots.Count(c => c.BookingStatus == BookingStatus.unavailable.ToString()), 4);
            Assert.AreEqual(slotTimes.BookingSlots.Count(c => c.BookingStatus == BookingStatus.booked.ToString()), 2);
            Assert.AreEqual(slotTimes.BookedSlots.SelectMany(c=>c).Count(), 2);
        }




        [TestMethod()]
        public void Test_ReturnSlots()
        {
            //Arrange
            var slotTimes = new SlotTimes(9, 17, HourSplitAmount.Thirty);



            var booked = new Booked(slotTimes);
            var booking = new Booking(slotTimes);

            var TimeSlotFactory = new Factory(booking, booked);


            List<Slot> SelectedSlots = new List<Slot>();
            SelectedSlots.Add(new Slot { StartTime = "9:00 AM", EndTime = "09:30 AM", SlotId = 1, BookingStatus = BookingStatus.selected.ToString() });
            SelectedSlots.Add(new Slot { StartTime = "9:30 AM", EndTime = "10:00 AM", SlotId = 2, BookingStatus = BookingStatus.selected.ToString() });

            // Act

            TimeSlotFactory.Confirm(SelectedSlots);
            TimeSlotFactory.Return(SelectedSlots);




            //Assert
            Assert.AreEqual(slotTimes.BookingSlots.Count(c => c.BookingStatus == BookingStatus.unavailable.ToString()), 4);
            Assert.AreEqual(slotTimes.BookingSlots.Count(c => c.BookingStatus == BookingStatus.booked.ToString()), 0);
            Assert.AreEqual(slotTimes.BookedSlots.Count(), 0);
        }






    }
}