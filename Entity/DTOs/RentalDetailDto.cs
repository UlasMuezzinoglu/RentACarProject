﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public string ReturnDate { get; set; }


    }
}