using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Models
{
    // Represensts a user who is booking a vehicle
    public class User
     {

        //Holds the user  Id value.
       public string Id { get; set; }

        //Holds the user  name.
        [Required]
        public string UserName { get; set; }

        //Holds the link to  bookings.
        public List<Booking> Bookings { get; set; }


    }
}
