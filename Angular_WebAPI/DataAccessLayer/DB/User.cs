using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.DB
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNum { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
