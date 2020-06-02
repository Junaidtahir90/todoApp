using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Web

{
    public class TaskDTO
        {
            public long Id { get; set; }
            [Required]
            public string Title { get; set; }
            public string Description { get; set; }
            [Required]
            public long StatusId { get; set; }
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            [DataType(DataType.Date)]
             public DateTime? CreatedDate { get; set; } 
            public DateTime? UpdatedDate { get; set; }
      }
}
