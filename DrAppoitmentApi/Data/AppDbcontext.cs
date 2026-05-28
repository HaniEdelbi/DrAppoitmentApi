using DrAppoitmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DrAppoitmentApi.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}