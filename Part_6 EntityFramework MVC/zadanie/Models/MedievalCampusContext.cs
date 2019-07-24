using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    public class MedievalCampusContext: DbContext
    {
        public MedievalCampusContext(DbContextOptions<MedievalCampusContext> options) : base(options)
        {

        }

        public DbSet<Professor> Professors { get; set; }
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
