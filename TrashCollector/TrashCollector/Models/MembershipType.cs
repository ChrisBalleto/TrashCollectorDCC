using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string MembershipName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public DateTime? BlackOutDates { get; set; }

        public string PickUpFrequency { get; set; }
    }
}