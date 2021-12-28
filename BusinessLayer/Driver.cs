using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Models
{
    //Keeps information about Drivers which are assigned to a car.
    public class Driver
    {
        //Holds the Id data.
        public string Id { get; set; }

        //Holds the Driver name.
        [Required]
        public string DriverName { get; set; }

        //Holds the link to Car.
        public Car Car { get; set; }

        //Holds the car id value.
        public string  CarId { get; set; }

        //Holds the car Reg number. Gets the car reg number from the linked car object.
        [NotMapped]
        public string CarRegNo
        {
            get
            {

                if (this.Car != null)
                 return this.Car.CarRegNo;
                else
                 return "";
                

            }
        } 

       
    }
}
