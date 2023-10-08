using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Password { get; set; }
        public DateTime? LastOnline { get; set; }

        public virtual Role Role { get; set; }
    }
}
