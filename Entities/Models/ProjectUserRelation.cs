using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ProjectUserRelation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
