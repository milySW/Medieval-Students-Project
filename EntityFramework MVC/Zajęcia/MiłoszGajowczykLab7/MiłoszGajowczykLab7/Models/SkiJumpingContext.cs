using System;
using Microsoft.EntityFrameworkCore;

namespace MiłoszGajowczykLab7.Models
{
    public class SkiJumpingContext : DbContext
    {
        public SkiJumpingContext(DbContextOptions<SkiJumpingContext> options) : base(options)
        {

        }

        public DbSet<Jumper> Jumpers { get; set; }
        public DbSet<Country> Countries { get; set; }

    }

}
