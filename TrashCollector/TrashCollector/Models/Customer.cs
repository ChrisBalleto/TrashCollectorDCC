using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        [Required]
        public int AddressId { get; set; }

        public string EMailAddress { get; set;}

        public bool IsCurrentCustomer { get; set; }

        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        
    }
}