using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Models
{
    //Keeps booking record for the car and the user with numberof days and calculates the total price.
    public class Booking
    {
        //Holds the booking primay key
        public string BookingId { get; set; }

        //Holds the carId 
        public string CarId { get; set; }

        //Holds the User Id 
        public string UserId { get; set; }

        // Holds the link to car 
        public Car Car { get; set; }
        //Holds the link to user
        public User User { get; set; }

        //Holds the number of booking days
        public int NumberOfDays { get; set; }

        //Holds the calculated total price based on booking days and car price.
        [NotMapped]
        public decimal TotalPrice { get {
                if (this.Car != null)
                {
                    return this.NumberOfDays * this.Car.PricePerDay;
                }
                else
                {
                    return 0;
                }

            } }
    }
}
