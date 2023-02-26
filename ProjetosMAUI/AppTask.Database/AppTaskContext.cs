using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTask.Database
{
    public class AppTaskContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<SubTaskModel> SubTasks { get; set; }
    }
}
