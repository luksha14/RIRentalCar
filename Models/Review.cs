﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIRentalCar.Models
{
    public class Review
    {
        public int Id { get; set; }  
        public string Name { get; set; }  
        public int Rating { get; set; }
        public string Comment { get; set; } = "";
    }
}
