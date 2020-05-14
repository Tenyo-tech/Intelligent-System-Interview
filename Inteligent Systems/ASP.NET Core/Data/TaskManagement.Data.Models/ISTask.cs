namespace TaskManagement.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TaskManagement.Data.Common.Models;

    public class ISTask : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
