using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Rental.Models
{
    //Represents  a car with all the details such as registration number make, model, year and rent price per day
    public class Car
     {
        //Holds primary key value of car
        public string Id { get; set; }

        //Holds the car registration number.
        [Required]
        public string CarRegNo { get; set; }

        //Holds the car make.
        [Required]
        public string CarMake { get; set; }

        //Holds the car model.
        [Required]
        public string CarModel { get; set; }

        //Holds the year.
        [Required]
        public int Year { get; set; }

        //Holds the image url.
        public string ImageUrl { get; set; }

        //Holds the price per day value.
        [Required]
        public decimal PricePerDay { get; set; }

        //Holds the link to bookings
        public List<Booking> Bookings { get; set; }

        //Holds the link to Driver
        public Driver Driver { get; set; }

        //Holds the uploaded image data.
        [NotMapped]
        public IFormFile UploadedFile { get; set; }

    }
}
