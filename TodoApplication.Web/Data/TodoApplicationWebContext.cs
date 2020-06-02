using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Web;

namespace TodoApplication.Web.Models
{
    public class TodoApplicationWebContext : DbContext
    {
        public TodoApplicationWebContext (DbContextOptions<TodoApplicationWebContext> options)
            : base(options)
        {
        }

        public DbSet<TodoApplication.Web.TaskDTO> TaskDTO { get; set; }
    }
}
