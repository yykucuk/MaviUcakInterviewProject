using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int? Progress { get; set; }

        public virtual Category Category { get; set; }
    }
}
