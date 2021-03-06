﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyStoreFront1.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProducts>();
            LineItems = new HashSet<LineItem>();
        }


        public int ID { get; set; }
        public Guid TrackingNumber { get; set; }
        //public string Email { get; set; }
        //public string ShippingStreet { get; set; }
        //public string ShippingCity { get; set; }
        //public string ShippingState { get; set; }
        //public string ShippingZip { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingTotal { get; set; }
        public decimal Tax { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}
