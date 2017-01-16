using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string StreetOne { get; set; }

        public string StreetTwo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }
}