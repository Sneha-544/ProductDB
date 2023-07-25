using Microsoft.EntityFrameworkCore;
using RazorPages.Models.Domain;

namespace RazorPages.Data
{
    public class RazorpageContext : DbContext
    {
        public RazorpageContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet < Employee>  employees  { get; set; }
    }
}
