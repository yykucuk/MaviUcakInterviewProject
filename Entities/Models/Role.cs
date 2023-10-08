﻿using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
