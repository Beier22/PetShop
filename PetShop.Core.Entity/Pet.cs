﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public int PreviousOwnerId { get; set; }
        public double Price { get; set; }
    }
}
