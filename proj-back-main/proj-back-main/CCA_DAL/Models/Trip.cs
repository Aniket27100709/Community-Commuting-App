using CCA_DAL.Models.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA_DAL.Models
{
    public class Trip
    {
        public string tripId { get; set; }

        public string creatorUserId { get; set; }

        public string vehicleId { get; set; }

        public DateOnly rideDate { get; set; }

        public TimeOnly rideTime { get; set; }

        public string rideStatus { get; set; }

       // [Range(0, int.MaxValue, ErrorMessage = "No of seats cannot be negative or less than zero")]
        public int noOfSeat { get; set; }

      //  [LessThanProperty("noOfSeat",ErrorMessage = "No of seats filled cannot be greater than no of seats")]
        public int seatsFilled { get; set; }

        public string fromLoc { get; set; }

        public string toLoc { get; set; }
        public ICollection<Booking> bookings { get; set; }

    }
}
