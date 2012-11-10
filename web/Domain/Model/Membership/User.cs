using System;
using System.ComponentModel.DataAnnotations;

namespace Footprint.Domain.Model.Membership
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}