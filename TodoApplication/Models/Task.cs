using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Models
{
    public class Task
        {
            public long Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            [ForeignKey("Statuses")]
            public long StatusId { get; set; }
            public DateTime? CreatedDate { get; set; } 
            public DateTime? UpdatedDate { get; set; }
        }
}
