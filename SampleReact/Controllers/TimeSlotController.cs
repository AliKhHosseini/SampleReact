using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleReact.Models;
using SampleReact.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleReact.Controllers
{



    [ApiController]
    public class TimeSlotController : ControllerBase
    {
     
        private static IFactory Factory;

        private readonly ILogger<TimeSlotController> _logger;
        public TimeSlotController(ILogger<TimeSlotController> logger, IFactory factory)
        {
            _logger = logger;
            //ConfirmService = confirmService;
            //ReturnService = returnService;
            //SelectService = selectService;
            // TimeSlotFactory = timeSlotFactory;
            Factory = factory;
        }


        [HttpGet]
        [Route("api/Schedule/TimeSlots")]
        public List<Slot> GetTimeSlots()
        {
            //return TimeSlotFactory.GetTimeSlots();
            return Factory.GetBooking();
        }


        [HttpPost]
        [Route("api/Schedule/Confirm")]
        public ISlotTimes ConfirmTimeSlots(List<Slot> SelectedSlots)
        {
            return Factory.Confirm(SelectedSlots);
        }



        [HttpPost]
        [Route("api/Schedule/Return")]
        public ISlotTimes ReturnTimeSlots(List<Slot> returnSlots)
        {
            return Factory.Return(returnSlots);
        }




    }
}
